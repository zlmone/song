<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataGrid.aspx.cs" Inherits="WSH.Web.Cmp.DataGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/extend.css" rel="stylesheet" type="text/css" />
    <link href="../css/buttons.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <WSH:DataGrid runat="server" ID="grid">
                <Columns>
                    <WSH:GridColumn Field="wang" Header="wang" />
                    <WSH:GridColumn Field="song" Header="song" />
                </Columns>
            </WSH:DataGrid>
            <WSH:Button Text="回发页面" runat="server"></WSH:Button>
    </div>
    </form>
</body>
</html>
