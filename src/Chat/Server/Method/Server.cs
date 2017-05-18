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
    public class Server : Core.Net.Server
    {
        public Server(IPEndPoint ipEndPoint) : base(ipEndPoint) { }

        public List<Socket> OnlineUserList;
        public ControlWriter Writer = ControlWriter.GetInstance();

        public bool Run(int maxBacklog)
        {
            OnlineUserList = new List<Socket>();
            this.MaxBackLog = maxBacklog;
            if (!this.Start())
                return false;
            this.Listener = new Thread(Listen);
            this.Listener.Start();
            return true;
        }

        public void StopRun()
        {
            this.Stop();
        }

        private void Listen()
        {
            while (this.RunStatus)
            {
                try
                {
                    Socket clientSocket;
                    clientSocket = this.ServerSocket.Accept();

                    OnlineUserList.Add(clientSocket);
                    //MassTextMsg(clientSocket.RemoteEndPoint + " is online");
                    Writer.SetMsg(clientSocket.RemoteEndPoint + " is connected");
                    this.Processer = new Thread(() => ProcessData(clientSocket));
                    this.Processer.Start();
                }
                catch (SocketException e)
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
                    MassTextMsg(socket.RemoteEndPoint + " say :" + msg.Content);
                    Writer.SetMsg(socket.RemoteEndPoint + " send message");
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

        private void MassTextMsg(string msg)
        {
            Core.Protocol.Message<string> temp =
                new Core.Protocol.Message<string>(Core.Protocol.DataType.Head.MSG, msg);
            foreach (var item in OnlineUserList)
            {
                this.SerializeData<string>(item, temp);
            }
        }
    }
}
