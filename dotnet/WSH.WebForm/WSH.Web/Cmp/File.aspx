<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="File.aspx.cs" Inherits="WSH.Web.Cmp.File" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../css/song.popup.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/song.base.js" type="text/javascript"></script>
    <script src="../js/song/song.popup.js" type="text/javascript"></script>
    <script type="text/javascript">
        function down() {
       //     var loading = new song.loading({ msg: "正在获取文件信息..." }).show();
            location.href = "../CommonPage/DownloadFile.aspx";
           
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="javascript:down();">下载文件</a>
    </div>
    </form>
</body>
</html>
