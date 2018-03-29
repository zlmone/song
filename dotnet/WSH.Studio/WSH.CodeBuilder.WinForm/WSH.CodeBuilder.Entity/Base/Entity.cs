using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.CodeBuilder.Entity
{
    [Serializable]
    public class Entity
    {
        private int id;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private DateTime editTime;
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime EditTime
        {
            get { return editTime; }
            set { editTime = value; }
        }
    }
}
