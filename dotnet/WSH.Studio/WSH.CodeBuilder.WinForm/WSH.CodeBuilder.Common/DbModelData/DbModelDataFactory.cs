using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public class DbModelDataFactory
    {
        /// <summary>
        /// 根据数据库类型和连接字符串获取数据库模型读取器
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbModelData GetDbModelData(string dbType, string connectionString)
        {
            DataBaseType dType = StringHelper.ToEnum<DataBaseType>(dbType);
            return GetDbModelData(dType,connectionString);
        }
        public static DbModelData GetDbModelData(DataBaseType dbType, string connectionString) {
            switch (dbType)
            {
                case DataBaseType.MySql:
                    return new MySqlModelData(connectionString);
                default:
                    return new SqlModelData(connectionString);
            }
        }
    }
}
