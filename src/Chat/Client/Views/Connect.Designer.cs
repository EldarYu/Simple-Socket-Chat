namespace Client
{
    partial class Connect
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
            this.groupBox_serverSet = new System.Windows.Forms.GroupBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.nud_port = new System.Windows.Forms.NumericUpDown();
            this.nud_ip4 = new System.Windows.Forms.NumericUpDown();
            this.nud_ip3 = new System.Windows.Forms.NumericUpDown();
            this.nud_ip2 = new System.Windows.Forms.NumericUpDown();
            this.nud_ip1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox_usrInfo = new System.Windows.Forms.GroupBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.groupBox_serverSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip1)).BeginInit();
            this.groupBox_usrInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_serverSet
            // 
            this.groupBox_serverSet.Controls.Add(this.btn_connect);
            this.groupBox_serverSet.Controls.Add(this.label);
            this.groupBox_serverSet.Controls.Add(this.nud_port);
            this.groupBox_serverSet.Controls.Add(this.nud_ip4);
            this.groupBox_serverSet.Controls.Add(this.nud_ip3);
            this.groupBox_serverSet.Controls.Add(this.nud_ip2);
            this.groupBox_serverSet.Controls.Add(this.nud_ip1);
            this.groupBox_serverSet.Location = new System.Drawing.Point(12, 12);
            this.groupBox_serverSet.Name = "groupBox_serverSet";
            this.groupBox_serverSet.Size = new System.Drawing.Size(497, 78);
            this.groupBox_serverSet.TabIndex = 0;
            this.groupBox_serverSet.TabStop = false;
            this.groupBox_serverSet.Text = "Server Information";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(356, 21);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(124, 50);
            this.btn_connect.TabIndex = 2;
            this.btn_connect.Text = "Test Connection";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(275, 38);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(12, 17);
            this.label.TabIndex = 5;
            this.label.Text = ":";
            // 
            // nud_port
            // 
            this.nud_port.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Client.Properties.Settings.Default, "port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_port.Location = new System.Drawing.Point(293, 36);
            this.nud_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_port.Name = "nud_port";
            this.nud_port.ReadOnly = true;
            this.nud_port.Size = new System.Drawing.Size(50, 22);
            this.nud_port.TabIndex = 4;
            this.nud_port.Value = global::Client.Properties.Settings.Default.port;
            // 
            // nud_ip4
            // 
            this.nud_ip4.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Client.Properties.Settings.Default, "ip4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip4.Location = new System.Drawing.Point(219, 36);
            this.nud_ip4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip4.Name = "nud_ip4";
            this.nud_ip4.Size = new System.Drawing.Size(50, 22);
            this.nud_ip4.TabIndex = 3;
            this.nud_ip4.Value = global::Client.Properties.Settings.Default.ip4;
            // 
            // nud_ip3
            // 
            this.nud_ip3.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Client.Properties.Settings.Default, "ip3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip3.Location = new System.Drawing.Point(163, 36);
            this.nud_ip3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip3.Name = "nud_ip3";
            this.nud_ip3.Size = new System.Drawing.Size(50, 22);
            this.nud_ip3.TabIndex = 2;
            this.nud_ip3.Value = global::Client.Properties.Settings.Default.ip3;
            // 
            // nud_ip2
            // 
            this.nud_ip2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Client.Properties.Settings.Default, "ip2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip2.Location = new System.Drawing.Point(107, 36);
            this.nud_ip2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip2.Name = "nud_ip2";
            this.nud_ip2.Size = new System.Drawing.Size(50, 22);
            this.nud_ip2.TabIndex = 1;
            this.nud_ip2.Value = global::Client.Properties.Settings.Default.ip2;
            // 
            // nud_ip1
            // 
            this.nud_ip1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Client.Properties.Settings.Default, "ip1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nud_ip1.Location = new System.Drawing.Point(51, 36);
            this.nud_ip1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ip1.Name = "nud_ip1";
            this.nud_ip1.Size = new System.Drawing.Size(50, 22);
            this.nud_ip1.TabIndex = 0;
            this.nud_ip1.Value = global::Client.Properties.Settings.Default.ip1;
            // 
            // groupBox_usrInfo
            // 
            this.groupBox_usrInfo.Controls.Add(this.btn_register);
            this.groupBox_usrInfo.Controls.Add(this.btn_login);
            this.groupBox_usrInfo.Controls.Add(this.tb_password);
            this.groupBox_usrInfo.Controls.Add(this.label_password);
            this.groupBox_usrInfo.Controls.Add(this.tb_name);
            this.groupBox_usrInfo.Controls.Add(this.label_name);
            this.groupBox_usrInfo.Location = new System.Drawing.Point(13, 96);
            this.groupBox_usrInfo.Name = "groupBox_usrInfo";
            this.groupBox_usrInfo.Size = new System.Drawing.Size(496, 226);
            this.groupBox_usrInfo.TabIndex = 1;
            this.groupBox_usrInfo.TabStop = false;
            this.groupBox_usrInfo.Text = "User Information";
            // 
            // btn_register
            // 
            this.btn_register.Enabled = false;
            this.btn_register.Location = new System.Drawing.Point(337, 165);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(87, 37);
            this.btn_register.TabIndex = 5;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            // 
            // btn_login
            // 
            this.btn_login.Enabled = false;
            this.btn_login.Location = new System.Drawing.Point(130, 165);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(88, 37);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(158, 109);
            this.tb_password.Name = "tb_password";
            this.tb_password.ReadOnly = true;
            this.tb_password.Size = new System.Drawing.Size(266, 22);
            this.tb_password.TabIndex = 3;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(77, 109);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(81, 17);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Password : ";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(158, 47);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(266, 22);
            this.tb_name.TabIndex = 1;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(101, 50);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(57, 17);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Name : ";
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 335);
            this.Controls.Add(this.groupBox_usrInfo);
            this.Controls.Add(this.groupBox_serverSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Connect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.Connect_Load);
            this.groupBox_serverSet.ResumeLayout(false);
            this.groupBox_serverSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ip1)).EndInit();
            this.groupBox_usrInfo.ResumeLayout(false);
            this.groupBox_usrInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_serverSet;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.NumericUpDown nud_port;
        private System.Windows.Forms.NumericUpDown nud_ip4;
        private System.Windows.Forms.NumericUpDown nud_ip3;
        private System.Windows.Forms.NumericUpDown nud_ip2;
        private System.Windows.Forms.NumericUpDown nud_ip1;
        private System.Windows.Forms.GroupBox groupBox_usrInfo;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label_name;
    }
}

