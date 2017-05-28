using System;
using System.Threading;
using System.Windows;
using Client.Method;
using System.Net;
using Client.Properties;
using Core.Protocol;
using System.Collections.Generic;

namespace Client.Views
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Method.Client Client;
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Client = new Method.Client(
               new IPEndPoint(IPAddress.Parse(Settings.Default.ipAddress), Settings.Default.port));
            if (!Client.Run())
            {
                MessageBox.Show("Server not online ! ,Program will exit");
                Environment.Exit(0);
            }
            mainContent.Content = new Connect(Client);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Message<List<string>> msg =
             new Message<List<string>>(DataType.Head.QUIT, null);
            Client.Send<List<string>>(msg);
            Environment.Exit(0);
        }
    }
}
