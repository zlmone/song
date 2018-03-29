using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WSH.CodeBuilder.Entity;
using WSH.Common.Helper;

namespace WSH.CodeBuilder.Manager
{
    public class ProjectManager : BaseManager 
    {
        public DataTable GetDataTableByID(string id) {
            string sql = string.Format("select * from [Project] where ID="+id);
            return db.GetDataTable(sql);
        }
        public ProjectEntity GetByID(string id) {
            return ConvertHelper.ToList<ProjectEntity>(GetDataTableByID(id))[0];
        }
        public DataTable GetDataTable() {
            string sql = string.Format("select * from [Project]");
            return db.GetDataTable(sql);
        }
        public List<ProjectEntity> GetList() {
            return ConvertHelper.ToList<ProjectEntity>(GetDataTable());
        }
        public int Add(ProjectEntity entity) {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Project](ProjectName,NameSpace,Attr,Remark,TemplateID,ConnectionID) values");
            //,ConnectionString,DbType
            sb.AppendFormat("('{0}','{1}','{2}','{3}',{4},{5});",entity.ProjectName,entity.NameSpace,entity.Attr,entity.Remark,
                 entity.TemplateID,entity.ConnectionID);
            //,'{4}','{5}'
            //entity.ConnectionString,entity.DbType
            string sql = sb.ToString();
            return db.ExecuteAdd(sql);
        }
        public bool Update(ProjectEntity entity) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Project] set ");
            sb.AppendFormat("ProjectName='{0}',",entity.ProjectName);
            sb.AppendFormat("NameSpace='{0}',",entity.NameSpace);
            sb.AppendFormat("Attr='{0}',", entity.Attr);
            if (entity.TemplateID>0)
            {
                sb.AppendFormat("TemplateID={0},", entity.TemplateID);
            }
            if(entity.ConnectionID>0){
                sb.AppendFormat("ConnectionID={0},", entity.ConnectionID);
            }
            //sb.AppendFormat("ConnectionString='{0}',",entity.ConnectionString);
            //sb.AppendFormat("DbType='{0}',", entity.DbType);
            sb.AppendFormat("Remark='{0}'", entity.Remark);
            sb.AppendFormat(" where [ID]={0}", entity.ID);
            string sql = sb.ToString();
            return db.ExecuteNonQuery(sql);
        }

        public bool Delete(string projectID) {
            List<string> sqlList = new List<string>();
            TableManager tm = new TableManager();
            List<TableEntity> tables = tm.GetList(projectID);
            foreach (TableEntity  table in tables)
            {
                string tableID = table.ID.ToString() ;
                sqlList.Add(string.Format("delete from [Column] where TableID={0}", tableID));
            }
            sqlList.Add(string.Format("delete from [Table] where ProjectID={0}", projectID));
            sqlList.Add(string.Format("delete from [Project] where ID={0}",projectID));
            return db.ExecuteTrans(sqlList);
        }
    }
}
