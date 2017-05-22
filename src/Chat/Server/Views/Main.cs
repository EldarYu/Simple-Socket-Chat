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
                Console.WriteLine("## STATUS -- Server is running!");
                Lock(true);
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            server.StopRun();
            Console.WriteLine("## SATUS -- Stopping the server");
            Lock(false);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                if (!server.Save())
                    MessageBox.Show("Data save fail!");
            Environment.Exit(0);
        }

        private void Lock(bool value)
        {
            btn_stop.Enabled = value;
            btn_start.Enabled = !value;
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
        }
    }
}
