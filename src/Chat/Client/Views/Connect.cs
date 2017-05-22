using Client.Views;
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
using System.Net;
using Core.Protocol;

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
                if (Auth(DataType.Head.LOGN))
                {
                    Chat fm = new Chat(Client);
                    fm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Account not exist,or check name or password");
                }
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
                if (Auth(DataType.Head.REGI))
                {
                    MessageBox.Show("Registration successful,press 'Login' to login");
                }
                else
                {
                    MessageBox.Show("Registration failure,check name or password");
                }
            }
            else
            {
                MessageBox.Show("Input name and password");
            }
        }

        private bool Auth(DataType.Head head)
        {
            Message<List<string>> msg = new Message<List<string>>
                   (head, new List<string>() { tb_name.Text, tb_password.Text });
            Client.Send<List<string>>(msg);
            int TimeCount = 0;
            while (true)
            {
                Message<List<string>> temp = Client.GetSession(head);
                if (temp != null)
                {
                    if (temp.Content[0] == "success")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if(TimeCount>10000000)
                {
                    MessageBox.Show("Server Connection interrupted");
                    Application.ExitThread();
                }
                TimeCount++;
                continue;
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
                Lock(true);
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
    }
}
