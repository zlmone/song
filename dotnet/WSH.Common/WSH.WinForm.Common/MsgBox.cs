using System;
using System.Text;
using System.Windows.Forms;

namespace WSH.WinForm.Common
{
    public class MsgBox
    {
        public static string DefaultTitle = "信息提示";
        public static void Alert(string msg)
        {
            MessageBox.Show(msg, DefaultTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Tip(string msg) {
            Alert(msg);
        }
        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, DefaultTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }
        /// <summary>
        /// YesNoCancel询问框
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Question(string msg)
        {
            return MessageBox.Show(msg, DefaultTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
         
    }
   
}
