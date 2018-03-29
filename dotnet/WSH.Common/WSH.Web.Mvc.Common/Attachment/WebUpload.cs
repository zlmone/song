using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WSH.Common;
using System.IO;
using WSH.Web.Common;
using WSH.Common.Helper;
using WSH.Common.Ftp;

namespace WSH.Web.Mvc.Common
{
    public class WebUpload
    {
        protected HttpPostedFileBase file;
        public WebUpload(HttpPostedFileBase file)
        {
            this.file = file;
        }
        private string newFileName;
        public string NewFileName
        {
            get
            {
                if (string.IsNullOrEmpty(newFileName))
                {
                    newFileName = PathHelper.GetNewFileName(file.FileName);
                }
                return newFileName;
            }
        }
        /// <summary>
        /// 保存在服务器上
        /// </summary>
        /// <param name="savePath">保存的服务器路径</param>
        /// <returns></returns>
        public string UploadServer(string savePath)
        {
            string path = HttpContext.Current.Server.MapPath(savePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filepath = Path.Combine(path, NewFileName);
            this.file.SaveAs(filepath);
            return Path.Combine(savePath, NewFileName);
        }
        /// <summary>
        /// 保存文件到FTP指定目录上
        /// </summary>
        /// <param name="savePath">保存的FTP路径</param>
        /// <param name="serverConfigName">FTP配置名</param>
        /// <returns>返回上传之后的文件路径</returns>
        public string UploadFtp(string savePath, string serverConfigName=null)
        {
            //读取ftp配置
            FtpClient ftp = FtpConfigManager.GetFtpClient(serverConfigName);
            string uploadFile = null;
            try
            {
                ftp.Connect();
                if (ftp.IsConnected)
                {
                    //判断ftp文件夹是否存在，不存在新建
                    ftp.MakeDir(savePath);
                    ftp.ChangeDir(savePath);
                    ftp.OpenUpload(this.file.InputStream, NewFileName);

                    while (ftp.DoUpload() > 0)
                    {
                        //ftp.BytesTotal 已上传的字节
                    }
                    uploadFile= UriHelper.Combine(savePath, NewFileName);
                }
            }
            catch
            {
                throw;
            }
            finally {
                ftp.Disconnect();                   
            }
            return uploadFile;
        }
    }
}
