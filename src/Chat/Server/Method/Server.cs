using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Server.Method
{
    public class Server : Core.Net.Server;
    {
        public Server(IPEndPoint ipEndPoint) : base(ipEndPoint) { }

        public List<Core.Function.Auth.User> OnlineUserList;

        public bool Run(int maxBacklog)
        {
            OnlineUserList = new List<Core.Function.Auth.User>();
            this.MaxBackLog = maxBacklog;
            if (this.Start())
                return false;
            this.Listener = new Thread(Listen);
            this.Listener.Start();
            return true;
        }

        private void Listen()
        {
            while (this.RunStatus)
            {
                try
                {
                    Socket clientSocket;
                    clientSocket = this.ServerSocket.Accept();
                    this.Processer = new Thread(() => ProcessData(clientSocket));
                    this.Processer.Start();
                }
                catch(SocketException e)
                {
                    new Core.Exceptions.SocketException(e);
                }
                catch (Exception e)
                {
                    new Core.Exceptions.UnknowException(e);
                }
            }
        }

        private void ProcessData(Socket socket)
        {
            while (this.RunStatus)
            {
                try
                {
                    Core.Protocol.Message<string> msg = this.DeserializeData<string>(socket);

                }
                catch (SocketException e)
                {
                    new Core.Exceptions.SocketException(e);
                    socket.Close();
                }
                catch (Exception e)
                {
                    new Core.Exceptions.UnknowException(e);
                    socket.Close();
                }

            }
        }
    }
}
