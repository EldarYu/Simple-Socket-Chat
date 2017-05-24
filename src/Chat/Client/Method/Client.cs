using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Core.Protocol;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Client.Method
{
    /// <summary>
    /// 客户端
    /// </summary>
    public class Client : Core.Net.Client
    {
        public List<Message<List<string>>> Session;

        public Client(IPEndPoint ipEndPoint) : base(ipEndPoint)
        {
            Session = new List<Message<List<string>>>();
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (!this.Connect())
                return false;
            this.Processer = new Thread(ProcessData);
            this.Processer.Start();
            return true;
        }

        /// <summary>
        /// 停止服务器,终止数据处理进程
        /// </summary>
        public void StopRun()
        {
            this.Stop();
            this.Processer.Abort();
        }

        public Message<List<string>> GetSession(DataType.Head head)
        {
            Message<List<string>> temp = null;
            lock (Session)
            {
                if (Session.Count > 0)
                {
                    foreach (var item in Session)
                    {
                        if (item.Header == head)
                        {
                            temp = item;
                        }
                    }
                }
            }
            Session.Remove(temp);
            return temp;
        }

        /// <summary>
        /// 处理数据
        /// </summary>
        private void ProcessData()
        {
            while (this.RunStatus)
            {
                try
                {
                    Message<List<string>> msg = this.DeserializeData<List<string>>(this.ClientSocket);
                    ParseData(msg);
                }
                catch (SocketException e)
                {
                    new Core.Exceptions.SocketException(e);
                    this.RunStatus = false;
                    this.ClientSocket.Close();
                    MessageBox.Show("Lost connection,Program will exit");
                    Environment.Exit(0);
                }
                catch (Exception e)
                {
                    new Core.Exceptions.UnknowException(e);
                    this.RunStatus = false;
                    this.ClientSocket.Close();
                    MessageBox.Show("Lost connection,Program will exit");
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="msg"></param>
        private void ParseData(Message<List<string>> msg)
        {
            lock (Session)
            {
                switch (msg.Header)
                {
                    //来自服务器的文字消息
                    case DataType.Head.MSG:
                        Console.WriteLine(msg.Content[0].ToString());
                        break;

                    //在线用户列表数据
                    case DataType.Head.GUL:
                        Session.Add(msg);
                        break;

                    //登录验证结果
                    case DataType.Head.LOGN:
                        Session.Add(msg);
                        break;

                    //注册验证结果
                    case DataType.Head.REGI:
                        Session.Add(msg);
                        break;
                }
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        public void Send<T>(Message<T> msg)
        {
            this.SerializeData<T>(this.ClientSocket, msg);
        }
    }
}
