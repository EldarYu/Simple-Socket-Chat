namespace Client.Views
{
    partial class Chat
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
            this.groupBox_userList = new System.Windows.Forms.GroupBox();
            this.listBox_userList = new System.Windows.Forms.ListBox();
            this.groupBox_message = new System.Windows.Forms.GroupBox();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.btn_sendMsg = new System.Windows.Forms.Button();
            this.tb_sendMsg = new System.Windows.Forms.TextBox();
            this.groupBox_userList.SuspendLayout();
            this.groupBox_message.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_userList
            // 
            this.groupBox_userList.Controls.Add(this.listBox_userList);
            this.groupBox_userList.Location = new System.Drawing.Point(12, 12);
            this.groupBox_userList.Name = "groupBox_userList";
            this.groupBox_userList.Size = new System.Drawing.Size(252, 601);
            this.groupBox_userList.TabIndex = 0;
            this.groupBox_userList.TabStop = false;
            this.groupBox_userList.Text = "Online User";
            // 
            // listBox_userList
            // 
            this.listBox_userList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_userList.FormattingEnabled = true;
            this.listBox_userList.ItemHeight = 20;
            this.listBox_userList.Location = new System.Drawing.Point(6, 21);
            this.listBox_userList.Name = "listBox_userList";
            this.listBox_userList.Size = new System.Drawing.Size(240, 564);
            this.listBox_userList.TabIndex = 0;
            // 
            // groupBox_message
            // 
            this.groupBox_message.Controls.Add(this.tb_message);
            this.groupBox_message.Controls.Add(this.btn_sendMsg);
            this.groupBox_message.Controls.Add(this.tb_sendMsg);
            this.groupBox_message.Location = new System.Drawing.Point(271, 12);
            this.groupBox_message.Name = "groupBox_message";
            this.groupBox_message.Size = new System.Drawing.Size(609, 601);
            this.groupBox_message.TabIndex = 2;
            this.groupBox_message.TabStop = false;
            this.groupBox_message.Text = "Message";
            // 
            // tb_message
            // 
            this.tb_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_message.Location = new System.Drawing.Point(7, 22);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.ReadOnly = true;
            this.tb_message.Size = new System.Drawing.Size(590, 486);
            this.tb_message.TabIndex = 3;
            // 
            // btn_sendMsg
            // 
            this.btn_sendMsg.Location = new System.Drawing.Point(518, 514);
            this.btn_sendMsg.Name = "btn_sendMsg";
            this.btn_sendMsg.Size = new System.Drawing.Size(79, 71);
            this.btn_sendMsg.TabIndex = 2;
            this.btn_sendMsg.Text = "Send";
            this.btn_sendMsg.UseVisualStyleBackColor = true;
            this.btn_sendMsg.Click += new System.EventHandler(this.btn_sendMsg_Click);
            // 
            // tb_sendMsg
            // 
            this.tb_sendMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_sendMsg.Location = new System.Drawing.Point(7, 514);
            this.tb_sendMsg.Multiline = true;
            this.tb_sendMsg.Name = "tb_sendMsg";
            this.tb_sendMsg.Size = new System.Drawing.Size(504, 71);
            this.tb_sendMsg.TabIndex = 1;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 620);
            this.Controls.Add(this.groupBox_message);
            this.Controls.Add(this.groupBox_userList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.groupBox_userList.ResumeLayout(false);
            this.groupBox_message.ResumeLayout(false);
            this.groupBox_message.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_userList;
        private System.Windows.Forms.ListBox listBox_userList;
        private System.Windows.Forms.GroupBox groupBox_message;
        private System.Windows.Forms.Button btn_sendMsg;
        private System.Windows.Forms.TextBox tb_sendMsg;
        private System.Windows.Forms.TextBox tb_message;
    }
}