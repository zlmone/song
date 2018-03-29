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

public partial class AutoPager : System.Web.UI.UserControl
{
    //BaseDataBoundControl bindControl; 
    private string[] PageCover = new string[] { "5", "10", "15", "20", "30", "40", "50" };
    private int PageSize
    {
        get { return Convert.ToInt32(DDLPageSize.SelectedValue); }
    }
    private int PageIndex
    {
        get { return ViewState["PageIndex"]==null ? 1 : Convert.ToInt32(ViewState["PageIndex"]); }
        set { ViewState["PageIndex"] = value; }
    }
    private int PageCount
    {
        get { return Convert.ToInt32(ViewState["PageCount"]); }
        set { ViewState["PageCount"] = value; }
    }
    private int resultCount;

    public int ResultCount
    {
        get { return resultCount; }
        set { resultCount = value; }
    }
    public delegate void PageEventHandler(object sender, PageConfig pc);
    public event PageEventHandler OnPage;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (string pc in PageCover)
            {
                ListItem li = new ListItem(pc, pc);
                DDLPageSize.Items.Add(li);
                DDLPageSize.SelectedValue = "10";
            }
            HidePageIndex.Value = PageIndex.ToString();
            CreateAutoPage();
        }
        if (HidePageIndex.Value!=PageIndex.ToString())
        {
            PageIndex=Convert.ToInt32(HidePageIndex.Value);
            CreateAutoPage();
        }
    }
    private void CreateAutoPage()
    {
        if (OnPage!=null) {
            PageConfig pc = new PageConfig();
            pc.PageIndex = PageIndex;
            pc.PageSize = PageSize;
            OnPage(this,pc);
        }
        Builder sb = new Builder();        
        if (ResultCount % PageSize == 0)
        {
            PageCount = ResultCount / PageSize;
        }
        else
        {
            PageCount = ResultCount / PageSize + 1;
        }
        if (PageCount > 0)
        {
            sb.Add(NewPageLink(1)); 

            if (PageCount <= 11)
            {
                for (int i = 2; i <= PageCount; i++)
                {
                    sb.Add(NewPageLink(i));
                }
            }
            else
            {
                if (PageIndex < 7)
                {
                    for (int i = 2; i <= 10; i++)
                    {
                        sb.Add(NewPageLink(i));
                    }
                    sb.Add(NewPageDot());
                }
                else if ((PageCount - PageIndex) >4)
                {
                    sb.Add(NewPageDot());
                    for (int i = PageIndex - 4; i <= PageIndex + 4; i++)
                    {
                        sb.Add(NewPageLink(i));
                    }
                    if ((PageCount - PageIndex) > 5)
                    {
                        sb.Add(NewPageDot());
                    }
                }
                else
                {
                    sb.Add(NewPageDot());
                    for (int i = PageCount - 10; i <= PageCount - 1; i++)
                    {
                        sb.Add(NewPageLink(i));
                    }
                }
                sb.Add(NewPageLink(PageCount));
            }
        }
        sb.AddFmt("&nbsp;共{0}条记录",ResultCount);
        LitPageHtml.Text = "";
        LitPageHtml.Text = sb.ToStr();
    }
    private string NewPageLink(int i) {
        if(i==PageIndex){
            return string.Format("<a href='{0}' class='currentpage' hidefocus='true'>{1}</a>", Consts.LINKNOTURL, i);
        }
        return string.Format("<a href='javascript:__gotoPage({0});' class='otherpage'>{1}</a>", i,i);
    }
    private string  NewPageDot() {
        return "<span class='dotpage'>...</span>";
    }
    protected void DDLPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageIndex = 1;
        CreateAutoPage();
    }
}
