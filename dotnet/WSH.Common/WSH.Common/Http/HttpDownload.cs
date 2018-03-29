using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

namespace WSH.Common.Http
{
    public class HttpDownload
    {
        public HttpDownload() { }
        public HttpDownload(string url, string saveFileName) {
            this.url = url;
            this.saveFileName = saveFileName;
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string saveFileName;

        public string SaveFileName
        {
            get { return saveFileName; }
            set { saveFileName = value; }
        }
        public event DownloadProgressHandler OnDownloadProgress;
        #region Download
        /// <summary>
        /// 下载文件
        /// </summary>
        public void Download()
        {
            System.IO.Stream st = null;
            System.IO.Stream so = null;
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                long totalBytes = response.ContentLength;
                st = response.GetResponseStream();
                so = new System.IO.FileStream(saveFileName, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                    if (OnDownloadProgress != null)
                    {
                        DownloadEventArgs args = new DownloadEventArgs();
                        args.TotalSize = totalBytes;
                        args.DownloadSize = totalDownloadedByte;
                        OnDownloadProgress(this, args);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (so != null)
                {
                    so.Close();
                }
                if (st != null)
                {
                    st.Close();
                }
            }
        }
        #endregion
    }
}
