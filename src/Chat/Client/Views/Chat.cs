using System;
using System.Windows.Forms;
using Client.Method;

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
                Client.Send(tb_sendMsg.Text);
                tb_sendMsg.Text = "";
            }
        }

    }
}
