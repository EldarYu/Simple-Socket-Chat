using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;

namespace Core.Net
{
    /// <summary>
    /// 服务器
    /// </summary>
    public class Server : Comm
    {
        /// <summary>
        /// 监听主进程
        /// </summary>
        protected Thread Listener;

        /// <summary>
        /// 数据处理进程
        /// </summary>
        protected Thread Processer;

        public Socket ServerSocket;
        private int maxBackLog;

        /// <summary>
        /// 等待的最大队列长度
        /// </summary>
        public int MaxBackLog
        {
            set
            {
                maxBackLog = value;
            }
            get
            {
                return maxBackLog;
            }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="ipEndPoint"></param>
        public Server(IPEndPoint ipEndPoint)
        {
            this.IpEndPoint = ipEndPoint;
            ServerSocket = null;
            this.Listener = null;
            this.Processer = null;
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <returns></returns>
        protected bool Start()
        {
            try
            {
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Bind(this.IpEndPoint);
                ServerSocket.Listen(MaxBackLog);
                this.RunStatus = true;
                return true;
            }
            catch(SocketException e)
            {
                new Exceptions.SocketException(e);
            }
            catch(Exception e)
            {
                new Exceptions.UnknowException(e);
            }
            this.RunStatus = false;
            return false;
        }

        /// <summary>
        /// 关闭socket
        /// </summary>
        protected void Stop()
        {
            this.RunStatus = false;
            ServerSocket.Close();
        }
    }
}
