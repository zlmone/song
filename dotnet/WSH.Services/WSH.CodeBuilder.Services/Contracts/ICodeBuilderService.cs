using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSH.CodeBuilder.Entity;
using System.Data;

namespace WSH.CodeBuilder.Services
{
    [ServiceContract(Namespace = "http://wsh.codebuilderinterface/", Name = "CodeBuilderService")]
    [XmlSerializerFormat]
    public interface ICodeBuilderService
    {
        #region Project
        [OperationContract(Name = "GetProjectDataTable")]
        DataTable GetProjectDataTable();

        [OperationContract(Name = "GetProjectList")]
        List<ProjectEntity> GetProjectList();

        [OperationContract(Name = "GetProjectById")]
        ProjectEntity GetProjectById(string projectID);

        [OperationContract(Name = "AddProject")]
        int AddProject(ProjectEntity projectEntity);

        [OperationContract(Name = "UpdateProject")]
        bool UpdateProject(ProjectEntity projectEntity);

        [OperationContract(Name = "DeleteProject")]
        bool DeleteProject(string projectID);
        #endregion

        #region Table
        [OperationContract(Name = "GetTableDataTable")]
        DataTable GetTableDataTable(string projectId);

        [OperationContract(Name = "GetTableList")]
        List<TableEntity> GetTableList(string projectId);

        [OperationContract(Name = "GetTableById")]
        TableEntity GetTableById(string tableId);

        [OperationContract(Name = "GetTableByName")]
        TableEntity GetTableByName(string projectId,string tableName);

        [OperationContract(Name = "ExistsTableName")]
        bool ExistsTableName(string tableName, string projectID, string id);

        [OperationContract(Name = "AddTable")]
        int AddTable(TableEntity tableEntity);

        [OperationContract(Name = "UpdateTable")]
        bool UpdateTable(TableEntity tableEntity);

        [OperationContract(Name = "DeleteTable")]
        bool DeleteTable(string tableId);
        #endregion

        #region Column
        [OperationContract(Name = "GetColumnDataTable")]
        DataTable GetColumnDataTable(string tableId);

        [OperationContract(Name = "GetColumnList")]
        List<ColumnEntity> GetColumnList(string tableId);

        [OperationContract(Name = "BatchUpdateColumn")]
        bool BatchUpdateColumn(DataTable dt, string tableID);

        [OperationContract(Name = "AddColumn")]
        int AddColumn(ColumnEntity columnEntity);

        [OperationContract(Name = "UpdateColumn")]
        bool UpdateColumn(ColumnEntity columnEntity);
        #endregion

        #region UserInfo
        [OperationContract(Name = "GetUserInfo")]
        UserInfoEntity GetUserInfo(UserInfoEntity userInfo);

        [OperationContract(Name = "GetUserDataTable")]
        DataTable GetUserDataTable();

        [OperationContract(Name = "GetUserList")]
        List<UserInfoEntity> GetUserList();

        [OperationContract(Name = "BatchUpdateUser")]
        bool BatchUpdateUser(DataTable dt);

        [OperationContract(Name = "AddUser")]
        int AddUser(UserInfoEntity userEntity);

        [OperationContract(Name = "UpdateUser")]
        bool UpdateUser(UserInfoEntity userEntity);
        [OperationContract(Name = "ExistsUser")]
        bool ExistsUser(UserInfoEntity userEntity);
        #endregion

        #region Template
        [OperationContract(Name = "GetTemplateDataTable")]
        DataTable GetTemplateDataTable(string parentid);

        [OperationContract(Name = "GetTemplateList")]
        List<TemplateEntity> GetTemplateList(string parentid);

        [OperationContract(Name = "GetTemplateById")]
        TemplateEntity GetTemplateById(string templateID);

        [OperationContract(Name = "AddTemplate")]
        int AddTemplate(TemplateEntity templateEntity);

        [OperationContract(Name = "UpdateTemplate")]
        bool UpdateTemplate(TemplateEntity templateEntity);

        [OperationContract(Name = "DeleteTemplate")]
        bool DeleteTemplate(string templateID);
        #endregion

        #region Connection
        [OperationContract(Name = "GetConnectionDataTable")]
        DataTable GetConnectionDataTable();

        [OperationContract(Name = "GetConnectionList")]
        List<ConnectionEntity> GetConnectionList();

        [OperationContract(Name = "GetConnectionById")]
        ConnectionEntity GetConnectionById(string connectionID);

        [OperationContract(Name = "BatchUpdateConnection")]
        bool BatchUpdateConnection(DataTable dt);

        [OperationContract(Name = "AddConnection")]
        int AddConnection(ConnectionEntity connectionEntity);

        [OperationContract(Name = "UpdateConnection")]
        bool UpdateConnection(ConnectionEntity connectionEntity);
        #endregion

        #region Dict
        [OperationContract(Name = "GetDictDataTable")]
        DataTable GetDictDataTable(string dictCode);

        [OperationContract(Name = "GetDictList")]
        List<DictEntity> GetDictList(string dictCode);

        [OperationContract(Name = "GetDictByCode")]
        DictEntity GetDictByCode(string dictCode);

        [OperationContract(Name = "BatchUpdateDict")]
        bool BatchUpdateDict(DataTable dt, string dictCode);

        [OperationContract(Name = "AddDict")]
        int AddDict(DictEntity DictEntity);

        [OperationContract(Name = "UpdateDict")]
        bool UpdateDict(DictEntity DictEntity);
        #endregion
    }
}
