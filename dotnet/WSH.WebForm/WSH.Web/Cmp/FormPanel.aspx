<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPanel.aspx.cs" Inherits="WSH.Web.Cmp.FormPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>表单</title>
        <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/extend.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
  <%--  
    <WSH:DockPanel runat="server" ID="dockPanel" IsViewport="true"  style="width:600px;">
        <WSH:DockItem runat="server" ID="dockItem1" Dock="Center" Border="1px solid red">--%>
             <WSH:FormPanel runat="server" ID="formPanel"  Columns="2" LabelWidth="90" Width="600">
                <WSH:FormLabel ID="FormLabel1" runat="server" >日期</WSH:FormLabel>
                <WSH:DateBox ID="DateBox1" runat="server"></WSH:DateBox>
               
                <WSH:FormLabel ID="FormLabel2" runat="server">日期</WSH:FormLabel>
                <WSH:InputBox ID="InputBox1" runat="server"></WSH:InputBox>

                <WSH:FormLabel ID="FormLabel10" runat="server">日期</WSH:FormLabel>
                <WSH:InputBox ID="InputBox3" runat="server"></WSH:InputBox>

                <WSH:FormLabel ID="FormLabel11" runat="server">日期</WSH:FormLabel>
                <WSH:InputBox ID="InputBox4" runat="server"></WSH:InputBox>

                <WSH:FormLabel ID="FormLabel13" runat="server">日期</WSH:FormLabel>
                <WSH:InputBox ID="InputBox6" runat="server"></WSH:InputBox>

                <WSH:FormLabel ID="FormLabel12" runat="server">日期</WSH:FormLabel>
                <WSH:InputBox ID="InputBox5" runat="server"></WSH:InputBox>

                <WSH:FormLabel ID="FormLabel3" runat="server" >选择</WSH:FormLabel>
                <WSH:ComboBox ID="ComboBox1" runat="server" ></WSH:ComboBox>

                <WSH:FormLabel ID="FormLabel4" runat="server" >选择</WSH:FormLabel>
                <WSH:CheckBox ID="CheckBox1" runat="server" />

                <WSH:FormLabel ID="FormLabel5" runat="server" >选择</WSH:FormLabel>
                <WSH:RadioButton ID="RadioButton1" runat="server"/>

                <WSH:FormLabel ID="FormLabel6" runat="server" >选择</WSH:FormLabel>
                <WSH:RadioButton ID="RadioButton2" runat="server"/>

                <WSH:FormLabel ID="FormLabel7" runat="server">选择</WSH:FormLabel>
                <WSH:InputBox ID="InputBox2" runat="server" TextMode="MultiLine" FullColumn="true" DataType="Float" Required="true"></WSH:InputBox>

                <WSH:FormLabel ID="FormLabel8" runat="server">日期</WSH:FormLabel>
                <WSH:DateBox ID="DateBox2" runat="server" FullColumn="false" ReadOnly="true" ></WSH:DateBox>

                <WSH:FormLabel ID="FormLabel9" runat="server">日期</WSH:FormLabel>
                <WSH:InputBox ID="wsh" runat="server" FullColumn="true" ></WSH:InputBox>
            </WSH:FormPanel>
   <%--     </WSH:DockItem>
        <WSH:DockItem runat="server" Dock="Bottom" Border="1px solid red">
            <WSH:HBox runat="server" ID="stackButtons">
                <WSH:Button runat="server" ID="btnSave" Text="保存"  Skin="Ext" />
                <WSH:Button runat="server" ID="btnSaveClose" Text="保存&关闭"  Skin="Ext" />
            </WSH:HBox>
        </WSH:DockItem>
        <WSH:DockItem Dock="Top" Border="1px solid red;" Visible="false">
                <WSH:Button runat="server" ID="Button1" Text="保存"   />
                <WSH:Button runat="server" ID="Button2" Text="保存&关闭"   />
        </WSH:DockItem>
    </WSH:DockPanel>--%>
    
    </form>
</body>
</html>
