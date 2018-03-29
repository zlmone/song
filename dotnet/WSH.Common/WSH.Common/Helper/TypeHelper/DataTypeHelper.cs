using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

namespace WSH.Common.Helper
{
    public class DataTypeHelper
    {
 
        #region 判断数据的类型
        public static bool IsBool(object value)
        {
            string v = value.ToString().ToLower();
            return v == "true" || v == "false";
        }
        public static bool IsString(object value)
        {
            return value.GetType().Name == "String";
        }
        public static bool IsInt(object value)
        {
            //return value.GetType==typeof(int);
            return typeof(int).IsInstanceOfType(value);
        }
        #endregion
    }
}
