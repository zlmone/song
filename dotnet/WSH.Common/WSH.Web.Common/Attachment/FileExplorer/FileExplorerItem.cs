using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Web.Common.Attachment
{
    public class FileExplorerItem
    {
        private bool isFile;
        /// <summary>
        /// 是否是文件
        /// </summary>
        public bool IsFile
        {
            get { return isFile; }
            set { isFile = value; }
        }
        private string fileExtend;
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtension
        {
            get { return fileExtend; }
            set { fileExtend = value; }
        }
        private long fileLength;
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileLength
        {
            get { return fileLength; }
            set { fileLength = value; }
        }
        private string fileName;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string fullFileName;
        /// <summary>
        /// 文件的物理路径
        /// </summary>
        public string FullFileName
        {
            get { return fullFileName; }
            set { fullFileName = value; }
        }
        private string fileUrl;
        /// <summary>
        /// 文件的可访问路径
        /// </summary>
        public string FileUrl
        {
            get { return fileUrl; }
            set { fileUrl = value; }
        }
    }
}
