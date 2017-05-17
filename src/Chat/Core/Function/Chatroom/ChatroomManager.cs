using System.Collections.Generic;

namespace Core.Function.Chatroom
{
    /// <summary>
    /// 聊天室列表
    /// </summary>
    public class ChatroomManager
    {
        private List<Chatroom> chatroomList;
        private FileHelper fileHelper;

        /// <summary>
        /// 聊天室列表
        /// </summary>
        public List<Chatroom> ChatroomList
        {
            set
            {
                chatroomList = value;
            }
            get
            {
                return chatroomList;
            }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="path"></param>
        public ChatroomManager(string path)
        {
            fileHelper = new FileHelper();
            Init(path);
        }

        /// <summary>
        /// 新增聊天室
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddChatroom(string name)
        {
            foreach (var item in ChatroomList)
            {
                if (item.Name == name)
                    return false;
            }

            ChatroomList.Add(new Chatroom(name));
            return true;
        }

        /// <summary>
        /// 删除聊天室
        /// </summary>
        /// <param name="name"></param>
        public void RemoveChatroom(string name)
        {
            foreach (var item in ChatroomList)
            {
                if (item.Name == name)
                {
                    ChatroomList.Remove(item);
                    break;
                }
            }
        }

        /// <summary>
        /// 从文件中读取聊天室信息
        /// </summary>
        /// <param name="path"></param>
        public void Init(string path)
        {
            List<Chatroom> temp = fileHelper.Load<Chatroom>(path);
            if (temp != null)
                ChatroomList = temp;
            else
                ChatroomList = new List<Chatroom>();
        }

        /// <summary>
        /// 保存聊天室信息到文件中
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Save(string path)
        {
            if (fileHelper.Save<Chatroom>(ChatroomList, path))
                return true;
            return false;
        }
    }
}
