using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class Grid : System.Web.UI.UserControl
{
    #region 公共属性
    private Dictionary<string, object> editValue;

    public Dictionary<string, object> EditValue
    {
        get { return editValue; }
        set { editValue = value; }
    }
    private string xmlPath;

    public string XmlPath
    {
        get { return xmlPath; }
        set { xmlPath = value; }
    }
    private int totalCount;

    public int TotalCount
    {
        get { return totalCount; }
        set { totalCount = value; }
    }
    //数据源
    private object dataSource;

    public object DataSource
    {
        get { return dataSource; }
        set { dataSource = value; }
    }
    private string pageClass;

    public string PageClass
    {
        get { return pageClass; }
        set { pageClass = value; }
    }
    //是否全选
    private bool showCheckColumn = true;

    public bool ShowCheckColumn
    {
        get { return showCheckColumn; }
        set { showCheckColumn = value; }
    }
    //是否列头排序
    private bool showColumnSort = true;

    public bool ShowColumnSort
    {
        get { return showColumnSort; }
        set { showColumnSort = value; }
    }

    //列头信息
    public List<ColInfo> ColList
    {
        get
        {
            return (ViewState["ColInfo"] as List<ColInfo>);
        }
        set
        {
            ViewState["ColInfo"] = value;
        }
    }
    //返回全选列选中的主键值
    public List<string> GetMultiId
    {
        get
        {
            if (ShowCheckColumn == true)
            {
                List<string> MultiId = new List<string>();
                for (int i = 0; i < this.WshPwtGv.Rows.Count; i++)
                {
                    TableCellCollection cel = this.WshPwtGv.Rows[i].Cells;
                    HtmlInputCheckBox cb = (HtmlInputCheckBox)cel[0].FindControl("MultiCheck");
                    if (cb.Checked)
                    {
                        string datakey = this.WshPwtGv.DataKeys[i].Value.ToString();
                        MultiId.Add(datakey);
                    }
                }
                return MultiId;
            }
            else
            {
                return null;
            }
        }
    }

    //给添加行的控件赋初始值
    private List<CellValue> setCellValue;

    public List<CellValue> SetCellValue
    {
        get { return setCellValue; }
        set { setCellValue = value; }
    }
    #endregion

    #region 私有属性
    //页大小
    public int PageSize
    {
        set { this.pager.PageSize = value; }
        get { return this.pager.PageSize; }
    }
    //排序模式
    private string SortMode
    {
        get { return ViewState["SortMode"] == null ? "" : ViewState["SortMode"].ToString(); }
        set { ViewState["SortMode"] = value; }
    }
    //排序模式
    private string SortName
    {
        get { return ViewState["SortName"] == null ? "" : ViewState["SortName"].ToString(); }
        set { ViewState["SortName"] = value; }
    }
    //排序模式
    private string DataKey
    {
        get { return ViewState["DataKey"] == null ? "" : ViewState["DataKey"].ToString(); }
        set { ViewState["DataKey"] = value; }
    }
    //样式配置
    private GridStyleConfig cssConfig;

    protected GridStyleConfig CssConfig
    {
        get { return cssConfig; }
        set { cssConfig = value; }
    }
    #endregion

    #region 自定义事件
    //双击行的js事件
    string jSRowDBClick;

    public string JSRowDBClick
    {
        get { return jSRowDBClick; }
        set { jSRowDBClick = value; }
    }
    //双击行的js事件
    string jSRowClick;

    public string JSRowClick
    {
        get { return jSRowClick; }
        set { jSRowClick = value; }
    }
    //定义委托

    public delegate void CellEditEventHandler(object sender, CellEditEventArg e);
    public delegate void RowBindEventHandler(object sender, RowBindEventArg e);
    public delegate void PageBindEventHandler(object sender, PageConfig e);

    //自定义在线添加事件

    public event CellEditEventHandler OnCellEdit;
    public event RowBindEventHandler OnRowBind;
    public event PageBindEventHandler OnPageBind;
    #endregion

    #region 得到列的配置信息
    private List<ColInfo> GetColInfo()
    {
        List<ColInfo> lInfo = new List<ColInfo>();
        XmlDocument XDoc = new XmlDocument();
        try
        {
            XDoc.Load(Server.MapPath(this.XmlPath));
        }
        catch
        {
            throw new DataNotFoundException("是否设置了xml列的配置文件！");
        }
        XmlElement XElement = XDoc.DocumentElement;
        SortName = XElement.Attributes["SortDefault"].Value;
        DataKey = XElement.Attributes["DataKey"].Value;

        foreach (XmlNode node in XElement.ChildNodes)
        {
            ColInfo col = new ColInfo();
            col.Format = node.Attributes["Format"] == null ? "" : node.Attributes["Format"].Value;

            col.Width = Convert.ToInt32(node.Attributes["Width"].Value == "" ? null : node.Attributes["Width"].Value);
                col.Field = node.Attributes["Field"].Value;
                col.Caption = node.Attributes["Caption"].Value;
                col.Sort = Convert.ToBoolean(node.Attributes["Sort"] == null ? "true" : node.Attributes["Sort"].Value);
                switch (node.Attributes["EditType"].Value)
                {
                    case "text": col.EditType = Enums.ControlType.Text;
                        break;
                    case "date": col.EditType = Enums.ControlType.Date;
                        break;
                    case "datetime": col.EditType = Enums.ControlType.DateTime;
                        break;
                    case "int": col.EditType = Enums.ControlType.Int;
                        break;
                    case "float": col.EditType = Enums.ControlType.Float;
                        break;
                    case "combox": col.EditType = Enums.ControlType.Combobox;
                        break;
                    case "textarea": col.EditType = Enums.ControlType.TextArea;
                        break;
                    default: col.EditType = Enums.ControlType.None;
                        break;
                }
                switch (node.Attributes["Type"].Value)
                {
                    case "link": col.Type = Enums.ColumnType.Link;
                        break;
                    default: col.Type = Enums.ColumnType.Default;
                        break;
                }
          
            
            col.Truncate = Convert.ToInt32(node.Attributes["Truncate"].Value == "" ? null : node.Attributes["Truncate"].Value);
            col.Url = node.Attributes["Url"] == null ? "" : (node.Attributes["Url"].Value.Trim() == "" ? "javascript:void(0)" : node.Attributes["Url"].Value);
            lInfo.Add(col);
        }
        return lInfo;
    }
    #endregion

    #region 加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否是ajax提交模式
        if (!string.IsNullOrEmpty(Request.Params["CellEditAjaxRequest"]))
        {
            CellEdit();
        }
        else
        {
            if (CssConfig == null)
            {
                CssConfig = new GridStyleConfig();
            }
            //设置加载的js
            SetReadyScript();

            if (ShowColumnSort == true)
            {
                WshPwtGv.Sorting += new GridViewSortEventHandler(WshPwtGv_Sorting);
                WshPwtGv.AllowSorting = true;
            }
            WshPwtGv.RowDataBound += new GridViewRowEventHandler(WshPwtGv_RowDataBound);
            this.pager.OnPage += new UserControls_Pager.PageEventHandler(pager_OnPage);
            WshPwtGv.CssClass = CssConfig.GridCss;

            if (!IsPostBack)
            {
                this.pagePanal.Attributes.Add("class", "pager-ext  " + (this.PageClass == null ? "" : this.PageClass));
            
                this.LitSelectedClass.Text = "<input type='hidden' id='HideSelectedClass' value='" + CssConfig.RowClickCss + "'></input>";
                ViewState["SortMode"] = "desc";
                ViewState["ColInfo"] = GetColInfo();
                //构建列头信息
                WshPwtGv.AutoGenerateColumns = false;
                if (ColList != null && ColList.Count > 0)
                {
                    foreach (ColInfo col in ColList)
                    {
                        if (col.Type == Enums.ColumnType.Default)
                        {
                            BoundField bf = new BoundField();
                            bf.DataField = col.Field;
                            if (col.Sort)
                            {
                                bf.SortExpression = col.Field;
                            }
                            bf.HeaderText = col.Caption;
                            if (!string.IsNullOrEmpty(col.Format))
                            {
                                bf.DataFormatString = col.Format;
                            }
                            if (col.Width> 0)
                            {
                                bf.HeaderStyle.Width = col.Width;
                            }
                            WshPwtGv.Columns.Add(bf);
                        }
                    }
                }
                //判断该隐藏的和该显示的
                if (ShowCheckColumn == false)
                {
                    this.WshPwtGv.Columns[0].Visible = false;
                }
                
            }
        }
    }

    void pager_OnPage(object sender, PageConfig pc)
    {
        PageBind(pc.PageSize,pc.PageIndex);
    }
    #endregion

    #region 绑定加载的js
    public void SetReadyScript()
    {
        //if (!this.Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "WSHGridScript"))
        //{
        //    this.Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "WSHGridScript", Page.ResolveUrl("~/js/Grid.js"));
        //}
        ////if (this.Page.Header.FindControl("WshPwtGridCss") == null)
        //{
        //    HtmlLink gridcss = new HtmlLink();
        //    gridcss.ID = "WshPwtGridCss";
        //    gridcss.Attributes.Add("type", "text/css");
        //    gridcss.Attributes.Add("rel", "stylesheet");
        //    gridcss.Attributes.Add("href", "~/css/Grid.css");
        //    this.Page.Header.Controls.Add(gridcss);
        //}
        StringBuilder sb = new StringBuilder();
       // sb.AppendFormat("showCheckColumn:{0},", ShowCheckColumn == true ? "true" : "false");
        sb.AppendFormat("evenClass:'{0}',", CssConfig.EvenCss);
        sb.AppendFormat("oddClass:'{0}',", CssConfig.OddCss);
        sb.AppendFormat("hoverClass:'{0}',", CssConfig.RowMouseCss);
        sb.AppendFormat("clickClass:'{0}',", CssConfig.RowClickCss);
        sb.AppendFormat("click:{0},", string.IsNullOrEmpty(JSRowClick) ? "null" : JSRowClick.Replace("()", ""));
        sb.AppendFormat("dblclick:{0},", string.IsNullOrEmpty(JSRowDBClick) ? "null" : JSRowDBClick.Replace("()", ""));
        sb.AppendFormat("cellEdit:{0}", OnCellEdit == null ? "false" : "true");
        string jQuery = "<script>$(function(){$('#" + WshPwtGv.ClientID + "').setGridStyle({" + sb.ToString() + "});});</script>";
        Literal lit = new Literal();
        lit.Text = jQuery;
        this.Parent.Page.Header.Controls.Add(lit);
        string  gid=this.ID;
        string gcid = this.WshPwtGv.ClientID;
        string client = string.Format("<script>var {0}=new Object();", gid);
        client += gid+".getmid=function(){return $('#"+gcid+"').getMultiId();};";
        client += gid+".getid=function(){return $('#"+gcid+"').getSelectId();};";
        client += gid+".getcell=function(key,col){return $('#"+gcid+"').getCellValue(key,col);};";
        client += "</script>";
        Literal l = new Literal();
        l.Text = client;
        this.Parent.Page.Header.Controls.Add(l);

    }
    #endregion

    #region 修改单元格的方法
    private void CellEdit()
    {
        GetColInfo();
        string RowDataKey = Request.Params["dataKey"];
        string EditValue = Request.Params["value"];
        string EditColName = Request.Params["colName"];
        string EditCellIndex = Request.Params["cellIndex"];

        CellEditEventArg Args = new CellEditEventArg();
        Args.ColName = EditColName;
        Args.Value = EditValue;
        Args.DataKey = RowDataKey;
        Args.KeyName = this.DataKey;
        Args.CellIndex = Convert.ToInt32(EditCellIndex);
        if (OnCellEdit != null)
        {
            OnCellEdit(this, Args);
        }
        Response.Clear();
        Response.ContentType = "application/json";
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        sb.Append("\"error\":" + (Args.Error == null ? "null" : "\"" + Args.Error + "\""));
        sb.Append("}");
        Response.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }
    #endregion


    #region 行绑定事件
    void WshPwtGv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        List<ColInfo> colLists = this.ColList;
        if (colLists == null)
        {
            colLists = GetColInfo();
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            TableCellCollection cells = e.Row.Cells;
            for (int j = 1; j < cells.Count; j++)
            {
                //cells[j].Attributes.Add("ColName", colLists[j - 1].FieldName);
                if (colLists[j - 1].Sort==false)
                {
                    Literal lSort = new Literal();
                    lSort.Text = colLists[j - 1].Caption;
                    cells[j].Controls.Add(lSort);
                }
                if (WshPwtGv.Columns[j].SortExpression == this.SortName)
                {
                    Image sortimg = new Image();
                    sortimg.Style.Add("margin", "0px 2px");
                    if (this.SortMode == "desc")
                    {
                        sortimg.ImageUrl = "~/images/GridImg/downarrow.gif";
                    }
                    else
                    {
                        sortimg.ImageUrl = "~/images/GridImg/uparrow.gif";
                    }
                    cells[j].Controls.Add(sortimg);
                }
                //if (colLists[j - 1].EditType != "" && OnCellEdit!=null)
                //{
                //    //cells[j].Attributes.Add("ColEdit", "ColEdit");
                //    Literal lit = new Literal();
                //    lit.Text = "<span style='color:red;font-size:11px;font-weight:normal;margin-left:2px'>edit</span>";
                //    cells[j].Controls.Add(lit);
                //}
            }

        }
        string datakey = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //添加行的js属性，用来保存主键
            datakey = this.WshPwtGv.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes.Add("dataKey", datakey);
            e.Row.Attributes.Add("rowType", "dataRow");
            //为单元格绑定列名
            List<CellValue> cValue = this.SetCellValue;
            TableCellCollection cells = e.Row.Cells;
            for (int j = 1; j < cells.Count; j++)
            {
                //if(colLists[j-1].Width>0){
                //    cells[j].Style.Add("width", colLists[j - 1].Width+"px");
                //}
                string oldText = cells[j].Text;
                string colName=colLists[j - 1].Field;
                cells[j].Attributes.Add("colName", colName);
                Enums.ControlType edittype=colLists[j - 1].EditType;
                
                Literal lit = new Literal();
                CellValue cv = new CellValue();
                //可以编辑的单元格
                if(edittype!= Enums.ControlType.None){
                    cells[j].Attributes.Add("onclick", "$(this).cellEdit();");
                    cells[j].Attributes.Add("editType", colLists[j-1].EditType.ToString());
                    //cells[j].Attributes.Add("class","editor");
                }
                if (edittype == Enums.ControlType.Text)
                {
                    lit.Text = "<div class='editor' val='"+oldText+"'>" + oldText + "</div><input type='text' value='" + oldText + "' class='editInput' onblur='$(this).blurEdit();' onchange='$(this).saveEdit();'/>";
                    if (cValue != null)
                    {
                        foreach (CellValue newCellVal in cValue)
                        {
                            if (colLists[j - 1].Field == newCellVal.ColName)
                            {
                                cv = newCellVal;
                            }
                        }
                    }
                    cells[j].Controls.Add(lit);
                }
                if (edittype== Enums.ControlType.Combobox)
                {
                    StringBuilder sb = new StringBuilder();
                    string val = oldText;
                    sb.AppendFormat("<select style='display:none;width:100%;' onblur='$(this).blurEdit();' onchange='$(this).saveEdit();'>");
                    if (this.EditValue != null)
                    {
                        object values = EditValue[colName];
                        if (values != null)
                        {
                            string[] p = values.ToString().Split(",".ToCharArray());
                            for (int k = 0; k < p.Length; k++)
                            {
                                string[] c = p[k].Split("=".ToCharArray());
                                string selected="";
                                if(oldText==c[0]){
                                    selected = " selected='selected'";
                                    oldText = c[1];
                                }
                                sb.AppendFormat("<option value='{0}'" + selected + ">{1}</option>", c[0], c[1]);
                            }
                        }
                    }
                    sb.Append("</select>");
                    sb.Append("<div class='editor' val='" + val + "'>" + oldText + "</div>");
                    lit.Text = sb.ToString();
                    cells[j].Controls.Add(lit);
                }
               
            }
        }
        //执行自定义绑定事件
        if (OnRowBind != null)
        {
            RowBindEventArg Args = new RowBindEventArg();
            Args.Row = e.Row;
            Args.DataKey = datakey;
            OnRowBind(this, Args);
        }
    }
    #endregion

    #region 列头排序
    void WshPwtGv_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.SortExpression))
        {
            this.SortMode = this.SortMode == "asc" ? "desc" : "asc";
            this.SortName = e.SortExpression;
            PageBind();
        }
    }
    #endregion


    #region 绑定控件数据源
    public void PageBind(int pagesize, int pageindex)
    {
       
        
            this.WshPwtGv.DataKeyNames = new string[] { this.DataKey };
            if (OnPageBind != null)
            {
                PageConfig pc = new PageConfig();
                pc.DataKey = this.DataKey;
                pc.PageIndex = pageindex;
                pc.PageSize = pagesize;
                pc.SortMode = this.SortMode;
                pc.SortName = this.SortName;
               // ScriptInfo.Alert(this.SortName);
                OnPageBind(this, pc);
                this.WshPwtGv.DataSource = this.DataSource;
                this.WshPwtGv.DataBind();
            }
            if (this.TotalCount <= 0)
            {
                ShowSourceNull();
            }
        this.pager.ResultCount = this.TotalCount;
    }
    public void PageBind() {
        pager.MovePage();
    }
    public void ReBind()
    {
        pager.PageIndex = 1;
        pager.MoveFirstPage();
    }
    private void ShowSourceNull()
    {
        //如果没有数据则显示空表头
       // this.WshPwtGv.Visible = false;
         GridNullShow.Visible = true;
        List<ColInfo> listCol = this.ColList;
        Table t = new Table();
        t.CssClass = CssConfig.GridCss;
        TableHeaderRow r1 = new TableHeaderRow();
        foreach (ColInfo col in listCol)
        {
            TableHeaderCell c1 = new TableHeaderCell();
            c1.Text = col.Caption;
            r1.Cells.Add(c1);
        }
        t.Rows.Add(r1);

        TableRow r2 = new TableRow();
        TableCell c2 = new TableCell();
        c2.ColumnSpan = listCol.Count;
        c2.Style.Add("background","#fff");
        c2.Text = "<div style='padding:1px 15px;color:red;text-align:left;'>目前没有记录</div>";
        r2.Cells.Add(c2);
        t.Rows.Add(r2);
        this.GridNullShow.Controls.Add(t);
    }
    #endregion

}