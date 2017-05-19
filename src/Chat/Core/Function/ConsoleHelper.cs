using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Core.Function
{
    /// <summary>
    /// 重写TextWriter,将TextBox变为Console
    /// </summary>
    public class ConsoleHelper: System.IO.TextWriter
    {
        private TextBox _textBox { set; get; }

        public ConsoleHelper(TextBox textBox)
        {
            this._textBox = textBox;
            Console.SetOut(this);
        }

        public override void Write(string value)
        {
            if (_textBox.IsHandleCreated)
                _textBox.BeginInvoke(new ThreadStart(() => _textBox.AppendText(value + " ")));
        }

        public override void WriteLine(string value)
        {
            if (_textBox.IsHandleCreated)
                _textBox.BeginInvoke(new ThreadStart(() => _textBox.AppendText(value + "\r\n")));
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
