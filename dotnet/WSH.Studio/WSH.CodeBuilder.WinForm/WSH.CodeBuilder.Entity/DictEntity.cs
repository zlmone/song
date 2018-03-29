using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.CodeBuilder.Entity
{
    public enum DictType { 
        None,
        ServerTemplatePath
    }
    public class DictEntity : WSH.CodeBuilder.Entity.Entity
    {
        private string dictCode;
        /// <summary>
        /// 字典编码
        /// </summary>
        public string DictCode
        {
            get { return dictCode; }
            set { dictCode = value; }
        }
        private string dictName;
        /// <summary>
        /// 字典名称
        /// </summary>
        public string DictName
        {
            get { return dictName; }
            set { dictName = value; }
        }
        private string dictValue;
        /// <summary>
        /// 字典值
        /// </summary>
        public string DictValue
        {
            get { return dictValue; }
            set { dictValue = value; }
        }
        private string attr;
        /// <summary>
        /// 属性说明
        /// </summary>
        public string Attr
        {
            get { return attr; }
            set { attr = value; }
        }
    }
}
