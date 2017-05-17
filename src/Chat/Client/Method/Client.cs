using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Client.Method
{
    public class Client :Core.Net.Client
    {
        public Client(IPEndPoint ipEndPoint) : base(ipEndPoint) { }
        
        public bool Run()
        {
            if (!this.Connect())
                return false;
            this.Processer = new Thread(ProcessData);
            return true;
        }

        public void Send<T>(Socket socket, Core.Protocol.Message<T> msg)
        {
            this.SerializeData<T>(socket, msg);
        }

        private void ProcessData()
        {
            while (this.RunStatus)
            {
                try
                {
                    Core.Protocol.Message<string> msg = this.DeserializeData<string>(this.ClientSocket);

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
    }
}
