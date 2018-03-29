using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Xml;
using System.Text;

public partial class Grid_DataGrid : System.Web.UI.UserControl
{
    #region 默认变量值
    private int defaultWidth = 150;
    private int checkWidth =35;
    private HtmlTable colTable = new HtmlTable();//表头
    private HtmlTable tbody = new HtmlTable();//表体
    private int tableWidth = 0;
    private HtmlInputCheckBox box;
    #endregion

    #region 属性集合
    private string height = "100%";

    public string Height
    {
        get { return height; }
        set { height = value; }
    }
 
    private string width="100%";

    public string Width
    {
        get { return width; }
        set { width = value; }
    }
    private Enums.ColumnMapSourceType columnMapSource = Enums.ColumnMapSourceType.Xml;

    public Enums.ColumnMapSourceType ColumnMapSource
    {
        get { return columnMapSource; }
        set { columnMapSource = value; }
    }
    private string xmlPath;

    public string XmlPath
    {
        get { return xmlPath; }
        set { xmlPath = value; }
    }
    private DataTable dataSource;

    public DataTable DataSource
    {
        get { return dataSource; }
        set { dataSource = value; }
    }
    private string tableName;

    public string TableName
    {
        get { return tableName; }
        set { tableName = value; }
    }
    //页大小
    public int PageSize
    {
        set { this.pager.PageSize = value; }
        get { return this.pager.PageSize; }
    }
    //排序模式
    private string SortMode
    {
        get { return ViewState["_SortMode"] == null ? "" : ViewState["_SortMode"].ToString(); }
        set { ViewState["_SortMode"] = value; }
    }
    //排序模式
    private string SortName
    {
        get { return ViewState["_SortName"] == null ? "" : ViewState["_SortName"].ToString(); }
        set { ViewState["_SortName"] = value; }
    }
    //排序模式
    private string DataKey
    {
        get { return ViewState["_DataKey"] == null ? "" : ViewState["_DataKey"].ToString(); }
        set { ViewState["_DataKey"] = value; }
    }
    private int totalCount;

    public int TotalCount
    {
        get { return totalCount; }
        set { totalCount = value; }
    }
    private bool showCheckColumn=true;

    public bool ShowCheckColumn
    {
        get { return showCheckColumn; }
        set { showCheckColumn = value; }
    }
    private List<ColInfo> columns;

    public List<ColInfo> Columns
    {
        get {
            List<ColInfo> cols = ViewState["columns"] as List<ColInfo>;
            if(cols==null){
                cols=columns = GetColumns();
            }   
            return columns; }
        set { columns = value; }
    }
    #endregion

    #region 事件集合
    public string ClientRowClick = "";
    public string ClientRowDblclick = "";
    public delegate void CellEditEventHandler(object sender, CellEditEventArg e);
    public delegate void CellCreatedEventHandler(object sender, CellEditEventArg e);
    public delegate void PageBindEventHandler(object sender, PageConfig e);

    public event CellEditEventHandler OnCellEdit;
    public event CellCreatedEventHandler OnCellCreated;
    public event PageBindEventHandler OnPageBind;
    #endregion

