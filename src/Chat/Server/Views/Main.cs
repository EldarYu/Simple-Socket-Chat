using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Server.Method;

namespace Server
{
    public partial class Main : Form
    {
        public Method.Server server;
        public ControlWriter writer;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            writer = ControlWriter.GetInstance();
            writer.writer += new ControlWriter.Write(UpdateStatus);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(nud_ip1.Value.ToString() + "."
                + nud_ip2.Value.ToString() + "." + nud_ip3.Value.ToString() + "."
                + nud_ip4.Value.ToString());
            int port = Convert.ToInt32(nud_port.Value);
            server = new Method.Server(new IPEndPoint(ipAddress, port));
            if (server.Run(100))
            {
                UpdateStatus("Server is running");
                btn_stop.Enabled = true;
                btn_start.Enabled = false;
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
            }
        }

        private void UpdateStatus(string msg)
        {
            tb_statuShow.AppendText("- " + msg + " -\r\n");
        }
    }
}
