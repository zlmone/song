<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileExplorer.aspx.cs" Inherits="Song.WebSite.View.js.fileExplorer.FileExplorer1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/global.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/css/song/default/song.fileExplorer.css" rel="stylesheet"
        type="text/css" />
    <link href="../../admin/css/fileType-16.16.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/css/song/default/song.css" rel="stylesheet" type="text/css" />
    <script src="../jquery/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../song/song.base.js" type="text/javascript"></script>
    <script src="song.fileExplorer.js" type="text/javascript"></script>
    <script src="../song/song.popup.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="song-explorer-title">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>当前目录：<%=CurrentPath%></td>
                    <td class="song-explorer-back"><a href="javascript:song.fileExplorer.back();">返回上一级</a></td>
                </tr>
            </table>
        </div>
        <div class="song-explorer-head">
            <table class="song-explorer-table" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <td class="song-explorer-num">&nbsp;</td>
                        <td class="song-explorer-type">&nbsp;</td>
                        <td>文件名</td>
                        <td class="song-explorer-size">文件大小</td>
                    </tr>
                </thead>
            </table>
        </div>
        <div class="song-explorer-body" style=" height:200px;">
            <table class="song-explorer-table" cellpadding="0" cellspacing="0">
                <tbody>
                    <%=FileItems %>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
