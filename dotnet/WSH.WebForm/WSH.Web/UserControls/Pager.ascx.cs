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

using DAL;
using System.Collections.Generic;

public partial class UserControls_Pager : System.Web.UI.UserControl
{
    private string[] PageCover =new string[]{"5","10","15","20","30","40","50"};
    private int pageSize;
    public int PageSize
    {
        get
        {
            int result = 10;
            try
            {
                result = Convert.ToInt32(DDLPageSize.SelectedValue);
            }
            catch (Exception e) {
                result = pageSize==0 ? 10 : pageSize;
            }
            return result;
        }
        set { pageSize = value; }
    }
    public int PageIndex
    {
        get { return Convert.ToInt32(ViewState["PageIndex"]); }
        set { ViewState["PageIndex"] = value; }
    }
    public int PageCount {
        get { return Convert.ToInt32(LitPageCount.Text); }
        set { LitPageCount.Text = value.ToString(); }
    }
    private int resultCount;

    public int ResultCount
    {
        get { return resultCount; }
        set { resultCount = value; }
    }
    private List<ToolItem> items;

    public List<ToolItem> Items
    {
        get { return items; }
        set { items = value; }
    }
 
    public delegate void PageEventHandler(object sender,PageConfig pc);
    public event PageEventHandler OnPage;
    public delegate void ToolItemEventHandler(object sender, string value);
    public event ToolItemEventHandler OnToolItemClick;
    public string isfirst = "true";
    public string islast = "true";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            DDLPageSize.Items.Add(new ListItem(PageSize.ToString(),PageSize.ToString()));
            foreach (string  pc in PageCover)
            {
                if (pc != PageSize.ToString())
                {
                    ListItem li = new ListItem(pc, pc);
                    DDLPageSize.Items.Add(li);
                }
            }
            DDLPageSize.SelectedValue = PageSize.ToString();
            ViewState["PageIndex"] = 1;
            MovePage();
        }
        if (this.Items != null)
        {
            foreach (ToolItem i in this.Items)
            {
                string val = i.Value == null ? Utils.GetGuid : i.Value;
                string title = i.Title == null ? "" : i.Title;
                HtmlTableCell c = new HtmlTableCell();
                c.InnerHtml = "<span class=\"pager-split\"></span>";
                PagerRow.Cells.Add(c);
                HtmlTableCell cl = new HtmlTableCell();
                LinkButton lb = new LinkButton();
                lb.ID = val;
                lb.CssClass = "pager-link";
                lb.Attributes.Add("hidefocus", "true");
                lb.Attributes.Add("title",title);
                lb.Text = "<img src='" + i.Icon + "'/>";
                if(!string.IsNullOrEmpty(i.ClientClick)){
                    lb.OnClientClick = string.Format("return {0}('{1}');", i.ClientClick, val);
                }
                lb.Click += new EventHandler(lb_Click);
                cl.Controls.Add(lb);
                PagerRow.Cells.Add(cl);
            }
        }
    }

    void lb_Click(object sender, EventArgs e)
    {
        if (OnToolItemClick!=null) {
            LinkButton lb = sender as LinkButton;
            OnToolItemClick(this, lb.ID);
        }
    }
    public void MovePage() {
        if (OnPage != null)
        {
            PageConfig pc = new PageConfig();
            pc.PageSize = this.PageSize;
            pc.PageIndex = this.PageIndex;
            pc.ResultCount =this.ResultCount;
            pc.PageCount = this.PageCount;
            OnPage(this, pc);
        }
        SetPageInfo();
    }
    public void MoveFirstPage() {
        this.PageIndex = 1;
        MovePage();
    }
    public void SetPageInfo() {
        this.LitPageResult.Text = ResultCount.ToString();
         this.TBPageIndex.Text = PageIndex.ToString();
        if (ResultCount % PageSize == 0)
        {
            PageCount = ResultCount / PageSize;
        }
        else
        {
            PageCount = ResultCount / PageSize + 1;
        }
        //this.LBPageFirst.Enabled = true;
        //this.LBPagePrev.Enabled = true;
        //this.LBPageNext.Enabled = true;
        //this.LBPageLast.Enabled = true;
        this.pagerFirst.CssClass = "pager-ext-first";
        this.pagerPrev.CssClass = "pager-ext-prev";
        this.pagerNext.CssClass = "pager-ext-next";
        this.pagerLast.CssClass = "pager-ext-last";
        if (PageIndex == 1)
        {
          //this.LBPageFirst.Enabled = false;
            //this.LBPagePrev.Enabled = false;

           // this.LBPageFirst.Attributes.Add("onclick","return false;");
            isfirst = "false";
            this.pagerFirst.CssClass = "pager-ext-first pager-ext-firstdisabled";
            this.pagerPrev.CssClass = "pager-ext-prev pager-ext-prevdisabled";
            
        }
        if (PageIndex == PageCount || PageCount == 0)
        {
            //this.LBPageNext.Enabled = false;
            //this.LBPageLast.Enabled = false;
            islast = "false";
            this.pagerNext.CssClass = "pager-ext-next pager-ext-nextdisabled";
            this.pagerLast.CssClass = "pager-ext-last pager-ext-lastdisabled";
            
        }
    }
    protected void LBPageFirst_Click(object sender, EventArgs e)
    {
        PageIndex = 1;
        MovePage();
    }
    protected void LBPagePrev_Click(object sender, EventArgs e)
    {
        PageIndex--;
        MovePage();
    }
    protected void LBPageNext_Click(object sender, EventArgs e)
    {
        PageIndex++;
        MovePage();
    }
    protected void LBPageLast_Click(object sender, EventArgs e)
    {
        PageIndex = PageCount;
        MovePage();
    }
    protected void DDLPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageIndex = 1;
        MovePage();
    }
    protected void LBPageReLoad_Click(object sender, EventArgs e)
    {
        PageIndex =Convert.ToInt32(this.TBPageIndex.Text);
        MovePage();
    }
}
