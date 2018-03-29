<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="NetStudio.Web.admin.UploadControls.UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html,body{ overflow:hidden; height:100%;}
        body{ font-size:12px; font-family:Tahoma; margin:10px;}
        .wrap{ margin:0px;}
        .upload{    }
        .btn{ margin-left:10px;}
        .filetype{ color:Red;}
        .rename{ margin-right:10px; vertical-align:middle;}
        .upload-options{ padding:5px 0px;}
        .btn-wrap{ text-align:center;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <div>
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="upload" size="70"/>
        </div>
        <div class="upload-options">
            是否重命名<asp:CheckBox ID="checkIsReName" runat="server" CssClass="rename"/>
            文件类型：<span class="filetype">.jpg|.gif|.bmp</span>
        </div>
        <div class="btn-wrap"> 
            <asp:Button ID="Button1" runat="server" Text="上传" CssClass="btn" />
        </div>
    </div>
    </form>
</body>
</html>
