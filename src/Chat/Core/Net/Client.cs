using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Core.Net
{
    /// <summary>
    /// 客户端
    /// </summary>
    public class Client : Comm
    {
        /// <summary>
        /// 数据处理进程
        /// </summary>
        protected Thread Processer;

        protected Socket ClientSocket;

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="ipEndPoint"></param>
        public Client(IPEndPoint ipEndPoint)
        {
            this.IpEndPoint = ipEndPoint;
            ClientSocket = null;
            this.Processer = null;
        }

        /// <summary>
        /// 启动客户端
        /// </summary>
        /// <returns></returns>
        protected bool Connect()
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(this.IpEndPoint);
                this.RunStatus = true;
                return true;
            }
            catch (SocketException e)
            {
                new Exceptions.SocketException(e);
            }
            catch (Exception e)
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
            this.ClientSocket.Close();
        }

    }
}
