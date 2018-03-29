using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Common
{
    public class DbHelper
    {
        public static ConnectionStringSettings GetConnectionStringSettings(string connectionString, DataBaseType type)
        { 
            ConnectionStringSettings cs = new ConnectionStringSettings();
            cs.ConnectionString = connectionString;
            cs.ProviderName = DataBaseHelper.GetProviderName(type);
            return cs;
        }
        private ConnectionStringSettings ConnectionSettings;
        private DbConnection connection;
        /// <summary>
        /// 构造函数初始化连接对象
        /// </summary>
        /// <param name="type">数据库类型</param>
        public DbHelper(DataBaseType type)
        {
            ConnectionSettings = ConfigurationManager.ConnectionStrings[type.ToString() + "ConnectionString"];
            connection = this.CreateConnection();
        }
        public DbHelper(DataBaseType type,string connectionString) {
            ConnectionSettings = DbHelper.GetConnectionStringSettings(connectionString, type);
            connection = this.CreateConnection();
        }
        /// <summary>
        /// 创建连接对象
        /// </summary>
        /// <returns>连接对象</returns>
        public DbConnection CreateConnection()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(ConnectionSettings.ProviderName);
            DbConnection dbconn = dbfactory.CreateConnection();
            dbconn.ConnectionString = ConnectionSettings.ConnectionString;
            return dbconn;
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open() {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
            }
            catch (DbException ex) {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close() { 
            if(this.connection!=null){
                this.connection.Close();
            }
        }
        /// <summary>
        /// 得到服务接口
        /// </summary>
        /// <returns></returns>
        private DbProviderFactory GetFactory()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(this.ConnectionSettings.ProviderName);
            return dbfactory;
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string sql)
        {
            try
            {
                this.Open();
                DbProviderFactory dbfactory = GetFactory();
                DbDataAdapter dr = dbfactory.CreateDataAdapter();
                DbCommand comm = this.connection.CreateCommand();
                comm.CommandText = sql;
                comm.CommandType = CommandType.Text;
                comm.Connection = this.connection;
                dr.SelectCommand = comm;
                DataTable dt = new DataTable();
                dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回受影响行数</returns>
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                this.Open();
                DbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery()>0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                this.Close();
            }
        }
        /// <summary>
        /// 执行新增命令，并返回自增长ID
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>自增长ID</returns>
        public int ExecuteAdd(string sql) {
            string querySql= "select @@identity;";
            try
            {
                this.Open();
                DbCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                if (cmd.ExecuteNonQuery() <= 0) { return 0; }
                cmd.CommandText = querySql;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                this.Close();
            }
        }
        /// <summary>
        /// 查询单行单条记录
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>查询结果</returns>
        public object ExecuteScalar(string sql)
        {
            try
            {
                this.Open();
                DbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
        public bool Exists(string tableName, string filter) {
            string sql = string.Format("select count(*) from {0} where {1}", tableName, filter);
            bool result= Convert.ToInt32(this.ExecuteScalar(sql)) > 0;
            return result;
        }
        /// <summary>
        /// 执行多条语句，并开启事务
        /// </summary>
        /// <param name="listSql"></param>
        /// <returns></returns>
        public bool ExecuteTrans(List<string> listSql) {
            if (listSql.Count <= 0) { return true; }
            this.Open();
            DbTransaction tran = this.connection.BeginTransaction();
            try
            {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.Transaction = tran;
                foreach (string  sql in listSql)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
            catch (DbException ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally {
                this.Close();
            }
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateDataTable(DataTable dt,string selectSql) {
            bool resule = true;
            if (dt == null || dt.Rows.Count <= 0) { return resule; }
            this.Open();
            DbTransaction trans = connection.BeginTransaction();
            try
            {
                DbProviderFactory dbfactory = GetFactory();
                DbCommand cmd = connection.CreateCommand();
                cmd.CommandText = selectSql;
                DbDataAdapter dr = dbfactory.CreateDataAdapter();
                dr.SelectCommand = cmd;
                dr.SelectCommand.Transaction = trans;
                DbCommandBuilder builder = dbfactory.CreateCommandBuilder();
                
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                builder.ConflictOption = ConflictOption.OverwriteChanges;
                builder.SetAllValues = false;
                builder.DataAdapter = dr;
                dr.InsertCommand = builder.GetInsertCommand();
                dr.UpdateCommand = builder.GetUpdateCommand();
                dr.DeleteCommand = builder.GetDeleteCommand();
                resule= dr.Update(dt)>0;
               // dt.AcceptChanges();
                trans.Commit();
                return resule;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}

