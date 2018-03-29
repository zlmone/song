<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WSH.Web.Cmp.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单</title>
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/extend.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../css/icons.css" rel="stylesheet" type="text/css" />
    <script src="../js/song.base.js" type="text/javascript"></script>
    <script src="../js/zTree/jquery.ztree.core-3.0.min.js" type="text/javascript"></script>
    <link href="../js/zTree/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../js/common/cmp.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <WSH:DockPanel runat="server"  ID="btnSave">
            <WSH:DockItem Dock="Top" Height="100" Border="1px solid red" >
               top
            </WSH:DockItem>
            <WSH:DockItem Dock="Left" Width="180" Border="1px solid red">
                <WSH:ZTree runat="server" ID="tree" OnRightClick="showMenu">
                    <Items>
                        <WSH:TreeItem Text="王松华项目管理">
                            <WSH:TreeItem Text="菜单管理"></WSH:TreeItem>
                            <WSH:TreeItem Text="菜单管理"></WSH:TreeItem>
                            <WSH:TreeItem Text="菜单管理"></WSH:TreeItem>
                            <WSH:TreeItem Text="菜单管理"></WSH:TreeItem>
                        </WSH:TreeItem>
                    </Items>
                </WSH:ZTree>
            </WSH:DockItem>
            <WSH:DockItem Dock="Center" Border="1px solid red">
                 
            </WSH:DockItem>
            <WSH:DockItem Dock="Bottom" Border="1px solid red">
                <WSH:HBox runat="server" Align="center">
                    <WSH:Button ID="Button1" runat="server" Text="按钮" ></WSH:Button>
                </WSH:HBox>
            </WSH:DockItem>
        </WSH:DockPanel>
     
        <WSH:ContextMenu runat="server" ID="menuNav" >
            <WSH:MenuItem Text="菜单1" IconUrl="../img/icons/add-row.gif" ID="a">
                <WSH:MenuItem Text="子菜单1" Icon="DeleteRow" ID="b"></WSH:MenuItem>
                <WSH:MenuItem Text="子菜单1" Icon="Edit" ID="c"></WSH:MenuItem>
            </WSH:MenuItem>
            <WSH:MenuItem Text="子菜单1" Icon="Save" ID="d"></WSH:MenuItem>
        </WSH:ContextMenu>
        <WSH:Menu ID="menuMenu" runat="server" Width="100">
            <WSH:MenuItem Text="添加子节点" Icon="AddRow" ></WSH:MenuItem>
            <WSH:MenuItem Text="修改节点" Icon="Edit"></WSH:MenuItem>
            <WSH:MenuItem Text="删除节点" Icon="DeleteRow"></WSH:MenuItem>
        </WSH:Menu>
    </form>
</body>
</html>
<script type="text/javascript">
    var id = "<%=Button1.ClientID %>";
    $("#" + id).click(function (e) {
//        var menu = song.getCmp("menuMenu");
//        //menu.showEl(this);
//        menu.show();
        e.preventDefault();
        e.stopPropagation();
    });
    function showMenu(e, treeid, treeNode) {
        if (treeNode) {
            var menu = song.getCmp("menuMenu");
            var tree = cmp.zTree.get(treeid);
            tree.selectNode(treeNode);
            menu.showEvent(e);
        }
    }
    </script>