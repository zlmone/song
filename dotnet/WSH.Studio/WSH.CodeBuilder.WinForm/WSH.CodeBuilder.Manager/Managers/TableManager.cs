using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WSH.CodeBuilder.Entity;
using WSH.Common.Helper;

namespace WSH.CodeBuilder.Manager
{
    public class TableManager : BaseManager
    {
        public DataTable GetDataTable(string projectID) {
            string sql = string.Format("select * from [Table] where ProjectID="+projectID);
            return db.GetDataTable(sql);
        }
        
        public TableEntity GetByID(string id) {
            string sql = string.Format("select * from [Table] where ID={0}",id);
            return ConvertHelper.ToList<TableEntity>(db.GetDataTable(sql))[0];
        }
        public TableEntity GetByName(string projectid,string tableName) {
            string sql = string.Format("select * from [Table] where ProjectID={0} and TableName='{1}';",projectid ,tableName);
            List<TableEntity> list= ConvertHelper.ToList<TableEntity>(db.GetDataTable(sql));
            if(list==null || list.Count<=0){
                return null; 
            }
            return list[0];
        }
        public List<TableEntity> GetList(string projectID) {
            DataTable dt = GetDataTable(projectID);
            return ConvertHelper.ToList<TableEntity>(dt);
        }
        public bool Exists(string name,string projectID,string id) {
            string filter = "TableName='" + name + "' and ProjectID="+projectID;
            if(!string.IsNullOrEmpty(id)){
                filter += " and ID<>" + id;
            }
            return db.Exists("[Table]", filter);
        }
        public int Add(TableEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Table](TableName,ProjectID,DataKey,DefaultSortName,DefaultSortMode,Attr,Remark,Enabled,DataKeyType) values");
            sb.AppendFormat("('{0}',{1},'{2}','{3}','{4}','{5}','{6}',{7},'{8}');", entity.TableName,entity.ProjectID, entity.DataKey,entity.DefaultSortName,entity.DefaultSortMode, entity.Attr, entity.Remark,
                GetBoolValue(entity.Enabled),
                entity.DataKeyType.ToString());
            string sql = sb.ToString();
            return db.ExecuteAdd(sql);
        }
        public bool Delete(string tableID) {
            List<string> sqlList = new List<string>();
            sqlList.Add(string.Format("delete from [Column] where TableID={0}",tableID));
            sqlList.Add(string.Format("delete from [Table] where ID={0}",tableID));
            return db.ExecuteTrans(sqlList);
        }
        public bool Update(TableEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Table] set ");
            sb.AppendFormat("TableName='{0}',", entity.TableName);
            sb.AppendFormat("ProjectID={0},", entity.ProjectID);
            sb.AppendFormat("DataKey='{0}',", entity.DataKey);
            sb.AppendFormat("DataKeyType='{0}',", entity.DataKeyType.ToString());
            sb.AppendFormat("DefaultSortName='{0}',", entity.DefaultSortName);
            sb.AppendFormat("DefaultSortMode='{0}',", entity.DefaultSortMode.ToString());
            sb.AppendFormat("Attr='{0}',", entity.Attr);
            sb.AppendFormat("Remark='{0}',", entity.Remark);
            sb.AppendFormat("Enabled={0}", GetBoolValue(entity.Enabled));
            sb.AppendFormat(" where [ID]={0}",entity.ID);
            string sql = sb.ToString();
            return db.ExecuteNonQuery(sql);
        }
    }
}
