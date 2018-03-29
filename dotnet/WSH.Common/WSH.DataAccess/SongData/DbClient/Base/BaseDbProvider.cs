using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using WSH.Common;
using System.Data;
using System.Collections;

namespace WSH.DataAccess.SongData
{
    public abstract class BaseDbProvider
    {
        /// <summary>
        /// 参数前缀
        /// </summary>
        public virtual string ParamPrefix
        {
            get { return "@"; }
        }
        /// <summary>
        /// 创建提供程序对数据源类的实现的实例
        /// </summary>
        public abstract DbProviderFactory GetDbProviderFactory { get; }

        /// <summary>
        /// 创建字段保护符
        /// </summary>
        /// <param name="fieldName">字符名称</param>
        public virtual string KeywordAegis(string fieldName)
        {
            return String.Format("[{0}]", fieldName);
        }

        #region 创建数据库参数
        /// <summary>
        ///     创建一个数据库参数对象
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        /// <param name="type">参数类型</param>
        /// <param name="lenth">参数长度</param>
        /// <param name="output">是否是输出值</param>
        public DbParameter CreateDbParameter(string name, object value, DbType type, int lenth = 0,bool output = false)
        {
            var param = GetDbProviderFactory.CreateParameter();
            param.DbType = type;
            param.ParameterName = ParamPrefix + name;
            param.Value = ParamConvertValue(value, type);
            if (lenth > 0)
            {
                param.Size = lenth;
            }
            if (output)
            {
                param.Direction = ParameterDirection.Output;
            }
            return param;
        }

        /// <summary>
        ///     创建一个数据库参数对象
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="valu">参数值</param>
        /// <param name="valType">值类型</param>
        /// <param name="output">是否是输出值</param>
        public DbParameter CreateDbParameter(string name, object valu, Type valType, bool output = false)
        {
            int len;
            var type = GetDbType(valType, out len);
            return CreateDbParameter(name, valu, type, len, output);
        }
        /// <summary>
        /// 根据值，返回类型
        /// </summary>
        /// <param name="type">参数类型</param>
        /// <param name="len">参数长度</param>
        /// <returns></returns>
        public DbType GetDbType(Type type, out int len)
        {
            if (type.Name.Equals("Nullable`1")) { type = Nullable.GetUnderlyingType(type); }
            if (type.BaseType != null && type.BaseType.Name == "Enum") { len = 1; return DbType.Byte; }
            switch (type.Name)
            {
                case "DateTime": len = 8; return DbType.DateTime;
                case "Boolean": len = 1; return DbType.Boolean;
                case "Int32": len = 4; return DbType.Int32;
                case "Int16": len = 2; return DbType.Int16;
                case "Decimal": len = 8; return DbType.Decimal;
                case "Byte": len = 1; return DbType.Byte;
                case "Long":
                case "Float":
                case "Double": len = 8; return DbType.Decimal;
                case "Guid": len = 16; return DbType.Guid;
                default: len = 0; return DbType.String;
            }
        }
        /// <summary>
        /// 将C#值转成数据库能存储的值
        /// </summary>
        /// <param name="valu"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object ParamConvertValue(object valu, DbType type)
        {
            if (valu == null) { return null; }

            // 时间类型转换
            if (type == DbType.DateTime)
            {
                DateTime dtValue; DateTime.TryParse(valu.ToString(), out dtValue);
                if (dtValue == DateTime.MinValue) { valu = new DateTime(1900, 1, 1); }
            }
            // 枚举类型转换
            if (valu is Enum) { valu = Convert.ToInt32(valu); }

            // List类型转换成字符串并以,分隔
            if (valu.GetType().IsGenericType)
            {
                var sb = new StringBuilder();
                // list类型
                if (valu.GetType().GetGenericTypeDefinition() != typeof(Nullable<>))
                {
                    var enumerator = ((IEnumerable)valu).GetEnumerator();
                    while (enumerator.MoveNext()) { sb.Append(enumerator.Current + ","); }
                }
                else
                {
                    if (valu.GetType().GetGenericArguments()[0] == typeof(int))
                    {
                        var enumerator = ((IEnumerable<int?>)valu).GetEnumerator();
                        while (enumerator.MoveNext()) { sb.Append(enumerator.Current.GetValueOrDefault() + ","); }
                    }
                }
                valu = sb.Length > 0 ? sb.Remove(sb.Length - 1, 1).ToString() : "";
            }
            return valu;
        }
        #endregion

        #region 返回DbProvider

        /// <summary>
        /// 根据数据库类型，获取对应的Provider实例
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="dbVersion">数据库版本</param>
        public static BaseDbProvider CreateDbProvider(DataBaseType dbType, string dbVersion = null)
        {
            switch (dbType)
            {
                case DataBaseType.Access: return new AccessProvider();
                case DataBaseType.MySql: return new MySqlProvider();
                case DataBaseType.SQLite: return new SqLiteProvider();
                case DataBaseType.Oracle: return new OracleProvider();
            }
            if (dbType == DataBaseType.SqlServer && dbVersion == "2000")
            {
                return new SqlServer2000Provider();
            }
            return new SqlServerProvider();
        }
        #endregion


    }
}
