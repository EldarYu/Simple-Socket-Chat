using System;

namespace Core.Function.Auth
{
    /// <summary>
    /// 用户信息,可串行化存放在文件中
    /// </summary>
    [Serializable]
    public class User
    {
        private string name;
        private string password;
        private Chatroom.Chatroom chatRoom;

        /// <summary>
        /// 用户名
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
        /// 密码
        /// </summary>
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        /// <summary>
        /// 所属聊天室
        /// </summary>
        public Chatroom.Chatroom ChatRoom
        {
            set
            {
                chatRoom = value;
            }
            get
            {
                return chatRoom;
            }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="chatroom"></param>
        public User(string name, string password, Chatroom.Chatroom chatroom)
        {
            this.Name = name;
            this.Password = password;
            this.ChatRoom = chatroom;
        }
    }
}
