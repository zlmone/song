using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using WSH.Common;

namespace WSH.DataAccess.SongData
{
    public class DbHelper
    {
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">数据库执行时间，单位秒</param>
        /// <param name="tranLevel">开启事务等级</param>
        public DbHelper(string connectionString, DataBaseType dbType = DataBaseType.SqlServer, int commandTimeout = 30, IsolationLevel tranLevel = IsolationLevel.Unspecified)
        {
            _connectionString = connectionString;
            _commandTimeout = commandTimeout;
            DataType = dbType;

            BeginTran(tranLevel);
        }

        /// <summary>
        ///     数据库执行时间，单位秒
        /// </summary>
        private readonly int _commandTimeout;
        /// <summary>
        ///     连接字符串
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        ///     数据类型
        /// </summary>
        public readonly DataBaseType DataType;
        /// <summary>
        ///     数据提供者
        /// </summary>
        private DbProviderFactory _factory;
        /// <summary>
        ///     是否开启事务
        /// </summary>
        private bool _isTransaction;
        /// <summary>
        ///     Sql执行对像
        /// </summary>
        private DbCommand _comm;
        /// <summary>
        ///     数据库连接对像
        /// </summary>
        private DbConnection _conn;

        /// <summary>
        ///     开启事务。
        /// </summary>
        /// <param name="tranLevel">事务方式</param>
        public void BeginTran(IsolationLevel tranLevel)
        {
            if (tranLevel != IsolationLevel.Unspecified)
            {
                Open();
                _comm.Transaction = _conn.BeginTransaction(tranLevel);
                _isTransaction = true;
            }
        }
        public void RollbackTran()
        {
            if (_comm.Transaction == null) { throw new Exception("未开启事务"); }
            _comm.Transaction.Rollback();
        }
        /// <summary>
        ///     提交事务
        ///     如果未开启事务则会引发异常
        /// </summary>
        public void CommitTran()
        {
            if (_comm.Transaction == null) { throw new Exception("未开启事务"); }
            _comm.Transaction.Commit();
        }
        /// <summary>
        ///     关闭事务。
        /// </summary>
        public void CloseTran()
        {
            if (_isTransaction && _comm != null && _comm.Transaction != null) { _comm.Transaction.Dispose(); }
            _isTransaction = false;
        }

        /// <summary>
        ///     打开数据库连接
        /// </summary>
        private void Open()
        {
            if (_conn == null)
            {
                _factory = DbFactory.CreateDbProviderFactory(DataType);
                _comm = _factory.CreateCommand();
                _comm.CommandTimeout = _commandTimeout;

                _conn = _factory.CreateConnection();
                _conn.ConnectionString = _connectionString;
                _comm.Connection = _conn;
            }
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
                _comm.Parameters.Clear();
            }
        }

        /// <summary>
        ///     关闭数据库连接
        /// </summary>
        public void Close(bool dispose)
        {
            if (_comm != null)
            {
                _comm.Parameters.Clear();
            }
            if ((dispose || _comm.Transaction == null) && _conn != null && _conn.State != ConnectionState.Closed)
            {
                _comm.Dispose();
                _comm = null;
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }

        /// <summary>
        ///     返回第一行第一列数据
        /// </summary>
        /// <param name="cmdType">执行方式</param>
        /// <param name="cmdText">SQL或者存储过程名称</param>
        /// <param name="parameters">参数</param>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(cmdText)) { return null; }
            try
            {
                Open();
                _comm.CommandType = cmdType;
                _comm.CommandText = cmdText;
                if (parameters != null) { _comm.Parameters.AddRange(parameters); }

                return _comm.ExecuteScalar();
            }
            finally
            {
                Close(false);
            }
        }

