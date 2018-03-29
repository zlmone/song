using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSH.Manager.Models
{
	[Table("Urls")]
    public class UrlsEntity : Entity
    {
    	/// <summary>
        /// 标题
        /// </summary>
        [Required,StringLength(300)]
        public virtual string Title { get; set; }
    	/// <summary>
        /// 网页地址
        /// </summary>
        [Required,StringLength(500)]
        public virtual string Url { get; set; }
    	/// <summary>
        /// 图标地址
        /// </summary>
        [StringLength(500)]
        public virtual string IconUrl { get; set; }
    	/// <summary>
        /// 图标名
        /// </summary>
        
        public virtual string IconName { get; set; }
    	/// <summary>
        /// 备注说明
        /// </summary>
        [StringLength(500)]
        public virtual string Remark { get; set; }
    	/// <summary>
        /// 点击量
        /// </summary>
        
        public virtual int Hits { get; set; }
        /// <summary>
        /// 网页编码
        /// </summary>
        public virtual string Encoding { get; set; }
    	/// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public virtual DateTime CreateTime { get; set; }
    }
}

