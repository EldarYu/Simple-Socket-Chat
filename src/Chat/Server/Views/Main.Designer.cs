namespace Server
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_setting = new System.Windows.Forms.GroupBox();
            this.nud_port = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.nud_ip4 = new System.Windows.Forms.NumericUpDown();
            this.nud_ip3 = new System.Windows.Forms.NumericUpDown();
            this.nud_ip2 = new System.Windows.Forms.NumericUpDown();
            this.nud_ip1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox_status = new System.Windows.Forms.GroupBox();
            this.tb_statuShow = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.groupBox_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip1)).BeginInit();
            this.groupBox_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_setting
            // 
            this.groupBox_setting.Controls.Add(this.nud_port);
            this.groupBox_setting.Controls.Add(this.label);
            this.groupBox_setting.Controls.Add(this.nud_ip4);
            this.groupBox_setting.Controls.Add(this.nud_ip3);
            this.groupBox_setting.Controls.Add(this.nud_ip2);
            this.groupBox_setting.Controls.Add(this.nud_ip1);
            this.groupBox_setting.Location = new System.Drawing.Point(12, 12);
            this.groupBox_setting.Name = "groupBox_setting";
            this.groupBox_setting.Size = new System.Drawing.Size(442, 88);
            this.groupBox_setting.TabIndex = 0;
            this.groupBox_setting.TabStop = false;
            this.groupBox_setting.Text = "Setting";
            // 
            // nud_port
            // 
            this.nud_port.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Server.Properties.Settings.Default, "port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_port.Location = new System.Drawing.Point(302, 42);
            this.nud_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_port.Name = "nud_port";
            this.nud_port.ReadOnly = true;
            this.nud_port.Size = new System.Drawing.Size(50, 22);
            this.nud_port.TabIndex = 5;
            this.nud_port.Value = global::Server.Properties.Settings.Default.port;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(284, 46);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(12, 17);
            this.label.TabIndex = 4;
            this.label.Text = ":";
            // 
            // nud_ip4
            // 
            this.nud_ip4.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Server.Properties.Settings.Default, "ip4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip4.Location = new System.Drawing.Point(227, 42);
            this.nud_ip4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip4.Name = "nud_ip4";
            this.nud_ip4.Size = new System.Drawing.Size(50, 22);
            this.nud_ip4.TabIndex = 3;
            this.nud_ip4.Value = global::Server.Properties.Settings.Default.ip4;
            // 
            // nud_ip3
            // 
            this.nud_ip3.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Server.Properties.Settings.Default, "ip3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip3.Location = new System.Drawing.Point(171, 42);
            this.nud_ip3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip3.Name = "nud_ip3";
            this.nud_ip3.Size = new System.Drawing.Size(50, 22);
            this.nud_ip3.TabIndex = 2;
            this.nud_ip3.Value = global::Server.Properties.Settings.Default.ip3;
            // 
            // nud_ip2
            // 
            this.nud_ip2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Server.Properties.Settings.Default, "ip2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip2.Location = new System.Drawing.Point(115, 42);
            this.nud_ip2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip2.Name = "nud_ip2";
            this.nud_ip2.Size = new System.Drawing.Size(50, 22);
            this.nud_ip2.TabIndex = 1;
            this.nud_ip2.Value = global::Server.Properties.Settings.Default.ip2;
            // 
            // nud_ip1
            // 
            this.nud_ip1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Server.Properties.Settings.Default, "ip1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip1.Location = new System.Drawing.Point(59, 42);
            this.nud_ip1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip1.Name = "nud_ip1";
            this.nud_ip1.Size = new System.Drawing.Size(50, 22);
            this.nud_ip1.TabIndex = 0;
            this.nud_ip1.Value = global::Server.Properties.Settings.Default.ip1;
            // 
            // groupBox_status
            // 
            this.groupBox_status.Controls.Add(this.tb_statuShow);
            this.groupBox_status.Location = new System.Drawing.Point(12, 106);
            this.groupBox_status.Name = "groupBox_status";
            this.groupBox_status.Size = new System.Drawing.Size(442, 459);
            this.groupBox_status.TabIndex = 1;
            this.groupBox_status.TabStop = false;
            this.groupBox_status.Text = "Status";
            // 
            // tb_statuShow
            // 
            this.tb_statuShow.Location = new System.Drawing.Point(7, 22);
            this.tb_statuShow.Multiline = true;
            this.tb_statuShow.Name = "tb_statuShow";
            this.tb_statuShow.ReadOnly = true;
            this.tb_statuShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_statuShow.Size = new System.Drawing.Size(429, 431);
            this.tb_statuShow.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(111, 583);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 38);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(274, 583);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 38);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 646);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.groupBox_status);
            this.Controls.Add(this.groupBox_setting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox_setting.ResumeLayout(false);
            this.groupBox_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip1)).EndInit();
            this.groupBox_status.ResumeLayout(false);
            this.groupBox_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_setting;
        private System.Windows.Forms.NumericUpDown nud_port;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.NumericUpDown nud_ip4;
        private System.Windows.Forms.NumericUpDown nud_ip3;
        private System.Windows.Forms.NumericUpDown nud_ip2;
        private System.Windows.Forms.NumericUpDown nud_ip1;
        private System.Windows.Forms.GroupBox groupBox_status;
        private System.Windows.Forms.TextBox tb_statuShow;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
    }
}

