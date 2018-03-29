using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Web.UI.Design;
using WSH.Web.Common;
using WSH.Common;

namespace WSH.WebForm.Controls
{
    [ToolboxItem(false)]
    [ParseChildren(true, "Items")]
    [PersistChildren(false)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MenuItem
    {
        private List<MenuItem> items;
        [Description("菜单项子项集合")]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [TypeConverter(typeof(CollectionConverter))]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<MenuItem> Items
        {
            get { if (items == null) { this.items = new List<MenuItem>(); }; return items; }
        }
        private string _ID;
        [Description("菜单项数据id")]
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Text;
        [Description("显示的名称")]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        private string _Value;
        [Description("菜单项存储的值")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private int itemsWidth=120;
        [Description("子菜单项的宽度")]
        public int ItemsWidth
        {
            get { return itemsWidth; }
            set { itemsWidth = value; }
        }
        private Icons _Icon= Icons.None;
        [Description("菜单项的图标")]
        public Icons Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }
         
        private string iconUrl;
        [Description("菜单项图标的路径")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        [UrlProperty(WebConsts.ImgFilter)]
        public string IconUrl
        {
            get { return iconUrl; }
            set { iconUrl = value; }
        }
        private string _IconClass;
        [Description("菜单项图标的className")]
        public string IconClass
        {
            get { return _IconClass; }
            set { _IconClass = value; }
        }
        private bool enabled = true;
        [Description("是否激活菜单项")]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        private string _OnClientClick;
        [Description("菜单项客户端的单击函数")]
        public string OnClientClick
        {
            get { return _OnClientClick; }
            set { _OnClientClick = value; }
        }
    }
}
