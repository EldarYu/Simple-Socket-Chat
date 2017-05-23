using System;
using System.Windows.Forms;
using Client.Method;
using Core.Protocol;
using System.Collections.Generic;
using System.Threading;

namespace Client.Views
{
    public partial class Chat : Form
    {
        public Method.Client Client;

        public Chat(Method.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            TextBoxWriter tw = new TextBoxWriter(tb_message);
            Thread Request = new Thread(RequestData);
            Thread Process = new Thread(ProcessData);
            Request.Start();
            Process.Start();
        }

        private void RequestData()
        {
            while (true)
            {
                Client.Send<List<string>>
                    (new Message<List<string>>(DataType.Head.GUL, new List<string>() { }));
                Client.Send<List<string>>
                    (new Message<List<string>>(DataType.Head.GCRL, new List<string>() { }));
                Thread.Sleep(1000);
            }
        }

        private void ProcessData()
        {
            while (true)
            {
                Message<List<string>> usrList = Client.GetSession(DataType.Head.GUL);
                Message<List<string>> chatromList = Client.GetSession(DataType.Head.GCRL);
                Message<List<string>> cecrReply = Client.GetSession(DataType.Head.CECR);
                if (usrList != null)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        listBox_userList.Items.Clear();
                        foreach (var item in usrList.Content)
                        {
                            listBox_userList.Items.Add(item);
                        }
                    }));
                }
                if (chatromList != null)
                {
                    if (chatromList.Content != null)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            cb_chatroomList.Items.Clear();
                            foreach (var item in chatromList.Content)
                            {
                                cb_chatroomList.Items.Add(item);
                            }
                        }));
                    }
                }
                if(cecrReply!=null)
                {
                    if (cecrReply.Content[0] == "success")
                        MessageBox.Show("Create successful");
                    else
                        MessageBox.Show(cecrReply.Content[0]);
                }
                Thread.Sleep(1000);
            }
        }



        private void btn_createChatroom_Click(object sender, EventArgs e)
        {
            if(tb_chatroom.Text!="")
            {
                Message<List<string>> msg =
                   new Message<List<string>>(DataType.Head.CECR, new List<string>() { tb_chatroom.Text });
                Client.Send<List<string>>(msg);
                tb_chatroom.Text = "";
            }

        }

        private void btn_sendMsg_Click(object sender, EventArgs e)
        {
            if (tb_sendMsg.Text != "")
            {
                Message<List<string>> msg =
                    new Message<List<string>>(DataType.Head.MSG, new List<string>() { tb_sendMsg.Text });
                Client.Send<List<string>>(msg);
                tb_sendMsg.Text = "";
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Message<List<string>> msg =
                new Message<List<string>>(DataType.Head.QUIT, null);
            Client.Send<List<string>>(msg);
            Environment.Exit(0);
        }
    }
}
