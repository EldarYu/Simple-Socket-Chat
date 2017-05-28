using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using Client.Properties;
using Core.Protocol;
using System.Threading;
using System;

namespace Client.Views
{
    /// <summary>
    /// Connect.xaml 的交互逻辑
    /// </summary>
    public partial class Connect : UserControl
    {
        public Method.Client Client;

        public Connect(Method.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void btn_login_Click_1(object sender, RoutedEventArgs e)
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

        private void btn_register_Click(object sender, RoutedEventArgs e)
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
                        this.Dispatcher.BeginInvoke(new ThreadStart( ()=>
                      {
                          this.Content = new Chat(Client);
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Thread Process = new Thread(ProcessData);
            Process.Start();
        }
    }
}
