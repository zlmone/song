using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.CodeBuilder.Common
{
    public enum DataType
    {
        Object,
        String,
        Binary,
        Boolean,
        DateTime,
        Currency,
        Xml,
        Float,
        Decimal,
        Guid,
        Byte,
        SmallInt,
        Int,
        BigInt
    }
    //public enum DataTypeLang { 
    //    sqlserver,
    //    oracle,
    //    mysql,
    //    access,
    //    sqlite,
    //    csharp,
    //    ado,
    //    java
    //}
    public class DataTypeMapping
    {
        public DataTypeMapping()
        {
            this.Languages = new List<DataTypeLanguage>();
        }
        public DataType DataType { get; set; }
        public List<DataTypeLanguage> Languages { get; set; }
    }
    public class DataTypeLanguage
    {
        public DataTypeLanguage()
        {
            DataTypeHelper = new List<string>();
            ReplaceTypes = new List<string>();
        }
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 替换的数据类型
        /// </summary>
        public List<string> ReplaceTypes { get; set; }
        public string ReplaceLength { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public List<string> DataTypeHelper { get; set; }
    }
}
