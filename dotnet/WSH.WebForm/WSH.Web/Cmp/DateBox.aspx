<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateBox.aspx.cs" Inherits="WSH.Web.Cmp.DateBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/form.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/datePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../js/cmp.js" type="text/javascript"></script>
    <script src="../js/valid.js" type="text/javascript"></script>
    <style type="text/css">
        *{ margin:0px; padding:0px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <WSH:DateBox runat="server" ID="dateStart"  />
            <WSH:DateBox runat="server" ID="dateEnd" />
            
            <button onclick="valid.checkDateRange('<%=dateStart.ClientID %>','<%=dateEnd.ClientID %>');return false;">提交</button>
            
    </div>
    </form>
</body>
</html>
