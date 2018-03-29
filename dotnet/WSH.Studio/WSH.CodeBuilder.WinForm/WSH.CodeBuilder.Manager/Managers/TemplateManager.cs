using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.Data;
using WSH.CodeBuilder.Entity;

namespace WSH.CodeBuilder.Manager
{
    public class TemplateManager : BaseManager
    {
        public DataTable GetDataTable(string parentid)
        {
            string sql = string.Format("select * from [Template] where ParentID=" + parentid);
            return db.GetDataTable(sql);
        }
        public TemplateEntity GetByID(string id)
        {
            string sql = string.Format("select * from [Template] where ID={0}", id);
            return ConvertHelper.ToList<TemplateEntity>(db.GetDataTable(sql))[0];
        }
        public List<TemplateEntity> GetList(string parentid)
        {
            DataTable dt = GetDataTable(parentid);
            return ConvertHelper.ToList<TemplateEntity>(dt);
        }
        public int Add(TemplateEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into [Template](ParentID,TemplateName,FileExtensions,FileName,Attr,Content,FilePrefix) values");
            sb.AppendFormat("({0},'{1}','{2}','{3}','{4}',@Content", entity.ParentID, entity.TemplateName,
                 entity.FileExtensions, entity.FileName, entity.Attr);
            if (entity.FilePrefix != null)
            {
                sb.Append(",@FilePrefix");
            }
            sb.Append(");");
            string sql = sb.ToString();
            var paramList = new List<Paramter>() { 
                new Paramter(){
                    ParamterName="@Content", Value=entity.Content,DbType= DbType.String
                }
            };
            if (entity.FilePrefix != null)
            {
                paramList.Add(new Paramter()
                {
                    ParamterName = "@FilePrefix",
                    Value = entity.FilePrefix,
                    DbType = DbType.String
                });
            }
            return db.ExecuteAdd(sql, paramList);
        }
        public bool Delete(string id)
        {
            List<string> sqlList = new List<string>();
            if (Convert.ToInt32(id) >= 0)
            {
                sqlList.Add(string.Format("delete from [Template] where ParentID={0}", id));
            }
            sqlList.Add(string.Format("delete from [Template] where ID={0}", id));
            return db.ExecuteTrans(sqlList);
        }
        public bool Update(TemplateEntity entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update [Template] set ");
            sb.AppendFormat("TemplateName='{0}',", entity.TemplateName);
            sb.AppendFormat("FileName='{0}',", entity.FileName);
            sb.AppendFormat("FileExtensions='{0}',", entity.FileExtensions);
            sb.AppendFormat("Attr='{0}',", entity.Attr);
            sb.AppendFormat("Content=@Content,");
            if(entity.FilePrefix!=null){
                sb.AppendFormat("FilePrefix=@FilePrefix,");
            }
            sb.AppendFormat("EditTime='{0}'", DateTimeHelper.NowDateTime);
            sb.AppendFormat(" where [ID]={0}", entity.ID);
            string sql = sb.ToString();
            var paramList=new List<Paramter>() { 
                new Paramter(){
                    ParamterName="@Content", Value=entity.Content,DbType= DbType.String
                }
            };
            if(entity.FilePrefix!=null){
                paramList.Add(new Paramter(){
                    ParamterName="@FilePrefix",Value=entity.FilePrefix,DbType= DbType.String
                });
            }
            return db.ExecuteNonQuery(sql,paramList);
        }
        ///// <summary>
        ///// 模板存放的路径
        ///// </summary>
        //public static string TemplatePath
        //{
        //    get
        //    {
        //        return System.IO.Path.Combine(PathHelper.GetMainPath, "Template");
        //    }
        //}
         
        
        ///// <summary>
        ///// 得到模板文件的本地路径
        ///// </summary>
        //public static string GetTemplateFile(string templateName, string typeName)
        //{
        //    if (templateName.LastIndexOf(".tt") == -1)
        //    {
        //        templateName += ".tt";
        //    }
        //    string path = TemplatePath + "\\" + typeName;
        //    return System.IO.Path.Combine(path, templateName);
        //}
        //public static string GetTemplateType(string typeName) {
        //    return System.IO.Path.Combine(TemplatePath,typeName);
        //}
    }
}
