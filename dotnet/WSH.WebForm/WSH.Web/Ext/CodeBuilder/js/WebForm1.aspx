<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Ext.CodeBuilder.js.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="WshPwtGv" runat="server" CellPadding="0" CellSpacing="0" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="35">
                    <HeaderTemplate>
                        <input type="checkbox" id="checkAll" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <input type="checkbox" name="checkAll" multicheck="true" runat="server" id="MultiCheck" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="" HeaderText="" SortExpression="" DataFormatString="" />
                <asp:CheckBoxField />
            </Columns>
        </asp:GridView>
        <!--设置GridView样式和客户端事件的脚本-->
        <script type="text/javascript">
            var grid=new  j.grid({
                skin:"DT",
                click:function(id,obj){},
                dblclick:function(id,obj){}
            });
        </script>
    </div>
    </form>
</body>
</html>
