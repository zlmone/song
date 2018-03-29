<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        html,body{  height:100%;}
        body{ font-family:宋体 Arial; font-size:12px; background:#eee; text-align:center; margin:0px;}
        table{ border-collapse:collapse;}
        a{ text-decoration:none; color:#000;}
        .main{ height:100%; width:100%;}
        .main-panel{ text-align:left; }
        .panel{ margin:0px auto; width:459px;}
        td{ padding:0px;}
        .head{ height:48px; background:url(../img/popup/MessageHead.gif) no-repeat;
        font-size:16px; font-weight:bold; text-align:left; padding-left:20px; }
        .content-bg{background:url(../img/popup/MessageBody.gif) repeat-y;}
        .icon{ width:100px; text-align:center; background-position:left top;}
        .icon img{ margin:20px 10px; margin-right:0px;}
        .text{ background-position:right top; padding:15px; padding-left:0px; }
        .back{ text-align:center;}
        .back a{ display:block; width:64px; height:22px; line-height:22px; text-align:center;
         background:url(../img/popup/back.gif); margin:0px auto;}
        .footer{ height:29px; background:url(../img/popup/MessageEnd.gif);}
    </style>
</head>
<body>
     
   <table class="main">
        <tr>
            <td class="main-panel">
                <table class="panel">
                    <tr>
                        <td colspan="2" class="head">
                            <asp:Literal ID="head" runat="server">信息提示</asp:Literal></td>
                    </tr>
                    <tr>
                        <td class="icon content-bg">
                            <asp:Image ID="icon" runat="server" ImageUrl="../img/popup/MessageError.gif"/>
                        </td>
                        <td class="content-bg text">
                            <asp:Literal ID="text" runat="server">系统遇到问题暂时关闭，请联系系统管理员</asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="back content-bg">
                            <a href="javascript:history.go(-1);">返回</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="footer">
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
 
</body>
</html>
