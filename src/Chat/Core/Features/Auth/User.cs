using System;

namespace Core.Features.Auth
{
    /// <summary>
    /// 用户信息,可串行化存放在文件中
    /// </summary>
    [Serializable]
    public class User
    {
        private string name;
        private string password;

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
        /// 实例化
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="chatroom"></param>
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}
