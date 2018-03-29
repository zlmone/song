using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Web.Mvc.Controls
{
    public interface IControl<T>
    {
        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        T Width(int width);
        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        T Height(int height);
        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        T Width(string width);
        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        T Height(string height);
    }
}
