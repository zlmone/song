<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dialog.aspx.cs" Inherits="WSH.Web.Cmp.Dialog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>弹出窗</title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/extend.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/datePicker/WdatePicker.js" type="text/javascript"></script>
   <link href="../js/artDilog/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../js/artDilog/jquery.artDialog.js" type="text/javascript"></script>
    <script src="../js/artDilog/iframeTools.js" type="text/javascript"></script> 

<%--     <link href="../js/lhgDialog/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../js/lhgDialog/lhgdialog.min.js" type="text/javascript"></script>--%>

 <%--   <link href="../js/lhg/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../js/lhg/lhgdialog.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        function show() {
            //var url="../Template/Layout.htm";
            var url = "FormPanel.aspx";
//            var api = $.dialog({ content: "url:"+url+"", lock: true, width: 600, height: 300, init: function () {
//                
//            } 
//            });

             var api = $.dialog.open(url, {width:600,height:300,lock:true,opacity:0.3});
//            var dg = new $.dialog({ page: "../Template/Layout.htm", width: 600, autoSize: false, height: 300 });
//            dg.ShowDialog();

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <WSH:Button runat="server" Text="弹出" OnClientClick="return show();"></WSH:Button>
    </div>
    </form>
</body>
</html>
