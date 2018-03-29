<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZTree.aspx.cs" Inherits="WSH.Web.Cmp.TreeControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>zTree服务器结合实例</title>
   
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/icons.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/ztree/jquery.ztree.core-3.0.min.js" type="text/javascript"></script>
    <script src="../js/ztree/jquery.ztree.excheck-3.0.min.js" type="text/javascript"></script>
    <script src="../js/ztree/jquery.ztree.exedit-3.0.min.js" type="text/javascript"></script>
    <script src="../js/song.base.js" type="text/javascript"></script>
    <script src="../js/common/cmp.js" type="text/javascript"></script>
    <script type="text/javascript">
        var zTree = {
            onClick: function (event, treeID, treeNode, clickFlag) {
                var tree = song.ztree.get(treeID);
                var node = song.ztree.node(tree);
             //   alert(node.name);
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="  ">
<%--    <asp:TreeView runat="server" ImageSet="XPFileExplorer" NodeIndent="15" 
            ShowLines="True">
        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
        <Nodes>
            <asp:TreeNode Text="我是原始控件树，功能弱爆了，千万别用我">
                <asp:TreeNode Text="aaa"></asp:TreeNode>
                <asp:TreeNode Text="把不把"></asp:TreeNode>
                <asp:TreeNode Text="把不把吧"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
            HorizontalPadding="0px" VerticalPadding="0px" />
    </asp:TreeView>--%>
     </div>
         <WSH:ZTree runat="server" ID="tree" style="   "
          OnClick="zTree.onClick">
                <Items>
                    <WSH:TreeItem Text="我是自定义控件树，封装了zTree，欢迎使用" Icon="../img/icons/apply.png" IsLeaf="false">
                       <WSH:TreeItem Text="节点一"  Icon="../img/icons/check.png">
                               <WSH:TreeItem Text="节点二" Icon="../img/icons/all.gif"></WSH:TreeItem>
                               <WSH:TreeItem Text="节点三"></WSH:TreeItem>
                               <WSH:TreeItem Text="节点四"></WSH:TreeItem>
                        </WSH:TreeItem>
                       <WSH:TreeItem Text="自定义节点" Icon="../img/icons/add.gif"></WSH:TreeItem>
                    </WSH:TreeItem>
                </Items>
                <View ShowLine="true" />
                <Check Enable="true" TwoWay="true" CheckStyle="CheckBox"  />
         </WSH:ZTree>
   
    </form>
</body>
</html>
        <script type="text/javascript">
            $(function () {
                //alert(cmp.zTree.get("tree"));
                var params = {getData:true}
              //  alert(cmp.getDefaultUrl(params));
            });
    </script>
