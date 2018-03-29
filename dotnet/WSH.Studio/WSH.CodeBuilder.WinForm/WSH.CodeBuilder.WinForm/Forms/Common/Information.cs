using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WSH.CodeBuilder.WinForm.Common
{
    public partial class Information : DockContent
    {
        public Information()
        {
            InitializeComponent();
        }
        public static StringBuilder sb = new StringBuilder();
        private static int Number = 0;
        public static void Add(string msg)
        {
            sb.AppendLine(GetNumber()+msg);
        }
        private static string GetNumber() {
            Number++;
            return Number + "：";
        }
        public static void AddFmt(string msg,params object[] obj) {
            sb.AppendLine(GetNumber() + string.Format(msg, obj));
        }
        public void SetContent() {
            this.txtContent.Text = sb.ToString();
        }
        public static void Clear() {
            Number = 0;
            if (sb.Length > 0)
            {
                sb.Remove(0, sb.Length);
            }
        }
    }
}
