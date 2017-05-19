using System;
using System.Windows.Forms;
using System.Net;
using Server.Method;

namespace Server
{
    public partial class Main : Form
    {
        public Method.Server server;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TextBoxWriter tw = new TextBoxWriter(tb_statuShow);
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
                Console.WriteLine("Server is running!");
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

        private void btn_stop_Click(object sender, EventArgs e)
        {
            server.StopRun();
            Console.WriteLine("Stopping the server");
            btn_stop.Enabled = false;
            btn_start.Enabled = true;
            nud_ip1.ReadOnly = false;
            nud_ip2.ReadOnly = false;
            nud_ip3.ReadOnly = false;
            nud_ip4.ReadOnly = false;
            nud_port.ReadOnly = false;
            nud_ip1.Increment = 1;
            nud_ip2.Increment = 1;
            nud_ip3.Increment = 1;
            nud_ip4.Increment = 1;
            nud_port.Increment = 1;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                if (!server.Save())
                    MessageBox.Show("Data save fail!");
        }
    }
}
