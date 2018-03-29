using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.DataAccess.SongData.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : System.Attribute
    {
        public FieldAttribute()
        {
            IsMapping = true;
        }
        /// <summary>
        /// 字段是否映射数据库
        /// </summary>
        public bool IsMapping { get; set; }
        /// <summary>
        /// 数据库字段名称（映射）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否为数据库主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 是否为数据库的标识字段（自动增长）
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 指示字段是否为存储过程中输出的参数
        /// （默认为false)
        /// </summary>
        public bool IsOutParam { get; set; }

        /// <summary>
        /// 指示字段是否为存储过程中输入的参数
        /// （默认为false)
        /// </summary>
        public bool IsInParam { get; set; }
    }
}
