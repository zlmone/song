<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="UserControls_Pager" %>

<script type="text/javascript">
    $(function() {
        var pIndex = dom("<%=TBPageIndex.ClientID %>");
        var pLoad = dom("<%=LBPageReLoad.ClientID %>");
        var pCount = "<%=LitPageCount.Text %>";
        var val = pIndex.value;
        var url = pLoad.href;
        pLoad.href = j.nullUrl;
        $(pIndex).change(function() {
            var curr=$(this).val();
            if(curr.isInt()){ 
                if(curr > pCount.toInt() || curr <= 0) {
                    $(this).val(val);
                    pLoad.href = j.nullUrl;
                } else {
                    pLoad.href = url;
                }
            }
        });
        var first = dom("<%=LBPageFirst.ClientID %>");
        var prev = dom("<%=LBPagePrev.ClientID %>");
        var next = dom("<%=LBPageNext.ClientID %>");
        var last = dom("<%=LBPageLast.ClientID %>");
        var isfirst = "<%=isfirst %>";
        var islast = "<%=islast %>";
        first.href = isfirst == "false" ? j.nullUrl : first.href;
        prev.href = isfirst == "false" ? j.nullUrl : prev.href;
        next.href = islast == "false" ? j.nullUrl : next.href;
        last.href = islast == "false" ? j.nullUrl : last.href;
    });
</script>

<table border="0" cellpadding="0" cellspacing="0">
    <tr runat="server" id="PagerRow">
        <td class="pager-height">
            <asp:DropDownList ID="DDLPageSize" runat="server" CssClass="pager-ext-size" OnSelectedIndexChanged="DDLPageSize_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
        </td>
        <td>
            <span class="pager-ext-split"></span>
        </td>
        <td>
            <asp:LinkButton ID="LBPageFirst" CssClass="pager-ext-link" runat="server" OnClick="LBPageFirst_Click">
                <span class="pager-ext-linkright"><span class="pager-ext-linkcenter">
                    <asp:Label ID="pagerFirst" runat="server" CssClass="pager-ext-first"></asp:Label>
                </span></span>
            </asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="LBPagePrev" CssClass="pager-ext-link" runat="server" OnClick="LBPagePrev_Click">
                <span class="pager-ext-linkright"><span class="pager-ext-linkcenter">
                    <asp:Label ID="pagerPrev" runat="server" CssClass="pager-ext-prev" Text="&nbsp;"></asp:Label>
                </span></span>
            </asp:LinkButton>
        </td>
        <td>
            <span class="pager-ext-split"></span>
        </td>
        <td>
            &nbsp;第
        </td>
        <td>
            <asp:TextBox ID="TBPageIndex" runat="server" CssClass="pager-ext-index" Text="0"
                onmouseover="this.select();" onmouseout="this.value=this.value;"></asp:TextBox>
        </td>
        <td>
            页/共<asp:Literal ID="LitPageCount" runat="server" Text="0"></asp:Literal>页&nbsp;
        </td>
        <td>
            <span class="pager-ext-split"></span>
        </td>
        <td>
            <asp:LinkButton ID="LBPageReLoad" CssClass="pager-ext-link" runat="server" OnClick="LBPageReLoad_Click">
                    <span class="pager-ext-linkright"><span class="pager-ext-linkcenter"><span class="pager-ext-linkgoto"></span></span></span>
            </asp:LinkButton>
        </td>
        <td>
            <span class="pager-ext-split"></span>
        </td>
        <td>
            <asp:LinkButton ID="LBPageNext" CssClass="pager-ext-link" runat="server" OnClick="LBPageNext_Click">
                <span class="pager-ext-linkright"><span class="pager-ext-linkcenter">
                    <asp:Label ID="pagerNext" runat="server" CssClass="pager-ext-next"></asp:Label>
                </span></span>
            </asp:LinkButton>
        </td>
        <td>
            <asp:LinkButton ID="LBPageLast" CssClass="pager-ext-link" runat="server" OnClick="LBPageLast_Click">
                <span class="pager-ext-linkright"><span class="pager-ext-linkcenter">
                    <asp:Label ID="pagerLast" runat="server" CssClass="pager-ext-last"></asp:Label>
                </span></span>
            </asp:LinkButton>
        </td>
        <td>
            <span class="pager-ext-split"></span>
        </td>
        <td>
            &nbsp;共<asp:Literal ID="LitPageResult" runat="server" Text="0"></asp:Literal>条记录&nbsp;
        </td>
    </tr>
</table>
