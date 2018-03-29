using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WSH.Options.Common;
using WSH.Manager.Models;
using WSH.Web.Mvc.Common;
using WSH.Manager.Applications;
using System.Web;
using System.IO;
using WSH.Common;
using WSH.Web.Common;
using WSH.Web.Common.Response;

namespace WSH.Manager.Controllers.Common
{
    public class FileUploaderController : BaseController
    {
        public ActionResult FileUploader() {
            return View();
        }
        /// <summary>
        /// 文件上传统一入口
        /// </summary>
        /// <returns></returns>
        public ContentResult Uploader() {
            AjaxResult result = new AjaxResult();
            try
            {
                string urlPath =string.Format("~/{0}/",Server.UrlDecode(Request.Params["uploadPath"]));
                HttpPostedFileBase postedfile = Request.Files["filedata"];
                WebUpload upload = new WebUpload(postedfile);
                string filePath = upload.UploadServer(urlPath);
                string url = Url.Content(filePath);
                result.Add("status", "1").Add("message", "上传成功").Add("url", url);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Add("status", "0").Add("message", "上传失败，错误信息：" + ex.Message).Add("url","");
            }
            return Content(result.GetJsonString());
        } 
    }
}
