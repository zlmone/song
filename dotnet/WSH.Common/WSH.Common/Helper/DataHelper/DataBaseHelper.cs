using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;
using System.Data.Common;

namespace WSH.Common.Helper
{
    
    public class DataBaseHelper
    {
        public static DataBaseType GetDbType(string dbType)
        {
            DataBaseType type = (DataBaseType)Enum.Parse(typeof(DataBaseType), dbType);
            return type;
        }
        public static DataKeyType GetPkType(string pkType)
        {
            DataKeyType type = (DataKeyType)Enum.Parse(typeof(DataKeyType), pkType);
            return type;
        }
        public static string GetProviderName(DataBaseType type)
        {
            switch (type)
            {
                case DataBaseType.Oracle:
                    return "Oracle.Data.OracleClient";
                case DataBaseType.Access:
                    return "System.Data.OleDb";
                case DataBaseType.MySql:
                    return "MySql.Data.MySqlClient";
                case DataBaseType.SQLite:
                    return "SQLite.Data.SQLiteClient";
                default: return "System.Data.SqlClient";
            }
        }
        /// <summary>
        /// 设置数据库连接超时时间
        /// </summary>
        public static string TimeoutString = ";Connect Timeout=1";
        /// <summary>
        /// 将数据库连接配置转换成数据库连接字符串
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="entity"></param>
        public static void ConvertConnectionString(DataBaseType dbType, DbConnectionOptions entity)
        {
            if (string.IsNullOrEmpty(entity.ConnectionString))
            {
                switch (dbType)
                {
                    case DataBaseType.SqlServer:
                        break;
                    case DataBaseType.Oracle:
                        break;
                    case DataBaseType.MySql:
                        break;
                    case DataBaseType.Access:
                        break;
                    case DataBaseType.SQLite:
                        break;
                    default:
                        break;
                }
                entity.ConnectionString = "";
            }
        }
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        public static Result Test(DataBaseType dbType, DbConnectionOptions entity)
        {
            Result r = new Result();
            try
            {
                ConvertConnectionString(dbType, entity);
                string pname = DataBaseHelper.GetProviderName(dbType);
                DbProviderFactory dbProvider = DbProviderFactories.GetFactory(pname);
                using (DbConnection db = dbProvider.CreateConnection())
                {
                    db.ConnectionString = entity.ConnectionString + DataBaseHelper.TimeoutString;
                    db.Open();
                    db.Close();
                }
                r.IsSuccess = true;
                r.Msg = "连接成功";
            }
            catch (DbException ex)
            {
                r.IsSuccess = false;
                r.Msg = ex.Message;
            }
            return r;
        }
    }
}
