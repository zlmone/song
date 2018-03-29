using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.CodeBuilder.Common
{
    public class ColumnInfo
    {
        /// <summary>
        /// 字段编号
        /// </summary>
        public int Seqno { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 字段说明
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 是否自增长
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsDataKey { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        public int Precision { get; set; }
        /// <summary>
        /// 小数位
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool IsNullable { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        public string Remark { get; set; }

    }
    public class DataKeyInfo
    {
        public string DataType { get; set; }
        public string Field { get; set; }
    }
}
