using System.Threading;
using System.Windows.Controls;
using Client.Method;
using Core.Protocol;
using System.Collections.Generic;

namespace Client.Views
{
    /// <summary>
    /// Chat.xaml 的交互逻辑
    /// </summary>
    public partial class Chat : UserControl
    {
        public Method.Client Client;

        public Chat(Method.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ControlWriter tw = new ControlWriter(tb_message);
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
                Thread.Sleep(1000);
            }
        }

        private void ProcessData()
        {
            while (true)
            {
                Message<List<string>> usrList = Client.GetSession(DataType.Head.GUL);
                if (usrList != null)
                {
                    this.Dispatcher.BeginInvoke(new ThreadStart( ()=>
                    {
                        var sclectItem = listbox_usr.SelectedItem;
                        listbox_usr.Items.Clear();
                        foreach (var item in usrList.Content)
                        {
                            listbox_usr.Items.Add(item);
                        }
                        if (sclectItem != null)
                            listbox_usr.SelectedItem = sclectItem;
                    }));
                }
                Thread.Sleep(1000);
            }
        }

        private void btn_send_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tb_sendMessage.Text != "")
            {
                Message<List<string>> msg =
                    new Message<List<string>>(DataType.Head.MSG, new List<string>() { tb_sendMessage.Text });
                Client.Send<List<string>>(msg);
                tb_sendMessage.Text = "";
            }
        }

        private void tb_message_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_message.ScrollToEnd();
        }
    }
}
