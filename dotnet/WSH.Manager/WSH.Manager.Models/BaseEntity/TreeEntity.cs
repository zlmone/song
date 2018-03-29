using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WSH.Manager.Models
{
    public class TreeEntity : Entity
    {
        /// <summary>
        /// 父节点Id
        /// </summary>
        [JsonProperty(PropertyName="_parentId")]
        public virtual int ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 层级编码
        /// </summary>
        public virtual string LevelCode { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public virtual int Level { get; set; }

        /// <summary>
        /// 设置层级信息
        /// </summary>
        /// <param name="parentNode"></param>
        public void SetLevelInfo(TreeEntity parentNode)
        {
            this.Level = parentNode.Level + 1;
            if (this.ParentId > 0)
            {
                this.LevelCode = parentNode.LevelCode+"." +this.Id;
            }
            else {
                this.LevelCode = this.Id.ToString();
            }
        }
    }
}
