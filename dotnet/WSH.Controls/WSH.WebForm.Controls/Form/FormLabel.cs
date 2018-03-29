using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using System.Web.UI.HtmlControls;

namespace WSH.WebForm.Controls
{
    [ParseChildren(true,"Text")]
    [ToolboxData("<{0}:FormLabel runat=server/>")]
    public class FormLabel : Control
    {
        #region 接口属性
        private string text;
        /// <summary>
        /// 表单元素显示的文本
        /// </summary>
        [Description("表单元素显示的文本")]
        [PersistenceMode( PersistenceMode.InnerDefaultProperty)]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        //private bool fullColumn;
        ///// <summary>
        ///// 表单元素是否填充剩余列
        ///// </summary>
        //[Description("表单元素是否填充剩余列")]
        //public bool FullColumn
        //{
        //    get { return fullColumn; }
        //    set { fullColumn = value; }
        //}
        //private int columnSpan;
        ///// <summary>
        ///// 表单元素横跨的列数
        ///// </summary>
        //[Description("表单元素横跨的列数")]
        //public int ColumnSpan
        //{
        //    get { return columnSpan; }
        //    set { columnSpan = value; }
        //}
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
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Controls.Clear();
            //添加lable
            HtmlGenericControl lable = new HtmlGenericControl("div");
            lable.Attributes.Add("class", "form-label");
            if (Required)
            {
                HtmlGenericControl notnull = new HtmlGenericControl("span");
                notnull.InnerHtml = "*";
                notnull.Attributes.Add("class", "form-required");
                lable.Controls.Add(notnull);
            }
            HtmlGenericControl text = new HtmlGenericControl("span");
            text.InnerHtml = Text + ":";
            lable.Controls.Add(text);
            this.Controls.Add(lable);
            this.ChildControlsCreated = true;
        }
        #endregion
    }
}