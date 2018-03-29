using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using WSH.Common;

namespace WSH.Web.Mvc.Controls.EasyUI
{
    public class EasyColumn
    {
        public EasyColumn()
        {
            this.Align = AlignType.Left;
            this.Width = 100;
        }
        /// <summary>
        /// 是否为复选框的列
        /// </summary>
        public virtual bool CheckBox { get; set; }
        /// <summary>
        /// 映射的数据列名
        /// </summary>
        public virtual string Field { get; set; }
        /// <summary>
        /// 显示的列标题
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public virtual int Width { get; set; }
        /// <summary>
        /// 列的对其方式
        /// </summary>
        public virtual AlignType Align { get; set; }
        /// <summary>
        /// 是否隐藏列
        /// </summary>
        public virtual bool? Hidden { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public virtual bool? Sortable { get; set; }
        /// <summary>
        /// 是否可以改变列宽
        /// </summary>
        public virtual bool? Resizable { get; set; }
        /// <summary>
        /// 列渲染的函数
        /// </summary>
        public virtual string Formatter { get; set; }
        /// <summary>
        /// 合并列的行数
        /// </summary>
        public virtual int? Rowspan { get; set; }
        /// <summary>
        /// 合并列的列数
        /// </summary>
        public virtual int? Colspan { get; set; }

    }
}
