using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Web.UI.Design;
using WSH.Web.Common;

namespace WSH.WebForm.Controls
{
    [ToolboxItem(false)]
    [ParseChildren(true, "Items")]
    [PersistChildren(false)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeItem
    {
        private List<TreeItem> items;
        [Description("子节点集合")]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [TypeConverter(typeof(CollectionConverter))]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<TreeItem> Items
        {
            get { if (items == null) { this.items = new List<TreeItem>(); }; return items; }
        }
        private string _ID;
        [Description("可绑定节点id（注：此id并不是dom节点的id，而是节点的数据id，与value属性性质相同）")]
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _PID;
        [Description("父节点ID")]
        public string PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
        private string _Text;
        [Description("显示的名称")]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        private string _Value;
        [Description("节点的属性值")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private Dictionary<string, object> _Attributes;
        [Description("自定义属性：可在js用[节点对象.属性名]获得对应的属性值")]
        [TypeConverter(typeof(Dictionary<string,object>))]
        public Dictionary<string, object> Attributes
        {
            get { if (_Attributes == null) { this._Attributes = new Dictionary<string, object>(); }; return _Attributes; }
        }
        private bool _IsOpen = true;
        [Description("是否展开节点")]
        public bool IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; }
        }
        private bool? _IsChecked;
        [Description("选择框的值")]
        public bool? IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; }
        }
        private bool? _NoCheck;
        [Description("是否显示选择框")]
        public bool? NoCheck
        {
            get { return _NoCheck; }
            set { _NoCheck = value; }
        }
        private bool? _IsLeaf;
        [Description("是否是叶子节点")]
        public bool? IsLeaf
        {
            get { return _IsLeaf; }
            set { _IsLeaf = value; }
        }
        private string _Icon;
        [Description("节点图标的路径")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        [UrlProperty(WebConsts.ImgFilter)]
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }
        private string _IconClass;
        [Description("节点图标的className")]
        public string IconClass
        {
            get { return _IconClass; }
            set { _IconClass = value; }
        }
        private string _IconOpen;
        [Description("节点为打开状态时的图标路径")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        [UrlProperty(WebConsts.ImgFilter)]
        public string IconOpen
        {
            get { return _IconOpen; }
            set { _IconOpen = value; }
        }
        private string _IconClose;
        [Description("节点为关闭状态时的图标路径")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        [UrlProperty(WebConsts.ImgFilter)]
        public string IconClose
        {
            get { return _IconClose; }
            set { _IconClose = value; }
        }
        private string _Target;
        [Description("导航的类型")]
        public string Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        private string _Url;
        [Description("导航的路径")]
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
    }
}
