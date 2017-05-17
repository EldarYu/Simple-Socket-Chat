using System;

namespace Core.Protocol
{
    /// <summary>
    /// 客户端与服务器交互的信息内容
    /// </summary>
    [Serializable]
    public class Message<T>
    {
        private DataType.Head header;
        private T content;

        /// <summary>
        /// 标识消息类型的头部
        /// </summary>
        public DataType.Head Header
        {
            set
            {
                header = value;
            }
            get
            {
                return header;
            }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public T Content
        {
            set
            {
                content = value;
            }
            get
            {
                return content;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="head"></param>
        /// <param name="content"></param>
        public Message(DataType.Head head, T content)
        {
            this.Header = head;
            this.Content = content;
        }
    }
}
