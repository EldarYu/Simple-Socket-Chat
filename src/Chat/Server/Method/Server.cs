using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Core.Protocol;
using Core.Function.Auth;
using Server.Properties;
using System.IO;

namespace Server.Method
{
    /// <summary>
    /// 服务器
    /// </summary>
    public class Server : Core.Net.Server
    {
        private UserManager UsrMana;

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
            UsrMana = new UserManager(Settings.Default.dataPath + "usrm");
        }

        /// <summary>
        /// 存储用户数据
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (UsrMana.Save(Settings.Default.dataPath + "usrm"))
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

        /// <summary>
        /// 根据socket获取用户名
        /// </summary>
        /// <param name="EndPoint"></param>
        /// <returns></returns>
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
        /// 获取在线用户列表
        /// </summary>
        /// <returns></returns>
        private List<string> GetUserList()
        {
            lock (OnlineUserList)
            {
                List<string> usrList = new List<string>();
                foreach (var item in OnlineUserList)
                {
                    usrList.Add(item.Value);
                }
                return usrList;
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="msg"></param>
        private void ParseData(Socket socket, Message<List<string>> msg)
        {
            switch (msg.Header)
            {
                //聊天消息
                case DataType.Head.MSG:
                    Console.WriteLine("## LOG -- " + socket.RemoteEndPoint + " send a message");
                    var usrname = GetUsr(socket.RemoteEndPoint);
                    MassTextMsg(usrname + " Say : " + msg.Content[0].ToString());
                    break;

                //客户端请求在线用户列表
                case DataType.Head.GUL:
                    Console.WriteLine("## LOG -- " + socket.RemoteEndPoint + " request online user list");
                    Send<List<string>>(socket, new Message<List<string>>(DataType.Head.GUL, GetUserList()));
                    break;

                //客户端下线
                case DataType.Head.QUIT:
                    //socket.Close();
                    Console.WriteLine("## USER -- " + GetUsr(socket.RemoteEndPoint) + " offline");
                    OnlineUserList.Remove(socket);
                    break;

                //账户登录
                case DataType.Head.LOGN:
                    Console.WriteLine("## USER -- " + socket.RemoteEndPoint + " trying to login");
                    if (!OnlineUserList.ContainsValue(msg.Content[0]))
                    {
                        if (UsrMana.Login(msg.Content[0], msg.Content[1]))
                        {
                            Send<List<string>>(socket, new Message<List<string>>
                                (DataType.Head.LOGN, new List<string>() { "success" }));
                            OnlineUserList.Add(socket, msg.Content[0]);
                            Console.WriteLine("## USER -- " + msg.Content[0] + " online");
                        }
                        else
                            Send<List<string>>(socket, new Message<List<string>>
                                (DataType.Head.LOGN, new List<string>() { "Account not exist,or check name or password" }));
                    }
                    else
                        Send<List<string>>(socket, new Message<List<string>>
                                    (DataType.Head.LOGN, new List<string>() { "Account already online" }));
                    break;

                //账户注册
                case DataType.Head.REGI:
                    Console.WriteLine("## USER -- " + socket.RemoteEndPoint + " trying to register");
                    if (UsrMana.Register(msg.Content[0], msg.Content[1]))
                        Send<List<string>>(socket, new Message<List<string>>
                            (DataType.Head.REGI, new List<string>() { "success" }));
                    else
                        Send<List<string>>(socket, new Message<List<string>>
                            (DataType.Head.REGI, new List<string>() { "Account already exist" }));
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
