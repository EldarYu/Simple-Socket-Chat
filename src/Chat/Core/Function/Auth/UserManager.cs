using System.Collections.Generic;

namespace Core.Function.Auth
{
    /// <summary>
    /// 用户列表
    /// </summary>
    public class UserManager
    {
        private List<User> userList;
        private FileHelper fileHelper;

        /// <summary>
        /// 用户表
        /// </summary>
        public List<User> UserList
        {
            set
            {
                userList = value;
            }
            get
            {
                return userList;
            }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        public UserManager(string path)
        {
            fileHelper = new FileHelper();
            Init(path);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string name,string password)
        {
            foreach (var item in UserList)
            {
                if (item.Name == name)
                    if (item.Password == password)
                        return true;
                continue;
            }
            return false;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Register(string name, string password)
        {
            foreach (var item in UserList)
            {
                if (item.Name == name)
                    return false;
            }

            UserList.Add(new User(name, password, null));
            return true;
        }

        /// <summary>
        /// 从文件中读取用户信息
        /// </summary>
        public void Init(string path)
        {
            List<User> temp = fileHelper.Load<User>(path);
            if (temp != null)
                UserList = temp;
            else
                UserList = new List<User>();
        }

        /// <summary>
        /// 将用户信息保存入文件
        /// </summary>
        /// <returns></returns>
        public bool Save(string path)
        {
            if (fileHelper.Save(UserList, path))
                return true;
            return false;
        }
    }
}
