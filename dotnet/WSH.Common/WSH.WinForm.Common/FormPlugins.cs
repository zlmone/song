using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WSH.WinForm.Common
{
    public class FormPlugins
    {
        /// <summary>
        /// 获取插件窗体
        /// </summary>
        /// <returns></returns>
        public static Form GetForm(string assemblyName, string formName)
        {
            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(formName))
            {
                return null;
            }
            Assembly asm = Assembly.Load(assemblyName);//程序集名
            return (Form)asm.CreateInstance(assemblyName + "." + formName);//程序集+form的类名。
        }
        /// <summary>
        /// 弹出插件窗体
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="formName"></param>
        public static void ShowDialog(string assemblyName, string formName)
        {
            Form frm = GetForm(assemblyName, formName);
            if (frm != null)
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}