    #region 加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Panal.Style.Add("width",this.Width);  
        if(!IsPostBack){
            this.pagePanal.Attributes.Add("class", "pager-ext ");
        }
        this.pager.OnPage += new UserControls_Pager.PageEventHandler(pager_OnPage);
        if (sortHideField.Value == "1")
        {
            this.SortMode = SortMode == "desc" ? "asc" : "desc";
            pager.MovePage();
            sortHideField.Value = "0";
        }
    }

    void pager_OnPage(object sender, PageConfig pc)
    {
        //创建表头
        CreateColumns();
        if(this.OnPageBind!=null){
            pc.DataKey = this.DataKey;
            pc.SortMode = this.SortMode;
            pc.SortName = this.SortName;
        //   ScriptInfo.Alert(this.SortName );
            this.OnPageBind(this,pc);
            this.pager.ResultCount = this.TotalCount;
            //执行的js代码
            ExecScript();
        }
    }
    #endregion

    #region 绑定数据源
    public override void DataBind()
    {
        DataTable dt = this.DataSource;
        List<ColInfo> cols = this.Columns;
        if (dt != null && dt.Rows.Count > 0)
        {
            HtmlGenericControl tbodyPanal = new HtmlGenericControl("div");
            tbodyPanal.Attributes.Add("class","datagrid-tbody-panal");
           // tbodyPanal.Style.Add("height", this.Height);
            tbody.CellPadding = 0;
            tbody.CellSpacing = 0;
            tbody.ID ="tbody";
            tbody.Attributes.Add("class", "datagrid-tbody-table");
           // tbody.Attributes.Add("rules", "all");
            //绑定数据源
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string dataKey=dt.Rows[i][this.DataKey].ToString();
                HtmlTableRow row = new HtmlTableRow();
                row.Attributes.Add("dataKey",dataKey);
                row.Attributes.Add("rowType","dataRow");
                 row.Attributes.Add("class", i % 2 == 0 ? "roweven" : "rowodd");
                if(this.ShowCheckColumn==true){
                    HtmlTableCell checkcell = new HtmlTableCell();
                    checkcell.Style.Add("width", this.checkWidth + "px");
                    HtmlInputCheckBox box = new HtmlInputCheckBox();
                    box.Attributes.Add("multiCheck","true");
                    //box.Attributes.Add("onclick", "");
                    checkcell.Controls.Add(box);
                    row.Controls.Add(checkcell);
                }
                for (int j = 0; j < cols.Count; j++)
                {
                    string txt = dt.Rows[i][cols[j].Field].ToString();
                    HtmlTableCell cell = new HtmlTableCell();
                    //设置宽度
                    int w = cols[j].Width;
                    cell.Style.Add("width", w + "px");

                    if (cols[j].Full == true)
                    {
                        cell.Attributes.Add("fullColumn", "true");
                    }
                    if (cols[j].Align != "")
                    {
                        cell.Style.Add("text-align", cols[j].Align);
                    }
                    Enums.ControlType editType = cols[j].EditType;
                    HtmlGenericControl cellChild = new HtmlGenericControl("div");
                    cellChild.Attributes.Add("class", "datagrid-tbody-cellChild datagrid-cell-nowrap"+(editType== Enums.ControlType.None ? "" : " editor"));
                    //装进文本
                    HtmlGenericControl celltxt = new HtmlGenericControl("span");
                    celltxt.InnerHtml = txt;
                    celltxt.ID = Utils.GetGuid;
                    cellChild.Controls.Add(celltxt);
                    //是否可以编辑
                    string colName=cols[j].Field;
                    if (editType != Enums.ControlType.None)
                    {
                        cellChild.Attributes.Add("editType",editType.ToString());
                        cellChild.Attributes.Add("colName", colName);
                        cellChild.Attributes.Add("onclick","$(this).datagridEditStart();");
                        //文本框
                        if(editType== Enums.ControlType.Text){
                            HtmlInputText textbox = new HtmlInputText();
                            textbox.Attributes.Add("class", "text datagrid-editinput");
                            cellChild.Controls.Add(textbox);
                            textbox.Attributes.Add("onblur", "$(this).datagridEditEnd();");
                            textbox.Attributes.Add("onchange","$(this).datagridEditSave();");
                        }
                    }
                    cell.Controls.Add(cellChild);
                    //执行单元格创建完毕事件
                    if (this.OnCellCreated != null)
                    {
                        CellEditEventArg arg = new CellEditEventArg();
                        arg.ColName = cols[j].Field;
                        arg.DataKey = dataKey;
                        arg.Value = txt;
                        this.OnCellCreated(this, arg);
                    }
                    row.Controls.Add(cell);
                }
                tbody.Controls.Add(row);
            }
            tbody.Style.Add("width",tableWidth+"px");
            tbodyPanal.Controls.Add(tbody);
            this.GridPanal.Controls.Add(tbodyPanal);

        }
        else { 
            //显示空表体
        }
    }
    #endregion

    #region 创建表头
    protected void CreateColumns() {
        List<ColInfo> cols = this.Columns;
        if (sortNameHideField.Value != "")
        {
            this.SortName = sortNameHideField.Value;
        }
        HtmlGenericControl colPanal = new HtmlGenericControl("div");
        colPanal.Attributes.Add("class", "datagrid-col-panal");
        //resize的参考线
        HtmlGenericControl resizeLine = new HtmlGenericControl("div");
        resizeLine.Attributes.Add("class","datagrid-resize-line");
      //  resizeLine.Style.Add("height",(this.Height+25)+"px");
        GridPanal.Controls.Add(resizeLine);

        colTable.Attributes.Add("class", "datagrid-col-table");
        colTable.ID = "tHead";
        colTable.CellPadding = 0;
        colTable.CellSpacing = 0;
        HtmlTableRow colRow = new HtmlTableRow();
        //全选列
        if(this.ShowCheckColumn==true){
            HtmlTableCell checkcell = new HtmlTableCell();
            checkcell.Style.Add("width",this.checkWidth+"px");
            tableWidth += checkWidth;
            box = new HtmlInputCheckBox();
            box.ID = "checkAll";
            checkcell.Controls.Add(box);
            colRow.Controls.Add(checkcell);
        }
        foreach (ColInfo col in cols)
        {
            //列头
            HtmlTableCell colCell = new HtmlTableCell();
           // colCell.Attributes.Add("class","datagrid-cell-nowrap");
            int w = col.Width;
            colCell.Style.Add("width", w + "px");
            tableWidth += w;
            if (col.Full == true)
            {
                colCell.Attributes.Add("fullColumn","true");
            }
            HtmlGenericControl colChild = new HtmlGenericControl("a");
            //colChild.ID = Utils.GetGuid;
            colChild.Attributes.Add("class", "datagrid-col-cellChild datagrid-cell-nowrap");
            if (col.Sort == true)
            {
                string js = "javascript:$('#" + sortHideField.ClientID + "').val('1');";
                js += "$('#" + sortNameHideField.ClientID + "').val('" + col.Field + "');";
                js += this.Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this));
                colChild.Attributes.Add("href", js);
            }
            else
            {
                colChild.Attributes.Add("href", "javascript:");
            }
            colChild.Attributes.Add("hidefocus", "true");
            //改变列宽
            if (col.Resize == true)
            {
                HtmlGenericControl resize = new HtmlGenericControl("span");
                resize.Attributes.Add("class", "datagrid-col-resize");
                colChild.Controls.Add(resize);
            }
            
            HtmlGenericControl title = new HtmlGenericControl("span");
            title.InnerHtml = col.Caption;
            colChild.Controls.Add(title);
            if (col.Field == this.SortName)
            {
                 HtmlGenericControl sorticon = new HtmlGenericControl("span");
                 sorticon.Attributes.Add("class", (SortMode == "asc" ? "datagrid-col-sortasc" : "datagrid-col-sortdesc"));
                 sorticon.InnerHtml = "&nbsp;";
                 colChild.Controls.Add(sorticon);
            }
            colCell.Controls.Add(colChild);
            colRow.Controls.Add(colCell);
        }
        ////创建滚动条的列
        //HtmlTableCell scrollCell = new HtmlTableCell();
        //scrollCell.Style.Add("width", 17 + "px");
        //colRow.Controls.Add(scrollCell);

        colTable.Controls.Add(colRow);
        colTable.Style.Add("width",tableWidth+"px");
        colPanal.Controls.Add(colTable);
        this.GridPanal.Controls.Add(colPanal);
    }
    #endregion

    #region 执行的js代码
    private void ExecScript() {
        StringBuilder sb = new StringBuilder();
        //sb.AppendFormat("evenClass:'{0}',", CssConfig.EvenCss);
        //sb.AppendFormat("oddClass:'{0}',", CssConfig.OddCss);
        //sb.AppendFormat("hoverClass:'{0}',", CssConfig.RowMouseCss);
        //sb.AppendFormat("clickClass:'{0}',", CssConfig.RowClickCss);
        //sb.AppendFormat("click:{0},", string.IsNullOrEmpty(JSRowClick) ? "null" : JSRowClick.Replace("()", ""));
        //sb.AppendFormat("dblclick:{0},", string.IsNullOrEmpty(JSRowDBClick) ? "null" : JSRowDBClick.Replace("()", ""));
        //sb.AppendFormat("cellEdit:{0}", OnCellEdit == null ? "false" : "true");
        //string jQuery = "<script>$(function(){$('#" + WshPwtGv.ClientID + "').setGridStyle({" + sb.ToString() + "});});</script>";
        //Literal lit = new Literal();
        //lit.Text = jQuery;
        //this.Parent.Page.Header.Controls.Add(lit);
        //string gid = this.ID;
        //string gcid = this.WshPwtGv.ClientID;
        //string client = string.Format("<script>var {0}=new Object();", gid);
        //client += gid + ".getmid=function(){return $('#" + gcid + "').getMultiId();};";
        //client += gid + ".getid=function(){return $('#" + gcid + "').getSelectId();};";
        //client += gid + ".getcell=function(key,col){return $('#" + gcid + "').getCellValue(key,col);};";
        //client += "</script>";
        Literal l = new Literal();
        string rowclick = this.ClientRowClick == "" ? "" : "rowClick:"+this.ClientRowClick+",";
        string rowdblclick = this.ClientRowDblclick == "" ? "" : "rowDblclick:" + this.ClientRowDblclick + ",";
        l.Text = "<script>$(function(){$('#" + colTable.ClientID + "').initDataGrid({"+rowclick+rowdblclick+"height:'" + this.Height + "',tPage:'" + pagePanal.ClientID+ "',panal:$('#" + GridPanal.ClientID + "'),checkAll:$('#" + box.ClientID + "'),tBody:$('#" + tbody.ClientID + "')});});</script>";
        this.Parent.Page.Header.Controls.Add(l);
    }
    #endregion

    #region 得到列的配置信息
    public List<ColInfo> GetColumns()
    {
        List<ColInfo> lInfo = new List<ColInfo>();
        XmlDocument XDoc = new XmlDocument();
        try
        {
            XDoc.Load(Server.MapPath(this.XmlPath));
        }
        catch
        {
            throw new DataNotFoundException("未设置xml列的配置文件！");
        }
        XmlElement XElement = XDoc.DocumentElement;
        try
        {
            SortName = XElement.Attributes["SortDefault"].Value;
            DataKey = XElement.Attributes["DataKey"].Value;
        }
        catch
        {
            throw new DataNotFoundException("xml中DataKey属性或SortDefault属性没有设置！");
        }
        foreach (XmlNode node in XElement.ChildNodes)
        {
            ColInfo col = new ColInfo();
            XmlAttribute fmt = node.Attributes["Format"];
            XmlAttribute w = node.Attributes["Width"];
            XmlAttribute align = node.Attributes["Align"];
            XmlAttribute field = node.Attributes["Field"];
            XmlAttribute cap = node.Attributes["Caption"];
            XmlAttribute sort = node.Attributes["Sort"];
            XmlAttribute resize = node.Attributes["Resize"];
            XmlAttribute full = node.Attributes["Full"];
            XmlAttribute editType = node.Attributes["EditType"];
            XmlAttribute colType = node.Attributes["Type"];
            XmlAttribute trun = node.Attributes["Truncate"];
            XmlAttribute url = node.Attributes["Url"];

            col.Format = fmt == null ? string.Empty : fmt.Value.Trim();
            col.Width = w == null ? defaultWidth : (w.Value.Trim() == "" ? defaultWidth : Convert.ToInt32(w.Value.Trim()));
            col.Align = align == null ? "center" : align.Value.Trim();
            if (field == null)
            {
                throw new DataNotFoundException("未设置列的Field属性！");
            }
            col.Field = field.Value.Trim();
            col.Caption = cap == null ? "" : cap.Value.Trim();
            col.Sort = sort == null ? true : Convert.ToBoolean(sort.Value.Trim());
            col.Resize = resize == null ? true : Convert.ToBoolean(resize.Value.Trim());
            col.Full = full == null ? false : Convert.ToBoolean(full.Value.Trim());
            col.Truncate = trun == null ? 0 : (trun.Value.Trim() == "" ? 0 : Convert.ToInt32(trun.Value.Trim()));
            col.Url = url == null ? string.Empty : url.Value.Trim();
            string edit = editType == null ? "" : editType.Value.Trim();
            switch (edit)
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
            string type = colType == null ? "" : colType.Value.Trim();
            switch (type)
            {
                case "link": col.Type = Enums.ColumnType.Link;
                    break;
                default: col.Type = Enums.ColumnType.Default;
                    break;
            }
            lInfo.Add(col);
        }
        return lInfo;
    }
    #endregion

}
