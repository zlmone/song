using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using WSH.WebForm.Common;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.WebForm.Controls
{
    [ToolboxData("<{0}:InputBox runat=server></{0}:InputBox>")]
    public class InputBox : TextBox, IFormControl
    {
        #region 文本框属性
        private InputType dataType = InputType.None;
        /// <summary>
        /// 输入的数据类型
        /// </summary>
        [Description("输入的数据类型")]
        public InputType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        private string regexType;
        /// <summary>
        /// 验证类型
        /// </summary>
        [Description("验证类型")]
        public string RegexType
        {
            get { return regexType; }
            set { regexType = value; }
        }
        #endregion

        #region 表单属性
        public override string ClientID
        {
            get
            {
                return this.ID;
            }
        }
        private bool isFormControl = true;
        /// <summary>
        /// 是否参与表单布局
        /// </summary>
        [Description("是否参与表单布局")]
        public bool IsFormControl
        {
            get { return isFormControl; }
            set { isFormControl = value; }
        }
        private bool fullColumn;
        /// <summary>
        /// 表单元素是否填充剩余列
        /// </summary>
        [Description("表单元素是否填充剩余列")]
        public bool FullColumn
        {
            get { return fullColumn; }
            set { fullColumn = value; }
        }
        private int columnSpan;
        /// <summary>
        /// 表单元素横跨的列数
        /// </summary>
        [Description("表单元素横跨的列数")]
        public int ColumnSpan
        {
            get { return columnSpan; }
            set { columnSpan = value; }
        }
        private bool required;
        /// <summary>
        /// 表单元素是否为必填项
        /// </summary>
        [Description("表单元素是否为必填项")]
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }
        #endregion

        #region 添加客户端属性
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                if (this.TextMode == TextBoxMode.MultiLine)
                {
                    Css.AddClass(this, "textarea");
                }
                else
                {
                    Css.AddClass(this, "textbox");
                }
                #region 添加表单控件属性
                if (IsFormControl)
                {
                    //Css.AddClass(this, "form-control");
                    if (FullColumn)
                    {
                        writer.AddAttribute("fullColumn", "true");
                    }
                    if (ColumnSpan > 1)
                    {
                        writer.AddAttribute("columnSpan", ColumnSpan.ToString());
                    }
                }
                if (Required)
                {
                    writer.AddAttribute("data-required", "true");
                }
                #endregion
                base.AddAttributesToRender(writer);
            }
        }
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            if (DataType != InputType.None)
            {
                writer.AddAttribute("data-dataType",  StringHelper.Capitalize(DataType.ToString(), CaseType.Lower));
            }
            if (!string.IsNullOrEmpty(RegexType))
            {
                writer.AddAttribute("data-regexType", RegexType);
            }
            base.Render(writer);
        }
    }
    public enum InputType
    {
        None,
        Email,
        En,
        Cn,
        Url,
        IP,
        Zip,
        Alpha,
        Tel,
        Mobile,
        Int,
        Float,
        IdCard,
        CarNo,
        qq,
        Msn
    }
}