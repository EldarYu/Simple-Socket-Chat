using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server.Method
{
    /// <summary>
    /// 用于更新窗口控件
    /// </summary>
    public class ControlWriter 
    {
        protected SynchronizationContext syncContext;

        public delegate void Write(string msg);
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
            syncContext.Post(Update, msg);
        }

        private void Update(object msg)
        {
            writer(msg as string);
        }
    }
}
