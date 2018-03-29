<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toolbar.aspx.cs" Inherits="WSH.Web.Cmp.Toolbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toolbar</title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/extend.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/song.base.js" type="text/javascript"></script>
    <link href="../css/icons.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <WSH:Toolbar ID="tb" runat="server">
            <WSH:Separator />
            <WSH:ToolbarText>姓名：</WSH:ToolbarText>
            <WSH:ToolbarItem>
                <WSH:InputBox runat="server" ID="txtName"></WSH:InputBox>
            </WSH:ToolbarItem>
            <WSH:Separator />
            <WSH:ToolbarButton runat="server" ID="btnAdd" Icon="AddRow" Text="添加"></WSH:ToolbarButton>
            <WSH:ToolbarItem>
                <WSH:Button runat="server" ID="btnQuery" Text="查询" Skin="Ext"></WSH:Button>
            </WSH:ToolbarItem>
            <WSH:Separator />
            <WSH:ToolbarButton runat="server" ID="btnNew" Text="新建">
                <Menu runat="server" ID="menuNew">
                    <WSH:MenuItem Text="文件夹"></WSH:MenuItem>
                    <WSH:MenuItem Text="文件"></WSH:MenuItem>
                    <WSH:MenuItem Text="导出" Icon="Folder">
                        <WSH:MenuItem Text="Excel" Icon="Excel"></WSH:MenuItem>
                        <WSH:MenuItem Text="Word" Icon="Word"></WSH:MenuItem>
                    </WSH:MenuItem>
                </Menu>
            </WSH:ToolbarButton>
        </WSH:Toolbar>
    </div>
    </form>
</body>
</html>
