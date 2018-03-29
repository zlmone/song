using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Drawing.Design;
using WSH.Web.Common;
using WSH.Common;

namespace WSH.WebForm.Controls
{
    [ToolboxItem(false)]
    [ParseChildren(true, "Text")]
    [PersistChildren(false)]
    public class ToolbarButton : ToolbarItem
    {
        private string text;
        [Description("按钮的文本值")]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string iD;
        [Description("唯一标示ID")]
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private Icons icon = Icons.None;
        [Description("图标的路径")]
        [UrlProperty]
        [Editor(typeof(ImageUrlEditor),typeof(UITypeEditor))]
        public Icons Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        private string iconClass;
        [Description("图标的样式名")]
        public string IconClass
        {

            get { return iconClass; }
            set { iconClass = value; }
        }
        private string iconUrl;
        [Description("图标的地址")]
        [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
        [UrlProperty(WebConsts.ImgFilter)]
        public string IconUrl
        {
            get { return iconUrl; }
            set { iconUrl = value; }
        }
        private bool enabled = true;
        [Description("是否激活菜单项")]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        private Menu menu;
        [Description("菜单")]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        [PersistenceMode( PersistenceMode.InnerProperty)]
        public Menu Menu
        {
            get { return menu; }
            set { menu = value; }
        }
        //private string target;
        //[Description("导航的类型")]
        //public string Target
        //{
        //    get { return target; }
        //    set { target = value;  }
        //}
        //private string url;
        //[Description("导航的路径")]
        //public string Url
        //{
        //    get { return url; }
        //    set { url = value; }
        //}
        private string isPostBack;
        [Description("是否回发到服务器，配合服务器事件使用")]
        public string IsPostBack
        {
            get { return isPostBack; }
            set { isPostBack = value; }
        }
        private string onClientClick;
        [Description("客户端单击执行的函数名")]
        public string OnClientClick
        {
            get { return onClientClick; }
            set { onClientClick = value; }
        }
        public delegate void ToolbarButtonHandler(object sender,string id);
        [Description("服务端单击事件")]
        public event ToolbarButtonHandler OnClick;
        public ToolbarButton() { }
        public ToolbarButton(string text)
        {
            this.text = text;
        }
    }
}
