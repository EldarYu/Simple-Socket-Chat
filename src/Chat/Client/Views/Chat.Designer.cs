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
            this.groupBox_chatRoom = new System.Windows.Forms.GroupBox();
            this.cb_chatroomList = new System.Windows.Forms.ComboBox();
            this.tb_createChatroom = new System.Windows.Forms.TextBox();
            this.btn_createChatroom = new System.Windows.Forms.Button();
            this.groupBox_message = new System.Windows.Forms.GroupBox();
            this.tb_sendMsg = new System.Windows.Forms.TextBox();
            this.btn_sendMsg = new System.Windows.Forms.Button();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.groupBox_userList.SuspendLayout();
            this.groupBox_chatRoom.SuspendLayout();
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
            this.listBox_userList.FormattingEnabled = true;
            this.listBox_userList.ItemHeight = 16;
            this.listBox_userList.Items.AddRange(new object[] {
            "111",
            "1111",
            "11111",
            "222",
            "2222",
            "22222"});
            this.listBox_userList.Location = new System.Drawing.Point(6, 21);
            this.listBox_userList.Name = "listBox_userList";
            this.listBox_userList.Size = new System.Drawing.Size(240, 564);
            this.listBox_userList.TabIndex = 0;
            // 
            // groupBox_chatRoom
            // 
            this.groupBox_chatRoom.Controls.Add(this.btn_createChatroom);
            this.groupBox_chatRoom.Controls.Add(this.tb_createChatroom);
            this.groupBox_chatRoom.Controls.Add(this.cb_chatroomList);
            this.groupBox_chatRoom.Location = new System.Drawing.Point(270, 12);
            this.groupBox_chatRoom.Name = "groupBox_chatRoom";
            this.groupBox_chatRoom.Size = new System.Drawing.Size(610, 82);
            this.groupBox_chatRoom.TabIndex = 1;
            this.groupBox_chatRoom.TabStop = false;
            this.groupBox_chatRoom.Text = "Chatroom";
            // 
            // cb_chatroomList
            // 
            this.cb_chatroomList.FormattingEnabled = true;
            this.cb_chatroomList.Location = new System.Drawing.Point(30, 30);
            this.cb_chatroomList.Name = "cb_chatroomList";
            this.cb_chatroomList.Size = new System.Drawing.Size(311, 24);
            this.cb_chatroomList.TabIndex = 0;
            // 
            // tb_createChatroom
            // 
            this.tb_createChatroom.Location = new System.Drawing.Point(370, 32);
            this.tb_createChatroom.Name = "tb_createChatroom";
            this.tb_createChatroom.Size = new System.Drawing.Size(124, 22);
            this.tb_createChatroom.TabIndex = 1;
            // 
            // btn_createChatroom
            // 
            this.btn_createChatroom.Location = new System.Drawing.Point(519, 26);
            this.btn_createChatroom.Name = "btn_createChatroom";
            this.btn_createChatroom.Size = new System.Drawing.Size(75, 35);
            this.btn_createChatroom.TabIndex = 2;
            this.btn_createChatroom.Text = "Create";
            this.btn_createChatroom.UseVisualStyleBackColor = true;
            this.btn_createChatroom.Click += new System.EventHandler(this.btn_createChatroom_Click);
            // 
            // groupBox_message
            // 
            this.groupBox_message.Controls.Add(this.tb_message);
            this.groupBox_message.Controls.Add(this.btn_sendMsg);
            this.groupBox_message.Controls.Add(this.tb_sendMsg);
            this.groupBox_message.Location = new System.Drawing.Point(271, 101);
            this.groupBox_message.Name = "groupBox_message";
            this.groupBox_message.Size = new System.Drawing.Size(609, 512);
            this.groupBox_message.TabIndex = 2;
            this.groupBox_message.TabStop = false;
            this.groupBox_message.Text = "Message";
            // 
            // tb_sendMsg
            // 
            this.tb_sendMsg.Location = new System.Drawing.Point(6, 425);
            this.tb_sendMsg.Multiline = true;
            this.tb_sendMsg.Name = "tb_sendMsg";
            this.tb_sendMsg.Size = new System.Drawing.Size(504, 71);
            this.tb_sendMsg.TabIndex = 1;
            // 
            // btn_sendMsg
            // 
            this.btn_sendMsg.Location = new System.Drawing.Point(518, 425);
            this.btn_sendMsg.Name = "btn_sendMsg";
            this.btn_sendMsg.Size = new System.Drawing.Size(79, 71);
            this.btn_sendMsg.TabIndex = 2;
            this.btn_sendMsg.Text = "Send";
            this.btn_sendMsg.UseVisualStyleBackColor = true;
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(7, 22);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.ReadOnly = true;
            this.tb_message.Size = new System.Drawing.Size(590, 379);
            this.tb_message.TabIndex = 3;
            this.tb_message.Text = "1233\r\n1231\r\n546\r\n";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 621);
            this.Controls.Add(this.groupBox_message);
            this.Controls.Add(this.groupBox_chatRoom);
            this.Controls.Add(this.groupBox_userList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.groupBox_userList.ResumeLayout(false);
            this.groupBox_chatRoom.ResumeLayout(false);
            this.groupBox_chatRoom.PerformLayout();
            this.groupBox_message.ResumeLayout(false);
            this.groupBox_message.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_userList;
        private System.Windows.Forms.ListBox listBox_userList;
        private System.Windows.Forms.GroupBox groupBox_chatRoom;
        private System.Windows.Forms.TextBox tb_createChatroom;
        private System.Windows.Forms.ComboBox cb_chatroomList;
        private System.Windows.Forms.Button btn_createChatroom;
        private System.Windows.Forms.GroupBox groupBox_message;
        private System.Windows.Forms.Button btn_sendMsg;
        private System.Windows.Forms.TextBox tb_sendMsg;
        private System.Windows.Forms.TextBox tb_message;
    }
}