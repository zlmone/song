using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WSH.DataAccess.SqlClient
{
    public class SqlHelper
    {
        public SqlHelper() { }
        private static string SqlConnectionString
        {
            get { return ConfigurationManager.AppSettings["SqlConnectionString"]; }
        }

        #region 打开连接
        public static SqlConnection GetConnection()
        {

            SqlConnection conn = new SqlConnection(SqlConnectionString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return conn;
        }
        #endregion

        #region 关闭连接
        public static void CloseConnection(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region 通用增删改
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn = GetConnection();
            int result = 0;
            try
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                result = comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection(conn);
            }
            return result;
        }
        #endregion
        /// <summary>
        /// 批量写入
        /// </summary>
        public static void BulkCopy(DataTable dt)
        {
            string tableName = dt.TableName;
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new Exception("批量写入时，DataTable表名为空");
            }
            BulkCopy(dt, tableName);
        }
        /// <summary>
        /// 批量写入
        /// </summary>
        public static void BulkCopy(DataTable dt, string tableName)
        {
            SqlConnection conn = GetConnection();
            try
            {
                using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn))
                {
                    //一次批量的插入的数据量
                    sqlBC.BatchSize = 5000;
                    //超时之前操作完成所允许的秒数，如果超时则事务不会提交 ，数据将回滚，所有已复制的行都会从目标表中移除
                    sqlBC.BulkCopyTimeout = 60;
                    //设置要批量写入的表
                    sqlBC.DestinationTableName = tableName;
                    //自定义的datatable和数据库的字段进行对应
                    foreach (DataColumn column in dt.Columns)
                    {
                        sqlBC.ColumnMappings.Add(column.ColumnName, column.ColumnName); ;
                    }
                    //批量写入
                    sqlBC.WriteToServer(dt);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                CloseConnection(conn);
            }
        }

        #region 查询，返回DataTable
        public static DataTable GetDataTable(string sql)
        {
            SqlConnection conn = GetConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sdr = new SqlDataAdapter(sql, conn);
                sdr.Fill(dt);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection(conn);
            }
            return dt;
        }
        #endregion

        #region 返回单行单列(object)
        public static object ExecuteScalarObject(string sql)
        {
            SqlConnection conn = GetConnection();
            object result = null;
            try
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                result = comm.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection(conn);
            }
            return result;
        }
        #endregion

        #region 返回单行单列(int)
        public static int ExecuteScalarInt(string sql)
        {
            object result = ExecuteScalarObject(sql);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }
        #endregion

        #region 通用事务提交
        public static bool Transaction(List<string> listsql)
        {
            SqlConnection conn = GetConnection();
            SqlTransaction tran = conn.BeginTransaction();
            SqlCommand comm = conn.CreateCommand();
            comm.Transaction = tran;
            try
            {
                foreach (string item in listsql)
                {
                    comm.CommandText = item;
                    comm.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection(conn);
            }
        }
        #endregion
    }
}
