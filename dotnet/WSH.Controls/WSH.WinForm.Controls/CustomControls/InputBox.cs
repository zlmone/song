using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WSH.Common.Helper;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.WinForm.Controls
{
    public partial class InputBox : TextBox
    {
        public InputBox()
        {
            InitializeComponent();
            this.Validating += new CancelEventHandler(InputBox_Validating);
        }
        private RegexType regexType = RegexType.None;
        /// <summary>
        /// 正则表达式类型
        /// </summary>
        public virtual RegexType RegexType
        {
            get { return regexType; }
            set { regexType = value; }
        }
        private string customMessage;
        /// <summary>
        /// 正则表达式错误提示
        /// </summary>
        public string RegexMessage
        {
            get { return customMessage; }
            set { customMessage = value; }
        }
        private bool required;
        /// <summary>
        /// 是否非空验证
        /// </summary>
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }
        private string requiredMessage = "此项必填";

        public string RequiredMessage
        {
            get { return requiredMessage; }
            set { requiredMessage = value; }
        }
        private ErrorProvider txtErrorProvider = new ErrorProvider();
        private bool isvalid=true;
        public bool IsValid
        {
            get { return isvalid; }
            protected set { isvalid = value; }
        }
        /// <summary>
        /// 文本框验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InputBox_Validating(object sender, CancelEventArgs e)
        {
            if (Required)
            {
                if (string.IsNullOrEmpty(this.Text.Trim()))
                {
                    txtErrorProvider.SetError(this, RequiredMessage);
                    IsValid = false;
                    return;
                }
            }
            if (RegexType != WSH.Common.RegexType.None)
            {
                RegexItem item = RegexHelper.GetRegexItem(RegexType);
                if (!RegexHelper.Test(this.Text, item.RegexString))
                {
                    txtErrorProvider.SetError(this, string.IsNullOrEmpty(this.RegexMessage) ? item.RegexMessage : RegexMessage);
                    IsValid = false;
                    return;
                }
            }
            IsValid = true;
            txtErrorProvider.Clear();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Form controlForm = null;
            //当用户按下Enter键或者是向下的方向键时，将控件的焦点移走
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Down:
                    {
                        controlForm = this.FindForm();
                        if (controlForm != null)
                        {
                            controlForm.SelectNextControl(this, true, false, true, true);
                        }
                        break;
                    }
                case Keys.Up: // 用户按下向上方向键时，将控件的焦点移到上一个控件。
                    {
                        controlForm = this.FindForm();
                        if (controlForm != null)
                        {
                            controlForm.SelectNextControl(this, false, false, true, true);
                        }
                        break;
                    }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
