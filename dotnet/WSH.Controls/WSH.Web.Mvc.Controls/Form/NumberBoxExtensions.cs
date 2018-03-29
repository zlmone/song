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
    public static class NumberBoxExtensions
    {
        public static MvcHtmlString NumberBox(this HtmlHelper helper, string name)
        {
            return NumberBox(helper, name, null, null, null);
        }
        public static MvcHtmlString NumberBox(this HtmlHelper helper, string name, object value)
        {
            return NumberBox(helper, name, value, null, null);
        }
        public static MvcHtmlString NumberBox(this HtmlHelper helper, string name, object value, NumberOptions options)
        {
            return NumberBox(helper, name, value, options, null);
        }
        public static MvcHtmlString NumberBox(
            this HtmlHelper helper,
            string name,
            object value,
            NumberOptions options,
            object htmlAttributes
        )
        {
           // IDictionary<string, object> attrs = SetAttributes(options, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            StringBuilder sb = new StringBuilder();
            sb.Append(helper.TextBox(name,value,htmlAttributes).ToString());
            sb.AppendLine(GetNumberBoxScript(options, name));
            return MvcHtmlString.Create(sb.ToString());
        }
        //强类型
        public static MvcHtmlString NumberBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression
        )
        {
            return NumberBoxFor(helper, expression, null, null);
        }
        public static MvcHtmlString NumberBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            NumberOptions options
        )
        {
            return NumberBoxFor(helper, expression, options, null);
        }
        public static MvcHtmlString NumberBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            NumberOptions options,
            object htmlAttributes
        )
        {

           // IDictionary<string, object> attrs = SetAttributes(options, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            string name= helper.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            StringBuilder sb = new StringBuilder();
            sb.Append(helper.TextBoxFor(expression, htmlAttributes).ToString());
            sb.AppendLine(GetNumberBoxScript(options, name));
            return MvcHtmlString.Create(sb.ToString());
        }
        /// <summary>
        /// 获取数字框的客户端的脚本参数配置
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string GetNumberBoxScript(NumberOptions options, string id)
        {
            if (options == null)
            {
                options = new NumberOptions();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.Append(WebConsts.ScriptBegin);
            sb.Append("new song.numberbox('#" + id + "',{");
            sb.AppendFormat("allowDecimal:{0},allowNegative:{1}", options.AllowDecimal.ToString().ToLower(), options.AllowNegative.ToString().ToLower());
            sb.Append(",maxValue:" + options.MaxValue);
            sb.Append(",minValue:" + options.MinValue);
            if (options.Precision.HasValue)
            {
                sb.Append(",precision:" + options.Precision.Value);
            }
            if (!string.IsNullOrEmpty(options.OnEnter))
            {
                sb.Append(",onEnter:" + options.OnEnter);
            }
            sb.Append("});");
            sb.Append(WebConsts.ScriptEnd);
            return sb.ToString();
        }
    }
    /// <summary>
    /// 数字框的属性配置
    /// </summary>
    public class NumberOptions
    {
        private bool allowDecimal=true;
        private bool allowNegative=true;
        private long maxValue=long.MaxValue;
        private long minValue=long.MinValue;
        private int? precision;


        public bool AllowDecimal
        {
            get { return allowDecimal; }
            set { allowDecimal = value; }
        }

        public bool AllowNegative
        {
            get { return allowNegative; }
            set { allowNegative = value; }
        }

        public long MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public long MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public int? Precision
        {
            get { return precision; }
            set { precision = value; }
        }
        private string onEnter;

        public string OnEnter
        {
            get { return onEnter; }
            set { onEnter = value; }
        }
    }
}
