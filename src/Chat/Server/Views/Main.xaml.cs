using System.Windows;
using Server.Method;
using System.Net;
using Server.Properties;
using System;

namespace Server.Views
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Method.Server Server;

        public Main()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(Settings.Default.ipAddress);
            int port = Settings.Default.port;
            Server = new Method.Server(new IPEndPoint(ipAddress, port));
            if(Server.Run(Settings.Default.maxBacklog))
            {
                Console.WriteLine("## STATUS -- Server is running!");
                btn_start.IsEnabled = false;
                btn_stop.IsEnabled = true;
            }
           else
            {
                MessageBox.Show("Server not run,check setting");
            }
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            Server.StopRun();
            Console.WriteLine("## SATUS -- Stopping the server");
            btn_start.IsEnabled = true;
            btn_stop.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ControlWriter writer = new ControlWriter(tb_status);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Server != null)
                if (!Server.Save())
                    MessageBox.Show("Data save fail!");
            Environment.Exit(0);
        }

        private void tb_status_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tb_status.ScrollToEnd();
        }
    }
}
