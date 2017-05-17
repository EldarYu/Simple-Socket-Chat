using System;

namespace Core.Function.Chatroom
{
    /// <summary>
    /// 聊天室信息,可串行化存放在文件中
    /// </summary>
    [Serializable]
    public class Chatroom
    {
        private string name;

        /// <summary>
        /// 聊天室名称
        /// </summary>
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="name"></param>
        public Chatroom(string name)
        {
            this.Name = name;
        }
    }
}
