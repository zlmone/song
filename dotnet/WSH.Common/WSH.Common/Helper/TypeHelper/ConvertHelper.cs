using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace WSH.Common.Helper
{
    public class ConvertHelper
    {
        #region 数据转换
        public static bool IsNullOrDBNull(object value)
        {
            return (value == null || value == DBNull.Value);
        }
        /// <summary>
        /// 转换成Int32,如果空值则返回默认值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(object value,Int32 defaultValue=0) {
            if (IsNullOrDBNull(value))
            {
                return defaultValue;
            }
            int result;
            if (!int.TryParse(value.ToString(), out result)) {
                result = defaultValue;
            }
            return result;
        }
         
        /// <summary>
        /// 转换成bool类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(object value) {
            if (IsNullOrDBNull(value))
            {
                return false;
            }
            return Convert.ToBoolean(value);
        }
        public static string ToString(object value) {
            if (IsNullOrDBNull(value))
            {
                return null;
            }
            return value.ToString();
        }
        #endregion
        /// <summary>
        /// 将数据转换成字符串,将null和dbnull处理成空字符
        /// </summary>
        public static string AsEmpty(object value)
        {
            if (IsNullOrDBNull(value))
            {
                return string.Empty;
            }
            return value.ToString();
        }
        /// <summary>
        /// DataTable转换成IList集合
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(DataTable dt) where T : class,new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取T的类型实例 反射的入口
            Type t = typeof(T);
            //获得T 的所有的Public 属性 并找出T属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            //创建返回的集合
            List<T> oblist = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                //创建T的实例
                T ob = new T();
                //找到对应的数据 并赋值
                prlist.ForEach(p =>
                {
                    if (row[p.Name] != null && row[p.Name] != DBNull.Value)
                    {
                        if (p.PropertyType.BaseType.Name == "Enum")
                        {
                            if (row[p.Name] != null && row[p.Name].ToString() != "")
                            {
                                p.SetValue(ob, (Enum.Parse(p.PropertyType, row[p.Name].ToString())), null);
                            }
                        }
                        else
                        {
                            p.SetValue(ob, row[p.Name], null);
                        }
                    }
                });
                //放入到返回的集合中.
                oblist.Add(ob);
            }
            return oblist;
        }
    }
}
