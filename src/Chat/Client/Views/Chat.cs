using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Method;
using Core.Protocol;
using System.Net;

namespace Client.Views
{
    public partial class Chat : Form
    {
        public Method.Client Client;
        public ControlWriter writer;
        public Chat(Method.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            writer = ControlWriter.GetInstance();
            writer.writer += new ControlWriter.Write(Update);
        }

        private void btn_createChatroom_Click(object sender, EventArgs e)
        {

        }

        private void btn_sendMsg_Click(object sender, EventArgs e)
        {
            if (tb_sendMsg.Text != "")
            {
                Message<string> msg = new Message<string>(DataType.Head.MSG, tb_sendMsg.Text.ToString());
                Client.Send<string>(msg);
                tb_sendMsg.Text = "";
            }
        }

        private void Update(object control, string msg)
        {
            if (control is TextBox)
                tb_message.AppendText("- " + msg + " -\r\n");

        }

    }
}
