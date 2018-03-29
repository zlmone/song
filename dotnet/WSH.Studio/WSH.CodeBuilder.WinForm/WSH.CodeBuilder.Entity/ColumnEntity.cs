using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.Common;

namespace WSH.CodeBuilder.Entity
{
    [Serializable]
    public class ColumnEntity : WSH.CodeBuilder.Entity.Entity
    {
        private int tableID;
        /// <summary>
        /// TableID
        /// </summary>
        public int TableID
        {
            get { return tableID; }
            set { tableID = value; }
        }
        private string field;
        /// <summary>
        /// Field
        /// </summary>
        public string Field
        {
            get { return field; }
            set { field = value; }
        }
        private string display;
        /// <summary>
        /// Display
        /// </summary>
        public string Display
        {
            get { return display; }
            set { display = value; }
        }
        private string dataType;
        /// <summary>
        /// DataType
        /// </summary>
        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        private int length;
        /// <summary>
        /// Length
        /// </summary>
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        private EditorType editorType;
        /// <summary>
        /// EditorType
        /// </summary>
        public EditorType EditorType
        {
            get { return editorType; }
            set { editorType = value; }
        }
        private bool sortable;
        /// <summary>
        /// Sortable
        /// </summary>
        public bool Sortable
        {
            get { return sortable; }
            set { sortable = value; }
        }
        private bool queryable;
        /// <summary>
        /// Queryable
        /// </summary>
        public bool Queryable
        {
            get { return queryable; }
            set { queryable = value; }
        }
        private bool hidden;
        /// <summary>
        /// Hidden
        /// </summary>
        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }
        private bool required;
        /// <summary>
        /// Required
        /// </summary>
        public bool Required
        {
            get { return required; }
            set { required = value; }
        }
        private int width;
        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private string formatString;
        /// <summary>
        /// FormatString
        /// </summary>
        public string FormatString
        {
            get { return formatString; }
            set { formatString = value; }
        }
        private AlignType align;
        /// <summary>
        /// Align
        /// </summary>
        public AlignType Align
        {
            get { return align; }
            set { align = value; }
        }
        private string defaultValue;

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
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
        private int sortID;
        /// <summary>
        /// SortID
        /// </summary>
        public int SortID
        {
            get { return sortID; }
            set { sortID = value; }
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
        private bool isDataKey;

        public bool IsDataKey
        {
            get { return isDataKey; }
            set { isDataKey = value; }
        }
        private int precision;

        public int Precision
        {
            get { return precision; }
            set { precision = value; }
        }
    }
}