        /// <summary>
        ///     返回受影响的行数
        /// </summary>
        /// <param name="cmdType">执行方式</param>
        /// <param name="cmdText">SQL或者存储过程名称</param>
        /// <param name="parameters">参数</param>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(cmdText)) { return 0; }
            try
            {
                Open();
                _comm.CommandType = cmdType;
                _comm.CommandText = cmdText;
                if (parameters != null) { _comm.Parameters.AddRange(parameters); }

                return _comm.ExecuteNonQuery();
            }
            finally
            {
                Close(false);
            }
        }

        /// <summary>
        ///     返回数据(IDataReader)
        /// </summary>
        /// <param name="cmdType">执行方式</param>
        /// <param name="cmdText">SQL或者存储过程名称</param>
        /// <param name="parameters">参数</param>
        public IDataReader GetReader(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(cmdText)) { return null; }
            Open();
            _comm.CommandType = cmdType;
            _comm.CommandText = cmdText;
            if (parameters != null) { _comm.Parameters.AddRange(parameters); }

            return _isTransaction ? _comm.ExecuteReader() : _comm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        ///     返回数据(DataSet)
        /// </summary>
        /// <param name="cmdType">执行方式</param>
        /// <param name="cmdText">SQL或者存储过程名称</param>
        /// <param name="parameters">参数</param>
        public DataSet GetDataSet(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(cmdText)) { return new DataSet(); }
            try
            {
                Open();
                _comm.CommandType = cmdType;
                _comm.CommandText = cmdText;
                if (parameters != null) { _comm.Parameters.AddRange(parameters); }
                var ada = _factory.CreateDataAdapter();
                ada.SelectCommand = _comm;
                var ds = new DataSet();
                ada.Fill(ds);
                return ds;
            }
            finally
            {
                Close(false);
            }
        }

        /// <summary>
        ///     返回数据(DataTable)
        /// </summary>
        /// <param name="cmdType">执行方式</param>
        /// <param name="cmdText">SQL或者存储过程名称</param>
        /// <param name="parameters">参数</param>
        public DataTable GetDataTable(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            var ds = GetDataSet(cmdType, cmdText, parameters);
            return ds.Tables.Count == 0 ? new DataTable() : ds.Tables[0];
        }

        /// <summary>
        /// 指量操作数据（仅支持Sql Server)
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">数据</param>
        public void ExecuteSqlBulkCopy(string tableName, DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) { return; }

            try
            {
                Open();
                using (var bulkCopy = new SqlBulkCopy((SqlConnection)_conn, SqlBulkCopyOptions.Default, (SqlTransaction)_comm.Transaction))
                {
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BatchSize = dt.Rows.Count;
                    bulkCopy.BulkCopyTimeout = 3600;
                    bulkCopy.WriteToServer(dt);
                }
            }
            finally { Close(false); }
        }

        private void Dispose(bool disposing)
        {
            //释放托管资源
            if (disposing) { Close(true); }
        }

        /// <summary>
        ///     注销
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ///// <summary>
        ///// 批量更新
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public bool UpdateDataTable(DataTable dt,string selectSql) {
        //    bool resule = true;
        //    if (dt == null || dt.Rows.Count <= 0) { return resule; }
        //    this.Open();
        //    DbTransaction trans = connection.BeginTransaction();
        //    try
        //    {
        //        DbProviderFactory dbfactory = GetFactory();
        //        DbCommand cmd = connection.CreateCommand();
        //        cmd.CommandText = selectSql;
        //        DbDataAdapter dr = dbfactory.CreateDataAdapter();
        //        dr.SelectCommand = cmd;
        //        dr.SelectCommand.Transaction = trans;
        //        DbCommandBuilder builder = dbfactory.CreateCommandBuilder();

        //        builder.QuotePrefix = "[";
        //        builder.QuoteSuffix = "]";
        //        builder.ConflictOption = ConflictOption.OverwriteChanges;
        //        builder.SetAllValues = false;
        //        builder.DataAdapter = dr;
        //        dr.InsertCommand = builder.GetInsertCommand();
        //        dr.UpdateCommand = builder.GetUpdateCommand();
        //        dr.DeleteCommand = builder.GetDeleteCommand();
        //        resule= dr.Update(dt)>0;
        //       // dt.AcceptChanges();
        //        trans.Commit();
        //        return resule;
        //    }
        //    catch (Exception ex)
        //    {
        //        trans.Rollback();
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        this.Close();
        //    }
        //}
    }
}

