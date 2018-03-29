using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web;
using System.IO;
using WSH.Common;
using WSH.Web.Common;
using WSH.Options.Common;

namespace WSH.WebForm.Common
{
   public class Upload
    {
       ///// <summary>
       ///// 批量上传文件
       ///// </summary>
       ///// <param name="options"></param>
       //public static void MultiFile(UploadOptions options) {
       //    HttpFileCollection files = HttpContext.Current.Request.Files;
       //    for (int i = 0,len=files.Count; i < len; i++)
       //    {
       //        HttpPostedFile file=files[i];
       //        file.SaveAs(HttpContext.Current.Server.MapPath(GetFileName(options.UploadPath,file.FileName,options.IsReName)));
       //    }
       //}
       ///// <summary>
       ///// 得到上传文件的路径
       ///// </summary>
       //public static string GetFileName(string uploadPath, string fileName, bool isReName) {
       //    string name = Path.GetFileNameWithoutExtension(fileName);
       //    string ext = Path.GetExtension(fileName);
       //    return Path.Combine(uploadPath,(isReName ? StringUtils.GuidNonSplit : name) + ext);
       //}
       ///// <summary>
       ///// 获取上传文件的二进制流
       ///// </summary>
       ///// <param name="file"></param>
       ///// <returns></returns>
       //public static byte[] GetFileByte(HttpPostedFile file) {
       //    int len = file.ContentLength;
       //    string contentType = file.ContentType;
       //    byte[] bytes=new byte[len];
       //    Stream s = file.InputStream;
       //    s.Read(bytes, 0, len);
       //    return bytes;
       //}
       //#region 保存附件并返回服务器地址
       //public static string GetServerFileName(HtmlInputFile upfile)
       //{
       //    //附件
       //    string ServerFileName = "";
       //    if (upfile != null && upfile.PostedFile.ContentLength != 0)
       //    {
       //        string upFileName = upfile.PostedFile.FileName;
       //        string[] strTemp = upFileName.Split('.');
       //        string upFileExp = strTemp[strTemp.Length - 1].ToString();
       //        ServerFileName = HttpContext.Current.Server.MapPath(DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + upFileExp);
       //        upfile.PostedFile.SaveAs(ServerFileName);
       //    }
       //    return ServerFileName;
       //}
       //#endregion
    }
}
