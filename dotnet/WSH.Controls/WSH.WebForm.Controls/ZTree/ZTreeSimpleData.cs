using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WebForm.Controls
{
    public class ZTreeSimpleData
    {
        private bool _Enable = false;
        /// <summary>
        /// 是否采用简单的数据模式（避免转换复杂的Nodes嵌套）
        /// </summary>
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
        private string _RootPID = "-1";
        /// <summary>
        /// 根节点数据（默认：-1）
        /// </summary>
        public string RootPID
        {
            get { return _RootPID; }
            set { _RootPID = value; }
        }
        private string _IDKey="id";
        /// <summary>
        /// 主键属性名称（默认：id）
        /// </summary>
        public string IDKey
        {
            get { return _IDKey; }
            set { _IDKey = value; }
        }
        private string _PIDKey = "pid";
        /// <summary>
        /// 父节点属性名称（默认：pid）
        /// </summary>
        public string PIDKey
        {
            get { return _PIDKey; }
            set { _PIDKey = value; }
        }

        private string _TextField;
        /// <summary>
        /// 指定数据源绑哪个字段绑定Text
        /// </summary>
        public string TextField
        {
            get { return _TextField; }
            set { _TextField = value; }
        }
        private string _ValueField;

        public string ValueField
        {
            get { return _ValueField; }
            set { _ValueField = value; }
        }
        private Dictionary<string, string> _AttributeFields;
        /// <summary>
        /// 指定数据源哪些字段为自定义属性值
        /// key:数据库中的字段，value:树节点的属性值
        /// </summary>
        public Dictionary<string, string> AttributeFields
        {
            get {if(_AttributeFields==null){this._AttributeFields= new Dictionary<string, string>();}; return _AttributeFields; }
        }

    }
}
