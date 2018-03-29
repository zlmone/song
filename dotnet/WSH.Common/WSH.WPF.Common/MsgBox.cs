using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WSH.WPF.Common
{
    public class MsgBox
    {
        public static string DefaultTitle = "信息提示";
        public static void Alert(string msg)
        {
            MessageBox.Show(msg, DefaultTitle, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, DefaultTitle, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
        }
        /// <summary>
        /// YesNoCancel询问框
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageBoxResult Question(string msg) {
            return MessageBox.Show(msg, DefaultTitle, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }
    }
}
