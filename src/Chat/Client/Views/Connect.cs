using Client.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using Core.Protocol;
using System.Threading;

namespace Client
{
    public partial class Connect : Form
    {
        public Method.Client Client;
        public Connect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (tb_name.Text != "" && tb_password.Text != "")
            {
                Message<List<string>> msg = new Message<List<string>>
                  (DataType.Head.LOGN, new List<string>() { tb_name.Text, tb_password.Text });
                Client.Send<List<string>>(msg);
            }
            else
            {
                MessageBox.Show("Input name and password");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (tb_name.Text != "" && tb_password.Text != "")
            {
                Message<List<string>> msg = new Message<List<string>>
                   (DataType.Head.REGI, new List<string>() { tb_name.Text, tb_password.Text });
                Client.Send<List<string>>(msg);
            }
            else
            {
                MessageBox.Show("Input name and password");
            }
        }

        private void ProcessData()
        {
            while (true)
            {
                Message<List<string>> loginReply = Client.GetSession(DataType.Head.LOGN);
                Message<List<string>> regisReply = Client.GetSession(DataType.Head.REGI);
                if (loginReply != null)
                {
                    if (loginReply.Content[0] == "success")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            Chat fm = new Chat(Client);
                            fm.Show();
                            this.Hide();
                        }));
                    }
                    else
                        MessageBox.Show(loginReply.Content[0]);
                }
                if (regisReply != null)
                {
                    if (regisReply.Content[0] == "success")
                        MessageBox.Show("Registration successful,press 'Login' to login");
                    else
                        MessageBox.Show(regisReply.Content[0]);
                }

                Thread.Sleep(500);
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(nud_ip1.Value.ToString() + "."
              + nud_ip2.Value.ToString() + "." + nud_ip3.Value.ToString() + "."
              + nud_ip4.Value.ToString());
            int port = Convert.ToInt32(nud_port.Value);
            Client = new Method.Client(new IPEndPoint(ipAddress, port));
            if (Client.Run())
            {
                Thread Process = new Thread(ProcessData);
                Process.Start();
                Lock(true);
            }
            else
            {
                Client = null;
                MessageBox.Show("Server not online !");
            }
        }

        private void Lock(bool value)
        {
            nud_ip1.ReadOnly = value;
            nud_ip2.ReadOnly = value;
            nud_ip3.ReadOnly = value;
            nud_ip4.ReadOnly = value;
            nud_port.ReadOnly = value;
            nud_ip1.Increment = value ? 0 : 1;
            nud_ip2.Increment = value ? 0 : 1;
            nud_ip3.Increment = value ? 0 : 1;
            nud_ip4.Increment = value ? 0 : 1;
            nud_port.Increment = value ? 0 : 1;
            tb_name.ReadOnly = !value;
            tb_password.ReadOnly = !value;
            btn_login.Enabled = value;
            btn_register.Enabled = value;
        }

        private void Connect_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
