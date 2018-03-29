using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.Data;
using WSH.CodeBuilder.Entity;

namespace WSH.CodeBuilder.Manager
{
    public class ConnectionManager : BaseManager
    {
        public string GetSelectSql() { 
            return string.Format("select * from [Connection]");
        }
        public DataTable GetDataTable()
        {
            return db.GetDataTable(GetSelectSql());
        }
        public ConnectionEntity GetByID(string id)
        {
            string sql = string.Format("select * from [Connection] where ID={0}", id);
            return ConvertHelper.ToList<ConnectionEntity>(db.GetDataTable(sql))[0];
        }
        public List<ConnectionEntity> GetList()
        {
            DataTable dt = GetDataTable();
            return ConvertHelper.ToList<ConnectionEntity>(dt);
        }
        public bool UpdateList(DataTable dt)
        {
            return db.UpdateDataTable(dt, GetSelectSql());
        }
        public int Add(ConnectionEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Connection](ConnectionName,ConnectionType,ConnectionString) values");
            sb.AppendFormat("('{0}','{1}','{2}');", entity.ConnectionName, entity.ConnectionType.ToString(),
                 entity.ConnectionString);
            string sql = sb.ToString();
            return db.ExecuteAdd(sql);
        }
        public bool Delete(string id)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add(string.Format("delete from [Connection] where ID={0}", id));
            return db.ExecuteTrans(sqlList);
        }
        public bool Update(ConnectionEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Connection] set ");
            sb.AppendFormat("ConnectionName='{0}',", entity.ConnectionName);
            sb.AppendFormat("ConnectionType='{0}',", entity.ConnectionType.ToString());
            sb.AppendFormat("ConnectionString='{0}',", entity.ConnectionString);
            sb.AppendFormat("EditTime='{0}'", DateTimeHelper.NowDateTime);
            sb.AppendFormat(" where [ID]={0}", entity.ID);
            string sql = sb.ToString();
            return db.ExecuteNonQuery(sql);
        }
       
    }
}
