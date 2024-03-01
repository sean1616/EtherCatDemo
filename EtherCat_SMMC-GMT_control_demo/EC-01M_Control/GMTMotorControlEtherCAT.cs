using NEXTWUSB_dotNET_12B;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EC_01M_Control
{
    public class GMTMotorControlEtherCAT
    {
        bool retValue, isOpen = false;
        char[] slaveType = new char[NEXTWUSB.DEF_MA_MAX];
        bool StopAxis = false;

        double[] _nowSteps;

        /// <summary>
        /// ReadPos first and use this 
        /// </summary>
        public double[] NowSteps => _nowSteps;
        public enum SlaveType
        {
            Drive,
            IO,
            HSP,
            Step
        }
        /// <summary>
        /// Idx start from 0
        /// </summary>
        public struct SlaveInfo
        {
            public int Idx;
            public SlaveType Type;
        }
        /// <summary>
        /// Idx start from 0
        /// </summary>
        public struct AxisInfo
        {
            public int SlaveIdx;
            public double Step;
        }
        bool checkResponse(uint slaves, uint column, uint expectValue, uint retry)
        {
            uint realValue = 0xFEDCBA98; //inital data
            uint retried;
            for (retried = 0; retried <= retry; retried++)
            {
                NEXTWUSB.ECMUSBRead();

                if (column == 0)
                    if (slaves == 41)
                        realValue = NEXTWUSB.respData[slaves].CMD;
                    else
                        realValue = (uint)(NEXTWUSB.respData[slaves].CMD & 0xFFFF);
                else if (column == 1)
                {
                    if (slaves == 0)
                        realValue = (uint)(NEXTWUSB.respData[slaves].Parm & 0xFF);
                    else
                        realValue = NEXTWUSB.respData[slaves].Parm;
                }
                else if (column == 2)
                    realValue = NEXTWUSB.respData[slaves].Data1;
                else
                    realValue = NEXTWUSB.respData[slaves].Data2;

                if (realValue == expectValue)
                {
                    // Console.WriteLine("PASS");
                    break;
                }
                else if (retry == retried)
                {
                    Console.WriteLine("Fail,realValue= " + realValue.ToString() + " expectValue= " + expectValue.ToString() + " retry = " + retried.ToString());
                }
                else
                {
                    NEXTWUSB.ClearCmdData();
                    NEXTWUSB.ECMUSBWrite();
                }
            }
            return (realValue == expectValue);
        }
        /// <summary>
        /// To set slave type Drive,IO,HSP,Step
        /// </summary>
        /// <param name="slaveInfos">Slave list info</param>
        /// <returns></returns>
        bool SetSlaveType(List<SlaveInfo> slaveInfos)
        {
            int errorCount = 0;
            if(slaveInfos.Any(slave => slave.Idx < 0 || slave.Idx > NEXTWUSB.DEF_MA_MAX - 1))
            {
                Console.WriteLine($"Index must > -1 and < {NEXTWUSB.DEF_MA_MAX - 1}");
                return false;
            }

            NEXTWUSB.ClearCmdData();
            slaveType = Enumerable.Repeat('n', NEXTWUSB.DEF_MA_MAX).ToArray();

            foreach (SlaveInfo info in slaveInfos)
            {
                switch (info.Type)
                {
                    case SlaveType.Drive:
                        slaveType[info.Idx] = 'd';
                        break;
                    case SlaveType.IO:
                        slaveType[info.Idx] = 'i';
                        break;
                    case SlaveType.Step:
                        slaveType[info.Idx] = 's';
                        break;
                    case SlaveType.HSP:
                        slaveType[info.Idx] = 'p';
                        break;
                    default:
                        slaveType[info.Idx] = 'n';
                        break;
                }
            }

            uint topology;
            int j = 0;
            for (int i = 1; i <= 5; i++)
            {
                topology = 0;
                for (; j < i * 8; j++)
                {
                    switch (slaveType[j])
                    {
                        case 'd':  // 'd' means drive		
                            break;
                        case 'i': // 'i' means io
                            topology += (uint)(Math.Pow(16, (j % 8)));
                            break;
                        case 'p': // 'p' means HSP(High Speed Pulse)
                            topology += (uint)(Math.Pow(16, (j % 8)) * 2);
                            break;
                        case 's': // 's' means Step
                            topology += (uint)(Math.Pow(16, (j % 8)) * 3);
                            break;
                        default:
                            break;
                    }
                }
                NEXTWUSB.cmdData[0].CMD = NEXTWUSB.SET_AXIS;
                NEXTWUSB.cmdData[0].Parm = (ushort)(i - 1); // Group

                NEXTWUSB.cmdData[0].Data1 = topology;
                NEXTWUSB.cmdData[0].Data2 = 0;
                if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                {
                    Console.WriteLine("Write Error");
                    errorCount++;
                }
            }
            if(errorCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Set ethercat board in dc mode
        /// </summary>
        /// <returns></returns>
        bool SetDC()
        {
            NEXTWUSB.cmdData[0].CMD = NEXTWUSB.SET_DC;
            NEXTWUSB.cmdData[0].Parm = 0;
            NEXTWUSB.cmdData[0].Data1 = 2000; // set cycle time to 2000 us
            NEXTWUSB.cmdData[0].Data2 = 0xFFFF; // Auto offet adjustment

            if (!isOpen || !NEXTWUSB.ECMUSBWrite())
            {
                Console.WriteLine("Write Error");
                return false;
            }
            else
            {
                return true;   
            }
        }
        /// <summary>
        /// Set ethercat board in driver mode
        /// </summary>
        /// <returns></returns>
        bool SetDriveMode()
        {
            NEXTWUSB.ClearCmdData();
            for (int i = 1; i < NEXTWUSB.DEF_MA_MAX - 1; i++)
            {
                if (slaveType[i - 1] == 'd' || slaveType[i - 1] == 'p' || slaveType[i - 1] == 's')
                {
                    NEXTWUSB.cmdData[i].CMD = NEXTWUSB.DRIVE_MODE;
                    NEXTWUSB.cmdData[i].Data1 = NEXTWUSB.CSP_MODE; // set to CSP mode
                    NEXTWUSB.cmdData[i].Data2 = NEXTWUSB.DCSYNC; // set using DC sync
                }
            }
            if (!isOpen || !NEXTWUSB.ECMUSBWrite())
            {
                Console.WriteLine("Write Error");
                return false;
            }
            else
            { 
                return true; 
            }
        }
        /// <summary>
        /// Set motor in pre op mode
        /// </summary>
        /// <returns></returns>
        bool SetPreOPMode()
        {
            NEXTWUSB.ClearCmdData();
            NEXTWUSB.cmdData[0].CMD = NEXTWUSB.SET_STATE;
            NEXTWUSB.cmdData[0].Data1 = NEXTWUSB.STATE_PRE_OP; // set state to pre-OP
            if (!isOpen || !NEXTWUSB.ECMUSBWrite())
            {
                Console.WriteLine("Write Error");
                return false;
            }
            return checkResponse(0, 1, 2, 100);
        }
        /// <summary>
        /// Set motor in safe op mode
        /// </summary>
        /// <returns></returns>
        bool SetSafeOPMode()
        {
            NEXTWUSB.ClearCmdData();
            NEXTWUSB.cmdData[0].CMD = NEXTWUSB.SET_STATE;
            NEXTWUSB.cmdData[0].Data1 = NEXTWUSB.STATE_SAFE_OP;// set state to Safe-OP
            if (!isOpen || !NEXTWUSB.ECMUSBWrite())
            {
                Console.WriteLine("Write Error");
                return false;
            }
            return checkResponse(0, 1, 4, 1000);  // wait for enter to safe op mode
        }
        /// <summary>
        /// Set motor in op mode
        /// </summary>
        /// <returns></returns>
        bool SetOPMode()
        {
            NEXTWUSB.ClearCmdData();
            NEXTWUSB.cmdData[0].CMD = NEXTWUSB.SET_STATE;
            NEXTWUSB.cmdData[0].Data1 = NEXTWUSB.STATE_OPERATIONAL;// set state to OP
            if (!isOpen || !NEXTWUSB.ECMUSBWrite())
            {
                Console.WriteLine("Write Error");
                return false;
            }
            return checkResponse(0, 1, 8, 1000);// wait for enter to op mode
        }
        /// <summary>
        /// Set motor in servo mode
        /// </summary>
        /// <param name="Status">Open(true) Close(false)</param>
        /// <returns></returns>
        public bool Servo(bool Status)
        {
            if (Status)
            {
                NEXTWUSB.ClearCmdData();
                for (int i = 1; i < NEXTWUSB.DEF_MA_MAX - 1; i++)
                {
                    if (slaveType[i - 1] == 'd' || slaveType[i - 1] == 'p' || slaveType[i - 1] == 's')  //set drive or HSP slave servo on
                        NEXTWUSB.cmdData[i].CMD = NEXTWUSB.SV_ON;
                }
                if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                {
                    Console.WriteLine("Write Error");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                NEXTWUSB.ClearCmdData();
                for (int i = 1; i < NEXTWUSB.DEF_MA_MAX - 1; i++)
                {
                    if (slaveType[i - 1] == 'd' || slaveType[i - 1] == 'p' || slaveType[i - 1] == 's') //Set drive or HSP slave servo off
                        NEXTWUSB.cmdData[i].CMD = NEXTWUSB.SV_OFF;
                }
                if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                {
                    Console.WriteLine("Write Error");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// Read position from encoder and update NowSteps
        /// </summary>
        public void ReadPos()
        {
            List<AxisInfo> returnAxisInfo = new List<AxisInfo>();

            NEXTWUSB.ECMUSBRead();

            _nowSteps = new double[NEXTWUSB.DEF_MA_MAX - 1];

            for (int i = 1; i < NEXTWUSB.DEF_MA_MAX; i++)
            {
                _nowSteps[i - 1] = (int)NEXTWUSB.respData[i].Data1;
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            retValue = NEXTWUSB.OpenECMUSB();
            if (retValue)
            {
                isOpen = true;
                return true;
            }
            else
            {
                Console.WriteLine("Open USB Fail");
                return false;
            }
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect()
        {
            NEXTWUSB.CloseECMUSB();
            isOpen = false;
        }
        /// <summary>
        /// Set motor to idle(release) mode
        /// </summary>
        /// <returns></returns>
        public bool SetIdle()
        {
            Servo(false);

            NEXTWUSB.ClearCmdData();
            NEXTWUSB.cmdData[0].CMD = NEXTWUSB.SET_STATE;
            NEXTWUSB.cmdData[0].Data1 = NEXTWUSB.STATE_INIT;
            if (!isOpen || !NEXTWUSB.ECMUSBWrite())
            {
                Console.WriteLine("Write Error");
                return false;
            }
            return checkResponse(0, 1, 1, 1000);
        }
        /// <summary>
        /// Initial motor and lock it for move
        /// </summary>
        /// <param name="SlaveInfo">Slave list info</param>
        /// <returns></returns>
        public bool Initial(List<SlaveInfo> SlaveInfo)
        {
            int errorCount = 0;

            //Pre OP
            if (!SetPreOPMode())
            {
                errorCount++;
            }

            AccurateDelay(100);

            //Set slave type
            if (!SetSlaveType(SlaveInfo))
            {
                errorCount++;
            }

            AccurateDelay(100);

            //Set DC

            if (!SetDC())
            {
                errorCount++;
            }

            AccurateDelay(100);

            //Set drive mode

            if (!SetDriveMode())
            {
                errorCount++;
            }

            AccurateDelay(100);

            //Set safe op

            if (!SetSafeOPMode())
            {
                errorCount++;
            }

            AccurateDelay(100);

            //Set op

            if (!SetOPMode())
            {
                errorCount++;
            }

            AccurateDelay(100);

            //Set servo on

            if (!Servo(true))
            {
                errorCount++;
            }

            if(errorCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Multi axis move
        /// </summary>
        /// <param name="targetSteps">Target position step</param>
        /// <param name="Speed">Speed 1~10 default is 3</param>
        public void AllAxisGo(List<AxisInfo> targetSteps, int Speed = 3)
        {
            if (Speed > 10)
            {
                Speed = 10;
            }
            if (Speed < 1)
            {
                Speed = 1;
            }

            ReadPos();

            double[] ReadPosition = (double[])_nowSteps.Clone();

            Task.Run(() =>
            {
                while (targetSteps.Any(x => Math.Abs(x.Step - ReadPosition[x.SlaveIdx]) > Speed))
                {
                    if (StopAxis)
                    {
                        break;
                    }

                    foreach (var axisinfo in targetSteps)
                    {
                        int goStep = Speed * ((axisinfo.Step > ReadPosition[axisinfo.SlaveIdx]) ? 1 : -1);
                        if (Math.Abs(axisinfo.Step - ReadPosition[axisinfo.SlaveIdx]) < 1000)
                        {
                            goStep = (axisinfo.Step > ReadPosition[axisinfo.SlaveIdx]) ? 1 : -1;
                        }
                        NEXTWUSB.cmdData[axisinfo.SlaveIdx + 1].CMD = NEXTWUSB.CSP;
                        NEXTWUSB.cmdData[axisinfo.SlaveIdx + 1].Data1 = (uint)(ReadPosition[axisinfo.SlaveIdx] += goStep);
                    }
                    if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                        Console.WriteLine("Write Error");
                }
                //到達最終步數避免無法整除
                if (!StopAxis)
                {
                    foreach (var axisinfo in targetSteps)
                    {
                        NEXTWUSB.cmdData[axisinfo.SlaveIdx + 1].CMD = NEXTWUSB.CSP;
                        NEXTWUSB.cmdData[axisinfo.SlaveIdx + 1].Data1 = (uint)axisinfo.Step;
                    }
                    if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                        Console.WriteLine("Write Error");
                }
                else
                {
                    StopAxis = false;
                }
            });
        }
        /// <summary>
        /// Single axis move
        /// </summary>
        /// <param name="targetStep">Target position step</param>
        /// <param name="Speed">Speed 1~10 default is 3</param>
        public void AxisGo(AxisInfo targetStep, int Speed = 3)
        {
            if (Speed > 10)
            {
                Speed = 10;
            }
            if (Speed < 1)
            {
                Speed = 1;
            }

            ReadPos();

            double ReadPosition = ((double[])_nowSteps.Clone())[targetStep.SlaveIdx];

            Speed = (targetStep.Step > ReadPosition) ? Speed : -1 * Speed;

            Task.Run(() =>
            {
                for (double i = ReadPosition; (Speed > 0) ? i < targetStep.Step : i > targetStep.Step; i += Speed)
                {
                    if (StopAxis)
                    {
                        StopAxis = false;
                        break;
                    }

                    NEXTWUSB.cmdData[targetStep.SlaveIdx + 1].CMD = NEXTWUSB.CSP;
                    NEXTWUSB.cmdData[targetStep.SlaveIdx + 1].Data1 = (uint)i;
                    if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                        Console.WriteLine("Write Error");
                }
                //到達最終步數避免無法整除
                NEXTWUSB.cmdData[targetStep.SlaveIdx + 1].CMD = NEXTWUSB.CSP;
                NEXTWUSB.cmdData[targetStep.SlaveIdx + 1].Data1 = (uint)targetStep.Step;
                if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                    Console.WriteLine("Write Error");
            });
        }
        /// <summary>
        /// Make axis continue move
        /// </summary>
        /// <param name="AxisIdx">Axis index</param>
        /// <param name="Speed">Speed 1~10 default is 3</param>
        public void AxisCW(int AxisIdx, int Speed = 3)
        {
            if (Speed > 10)
            {
                Speed = 10;
            }
            if (Speed < 1)
            {
                Speed = 1;
            }

            ReadPos();

            double ReadPosition = _nowSteps[AxisIdx];

            Task.Run(() =>
            {
                while (!StopAxis)
                {
                    NEXTWUSB.cmdData[AxisIdx + 1].CMD = NEXTWUSB.CSP;
                    NEXTWUSB.cmdData[AxisIdx + 1].Data1 = (uint)(ReadPosition += Speed);
                    if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                        Console.WriteLine("Write Error");
                }

                if (StopAxis)
                {
                    StopAxis = false;
                }

                NEXTWUSB.ClearCmdData();
            });
        }
        /// <summary>
        /// Make axis counter continue move
        /// </summary>
        /// <param name="AxisIdx">Axis index</param>
        /// <param name="Speed">Speed 1~10 default is 3</param>
        public void AxisCCW(int AxisIdx, int Speed = 3)
        {
            if (Speed > 10)
            {
                Speed = 10;
            }
            if (Speed < 1)
            {
                Speed = 1;
            }

            ReadPos();

            double ReadPosition = _nowSteps[AxisIdx];

            Task.Run(() =>
            {
                while (!StopAxis)
                {
                    NEXTWUSB.cmdData[AxisIdx + 1].CMD = NEXTWUSB.CSP;
                    NEXTWUSB.cmdData[AxisIdx + 1].Data1 = (uint)(ReadPosition -= Speed);
                    if (!isOpen || !NEXTWUSB.ECMUSBWrite())
                        Console.WriteLine("Write Error");
                }

                if (StopAxis)
                {
                    StopAxis = false;
                }

                NEXTWUSB.ClearCmdData();
            });
        }
        /// <summary>
        /// Stop all axis
        /// </summary>
        public void AxisStop()
        {
            StopAxis = true;
            NEXTWUSB.ClearCmdData();
        }
        /// <summary>
        /// Accurate delay
        /// </summary>
        /// <param name="delay_ms">ms</param>
        /// <param name="printConsole"></param>
        private void AccurateDelay(double delay_ms, bool printConsole = false)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalMilliseconds < delay_ms)
            {
            }

            stopwatch.Stop();
            if (printConsole)
            {
                Console.WriteLine($"Accurate Delay Time : {stopwatch.Elapsed.TotalMilliseconds}");
            }
        }
    }
}
