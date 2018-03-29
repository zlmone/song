using System;
using System.Collections.Generic;
using System.Text;
using WSH.Tools.Connection;
using WSH.Common.Helper;
using WSH.Options.Common;
using WSH.CodeBuilder.DispatchServers;
using WSH.WinForm.Controls;

namespace WSH.CodeBuilder.WinForm
{
   public class Global
    {
       public static string ConnectionString = string.Empty;
       public static bool IsConnection
       {
           get
           {
               return string.IsNullOrEmpty(ConnectionString)==false;
           }
       }
       public static StartLoading LoadingForm = new StartLoading();
       public static WSH.CodeBuilder.DispatchServers.UserInfoEntity User = new UserInfoEntity();
       private static ProjectEntity Project=null;
       private static ConnectionEntity Connection=null;
       public static void SetCurrentProject(ProjectEntity entity) {
           Project = entity;
           if (entity == null || entity.ConnectionID<=0)
           {
               Connection = null;
           }
       }
       public static void SetCurrentProject(string projectId) {
           ProjectEntity entity = new ProjectEntity();
           if (!string.IsNullOrEmpty(projectId))
           {
               CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
               entity = service.GetProjectById(projectId);
           }
           SetCurrentProject(entity);
       }
       /// <summary>
       /// 获取当前项目的实体
       /// </summary>
       /// <returns></returns>
       public static ProjectEntity GetCurrentProject() {
           return Project==null ? new ProjectEntity(){} : Project;
       }
       public static string GetCurrentProjectID() {
           return GetCurrentProject().ID.ToString();
       }
       /// <summary>
       /// 获取当前项目的数据库连接对象
       /// </summary>
       /// <returns></returns>
       public static ConnectionEntity GetProjectConnection()
       {
           if (Connection != null && Connection.ID>0)
           {
               if (!string.IsNullOrEmpty(ConnectionString))
               {
                   Connection.ConnectionString = ConnectionString;
               }
               return Connection;
           }
           ProjectEntity project = GetCurrentProject();
           ConnectionEntity entity = new ConnectionEntity();
           if (project.ConnectionID > 0)
           {
               CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
               entity = service.GetConnectionById(project.ConnectionID.ToString());
               //填充当前的链接字符
               if (!string.IsNullOrEmpty(ConnectionString))
               {
                   entity.ConnectionString = ConnectionString;
               }
           }
           return entity;
       }
    }
}
