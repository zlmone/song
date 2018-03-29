 <%@ Control Language="C#" AutoEventWireup="true" CodeFile="Grid.ascx.cs" Inherits="Grid" %>
 <div>
    <asp:GridView ID="WshPwtGv" runat="server" CellPadding="0" CellSpacing="0">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="35">
                <HeaderTemplate>
                    <input type="checkbox" onclick="$('#<%=WshPwtGv.ClientID %>').checkAll($(this))"/>
                </HeaderTemplate>
                <ItemTemplate>
                    <input type="checkbox" MultiCheck="true" runat="server" id="multiCheck"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
     <asp:Literal ID="LitSelectedClass" runat="server"></asp:Literal>
     <asp:Label ID="GridNullShow" runat="server" Text=""></asp:Label>
 <div runat="server" id="pagePanal">
     <WSH:Pager ID="pager" runat="server" />
 </div>
 </div>