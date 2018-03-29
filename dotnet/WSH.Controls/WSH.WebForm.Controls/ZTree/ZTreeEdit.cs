using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Controls
{
    public class ZTreeEdit
    {
        private bool _Enable = false;
        /// <summary>
        /// 是否开启编辑功能
        /// </summary>
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
        private string _RemoveTitle = "删除";
        /// <summary>
        /// 删除按钮的提示文字（默认：删除）
        /// </summary>
        public string RemoveTitle
        {
            get { return _RemoveTitle; }
            set { _RemoveTitle = value; }
        }
        private string _RenameTitle = "重命名";
        /// <summary>
        /// 重命名按钮的提示文字（默认：重命名）
        /// </summary>
        public string RenameTitle
        {
            get { return _RenameTitle; }
            set { _RenameTitle = value; }
        }
        private bool _ShowRemoveBtn = true;
        /// <summary>
        /// 是否显示删除按钮，如果显示请编写相关的回调函数修改服务器数据（默认：显示）
        /// </summary>
        public bool ShowRemoveBtn
        {
            get { return _ShowRemoveBtn; }
            set { _ShowRemoveBtn = value; }
        }
        private bool _ShowRenameBtn = true;
        /// <summary>
        /// 是否显示重命名按钮，如果显示请编写相关的回调函数修改服务器数据（默认：显示）
        /// </summary>
        public bool ShowRenameBtn
        {
            get { return _ShowRenameBtn; }
            set { _ShowRenameBtn = value; }
        }
    }
}
