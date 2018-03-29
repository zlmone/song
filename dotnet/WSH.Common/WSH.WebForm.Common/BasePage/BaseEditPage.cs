using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Common
{
    public class BaseEditPage : BasePage
    {
        #region
        /// <summary>
        /// 清空页面控件的值
        /// </summary>
        public void ClearForm()
        {
            Script.WriteScript(this,"ClearForm", string.Format("$(\"#{0}\").clearForm();", this.Form.ClientID));
        }
        /// <summary>
        /// 设置页面控件为只读
        /// </summary>
        public void EnabledForm()
        {
            Script.WriteScript(this,"EnabledForm", string.Format("$(\"#{0}\").disabledForm();", this.Form.ClientID));
        }
        public bool IsEdit
        {
            get { return GetAction() == "edit"; }
        }
        public bool IsAdd
        {
            get { string a = GetAction(); return (a == null || a == "add"); }
        }
        public bool IsView
        {
            get { return GetAction() == "view"; }
        }
        private string GetAction()
        {
            string action = Request.Params["action"];
            return string.IsNullOrEmpty(action) ? null : action.ToLower();
        }
        #endregion
    }
}
