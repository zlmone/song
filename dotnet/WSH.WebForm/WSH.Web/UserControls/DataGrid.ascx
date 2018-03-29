<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DataGrid.ascx.cs" Inherits="Grid_DataGrid" %>
 <asp:Panel ID="Panal" runat="server">
<asp:Panel ID="GridPanal" runat="server" CssClass="datagrid-panal">

</asp:Panel>
<div runat="server" id="pagePanal" style=" border-top:0px;">
 <WSH:Pager ID="pager" runat="server" />
</div>
     <asp:HiddenField ID="sortHideField" runat="server" />
     <asp:HiddenField ID="sortNameHideField" runat="server" />
 </asp:Panel>
 