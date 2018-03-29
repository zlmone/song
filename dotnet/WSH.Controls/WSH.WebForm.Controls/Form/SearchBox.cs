using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using WSH.Web.Common;
using WSH.WebForm.Common;

namespace WSH.WebForm.Controls
{
   public class SearchBox : TextBox,IFormControl
    {
        #region 表单属性
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
                Css.AddClass(this, "textbox");
                #region 添加表单控件属性
                if (IsFormControl)
                {
                    Css.AddClass(this, "form-control");
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
                    writer.AddAttribute("required", "true");
                }
                #endregion
                base.AddAttributesToRender(writer);
            }
        }
        #endregion
    }
}
