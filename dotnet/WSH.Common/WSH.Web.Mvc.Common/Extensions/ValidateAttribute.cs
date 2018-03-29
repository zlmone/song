using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WSH.Web.Mvc.Common
{
    /// <summary>
    /// MVC中对时间的验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DateAttribute : ValidationAttribute
    {
        public DateAttribute()
        {
            //set default max and min time according to sqlserver datetime type
            MinDate = new DateTime(1753, 1, 1).ToString();
            MaxDate = new DateTime(9999, 12, 31).ToString();
        }

        /// <summary>
        /// 最小时间
        /// </summary>
        public string MinDate
        {
            get;
            set;
        }

        /// <summary>
        /// 最大时间
        /// </summary>
        public string MaxDate
        {
            get;
            set;
        }

        private DateTime minDate, maxDate;
        //indicate if the format of the input is really a datetime
        private bool isFormatError = true;

        public override bool IsValid(object value)
        {
            //ignore it if no value
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;
            //begin check
            string s = value.ToString();
            minDate = DateTime.Parse(MinDate);
            maxDate = DateTime.Parse(MaxDate);
            bool result = true;
            try
            {
                DateTime date = DateTime.Parse(s);
                isFormatError = false;
                if (date > maxDate || date < minDate)
                    result = false;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            if (isFormatError)
                return "请输入合法的日期";
            return base.FormatErrorMessage(name);
        }
    }
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SpecialAttribute : RegularExpressionAttribute
    {
        public SpecialAttribute()
            : base("[^\\^\\|&@;；$%\"'\\<>()+-,?!#&*~]+")
        {
            ErrorMessage = "输入内容有特殊字符";
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class UIntAttribute : RegularExpressionAttribute
    {
        public UIntAttribute()
            : base(@"^[0-9]+$")
        {
            ErrorMessage = "只能为数字";
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AlphaAttribute : RegularExpressionAttribute
    {
        public AlphaAttribute()
            : base(@"^[A-Za-z0-9]+$")
        {
            ErrorMessage = "只能是字母和数字";
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class UrlAttribute : RegularExpressionAttribute
    {
        public UrlAttribute()
            : base(@"^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?(([0-9]{1,3}\.){3}[0-9]{1,3}|([0-9a-z_!~*'()-]+\.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\.[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$")
        {
            ErrorMessage = "URL地址格式不正确";
        }
    }
}
