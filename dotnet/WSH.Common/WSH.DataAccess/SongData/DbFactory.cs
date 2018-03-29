using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace WSH.DataAccess.SongData
{
    public class DbFactory
    {
        /// <summary>
        /// 返回数据库类型名称
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        public static DbProviderFactory CreateDbProviderFactory(DataBaseType dbType)
        {
            switch (dbType)
            {
                case DataBaseType.MySql: return DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                case DataBaseType.Access: return DbProviderFactories.GetFactory("System.Data.OleDb");
                case DataBaseType.Oracle: return DbProviderFactories.GetFactory("System.Data.OracleClient");
                case DataBaseType.SQLite: return DbProviderFactories.GetFactory("System.Data.SQLite");
                case DataBaseType.SqlServer: return DbProviderFactories.GetFactory("System.Data.SqlClient");
            }
            return DbProviderFactories.GetFactory("System.Data.SqlClient");
        }
        /// <summary>
        /// 返回数据库类型名称
        /// </summary>
        public static DbProviderFactory CreateDbProviderFactory(string providerName) {
            return DbProviderFactories.GetFactory(providerName);
        }
        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionString">连接字符串</param>
        public static DbConnection GetDbConnection(DataBaseType dbType, string connectionString)
        {
            DbConnection conn;
            switch (dbType)
            {
                case DataBaseType.SqlServer:return new SqlConnection(connectionString);
                default: conn = CreateDbProviderFactory(dbType).CreateConnection(); break;
            }
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
