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

        public Dictionary<Socket, string> OnlineUserList;

        /// <summary>
        /// 初始化,读取用户数据
        /// </summary>
        /// <param name="ipEndPoint"></param>
        public Server(IPEndPoint ipEndPoint) : base(ipEndPoint)
        {
            OnlineUserList = new Dictionary<Socket, string>();
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
            if (this.Processer != null)
                this.Processer.Abort();
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
                    Console.WriteLine("## CONNECT -- " + clientSocket.RemoteEndPoint + " is connected");
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
                    Message<List<string>> msg = this.DeserializeData<List<string>>(socket);
                    ParseData(socket, msg);
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
            Message<List<string>> temp =
                new Message<List<string>>(DataType.Head.MSG, new List<string>() { msg });
            foreach (var item in OnlineUserList)
            {
                this.SerializeData<List<string>>(item.Key, temp);
            }
        }


        private string GetUsr(EndPoint EndPoint)
        {
            foreach (var item in OnlineUserList)
            {
                if (item.Key.RemoteEndPoint == EndPoint)
                    return item.Value;
            }
            return null;
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="msg"></param>
        private void ParseData(Socket socket, Message<List<string>> msg)
        {
            Console.WriteLine("## DATA -- Receiving a data from" + socket.RemoteEndPoint);
            switch (msg.Header)
            {
                //聊天消息
                case DataType.Head.MSG:
                    MassTextMsg(GetUsr(socket.RemoteEndPoint) + " Say : " + msg.Content[0].ToString());
                    break;


                case DataType.Head.GCRL:
                    break;
                case DataType.Head.GUL:
                    break;
                case DataType.Head.JICM:
                    break;
                case DataType.Head.QUIT:
                    OnlineUserList.Remove(socket);
                    Console.WriteLine("## USER -- " + GetUsr(socket.RemoteEndPoint) + " offline !");
                    break;

                //账户登录
                case DataType.Head.LOGN:
                    if (UsrMana.Login(msg.Content[0], msg.Content[1]))
                    {
                        Send<List<string>>(socket, new Message<List<string>>
                            (DataType.Head.LOGN, new List<string>() { "success" }));
                        OnlineUserList.Add(socket, msg.Content[0]);
                        Console.WriteLine("## USER -- " + msg.Content[0] + " online !");
                    }
                    else
                        Send<List<string>>(socket, new Message<List<string>>
                            (DataType.Head.LOGN, new List<string>() { "fail" }));
                    break;

                //账户注册
                case DataType.Head.REGI:
                    if (UsrMana.Register(msg.Content[0], msg.Content[1]))
                        Send<List<string>>(socket, new Message<List<string>>
                            (DataType.Head.REGI, new List<string>() { "success" }));
                    else
                        Send<List<string>>(socket, new Message<List<string>>
                            (DataType.Head.REGI, new List<string>() { "fail" }));
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
