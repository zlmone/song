using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using WSH.Common.Ftp;
using WSH.Web.Common.Response;

namespace WSH.Web.Common.Attachment
{
    public class WebDownload
    {
        public WebDownload() { }
        public WebDownload(string fileName)
        {
            this.fileName = fileName;
        }
        private string localFilePath;
        /// <summary>
        /// 下载文件到本地的目录
        /// </summary>
        public string LocalFilePath
        {
            get { 
                if(string.IsNullOrEmpty(localFilePath)){
                    localFilePath = HttpContext.Current.Server.MapPath("~/Temporary/Download");
                    if (!Directory.Exists(localFilePath))
                    {
                        Directory.CreateDirectory(localFilePath);
                    }
                }
                return localFilePath;
            }
            set { localFilePath = value; }
        }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private bool isAutoContentType=false;

        public bool IsAutoContentType
        {
            get { return isAutoContentType; }
            set { isAutoContentType = value; }
        }
        /// <summary>
        /// 将byte数组输出到下载流
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        public void DownloadBytes(byte[] bytes)
        {
            HttpResponse response = this.GetResponse();
            response.AddHeader("Content-Length", bytes.Length.ToString());
            response.BinaryWrite(bytes);
            EndResponse(response);
        }
        /// <summary>
        /// 将string输出到下载流
        /// </summary>
        /// <param name="content"></param>
        public void DownloadContent(string content)
        {
            HttpResponse response = this.GetResponse();
            //response.AddHeader("Content-Length",content.Length);
            response.Write(content);
            EndResponse(response);
        }
        /// <summary>
        /// 下载服务器文件
        /// </summary>
        /// <param name="filePath">服务器文件地址</param>
        public void DownloadServerFile(string filePath, string fileName = null)
        {
            this.SetFileName(filePath, fileName);
            FileInfo file = new FileInfo(filePath);
            HttpResponse response = this.GetResponse();
            response.AddHeader("Content-Length", file.Length.ToString());
            response.WriteFile(file.FullName);
            this.EndResponse(response);
        }
        /// <summary>
        /// 下载FTP文件
        /// </summary>
        /// <param name="ftpFilePath">FTP文件路径</param>
        /// <param name="localFileName">下载的文件名</param>
        /// <param name="ftpConfigName">FTP配置节点名</param>
        public void DownloadFtpFile(string ftpFilePath, string localFileName = null,string ftpConfigName=null)
        {
            FtpClient ftp = FtpConfigManager.GetFtpClient(ftpConfigName);
            string localFile = Path.Combine(LocalFilePath, Path.GetFileName(ftpFilePath));
            try
            {
                ftp.Connect();
                if (ftp.IsConnected)
                {
                    ftp.OpenDownload(ftpFilePath, localFile);
                    while (ftp.DoDownload() > 0)
                    {
                        //ftp.BytesTotal //已经下载的字节
                    }
                }
            }
            catch (Exception ex) {
                throw;
            }finally{
                //关闭ftp连接
                ftp.Disconnect();
            }
            if (!File.Exists(localFile))
            {
                throw new FileNotFoundException("FTP文件下载到本地失败，本地文件目录：" + localFile);
            }
            DownloadServerFile(localFile, fileName);
            //删除本地文件
            File.Delete(localFile);
        }
        /// <summary>
        /// 获取下载输出流
        /// </summary>
        /// <returns></returns>
        protected HttpResponse GetResponse() {
            return ResponseHelper.GetFileResponse(this.FileName, this.IsAutoContentType);
        }
        protected void SetFileName(string filePath,string fileName) {
            if (!string.IsNullOrEmpty(fileName))
            {
                this.FileName = fileName;
            }
            if (!string.IsNullOrEmpty(filePath) && string.IsNullOrEmpty(fileName))
            {
                this.FileName = Path.GetFileName(filePath);
            }
        }
        protected void EndResponse(HttpResponse response) {
            if (response!=null)
            {
                response.Flush();
                response.End();
            }
        }
    }
}
