﻿namespace Core.Protocol
{
    /// <summary>
    /// 客户端与服务器交互的数据类型
    /// </summary>
    public class DataType
    {
        public enum Head
        {
            /// <summary>
            /// 文字消息            
            /// </summary>
            MSG,

            /// <summary>
            /// 获取在线用户列表
            /// </summary>
            GUL,

            /// <summary>
            /// 获取聊天室列表
            /// </summary>
            GCRL,

            /// <summary>
            /// 用户登陆
            /// </summary>
            LOGN,

            /// <summary>
            /// 用户注册
            /// </summary>
            REGI,

            /// <summary>
            /// 加入聊天室
            /// </summary>
            JICM, 
           
            /// <summary>
            /// 创建聊天室
            /// </summary>
            CECR,

            /// <summary>
            /// 用户下线
            /// </summary>
            QUIT,
           
        };
    }
}
