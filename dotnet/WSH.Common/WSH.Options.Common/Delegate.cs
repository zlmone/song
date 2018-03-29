using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    /// <summary>
    /// 无参数无返回值的方法委托
    /// </summary>
    public delegate void Action();
    
    /// <summary>
    /// 进度事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ProgressHandler(object sender, ProgressEventArgs e);
    /// <summary>
    /// 下载进度委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DownloadProgressHandler(object sender, DownloadEventArgs e);
    /// <summary>
    /// 自定义验证
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="result"></param>
    public delegate void CustomValidateHanlder(object sender, ValidResult result);
}
