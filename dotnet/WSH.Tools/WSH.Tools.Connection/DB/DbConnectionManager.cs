using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using System.Data.Common;
using WSH.Options.Common;
using WSH.Common;

namespace WSH.Tools.Connection.DB
{
    public class DbConnectionManager
    {
        /// <summary>
        /// 打开数据库连接窗口，返回连接是否成功
        /// </summary>
        /// <returns></returns>
        public static Result Connection(DataBaseType dbType, DbConnectionOptions connEntity)
        {
            DbConnection conn = new DbConnection();
            conn.DefaultDataBase = dbType;
            conn.DefaultConnection = connEntity;
            DialogResult r = conn.ShowDialog();
            Result result = new Result();
            result.IsSuccess = r == DialogResult.Yes;
            result.Msg = conn.ConnectionString;
            return result;
        }
        public static void SetResult(DbConnection frm, bool result,string connectionString)
        {
            frm.DialogResult = result ? DialogResult.Yes : DialogResult.No;
            frm.ConnectionString = connectionString;
        }
        public static  string TimeoutString = ";Connect Timeout=1";
    }
}
