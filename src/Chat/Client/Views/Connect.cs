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
            Chat chat = new Chat(Client);
            chat.Show();
            this.Hide();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(nud_ip1.Value.ToString() + "."
              + nud_ip2.Value.ToString() + "." + nud_ip3.Value.ToString() + "."
              + nud_ip4.Value.ToString());
            int port = Convert.ToInt32(nud_port.Value);
            Client = new Method.Client(new IPEndPoint(ipAddress, port));
            if(Client.Run())
            {
                nud_ip1.ReadOnly = true;
                nud_ip2.ReadOnly = true;
                nud_ip3.ReadOnly = true;
                nud_ip4.ReadOnly = true;
                nud_port.ReadOnly = true;
                nud_ip1.Increment = 0;
                nud_ip2.Increment = 0;
                nud_ip3.Increment = 0;
                nud_ip4.Increment = 0;
                nud_port.Increment = 0;
                tb_name.ReadOnly = false;
                tb_password.ReadOnly = false;
                btn_login.Enabled = true;
                btn_register.Enabled = true;
            }
        }
    }
}
