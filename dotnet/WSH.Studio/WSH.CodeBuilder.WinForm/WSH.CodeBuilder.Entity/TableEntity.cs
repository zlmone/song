using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.Options.Common;
using WSH.Common;

namespace WSH.CodeBuilder.Entity
{
    [Serializable]
    public class TableEntity : WSH.CodeBuilder.Entity.Entity
    {
        
        private int projectID;
        /// <summary>
        /// ProjectID
        /// </summary>
        public int ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
        private string tableName;
        /// <summary>
        /// TableName
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        private string dataKey;
        /// <summary>
        /// DataKey
        /// </summary>
        public string DataKey
        {
            get { return dataKey; }
            set { dataKey = value; }
        }
        private DataKeyType dataKeyType;
        /// <summary>
        /// DataKeyType
        /// </summary>
        public DataKeyType DataKeyType
        {
            get { return dataKeyType; }
            set { dataKeyType = value; }
        }
        private string defaultSortName;
        /// <summary>
        /// DefaultSortName
        /// </summary>
        public string DefaultSortName
        {
            get { return defaultSortName; }
            set { defaultSortName = value; }
        }
        private SortMode defaultSortMode;
        /// <summary>
        /// DefaultSortMode
        /// </summary>
        public SortMode DefaultSortMode
        {
            get { return defaultSortMode; }
            set { defaultSortMode = value; }
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
        private bool enabled;
        /// <summary>
        /// Enable
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

    }
}
