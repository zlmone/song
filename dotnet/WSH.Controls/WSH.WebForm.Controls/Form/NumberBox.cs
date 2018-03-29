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

namespace WSH.WebForm.Controls
{
    [ToolboxData("<{0}:NumberBox runat=server></{0}:NumberBox>")]
    public class NumberBox : TextBox
    {
        #region 文本框属性
        private bool allowDecimal;
        /// <summary>
        /// 是否允许小数
        /// </summary>
        [Description("是否允许小数")]
        public bool AllowDecimal
        {
            get { return allowDecimal; }
            set { allowDecimal = value; }
        }
        private bool allowNegative;
        /// <summary>
        /// 是否允许负数
        /// </summary>
        [Description("是否允许负数")]
        public bool AllowNegative
        {
            get { return allowNegative; }
            set { allowNegative = value; }
        }
        private long maxValue;

        public long MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        private long minValue;

        public long MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        private int precision;
        /// <summary>
        /// 小数位
        /// </summary>
        [Description("小数位")]
        public int Precision
        {
            get { return precision; }
            set { precision = value; }
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
            base.Render(writer);
        }
    }
}