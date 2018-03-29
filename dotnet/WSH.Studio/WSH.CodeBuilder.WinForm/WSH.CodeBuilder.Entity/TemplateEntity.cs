using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.CodeBuilder.Entity
{
    [Serializable]
    public class TemplateEntity : WSH.CodeBuilder.Entity.Entity
    {
        private int parentID;
        /// <summary>
        /// ParentID
        /// </summary>
        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private string templateName;
        /// <summary>
        /// TemplateName
        /// </summary>
        public string TemplateName
        {
            get { return templateName; }
            set { templateName = value; }
        }
        private string fileExtensions;
        /// <summary>
        /// FileExtensions
        /// </summary>
        public string FileExtensions
        {
            get { return fileExtensions; }
            set { fileExtensions = value; }
        }
        private string fileName;
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string attr;
        /// <summary>
        /// Attr
        /// </summary>
        public string Attr
        {
            get { return attr; }
            set { attr = value; }
        }
        private string content;
        /// <summary>
        /// 模板内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string filePrefix;
        /// <summary>
        /// 生成文件的前缀
        /// </summary>
        public string FilePrefix
        {
            get { return filePrefix; }
            set { filePrefix = value; }
        }
    }
}
