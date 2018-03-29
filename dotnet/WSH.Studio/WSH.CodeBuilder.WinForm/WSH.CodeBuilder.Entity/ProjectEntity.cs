using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.CodeBuilder.Entity
{
    [Serializable]
    public class ProjectEntity : WSH.CodeBuilder.Entity.Entity
    {
        
        private string projectName;
        /// <summary>
        /// ProjectName
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string nameSpace;
        /// <summary>
        /// NameSpace
        /// </summary>
        public string NameSpace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
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
        private string remark;
        /// <summary>
        /// Remark
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private int connectionID;
        /// <summary>
        /// ConnectionID
        /// </summary>
        public int ConnectionID
        {
            get { return connectionID; }
            set { connectionID = value; }
        }
        private int templateID;
        /// <summary>
        /// 模板id
        /// </summary>
        public int TemplateID
        {
            get { return templateID; }
            set { templateID = value; }
        }
    }
}
