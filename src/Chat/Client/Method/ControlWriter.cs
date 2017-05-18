using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Method
{
    /// <summary>
    /// 用于更新窗口控件
    /// </summary>
    public class ControlWriter
    {
        protected SynchronizationContext syncContext;

        public delegate void Write(object control, string msg);
        public event Write writer;

        private static ControlWriter write;

        private ControlWriter()
        {
            syncContext = SynchronizationContext.Current;
        }

        public static ControlWriter GetInstance()
        {
            if (write == null)
            {
                write = new ControlWriter();
            }
            return write;
        }

        public void SetMsg(string msg)
        {
            syncContext.Post(UpdateTextbox, msg);
        }

        public void SetUserList(string[] userList)
        {
            string temp = string.Empty;
            foreach (var item in userList)
            {
                temp += (item + "\r\n");
            }
            syncContext.Post(UpdateTextbox, temp);
        }

        private void UpdateTextbox(object msg)
        {
            object control = new TextBox();
            writer(control, msg as string);
        }

        private void UpdateListbox(object msg)
        {
            object control = new ListBox();
            writer(control, msg as string);
        }
    }
}
