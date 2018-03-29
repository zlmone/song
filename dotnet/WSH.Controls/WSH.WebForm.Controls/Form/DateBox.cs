using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using WSH.Common;
using WSH.WebForm.Common;
using WSH.Common.Helper;

namespace WSH.WebForm.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:DateBox runat=server></{0}:DateBox>")]
    public class DateBox : TextBox,IFormControl
    {
        #region 日期属性
        public enum SkinType {
            Default, WhyGreen
        }
        private string dateFmt;
        /// <summary>
        /// 日期格式化字符串
        /// </summary>
        [Description("日期格式化字符串")]
        public string DateFmt
        {
            get { if (string.IsNullOrEmpty(dateFmt)) { dateFmt = FormatHelper.Date; }; return dateFmt; }
            set { dateFmt = value; }
        }
        private bool doubleCalendar=false;
        /// <summary>
        /// 是否是显示双月份模式
        /// </summary>
        [Description("是否是显示双月份模式")]
        public bool DoubleCalendar
        {
            get { return doubleCalendar; }
            set { doubleCalendar = value; }
        }
        private bool enableInputMask = true;
        /// <summary>
        /// 文本框输入启用掩码开关
        /// </summary>
        [Description("文本框输入启用掩码开关")]
        public bool EnableInputMask
        {
            get { return enableInputMask; }
            set { enableInputMask = value; }
        }
        private WeekType weekMethod = WeekType.ISO8601;
        /// <summary>
        /// <para>周算法不同的地方有一些差异,常见算法有两种</para>
        /// <para>1. ISO8601:规定第一个星期四为第一周,默认值</para>
        /// <para>2. MSExcel:1月1日所在的周</para>
        /// </summary>
        [Description("周算法不同的地方有一些差异,常见算法有两种,1. ISO8601:规定第一个星期四为第一周,默认值,2. MSExcel:1月1日所在的周")]
        public WeekType WeekMethod
        {
            get { return weekMethod; }
            set { weekMethod = value; }
        }
        private SkinType skin = SkinType.Default;
        /// <summary>
        /// 皮肤名称
        /// </summary>
        [Description("皮肤名称")]
        public SkinType Skin
        {
            get { return skin; }
            set { skin = value; }
        }
        private string minDate;
        /// <summary>
        /// 最小日期
        /// </summary>
        [Description("最小日期")]
        public string MinDate
        {
            get { return minDate; }
            set { minDate = value; }
        }
        private string maxDate;
        /// <summary>
        /// 最大日期
        /// </summary>
        [Description("最大日期")]
        public string MaxDate
        {
            get { return maxDate; }
            set { maxDate = value; }
        }
        private string startDate;
        /// <summary>
        /// 点击日期框时显示的起始日期
        /// </summary>
        [Description("点击日期框时显示的起始日期")]
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private bool isShowWeek = false;
        /// <summary>
        /// 是否显示周
        /// </summary>
        [Description("是否显示周")]
        public bool IsShowWeek
        {
            get { return isShowWeek; }
            set { isShowWeek = value; }
        }
        private bool isShowClear = true;
        /// <summary>
        /// 是否显示清空按钮
        /// </summary>
        [Description("是否显示清空按钮")]
        public bool IsShowClear
        {
            get { return isShowClear; }
            set { isShowClear = value; }
        }
        private string[] disabledDates;
        [Description("禁用所指定的一个或多个日期")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] DisabledDates
        {
            
            get { return disabledDates; }
            set { disabledDates = value; }
        }
        private string minDateControl;
        [Description("最小日期以哪个日期框为准")]
        [TypeConverter(typeof(ControlIDConverter))]
        public string MinDateControl
        {
            get { return minDateControl; }
            set { minDateControl = value; }
        }
        private string valueControl;
        [Description("保存计算机可识别的值的控件ID")]
        [TypeConverter(typeof(ControlIDConverter))]
        public string ValueControl
        {
            get { return valueControl; }
            set { valueControl = value; }
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
        private bool isFormControl=true;
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

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
           // Script.AddScript(this.Page,"DatePickerJs",ClientResourceUrl.DatePickerJs);
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
           
            if (!this.DesignMode)
            {
                Css.AddClass(this, "textbox");
                if (Required)
                {
                    writer.AddAttribute("data-required", "true");
                }
                base.AddAttributesToRender(writer);
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.AppendFormat("el:this,dateFmt:'{0}'", DateFmt);
                if(!string.IsNullOrEmpty(ValueControl)){
                    string clientID = Page.FindControl(ValueControl).ClientID;
                    sb.AppendFormat(",vel:'{0}'",clientID);
                }
                if (DoubleCalendar)
                {
                    sb.Append(",doubleCalendar:true");
                }
                if (!EnableInputMask)
                {
                    sb.Append(",enableInputMask:false");
                }
                if (WeekMethod != WeekType.ISO8601)
                {
                    sb.Append(",weekMethod:'MSExcel'");
                }
                if (Skin != SkinType.Default)
                {
                    sb.Append(",skin:'whyGreen'");
                }
                if (!string.IsNullOrEmpty(MinDate) || !string.IsNullOrEmpty(MinDateControl))
                {
                    if (!string.IsNullOrEmpty(MinDateControl))
                    {
                        string clientID = Page.FindControl(MinDateControl).ClientID;
                        sb.Append(",minDate:'#F{$dp.$D(\\'" + clientID + "\\');}'");
                    }
                    else
                    {
                        sb.AppendFormat(",minDate:'{0}'", MinDate);
                    }
                }
                if (!string.IsNullOrEmpty(MaxDate))
                {
                    sb.AppendFormat(",maxDate:'{0}'", MaxDate);
                }
                if (!string.IsNullOrEmpty(StartDate))
                {
                    sb.AppendFormat(",startDate:'{0}'", StartDate);
                }
                if (IsShowWeek)
                {
                    sb.Append(",isShowWeek:true");
                }
                if (!IsShowClear)
                {
                    sb.Append(",isShowClear:true");
                }
                if (DisabledDates != null && DisabledDates.Length > 0)
                {
                    sb.Append(",disabledDates:[");
                    for (int i = 0; i < DisabledDates.Length; i++)
                    {
                        sb.AppendFormat("'{0}'", DisabledDates[i]);
                        if (i < DisabledDates.Length - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                }
                sb.Append("}");
                writer.AddAttribute("onfocus", "WdatePicker(" + sb.ToString() + ");");
                writer.AddAttribute("autoComplete","off");
            }
        }
    }
    public enum WeekType{
        ISO8601,MSExcel
    }
}
