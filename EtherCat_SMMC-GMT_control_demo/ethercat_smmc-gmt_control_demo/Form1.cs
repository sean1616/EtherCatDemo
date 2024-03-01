using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ethercat_smmc_gmt_control_demo
{
    public partial class Form1 : Form
    {
        EC_01M_Control.GMTMotorControlEtherCAT MotorControl = new EC_01M_Control.GMTMotorControlEtherCAT();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            MotorControl.Connect();
        }

        private void btn_Initial_Click(object sender, EventArgs e)
        {
            List<EC_01M_Control.GMTMotorControlEtherCAT.SlaveInfo> slaveInfo = new List<EC_01M_Control.GMTMotorControlEtherCAT.SlaveInfo>();
            slaveInfo.Add(new EC_01M_Control.GMTMotorControlEtherCAT.SlaveInfo
            {
                Idx = 0,
                Type = EC_01M_Control.GMTMotorControlEtherCAT.SlaveType.Step
            });
            slaveInfo.Add(new EC_01M_Control.GMTMotorControlEtherCAT.SlaveInfo
            {
                Idx = 1,
                Type = EC_01M_Control.GMTMotorControlEtherCAT.SlaveType.Step
            });
            slaveInfo.Add(new EC_01M_Control.GMTMotorControlEtherCAT.SlaveInfo
            {
                Idx = 2,
                Type = EC_01M_Control.GMTMotorControlEtherCAT.SlaveType.Step
            });

            MotorControl.Initial(slaveInfo);
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            MotorControl.Disconnect();
        }

        private void btn_ReadPos_Click(object sender, EventArgs e)
        {
            MotorControl.ReadPos();

            label_Axis0.Text = MotorControl.NowSteps[0].ToString();
            label_Axis1.Text = MotorControl.NowSteps[1].ToString();
            label_Axis2.Text = MotorControl.NowSteps[2].ToString();
        }

        private void btn_GoAllAxis_Click(object sender, EventArgs e)
        {
            List<EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo> axisInfos = new List<EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo>();
            axisInfos.Add(new EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo
            {
                SlaveIdx = 0,
                Step = (double)nud_Axis0.Value
            });
            axisInfos.Add(new EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo
            {
                SlaveIdx = 1,
                Step = (double)nud_Axis1.Value
            });
            axisInfos.Add(new EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo
            {
                SlaveIdx = 2,
                Step = (double)nud_Axis2.Value
            });

            MotorControl.AllAxisGo(axisInfos, (int)nud_Speed.Value);
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Idle_Click(object sender, EventArgs e)
        {
            MotorControl.SetIdle();
        }

        private void btn_Axis0CW_MouseDown(object sender, MouseEventArgs e)
        {
            MotorControl.AxisCW(0, (int)nud_Speed.Value);
        }

        private void btn_Axis0CW_MouseUp(object sender, MouseEventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Axis0CCW_MouseDown(object sender, MouseEventArgs e)
        {
            MotorControl.AxisCCW(0, (int)nud_Speed.Value);
        }

        private void btn_Axis0CCW_MouseUp(object sender, MouseEventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Axis1CW_MouseDown(object sender, MouseEventArgs e)
        {
            MotorControl.AxisCW(1, (int)nud_Speed.Value);
        }

        private void btn_Axis1CW_MouseUp(object sender, MouseEventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Axis2CW_MouseDown(object sender, MouseEventArgs e)
        {
            MotorControl.AxisCW(2, (int)nud_Speed.Value);
        }

        private void btn_Axis2CW_MouseUp(object sender, MouseEventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Axis2CCW_MouseDown(object sender, MouseEventArgs e)
        {
            MotorControl.AxisCCW(2, (int)nud_Speed.Value);
        }

        private void btn_Axis2CCW_MouseUp(object sender, MouseEventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Axis1CCW_MouseDown(object sender, MouseEventArgs e)
        {
            MotorControl.AxisCCW(1 , (int)nud_Speed.Value);
        }

        private void btn_Axis1CCW_MouseUp(object sender, MouseEventArgs e)
        {
            MotorControl.AxisStop();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo goAxis = new EC_01M_Control.GMTMotorControlEtherCAT.AxisInfo
            {
                SlaveIdx = 0,
                Step = (double)nud_Axis0.Value,
            };
            MotorControl.AxisGo(goAxis, (int)nud_Speed.Value);
        }
    }
}
