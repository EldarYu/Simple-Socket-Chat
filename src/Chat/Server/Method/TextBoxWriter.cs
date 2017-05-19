using System.Windows.Forms;

namespace Server.Method
{
    /// <summary>
    /// 将TextBox变为Console
    /// </summary>
    public class TextBoxWriter:Core.Function.ConsoleHelper
    {
        public TextBoxWriter(TextBox textBox) : base(textBox) { }
    }
}
