namespace ethercat_smmc_gmt_control_demo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Initial = new System.Windows.Forms.Button();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_ReadPos = new System.Windows.Forms.Button();
            this.btn_Idle = new System.Windows.Forms.Button();
            this.nud_Axis0 = new System.Windows.Forms.NumericUpDown();
            this.nud_Axis1 = new System.Windows.Forms.NumericUpDown();
            this.nud_Axis2 = new System.Windows.Forms.NumericUpDown();
            this.label_Axis0 = new System.Windows.Forms.Label();
            this.label_Axis1 = new System.Windows.Forms.Label();
            this.label_Axis2 = new System.Windows.Forms.Label();
            this.btn_GoAllAxis = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Axis0CW = new System.Windows.Forms.Button();
            this.btn_Axis0CCW = new System.Windows.Forms.Button();
            this.btn_Axis1CCW = new System.Windows.Forms.Button();
            this.btn_Axis1CW = new System.Windows.Forms.Button();
            this.btn_Axis2CCW = new System.Windows.Forms.Button();
            this.btn_Axis2CW = new System.Windows.Forms.Button();
            this.nud_Speed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Axis0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Axis1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Axis2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(14, 15);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(88, 29);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Initial
            // 
            this.btn_Initial.Location = new System.Drawing.Point(14, 51);
            this.btn_Initial.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Initial.Name = "btn_Initial";
            this.btn_Initial.Size = new System.Drawing.Size(88, 29);
            this.btn_Initial.TabIndex = 1;
            this.btn_Initial.Text = "Initial";
            this.btn_Initial.UseVisualStyleBackColor = true;
            this.btn_Initial.Click += new System.EventHandler(this.btn_Initial_Click);
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(108, 15);
            this.btn_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(88, 29);
            this.btn_Disconnect.TabIndex = 2;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_ReadPos
            // 
            this.btn_ReadPos.Location = new System.Drawing.Point(14, 88);
            this.btn_ReadPos.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReadPos.Name = "btn_ReadPos";
            this.btn_ReadPos.Size = new System.Drawing.Size(88, 29);
            this.btn_ReadPos.TabIndex = 3;
            this.btn_ReadPos.Text = "ReadPos";
            this.btn_ReadPos.UseVisualStyleBackColor = true;
            this.btn_ReadPos.Click += new System.EventHandler(this.btn_ReadPos_Click);
            // 
            // btn_Idle
            // 
            this.btn_Idle.Location = new System.Drawing.Point(108, 51);
            this.btn_Idle.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Idle.Name = "btn_Idle";
            this.btn_Idle.Size = new System.Drawing.Size(88, 29);
            this.btn_Idle.TabIndex = 4;
            this.btn_Idle.Text = "Idle";
            this.btn_Idle.UseVisualStyleBackColor = true;
            this.btn_Idle.Click += new System.EventHandler(this.btn_Idle_Click);
            // 
            // nud_Axis0
            // 
            this.nud_Axis0.Location = new System.Drawing.Point(14, 156);
            this.nud_Axis0.Margin = new System.Windows.Forms.Padding(4);
            this.nud_Axis0.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.nud_Axis0.Minimum = new decimal(new int[] {
            600000,
            0,
            0,
            -2147483648});
            this.nud_Axis0.Name = "nud_Axis0";
            this.nud_Axis0.Size = new System.Drawing.Size(140, 23);
            this.nud_Axis0.TabIndex = 5;
            // 
            // nud_Axis1
            // 
            this.nud_Axis1.Location = new System.Drawing.Point(161, 156);
            this.nud_Axis1.Margin = new System.Windows.Forms.Padding(4);
            this.nud_Axis1.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.nud_Axis1.Minimum = new decimal(new int[] {
            600000,
            0,
            0,
            -2147483648});
            this.nud_Axis1.Name = "nud_Axis1";
            this.nud_Axis1.Size = new System.Drawing.Size(140, 23);
            this.nud_Axis1.TabIndex = 6;
            // 
            // nud_Axis2
            // 
            this.nud_Axis2.Location = new System.Drawing.Point(308, 156);
            this.nud_Axis2.Margin = new System.Windows.Forms.Padding(4);
            this.nud_Axis2.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.nud_Axis2.Minimum = new decimal(new int[] {
            600000,
            0,
            0,
            -2147483648});
            this.nud_Axis2.Name = "nud_Axis2";
            this.nud_Axis2.Size = new System.Drawing.Size(140, 23);
            this.nud_Axis2.TabIndex = 7;
            // 
            // label_Axis0
            // 
            this.label_Axis0.AutoSize = true;
            this.label_Axis0.Location = new System.Drawing.Point(12, 189);
            this.label_Axis0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Axis0.Name = "label_Axis0";
            this.label_Axis0.Size = new System.Drawing.Size(35, 15);
            this.label_Axis0.TabIndex = 8;
            this.label_Axis0.Text = "Axis0";
            // 
            // label_Axis1
            // 
            this.label_Axis1.AutoSize = true;
            this.label_Axis1.Location = new System.Drawing.Point(159, 188);
            this.label_Axis1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Axis1.Name = "label_Axis1";
            this.label_Axis1.Size = new System.Drawing.Size(35, 15);
            this.label_Axis1.TabIndex = 9;
            this.label_Axis1.Text = "Axis1";
            // 
            // label_Axis2
            // 
            this.label_Axis2.AutoSize = true;
            this.label_Axis2.Location = new System.Drawing.Point(306, 188);
            this.label_Axis2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Axis2.Name = "label_Axis2";
            this.label_Axis2.Size = new System.Drawing.Size(35, 15);
            this.label_Axis2.TabIndex = 10;
            this.label_Axis2.Text = "Axis2";
            // 
            // btn_GoAllAxis
            // 
            this.btn_GoAllAxis.Location = new System.Drawing.Point(14, 281);
            this.btn_GoAllAxis.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GoAllAxis.Name = "btn_GoAllAxis";
            this.btn_GoAllAxis.Size = new System.Drawing.Size(434, 29);
            this.btn_GoAllAxis.TabIndex = 11;
            this.btn_GoAllAxis.Text = "Go all";
            this.btn_GoAllAxis.UseVisualStyleBackColor = true;
            this.btn_GoAllAxis.Click += new System.EventHandler(this.btn_GoAllAxis_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(14, 318);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(434, 29);
            this.btn_Stop.TabIndex = 12;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Axis0CW
            // 
            this.btn_Axis0CW.Location = new System.Drawing.Point(14, 208);
            this.btn_Axis0CW.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Axis0CW.Name = "btn_Axis0CW";
            this.btn_Axis0CW.Size = new System.Drawing.Size(88, 29);
            this.btn_Axis0CW.TabIndex = 13;
            this.btn_Axis0CW.Text = "CW";
            this.btn_Axis0CW.UseVisualStyleBackColor = true;
            this.btn_Axis0CW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Axis0CW_MouseDown);
            this.btn_Axis0CW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Axis0CW_MouseUp);
            // 
            // btn_Axis0CCW
            // 
            this.btn_Axis0CCW.Location = new System.Drawing.Point(14, 244);
            this.btn_Axis0CCW.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Axis0CCW.Name = "btn_Axis0CCW";
            this.btn_Axis0CCW.Size = new System.Drawing.Size(88, 29);
            this.btn_Axis0CCW.TabIndex = 14;
            this.btn_Axis0CCW.Text = "CCW";
            this.btn_Axis0CCW.UseVisualStyleBackColor = true;
            this.btn_Axis0CCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Axis0CCW_MouseDown);
            this.btn_Axis0CCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Axis0CCW_MouseUp);
            // 
            // btn_Axis1CCW
            // 
            this.btn_Axis1CCW.Location = new System.Drawing.Point(161, 244);
            this.btn_Axis1CCW.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Axis1CCW.Name = "btn_Axis1CCW";
            this.btn_Axis1CCW.Size = new System.Drawing.Size(88, 29);
            this.btn_Axis1CCW.TabIndex = 16;
            this.btn_Axis1CCW.Text = "CCW";
            this.btn_Axis1CCW.UseVisualStyleBackColor = true;
            this.btn_Axis1CCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Axis1CCW_MouseDown);
            this.btn_Axis1CCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Axis1CCW_MouseUp);
            // 
            // btn_Axis1CW
            // 
            this.btn_Axis1CW.Location = new System.Drawing.Point(161, 208);
            this.btn_Axis1CW.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Axis1CW.Name = "btn_Axis1CW";
            this.btn_Axis1CW.Size = new System.Drawing.Size(88, 29);
            this.btn_Axis1CW.TabIndex = 15;
            this.btn_Axis1CW.Text = "CW";
            this.btn_Axis1CW.UseVisualStyleBackColor = true;
            this.btn_Axis1CW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Axis1CW_MouseDown);
            this.btn_Axis1CW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Axis1CW_MouseUp);
            // 
            // btn_Axis2CCW
            // 
            this.btn_Axis2CCW.Location = new System.Drawing.Point(308, 244);
            this.btn_Axis2CCW.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Axis2CCW.Name = "btn_Axis2CCW";
            this.btn_Axis2CCW.Size = new System.Drawing.Size(88, 29);
            this.btn_Axis2CCW.TabIndex = 18;
            this.btn_Axis2CCW.Text = "CCW";
            this.btn_Axis2CCW.UseVisualStyleBackColor = true;
            this.btn_Axis2CCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Axis2CCW_MouseDown);
            this.btn_Axis2CCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Axis2CCW_MouseUp);
            // 
            // btn_Axis2CW
            // 
            this.btn_Axis2CW.Location = new System.Drawing.Point(308, 208);
            this.btn_Axis2CW.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Axis2CW.Name = "btn_Axis2CW";
            this.btn_Axis2CW.Size = new System.Drawing.Size(88, 29);
            this.btn_Axis2CW.TabIndex = 17;
            this.btn_Axis2CW.Text = "CW";
            this.btn_Axis2CW.UseVisualStyleBackColor = true;
            this.btn_Axis2CW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Axis2CW_MouseDown);
            this.btn_Axis2CW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Axis2CW_MouseUp);
            // 
            // nud_Speed
            // 
            this.nud_Speed.Location = new System.Drawing.Point(231, 93);
            this.nud_Speed.Margin = new System.Windows.Forms.Padding(4);
            this.nud_Speed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Speed.Name = "nud_Speed";
            this.nud_Speed.Size = new System.Drawing.Size(70, 23);
            this.nud_Speed.TabIndex = 20;
            this.nud_Speed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Speed";
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(380, 15);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(88, 29);
            this.btn_Test.TabIndex = 22;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 431);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_Speed);
            this.Controls.Add(this.btn_Axis2CCW);
            this.Controls.Add(this.btn_Axis2CW);
            this.Controls.Add(this.btn_Axis1CCW);
            this.Controls.Add(this.btn_Axis1CW);
            this.Controls.Add(this.btn_Axis0CCW);
            this.Controls.Add(this.btn_Axis0CW);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_GoAllAxis);
            this.Controls.Add(this.label_Axis2);
            this.Controls.Add(this.label_Axis1);
            this.Controls.Add(this.label_Axis0);
            this.Controls.Add(this.nud_Axis2);
            this.Controls.Add(this.nud_Axis1);
            this.Controls.Add(this.nud_Axis0);
            this.Controls.Add(this.btn_Idle);
            this.Controls.Add(this.btn_ReadPos);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.btn_Initial);
            this.Controls.Add(this.btn_Connect);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Axis0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Axis1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Axis2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Initial;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_ReadPos;
        private System.Windows.Forms.Button btn_Idle;
        private System.Windows.Forms.NumericUpDown nud_Axis0;
        private System.Windows.Forms.NumericUpDown nud_Axis1;
        private System.Windows.Forms.NumericUpDown nud_Axis2;
        private System.Windows.Forms.Label label_Axis0;
        private System.Windows.Forms.Label label_Axis1;
        private System.Windows.Forms.Label label_Axis2;
        private System.Windows.Forms.Button btn_GoAllAxis;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Axis0CW;
        private System.Windows.Forms.Button btn_Axis0CCW;
        private System.Windows.Forms.Button btn_Axis1CCW;
        private System.Windows.Forms.Button btn_Axis1CW;
        private System.Windows.Forms.Button btn_Axis2CCW;
        private System.Windows.Forms.Button btn_Axis2CW;
        private System.Windows.Forms.NumericUpDown nud_Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Test;
    }
}

