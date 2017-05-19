using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Core.Protocol;
using Core.Function.Auth;
using Core.Function.Chatroom;
using Server.Properties;
using System.IO;
using System.Text.RegularExpressions;

namespace Server.Method
{
    /// <summary>
    /// 服务器
    /// </summary>
    public class Server : Core.Net.Server
    {
        private UserManager UsrMana;
        private ChatroomManager ChatMana;

        public List<Socket> OnlineUserList;

        /// <summary>
        /// 初始化,读取用户数据
        /// </summary>
        /// <param name="ipEndPoint"></param>
        public Server(IPEndPoint ipEndPoint) : base(ipEndPoint)
        {
            if (!Directory.Exists(Settings.Default.dataPath))
                Directory.CreateDirectory(Settings.Default.dataPath);
            UsrMana = new UserManager(Settings.Default.dataPath + "usrm.pkg");
            ChatMana = new ChatroomManager(Settings.Default.dataPath + "chtm.pkg");
        }

        /// <summary>
        /// 存储用户数据
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (UsrMana.Save(Settings.Default.dataPath + "usrm.pkg") &&
                ChatMana.Save(Settings.Default.dataPath + "chtm.pkg"))
                return true;
            return false;
        }


        /// <summary>
        /// 启动服务器及监听进程
        /// </summary>
        /// <param name="maxBacklog"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 停止服务器,终止监听进程
        /// </summary>
        public void StopRun()
        {
            this.Stop();
            this.Listener.Abort();
        }

        /// <summary>
        /// 监听
        /// </summary>
        private void Listen()
        {
            while (this.RunStatus)
            {
                try
                {
                    Socket clientSocket;
                    clientSocket = this.ServerSocket.Accept();

                    OnlineUserList.Add(clientSocket);
                    Console.WriteLine(clientSocket.RemoteEndPoint + " is connected");
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

        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="socket"></param>
        private void ProcessData(Socket socket)
        {
            while (this.RunStatus)
            {
                try
                {
                    Message<string> msg = this.DeserializeData<string>(socket);
                    ParseData(socket, msg);
                    Console.WriteLine("Receiving a message from" + socket.RemoteEndPoint);
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

        /// <summary>
        /// 向所有在线客户端服务数据
        /// </summary>
        /// <param name="msg"></param>
        private void MassTextMsg(string msg)
        {
            Message<string> temp =
                new Message<string>(DataType.Head.MSG, msg);
            foreach (var item in OnlineUserList)
            {
                this.SerializeData<string>(item, temp);
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="msg"></param>
        private void ParseData(Socket socket, Message<string> msg)
        {
            switch (msg.Header)
            {
                case DataType.Head.MSG:
                    MassTextMsg(socket.RemoteEndPoint.ToString()+ " Say : "+ msg.Content);
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
                    string[] lognUsr = Regex.Split(msg.Content, "\r\n");
                    if (UsrMana.Login(lognUsr[0], lognUsr[1]))
                        Send<bool>(socket, new Message<bool>(DataType.Head.VERF, true));
                    else
                        Send<bool>(socket, new Message<bool>(DataType.Head.VERF, false));
                    break;

                case DataType.Head.REGI:
                    string[] regiUsr = Regex.Split(msg.Content, "\r\n");
                    if (UsrMana.Register(regiUsr[0], regiUsr[1]))
                        Send<bool>(socket, new Message<bool>(DataType.Head.VERF, true));
                    else
                        Send<bool>(socket, new Message<bool>(DataType.Head.VERF, false));
                    break;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        private void Send<T>(Socket socket, Message<T> msg)
        {
            this.SerializeData<T>(socket, msg);
        }
    }
}
