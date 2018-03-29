<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AutoPager.ascx.cs" Inherits="AutoPager" %>
  <asp:DropDownList ID="DDLPageSize" runat="server"
                    onselectedindexchanged="DDLPageSize_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
 
<asp:Literal ID="LitPageHtml" runat="server"></asp:Literal>
<asp:HiddenField ID="HidePageIndex" runat="server" />
<script type="text/javascript">
    function __gotoPage(idx){
        document.getElementById("<%=HidePageIndex.ClientID %>").value=idx.toString();
        document.forms[0].submit();
    }
</script>