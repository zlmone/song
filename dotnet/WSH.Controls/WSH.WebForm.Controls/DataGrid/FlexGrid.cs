    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSH.Web.Common;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Web.UI.Design;
using WSH.Common;
using WSH.WebForm.Common;


namespace WSH.WebForm.Controls
{
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ToolboxData("<{0}:FlexGrid runat=server></{0}:FlexGrid>")]
    //CompositeControl
        // System.Web.UI.Control
    public class FlexGrid : CompositeControl
    {
        public FlexGrid() { }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Table;
            }
        }
        //private static string TagTemplate = "<table id=\"{0}\" class=\"flexigrid\"></table>";
        #region 属性集合
        private List<GridColumn> columns;
        [Description("列集合")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<GridColumn> Columns
        {
            get { if (columns == null) { this.columns = new List<GridColumn>(); } return columns; }
        }
        private List<ToolbarItem> buttons;
        [Description("按钮集合")]
        [PersistenceMode( PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content)]
        public List<ToolbarItem> Buttons
        {
            get { if (buttons == null) { this.buttons = new List<ToolbarItem>(); } return buttons; }
        }
        private string url;
        [Category("基本属性")]
        [Description("Ajax获取数据路径")]
        [Editor(typeof(UrlEditor),typeof(UITypeEditor))]
        [UrlProperty(WebConsts.PageFilter)]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private AjaxDataType dataType= AjaxDataType.Json;
        [Category("基本属性")]
        [Description("Ajax数据类型")]
        public AjaxDataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        private bool usePager = true;
        [Category("基本属性")]
        [Description("是否使用分页")]
        public bool UsePager
        {
            get { return usePager; }
            set { usePager = value; }
        }
        private int pageSize;
        [Category("基本属性")]
        [Description("分页页大小")]
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        private string title;
        [Category("基本属性")]
        [Description("标题文字")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        //private string width;
        //[Category("基本属性")]
        //[Description("宽度")]
        //public string Width
        //{
        //    get { return width; }
        //    set { width = value; }
        //}
        //private string height;
        //[Category("基本属性")]
        //[Description("高度")]
        //public string Height
        //{
        //    get { return height; }
        //    set { height = value; }
        //}
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            // writer.Write(string.Format(TagTemplate,this.ID));
            writer.AddAttribute("id",this.ID);
            writer.AddAttribute("class","flexigrid");
            base.Render(writer);
        }
        protected override void OnPreRender(EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(Script.BeginTag);
           // sb.Append("$(function(){");
            sb.AppendLine("var colModel=[");
            for (int i = 0; i < columns.Count; i++)
            {
                GridColumn col = columns[i];
                sb.Append("{");
                sb.AppendFormat("name:\"{0}\"",col.Field);
                sb.AppendFormat(",display:\"{0}\"",col.Header);
                sb.Append(",width:" + col.Width);
                sb.AppendFormat(",align:\"{0}\"", WSH.Web.Common.Helper.ClientHelper.GetEnum(col.Align));
                sb.Append(",sortable:"+WSH.Web.Common.Helper.ClientHelper.GetBool(col.Sortable));
                if(col.Hidden){
                    sb.Append(",hide:"+WSH.Web.Common.Helper.ClientHelper.GetBool(col.Hidden));
                }
                if (!string.IsNullOrEmpty(col.Renderer))
                {
                    sb.Append(",process:" + col.Renderer);
                }
                sb.Append("}");
                if(i<columns.Count-1){
                    sb.Append(",");
                }
                sb.Append(Script.Line);
            }
            sb.AppendLine("];");
            sb.Append("$(\"#"+this.ID+"\").flexigrid({");
            sb.Append("colModel:colModel");
            if(this.Buttons.Count>0){
                sb.Append(",buttons:[");
                for (int i = 0; i < this.Buttons.Count; i++)
                {
                    ToolbarItem item = Buttons[i];
                    sb.Append("{");
                    if (item is ToolbarButton)
                    {
                        ToolbarButton btn = item as ToolbarButton;
                        sb.AppendFormat("displayname:\"{0}\"", btn.Text);
                        if (!string.IsNullOrEmpty(btn.ID))
                        {
                            sb.AppendFormat(",name:\"{0}\"", btn.ID);
                        }
                        if (btn.Icon != Icons.None || !string.IsNullOrEmpty(btn.IconClass))
                        {
                            sb.AppendFormat(",bclass:\"{0}\"", btn.Icon == Icons.None ? btn.IconClass : WSH.Web.Common.Helper.ClientHelper.GetIcon(btn.Icon));
                        }
                        if (!string.IsNullOrEmpty(btn.OnClientClick))
                        {
                            sb.AppendFormat(",onpress:{0}", btn.OnClientClick);
                        }
                    }else if(item is Separator){
                        Separator sep = item as Separator;
                        sb.Append("separator:true");
                    }
                    sb.Append("}");
                    if(i<Buttons.Count-1){
                        sb.Append(",");
                    }
                }
                sb.Append("]");
            }
           
            sb.AppendFormat(",url:{0}",(string.IsNullOrEmpty(Url) ? "cmp.getDefaultUrl()" : "\""+Url+"\""));
            sb.AppendFormat(",dataType:\"{0}\"",(DataType== AjaxDataType.Xml ? "xml" : "json"));
            sb.Append(",usepager:"+WSH.Web.Common.Helper.ClientHelper.GetBool(usePager));
            if(!string.IsNullOrEmpty(title)){
                sb.AppendFormat(",title:\"{0}\"",title);
            }
            if (!string.IsNullOrEmpty(Width.ToString()))
            {
                sb.AppendFormat(",width:\"{0}\"", Width);
            }
            if (!string.IsNullOrEmpty(Height.ToString()))
            {
                sb.AppendFormat(",height:\"{0}\"", Height.ToString());
            }
            if(PageSize>0){
                sb.Append(",rp:"+PageSize);
            }
            sb.AppendLine("});");
            //sb.Append("});");
            //sb.AppendLine(Script.EndTag);
            Script.RegisterStartupScript(Page, "FlexGrid-" + this.ID, sb.ToString());
            base.OnPreRender(e);
        }
    }
}
