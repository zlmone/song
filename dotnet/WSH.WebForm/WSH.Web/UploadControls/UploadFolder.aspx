<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFolder.aspx.cs" Inherits="NetStudio.Web.admin.UploadControls.UploadFolder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="fileType-16.16.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body,html,form{ margin:0px; height:100%; overflow:hidden;}
        body{ font-family:Tahoma; font-size:12px;}
        p{ padding:0px; margin:0px;}
       .head{ border-bottom:1px solid black;}
        a{ text-decoration:none; color:#000;}
        a:hover{ color:Red; text-decoration:underline;}
        .title{ padding:4px 4px; position:relative; padding-left:6px; background:#f3f3f3;}
        .title span{ vertical-align:middle;}
        .back{ position:absolute; right:5px; top:6px;  }
        .checkall{  vertical-align:middle;  }
        .list{ overflow:auto; border-bottom:1px solid black; position:relative;}
        .list div{ padding:2px 0px; padding-left:5px; border:1px solid #fff; }
        .list div img,.list div input,.list div a{ vertical-align:middle; margin-right:2px;}
        .list div span{  display:none;}
        .list div.odd{ background:#FAFAFA; border:1px solid #eee;}
        .list div.over{ background:#E8F6FD; border:1px solid #9AC6FF;}
        .list div.selected{ background:blue;}
        .preview{ border:1px solid black; width:200px; height:200px; position:absolute; right:0px; bottom:0px;
                   background:#fff; border-right:0px; border-bottom:0px; display:none; }
        .preview img{ position:absolute;left:50%; top:50%; }
        .preview-loading{ position:absolute; left:50%; top:50%; margin-left:-16px; margin-top:-16px; display:none; z-index:100;}
    </style>
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var BlankImgSrc = "img/s.gif";
        ; (function () {
            var currentPathID = "<%=lbCurrentPath.ClientID %>";
            var previewWidth = 200;
            var previewHeight = 200;
            window.dom = function (el) {
                return typeof el == "string" ? document.getElementById(el) : el;
            };
            window.upload = {
                setHeight: function () {
                    var listHeight = $(window).height() - $("#head").outerHeight() - 1;
                    $("#list").height(listHeight);
                },
                checkAll: function (me) {
                    var items = $("#list input:checkbox").attr("checked", me.checked);
                },
                itemOver: function () {
                    $(this).addClass("over").children("span").show();
                },
                itemOut: function (me) {
                    $(this).removeClass("over").children("span").hide();
                },
                itemSelected: function () {
                    $(this).toggleClass("selected");
                    //                    var check=dom.tagNames(this,"input")[0];
                    //                    check.checked=!check.checked;
                },
                getCurrentPath: function () {
                    return $("#" + currentPathID).html();
                },
                checkImg:function(img,filePath){
                    for (var i = 0; i < img.length; i++) {
                            if($(img[i]).attr("src")==filePath){
                            return true;
                        }
                        return false;
                    }
                },
                preview: function (me) {
                    var viewBox = $("#preview").show();
                    var fileName = $(this).parent().prev("a").html();
                    var filePath = upload.getCurrentPath() + fileName
                    //var filePath="http://www.baidu.com/img/baidu_sylogo1.gif";
                    var img = viewBox.find("img");
                    alert(upload.checkImg(img,filePath));
                    if (upload.checkImg(img,filePath)) {
                     
                        var currImg = viewBox.find("img:visible");
                        alert(currImg.length);
                        if (currImg.attr("src") != filePath) {
                            currImg.hide();
                            img.fadeIn();
                        }
                    } else {
                        var loading = $("#previewLoading").show();
                        var newImg = $("<img>").attr("src", filePath).appendTo(viewBox);
                        newImg.bind("load", function () {
                            loading.hide();
                            var that = $(this);
                            var w = that.outerWidth();
                            var h = that.outerHeight();
                            if (w > previewWidth) {
                                w = previewWidth;
                                that.css({ left: 0 }).width(w);
                            } else {
                                that.css({ marginLeft: -(w / 2) });
                            }
                            if (h > previewHeight) {
                                h = previewHeight;
                                that.css({ top: 0, height: h });
                            } else {
                                that.css({ marginTop: -(h / 2) });
                            }
                        });
                    }
                },
                setStyle: function () {
                    upload.setHeight();
                    $("#list div").hover(upload.itemOver, upload.itemOut);
                    $("#list a.btn-preview").click(upload.preview);
                    // upload.preview();
                }
            }
        })()
        window.onload=function(){
            setTimeout(upload.setStyle,50);
        }
        window.onresize=upload.setHeight;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <p class="preview" id="preview">
                <img src="img/loading.gif" id="previewLoading" class="preview-loading"/>
                <img src="img/s.gif" id="previewImg"/>
            </p>
        <asp:HiddenField ID="hidePath" runat="server"/>
        <div id="head" class="head">
            <div class="title">
                <input id="checkAll" class="checkall" type="checkbox" onclick="upload.checkAll(this);"/>
                <span>当前目录:</span>
                 <asp:Label ID="lbCurrentPath" runat="server" Text="/UploadFolder/image/"></asp:Label>
                <asp:LinkButton ID="linkBack" runat="server" CssClass="back">返回上一级</asp:LinkButton>
            </div>
        </div>

        <div id="list" class="list">
            <div>
                <input type="checkbox" name="checkItem"/>
                <img src="img/s.gif" class="file gif"/> 
                <a href="#">error.gif</a>
                <span>
                    <a href="#" class="btn-preview">预览</a>
                    <a href="#">插入</a>
                    <a href="#">删除</a>
                </span>
            </div>
            <div class="odd">
                <input type="checkbox" name="checkItem"/>
                <img src="img/s.gif" class="file png" /> 
                <a href="#">loading.png</a>
                <span>
                    <a href="#" class="btn-preview">预览</a>
                    <a href="#">插入</a>
                    <a href="#">删除</a>
                </span>
            </div>
            <div>
                <input type="checkbox" name="checkItem"/>
                <img src="img/s.gif" class="file gif"/> 
                <a href="#">error.gif</a>
                <span>
                    <a href="#" class="btn-preview">预览</a>
                    <a href="#">插入</a>
                    <a href="#">删除</a>
                </span>
            </div>
             <div class="odd">
                <input type="checkbox" name="checkItem"/>
                <img src="img/s.gif" class="file png" /> 
                <a href="#">loading.png</a>
                <span>
                    <a href="#" class="btn-preview">预览</a>
                    <a href="#">插入</a>
                    <a href="#">删除</a>
                </span>
            </div>
            <div>
                <input type="checkbox" name="checkItem"/>
                <img src="img/s.gif" class="file gif"/> 
                <a href="#">error.gif</a>
                <span>
                    <a href="#" class="btn-preview">预览</a>
                    <a href="#">插入</a>
                    <a href="#">删除</a>
                </span>
            </div>
            <div class="odd">
                <input type="checkbox" name="checkItem"/>
                <img src="img/s.gif" class="file png" /> 
                <a href="#">loading.png</a>
                <span>
                    <a href="#" class="btn-preview">预览</a>
                    <a href="#">插入</a>
                    <a href="#">删除</a>
                </span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
