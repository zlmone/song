using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace WSH.WinForm.Common
{
    public class DataBind
    {
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        public static void BindCombox(ComboBox combox, object data, string display, string value)
        {
            combox.DisplayMember = display;
            combox.ValueMember = value;
            combox.DataSource = data;
        }
        public static void BindCombox(ComboBox combox, object data, string field)
        {
            BindCombox(combox, data, field,field);
        }
    }
}
