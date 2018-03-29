using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Manager.Models.BaseEntity
{
    public class BaseEntity : Entity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime
        {
            get;
            set;
        }
    }
}
