using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Controls.EasyUI
{
    public enum EasyEditorType
    {
        Text,
        TextArea,
        CheckBox,
        NumberBox,
        ValidateBox,
        DateBox,
        ComboBox,
        ComboTree
    }
    public class EasyEditorColumn
    {
        public EasyEditorColumn()
        {
            Type = EasyEditorType.Text;
        }
        /// <summary>
        /// 编辑类型
        /// </summary>
        public virtual EasyEditorType Type { get; set; }

    }
}
