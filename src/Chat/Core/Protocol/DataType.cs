using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protocol
{
    /// <summary>
    /// 客户端与服务器交互的数据类型
    /// </summary>
    public class DataType
    {
        /// <summary>
        /// 类型枚举
        /// MSG-文字消息,GUL-get user list 获取在线用户列表,GCRL-get chatroom list 获取聊天室列表
        /// REGI-register 用户注册,QUIT-用户下线,JICM-join chatroom 加入聊天室
        /// </summary>
        public enum Head {
            MSG,
            GUL,GCRL,
            REGI,QUIT,
            JICM
        };
    }
}
