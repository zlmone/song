using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSH.CodeBuilder.Entity;
using WSH.CodeBuilder.Manager;
using System.ServiceModel.Activation;
using System.Data;

namespace WSH.CodeBuilder.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CodeBuilderService : ICodeBuilderService
    {
        #region Project
        public DataTable GetProjectDataTable()
        {
            ProjectManager mgr = new ProjectManager();
            return mgr.GetDataTable();
        }

        public List<ProjectEntity> GetProjectList()
        {
            ProjectManager mgr = new ProjectManager();
            return mgr.GetList();
        }

        public ProjectEntity GetProjectById(string id)
        {
            ProjectManager mgr = new ProjectManager();
            return mgr.GetByID(id); 
        }

        public int AddProject(ProjectEntity entity)
        {
            ProjectManager mgr = new ProjectManager();
            return mgr.Add(entity);
        }

        public bool UpdateProject(ProjectEntity entity)
        {
            ProjectManager mgr = new ProjectManager();
            return mgr.Update(entity);
        }

        public bool DeleteProject(string projectID)
        {
            ProjectManager mgr = new ProjectManager();
            return mgr.Delete(projectID);
        }
        #endregion

        #region Table
        public DataTable GetTableDataTable(string projectId) {
            TableManager mgr = new TableManager();
            return mgr.GetDataTable(projectId);
        }

        public List<TableEntity> GetTableList(string projectId)
        {
            TableManager mgr = new TableManager();
            return mgr.GetList(projectId);
        }

        public TableEntity GetTableById(string tableId)
        {
            TableManager mgr = new TableManager();
            return mgr.GetByID(tableId);
        }

        public TableEntity GetTableByName(string projectId,string tableName)
        {
            TableManager mgr = new TableManager();
            return mgr.GetByName(projectId,tableName);
        }

        public bool ExistsTableName(string tableName, string projectID, string id)
        {
            TableManager mgr = new TableManager();
            return mgr.Exists(tableName,projectID,id);
        }

        public int AddTable(TableEntity tableEntity)
        {
            TableManager mgr = new TableManager();
            return mgr.Add(tableEntity);
        }

        public bool UpdateTable(TableEntity tableEntity)
        {
            TableManager mgr = new TableManager();
           return  mgr.Update(tableEntity);
        }

        public bool DeleteTable(string tableId)
        {
            TableManager mgr = new TableManager();
            return mgr.Delete(tableId);
        }
        #endregion

        #region Column
        public System.Data.DataTable GetColumnDataTable(string tableId)
        {
            ColumnManager mgr = new ColumnManager();
            return mgr.GetDataTable(tableId);
        }

        public List<ColumnEntity> GetColumnList(string tableId)
        {
            ColumnManager mgr = new ColumnManager();
            return mgr.GetList(tableId);
        }

        public bool BatchUpdateColumn(System.Data.DataTable dt, string tableID)
        {
            ColumnManager mgr = new ColumnManager();
            return mgr.UpdateList(dt, tableID);
        }

        public int AddColumn(ColumnEntity columnEntity)
        {
            ColumnManager mgr = new ColumnManager();
            return mgr.Add(columnEntity);
        }

        public bool UpdateColumn(ColumnEntity columnEntity)
        {
            ColumnManager mgr = new ColumnManager();
            return mgr.Update(columnEntity);
        }
        #endregion

        #region UserInfo
        public UserInfoEntity GetUserInfo(UserInfoEntity userInfo)
        {
            UserInfoManager mgr = new UserInfoManager();
            return mgr.GetUserInfo(userInfo);
        }
        public System.Data.DataTable GetUserDataTable()
        {
            UserInfoManager mgr = new UserInfoManager();
            return mgr.GetDataTable();
        }

        public List<UserInfoEntity> GetUserList()
        {
            throw new NotImplementedException();
        }

        public bool BatchUpdateUser(System.Data.DataTable dt)
        {
            UserInfoManager mgr = new UserInfoManager();
            return mgr.UpdateList(dt);
        }

        public int AddUser(UserInfoEntity userEntity)
        {
            UserInfoManager mgr = new UserInfoManager();
            return mgr.Add(userEntity);
        }

        public bool UpdateUser(UserInfoEntity userEntity)
        {
            UserInfoManager mgr = new UserInfoManager();
            return mgr.Update(userEntity);
        }
        public bool ExistsUser(UserInfoEntity userEntity) {
            UserInfoManager mgr = new UserInfoManager();
            return mgr.ExitisUser(userEntity);
        }
        #endregion

        #region Template
        public DataTable GetTemplateDataTable(string parentid)
        {
            TemplateManager mgr = new TemplateManager();
            return mgr.GetDataTable(parentid);
        }

        public List<TemplateEntity> GetTemplateList(string parentid)
        {
            TemplateManager mgr = new TemplateManager();
            return mgr.GetList(parentid);
        }

        public TemplateEntity GetTemplateById(string templateID)
        {
            TemplateManager mgr = new TemplateManager();
            return mgr.GetByID(templateID);
        }

        public int AddTemplate(TemplateEntity templateEntity)
        {
            TemplateManager mgr = new TemplateManager();
            return mgr.Add(templateEntity);
        }

        public bool UpdateTemplate(TemplateEntity templateEntity)
        {
            TemplateManager mgr = new TemplateManager();
            return mgr.Update(templateEntity);
        }

        public bool DeleteTemplate(string templateID)
        {
            TemplateManager mgr = new TemplateManager();
            return mgr.Delete(templateID);
        }
        #endregion

        #region Connection
        public System.Data.DataTable GetConnectionDataTable()
        {
            ConnectionManager mgr = new ConnectionManager();
            return mgr.GetDataTable();
        }

        public List<ConnectionEntity> GetConnectionList()
        {
            ConnectionManager mgr = new ConnectionManager();
            return mgr.GetList();
        }

        public ConnectionEntity GetConnectionById(string connectionID) {
            ConnectionManager mgr = new ConnectionManager();
            return mgr.GetByID(connectionID);
        }

        public bool BatchUpdateConnection(System.Data.DataTable dt)
        {
            ConnectionManager mgr = new ConnectionManager();
            return mgr.UpdateList(dt);
        }

        public int AddConnection(ConnectionEntity connectionEntity)
        {
            ConnectionManager mgr = new ConnectionManager();
            return mgr.Add(connectionEntity);
        }

        public bool UpdateConnection(ConnectionEntity connectionEntity)
        {
            ConnectionManager mgr = new ConnectionManager();
            return mgr.Update(connectionEntity);
        }
        #endregion

        #region Dict
        public System.Data.DataTable GetDictDataTable(string dictCode)
        {
            DictManager mgr = new DictManager();
            return mgr.GetDataTable(dictCode);
        }

        public List<DictEntity> GetDictList(string dictCode)
        {
            DictManager mgr = new DictManager();
            return mgr.GetList(dictCode);
        }

        public DictEntity GetDictByCode(string dictCode)
        {
            DictManager mgr = new DictManager();
            return mgr.GetByCode(dictCode);
        }

        public bool BatchUpdateDict(System.Data.DataTable dt, string dictCode)
        {
            throw new NotImplementedException();
        }

        public int AddDict(DictEntity DictEntity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDict(DictEntity DictEntity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}