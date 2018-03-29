using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using WSH.Web.Common;

namespace WSH.WebForm.Controls
{
    public class ZTreeAsync
    {
        private bool _Enable=false;
        /// <summary>
        /// 是否启动异步加载节点
        /// </summary>
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
        private string _Url;
        /// <summary>
        /// 异步请求路径
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        private string[] _AutoParam;
        /// <summary>
        /// 自动参数（可以为id=pid，表示参数名为pid但参数值为原始数据的id）
        /// </summary>
        public string[] AutoParam
        {
            get { return _AutoParam; }
            set { _AutoParam = value; }
        }
        private Dictionary<string, string> _OtherParam=new Dictionary<string,string>();
        /// <summary>
        /// 外部参数
        /// </summary>
        public Dictionary<string, string> OtherParam
        {
            get { return _OtherParam; }
            set { _OtherParam = value; }
        }
        private string _DataFilter;
        /// <summary>
        /// 返回数据处理的js函数(treeID,parentNode,childNodes)
        /// </summary>
        public string DataFilter
        {
            get { return _DataFilter; }
            set { _DataFilter = value; }
        }
        private AjaxDataType _DataType= AjaxDataType.Text;
        [Description("异步返回数据类型")]
        public AjaxDataType DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }
        private AjaxType _Type= AjaxType.POST;
        /// <summary>
        /// 异步加载请求模式(默认：post)
        /// </summary>
        public AjaxType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}
