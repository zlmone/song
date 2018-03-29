using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
namespace Song.WebSite.View.js.fileExplorer
{
    public partial class FileExplorer1 : System.Web.UI.Page
    {
        public string FileItems;
        public string CurrentPath;
        protected void Page_Load(object sender, EventArgs e)
        {
      
            CurrentPath = Request.Params["path"];
            //FileExplorerManager mgr = new FileExplorerManager();
            //mgr.RootPath =Server.MapPath("~/admin/img");
            //mgr.CurrentPath = CurrentPath;
            //CurrentPath =Server.UrlDecode(mgr.CurrentPath);
            //FileItems = mgr.GetHtmlFiles();
        }
    }
}