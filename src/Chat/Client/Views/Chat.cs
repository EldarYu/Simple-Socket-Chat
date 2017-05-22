using System;
using System.Windows.Forms;
using Client.Method;
using Core.Protocol;
using System.Collections.Generic;

namespace Client.Views
{
    public partial class Chat : Form
    {
        public Method.Client Client;
        public Method.Client GetUserList;
        public Method.Client GetChtromList;

        public Chat(Method.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            TextBoxWriter tw = new TextBoxWriter(tb_message);
        }

        private void btn_createChatroom_Click(object sender, EventArgs e)
        {

        }

        private void btn_sendMsg_Click(object sender, EventArgs e)
        {
            if (tb_sendMsg.Text != "")
            {
                Client.SendMsg(tb_sendMsg.Text);
                tb_sendMsg.Text = "";
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Message<List<string>> msg = new Message<List<string>>(DataType.Head.QUIT, null);
            Client.Send<List<string>>(msg);
        }
    }
}
