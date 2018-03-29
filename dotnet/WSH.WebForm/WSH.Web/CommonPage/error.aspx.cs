using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
 
public partial class error : System.Web.UI.Page
{

    protected string ErrorTitle;
    protected string ErrorText;
    protected string ErrorImg;
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorTitle = Request.Params["ErrorTitle"];
        ErrorText = Request.Params["ErrorText"];
        ErrorImg = Request.Params["ErrorImg"];

        //if (ErrorImg != "")
        //{
        //    icon.ImageUrl = "images/Error/" + ErrorImg + ".gif";
        //}
        //if (ErrorText != "")
        //{
        //    text.Text = Server.UrlDecode(ErrorText);
        //}
        //if(ErrorTitle!=""){
        //    head.Text = ErrorTitle;
        //}
    }

}
