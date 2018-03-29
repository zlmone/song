using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using WSH.Options.Common;
using WSH.Common.Helper;

namespace WSH.Common.Http
{
    /// <summary>
    /// 发送文件请求类
    /// </summary>
    public class HttpFileRequest : HttpSimpleRequest
    {
        public HttpFileRequest()
        {
            this.KeepAlive = true;
            this.UserAgent = "WSHSDK";
            this.Method = RequestMethod.POST;
        }
        #region 受保护方法属性
        protected Dictionary<string, string> FileItems = new Dictionary<string, string>();
        private string boundaryLine = DateTime.Now.Ticks.ToString("X");
        /// <summary>
        /// 分隔线
        /// </summary>
        protected string BoundaryLine
        {
            get { return boundaryLine; }
            set { boundaryLine = value; }
        }
        #endregion
        /// <summary>
        /// 添加需要发送的文件参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileFullName"></param>
        public void AddFile(string key, string fileFullName)
        {
            if (!FileItems.ContainsKey(key))
            {
                FileItems.Add(key, fileFullName);
            }
        }
        #region 重写方法
        /// <summary>
        /// 设置请求参数值
        /// </summary>
        /// <returns></returns>
        protected override void SetRequestParamter()
        {
            this.ContentType = "multipart/form-data;charset=utf-8;boundary=" + BoundaryLine;
            using (Stream reqStream = request.GetRequestStream())
            {
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + BoundaryLine + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + BoundaryLine + "--\r\n");

                // 组装文本请求参数
                string textTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
                IEnumerator<KeyValuePair<string, string>> textEnum = Paramters.GetEnumerator();
                while (textEnum.MoveNext())
                {
                    string textEntry = string.Format(textTemplate, textEnum.Current.Key, textEnum.Current.Value);
                    byte[] itemBytes = Encoding.UTF8.GetBytes(textEntry);
                    reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    reqStream.Write(itemBytes, 0, itemBytes.Length);
                }

                // 组装文件请求参数
                string fileTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
                IEnumerator<KeyValuePair<string, string>> fileEnum = FileItems.GetEnumerator();
                while (fileEnum.MoveNext())
                {
                    string key = fileEnum.Current.Key;
                    string fullName = fileEnum.Current.Value;
                    string fileName = Path.GetFileName(fullName);
                    string fileEntry = string.Format(fileTemplate, key, fileName, HttpHepler.GetContentType(Path.GetExtension(fileName)));
                    byte[] itemBytes = Encoding.UTF8.GetBytes(fileEntry);
                    reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    reqStream.Write(itemBytes, 0, itemBytes.Length);
                    byte[] fileBytes = FileHelper.GetFileBytes(fullName);
                    reqStream.Write(fileBytes, 0, fileBytes.Length);
                }
                reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            }
        }
        #endregion
    }
}
