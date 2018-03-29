<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
        //在出现未处理的错误时运行的代码
        Exception ex = Server.GetLastError().GetBaseException();
        string msg = ex.Message;
        Server.ClearError();
        string title = "操作失败";

        if (ex is DAL.DataBaseException)
        {
            title = "数据库操作出错";
        }
        else if (ex is DAL.DataExistException)
        {
            title = "数据重复";
        }
        else if (ex is DAL.DataNotFoundException)
        {
            title = "数据找不到";
        }
        else if (ex is DAL.NotRoleException)
        {
            title = "没有权限";
        }
        else
        {
            title = "操作失败";
        }
        Common.Error err = new Common.Error();
        err.Text = msg;
        err.Title = title;
        err.Type = Common.Flag.ErrorType.Error;
        err.Show();
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
