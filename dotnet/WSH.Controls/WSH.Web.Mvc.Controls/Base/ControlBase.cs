using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Web.Common;

namespace WSH.Web.Mvc.Controls
{
    public class ControlBase<T> : HtmlBuilder, IControl<T>
    {
        #region 构造方法
        public ControlBase() { }
        public ControlBase(string id)
        {
            this.ID = id;
        }
        /// <summary>
        /// 返回组件
        /// </summary>
        protected T This()
        {
            return (T)((object)this);
        }
        #endregion

        #region 设置高宽
        public T Width(int width)
        {
            this.AddStyle("width", width + "px");
            return This();
        }

        public T Height(int height)
        {
            this.AddStyle("height", height + "px");
            return This();
        }
        public T Width(string width)
        {
            this.AddStyle("width", width);
            return This();
        }

        public T Height(string height)
        {
            this.AddStyle("height", height);
            return This();
        }
        #endregion

    }
}
