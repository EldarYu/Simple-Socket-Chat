﻿using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Core.Protocol;
using System.Collections.Generic;

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
            if (Session.Count > 0)
            {
                foreach (var item in Session)
                {
                    if(item.Header==head)
                    {
                        Message<List<string>> temp = item;
                        Session.Clear();
                        return temp;
                    }
                }
                return null;
            }
            return null;
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
        private void ParseData(Message<List<string>> msg)
        {
            switch (msg.Header)
            {
                case DataType.Head.MSG:
                    Console.WriteLine(msg.Content[0].ToString());
                    break;

                case DataType.Head.GCRL:
                    Session.Add(msg);
                    break;
                case DataType.Head.GUL:
                    Session.Add(msg);
                    break;

                case DataType.Head.JICM:
                    break;

                case DataType.Head.LOGN:
                    Session.Add(msg);
                    break;
                case DataType.Head.REGI:
                    Session.Add(msg);
                    break;

            }
        }

        /// <summary>
        /// 发送文字消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {
            Message<List<string>> temp = new Message<List<string>>(DataType.Head.MSG, new List<string>() { msg });
            Send<List<string>>(temp);
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
