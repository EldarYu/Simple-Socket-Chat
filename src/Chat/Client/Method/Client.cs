using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Core.Protocol;

namespace Client.Method
{
    /// <summary>
    /// 客户端
    /// </summary>
    public class Client : Core.Net.Client
    {
        public Client(IPEndPoint ipEndPoint) : base(ipEndPoint) { }

        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <returns></returns>
        public bool Run(bool isChatClient)
        {
            if (!this.Connect())
                return false;
            if (isChatClient)
                Listene();
            return true;
        }

        /// <summary>
        /// 启动数据处理进程
        /// </summary>
        public void Listene()
        {
            this.Processer = new Thread(ProcessData);
            this.Processer.Start();
        }

        /// <summary>
        /// 停止服务器,终止数据处理进程
        /// </summary>
        public void StopRun()
        {
            this.Stop();
            this.Processer.Abort();
        }

        public void Send(string msg)
        {
            Message<string> _msg = new Message<string>(DataType.Head.MSG, msg);
            ParseData(_msg);
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
                    Message<string> msg = this.DeserializeData<string>(this.ClientSocket);
                    Console.WriteLine(msg.Content);
                }
                catch (SocketException e)
                {
                    new Core.Exceptions.SocketException(e);
                    this.ClientSocket.Close();
                }
                catch (Exception e)
                {
                    new Core.Exceptions.UnknowException(e);
                    this.ClientSocket.Close();
                }
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        private void ParseData<T>(Message<T> msg)
        {
            switch (msg.Header)
            {
                case DataType.Head.MSG:
                    Send(msg as Message<string>);
                    break;

                case DataType.Head.GCRL:
                    break;
                case DataType.Head.GUL:
                    break;
                case DataType.Head.JICM:
                    break;
                case DataType.Head.QUIT:
                    break;
                case DataType.Head.LOGN:

                    break;
                case DataType.Head.REGI:
                    break;

            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        private void Send<T>(Message<T> msg)
        {
            this.SerializeData<T>(this.ClientSocket, msg);
        }
    }
}
