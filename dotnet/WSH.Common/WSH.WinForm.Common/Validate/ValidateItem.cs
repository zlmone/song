using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WSH.Options.Common;

namespace WSH.WinForm.Common
{
    
    public class ValidateItem : BaseValidateItem
    {
        private ErrorProvider error = new ErrorProvider();
        protected Control control = null;
        protected string property = "Text";
        public event CustomValidateHanlder OnCustomValidate;
         
        public override string Value
        {
            get
            {
                return this.control.GetType().GetProperty(this.property).GetValue(this.control, null).ToString().Trim();
            }
            set
            {
                base.Value = value;
            }
        }
        public ValidateItem(Control control, string property)
        {
            this.control = control;
            this.property = property;
            control.Leave += new EventHandler(control_Leave);
        }
        public ValidateItem(Control control)
        {
            this.control = control;
            control.Leave += new EventHandler(control_Leave);
        }
        void control_Leave(object sender, EventArgs e)
        {
            this.Check();
        }
        public override void ClearError() {
            this.error.Clear();
        }
        /// <summary>
        /// 验证方法
        /// </summary>
        /// <returns>是否通过验证</returns>
        public override bool Check()
        {
            bool re = false;
            string value = this.Value;
            if (value.Equals(""))
            {
                if (this.Required)
                {
                    this.error.SetError(this.control, this.RequiredMsg);
                    return false;
                }
                this.error.Clear();
                return true;
            }
            if ((value.Length >= this.MinLength) && (value.Length <= this.MaxLength))
            {
                this.error.Clear();
                re = true;
            }
            else
            {
                if (value.Trim().Length < this.MinLength)
                {
                    this.error.SetError(this.control, this.MinLengthMsg);
                    return false;
                }
                if (value.Trim().Length > this.MaxLength)
                {
                    this.error.SetError(this.control, this.MaxLengthMsg);
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(Regex))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, this.Regex))
                {
                    this.error.SetError(this.control, this.RegexMsg);
                    return false;
                }
                this.error.Clear();
                re = true;
            }
            if (OnCustomValidate != null)
            {
                ValidResult result = new ValidResult();
                result.Value = this.Value;
                OnCustomValidate(this, result);
                if (!result.IsSuccess)
                {
                    this.error.SetError(this.control, string.IsNullOrEmpty(result.Msg) ? "输入不正确" : result.Msg);
                    return false;
                }
                this.error.Clear();
                re = true;
            }
            return re;
        }
    }
}