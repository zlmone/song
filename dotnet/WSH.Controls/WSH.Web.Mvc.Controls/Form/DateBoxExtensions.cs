using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WSH.Web.Mvc.Common;
using WSH.Web.Common;
using WSH.Web.Common.Helper;

namespace WSH.Web.Mvc.Controls
{
    public static class DateBoxExtensions
    {
        public static MvcHtmlString DateBox(this HtmlHelper helper, string name)
        {
            return DateBox(helper, name, null, null, null);
        }
        public static MvcHtmlString DateBox(this HtmlHelper helper, string name, string value)
        {
            return DateBox(helper, name, value, null, null);
        }
        public static MvcHtmlString DateBox(this HtmlHelper helper, string name, string value, DateOptions options)
        {
            return DateBox(helper, name, value, options, null);
        }
        public static MvcHtmlString DateBox(
            this HtmlHelper helper,
            string name,
            string value,
            DateOptions options,
            object htmlAttributes
        )
        {
            IDictionary<string, object> attrs = SetAttributes(options, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return helper.TextBox(name, value, attrs);
        }
        //强类型
        public static MvcHtmlString DateBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression
        )
        {
            return DateBoxFor(helper, expression, null, null);
        }
        public static MvcHtmlString DateBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            DateOptions options
        )
        {
            return DateBoxFor(helper, expression, options, null);
        }
        public static MvcHtmlString DateBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            DateOptions options,
            object htmlAttributes
        )
        {
            IDictionary<string, object> attrs = SetAttributes(options, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return helper.TextBoxFor(expression, attrs);
        }
        /// <summary>
        /// 获取日期框的客户端的参数配置
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private static string GetDateBoxOptions(DateOptions options)
        {
            if (options == null)
            {
                options = new DateOptions();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.AppendFormat("el:this,dateFmt:'{0}'", options.DateFmt);
            if (options.DoubleCalendar)
            {
                sb.Append(",doubleCalendar:true");
            }
            if (!string.IsNullOrEmpty(options.MinDate) || !string.IsNullOrEmpty(options.MinDateClientID))
            {
                if (!string.IsNullOrEmpty(options.MinDateClientID))
                {
                    sb.Append(",minDate:'#F{$dp.$D(\\'" + options.MinDateClientID + "\\');}'");
                }
                else
                {
                    sb.AppendFormat(",minDate:'{0}'", options.MinDate);
                }
            }
            if (!string.IsNullOrEmpty(options.MaxDate) || !string.IsNullOrEmpty(options.MaxDateClientID))
            {
                if (!string.IsNullOrEmpty(options.MaxDateClientID))
                {
                    sb.Append(",maxDate:'#F{$dp.$D(\\'" + options.MaxDateClientID + "\\');}'");
                }
                else
                {
                    sb.AppendFormat(",maxDate:'{0}'", options.MaxDate);
                }
            }
            if (!string.IsNullOrEmpty(options.StartDate))
            {
                sb.AppendFormat(",startDate:'{0}'", options.StartDate);
            }
            if (options.IsShowWeek)
            {
                sb.Append(",isShowWeek:true");
            }
            if (!options.IsShowClear)
            {
                sb.Append(",isShowClear:true");
            }
            if (options.DisabledDates != null && options.DisabledDates.Length > 0)
            {
                sb.Append(",disabledDates:[");
                for (int i = 0; i < options.DisabledDates.Length; i++)
                {
                    sb.AppendFormat("'{0}'", options.DisabledDates[i]);
                    if (i < options.DisabledDates.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
            }
            sb.Append("}");
            return sb.ToString();
        }
        private static IDictionary<string, object> SetAttributes(DateOptions options, IDictionary<string, object> attrs)
        {
            if (attrs == null)
            {
                attrs = new Dictionary<string, object>();
            }
            attrs.Add("onfocus", "WdatePicker(" + GetDateBoxOptions(options) + ");");
            attrs.Add("autoComplete", "off");
            ClientHelper.AddAttr(attrs, "class", "Wdate");
            return attrs;
        }
    }
    /// <summary>
    /// 日期框的属性配置
    /// </summary>
    public class DateOptions
    {
        private string dateFmt = "yyyy-MM-dd";
        /// <summary>
        /// 格式化字符串(默认：yyyy-MM-dd)
        /// </summary>
        public string DateFmt
        {
            get { return dateFmt; }
            set { dateFmt = value; }
        }
        private bool doubleCalendar = false;
        /// <summary>
        /// 是否显示双月份模式
        /// </summary>
        public bool DoubleCalendar
        {
            get { return doubleCalendar; }
            set { doubleCalendar = value; }
        }
        private string minDate;
        /// <summary>
        /// 最小日期
        /// </summary>

        public string MinDate
        {
            get { return minDate; }
            set { minDate = value; }
        }
        private string maxDate;
        /// <summary>
        /// 最大日期
        /// </summary>

        public string MaxDate
        {
            get { return maxDate; }
            set { maxDate = value; }
        }
        private string startDate;
        /// <summary>
        /// 点击日期框时显示的起始日期
        /// </summary>

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private bool isShowWeek = false;
        /// <summary>
        /// 是否显示周
        /// </summary>

        public bool IsShowWeek
        {
            get { return isShowWeek; }
            set { isShowWeek = value; }
        }
        private bool isShowClear = true;
        /// <summary>
        /// 是否显示清空按钮
        /// </summary>
        public bool IsShowClear
        {
            get { return isShowClear; }
            set { isShowClear = value; }
        }
        private string[] disabledDates;

        public string[] DisabledDates
        {

            get { return disabledDates; }
            set { disabledDates = value; }
        }
        private string minDateClientID;
        /// <summary>
        /// 根据客户端控件的id来设置最小日期
        /// </summary>
        public string MinDateClientID
        {
            get { return minDateClientID; }
            set { minDateClientID = value; }
        }
        private string maxDateClientID;
        /// <summary>
        /// 根据客户端控件的id来设置最小日期
        /// </summary>
        public string MaxDateClientID
        {
            get { return maxDateClientID; }
            set { maxDateClientID = value; }
        }

    }
}
