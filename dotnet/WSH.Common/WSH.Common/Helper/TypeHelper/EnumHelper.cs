using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WSH.Common.Helper
{
    public class EnumHelper
    {
        /// <summary>
        /// 转成枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T Parse<T>(string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }
        /// <summary>
        /// 获取枚举的描述信息
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(Enum en)
        {
            #region 原来
            //var type = en.GetType();
            //var memInfo = type.GetMember(en.ToString());

            //if (memInfo != null && memInfo.Length > 0)
            //{
            //    var attrs = memInfo[0].GetCustomAttributes(typeof (DescriptionAttribute), false);
            //    if (attrs != null && attrs.Length > 0)
            //        return ((DescriptionAttribute) attrs[0]).Description;
            //}
            //return en.ToString(); 
            #endregion
            if (en == null)
            {
                return null;
            }
            //加上支持位移
            var type = en.GetType();
            var strList = en.ToString().Split(',');
            string Description = en.ToString();
            if (strList.Length > 0)
            {
                Description = "";
            }
            foreach (var s in strList)
            {
                var memInfo = type.GetMember(s.Trim());
                if (memInfo != null && memInfo.Length > 0)
                {
                    var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs != null && attrs.Length > 0)
                    {
                        Description += ((DescriptionAttribute)attrs[0]).Description + ";";
                    }
                    else
                    {
                        Description += s;
                    }
                }
            }
            if (strList.Length > 0)
            {
                if (Description.Length > 0 && Description.LastIndexOf(";") == Description.Length - 1)
                {
                    return Description.Substring(0, Description.Length - 1);
                }
            }
            return Description;
        }
    }
}
