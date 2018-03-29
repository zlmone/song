<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Draw.aspx.cs" Inherits="Song.WebSite.View.page.Draw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        body{ padding:0px; margin:0px; overflow:hidden;}
        .reportPageItem{ width:100%;}
        .reportPageLeft{ float:left; width:70%; background:#ccc; overflow:auto;}
        .reportPageRight{ float:left; width:29.9%; background:#ddd;}
        .reportPageRight table{width:100%; }
        .reportPageClear{ clear:both; overflow:hidden; font-size:0px; height:0px; width:0px;}
    </style> 
    <script type="text/javascript">
        function report(options) {
            $.extend(this, {
                pages:1,
                index:1,
                prevBtn: $("#btnPrevReport"),
                nextBtn: $("#btnNextReport"),
                firstBtn:$("#btnFirstReport"),
                lastBtn:$("#btnLastReport"),
                pageInfo:$("#reportPageInfo")
            },options);
        }
        report.prototype = {
            init: function () {
                var me = this;
                this.prevBtn.click(function () {
                    me.prev();
                });
                this.nextBtn.click(function () {
                    me.next();
                });
                this.firstBtn.click(function () {
                    me.first();
                });
                this.lastBtn.click(function () {
                    me.last();
                });
                this.pageChange();
            },
            disabled: function (obj, isDisabled) {
                isDisabled ? obj.attr("disabled", "disabled") : obj.removeAttr("disabled");
            },
            prev: function () {
                this.index--;
                this.pageChange();
            },
            next: function () {
                this.index++;
                this.pageChange();
            },
            first:function(){
                this.index=1;
                this.pageChange();
            },
            last:function(){
                this.index=this.pages;
                this.pageChange();
            },
            pageChange: function () {
                this.items && this.items.hide();
                this.items.eq(this.index - 1).show();
                this.setEnabled();
            },
            setEnabled: function () {
                this.disabled(this.firstBtn, false);
                this.disabled(this.prevBtn, false);
                this.disabled(this.nextBtn, false);
                this.disabled(this.lastBtn, false);
                if (this.index <= 1) {
                    this.disabled(this.firstBtn, true);
                    this.disabled(this.prevBtn, true);
                }
                if (this.index >= this.pages) {
                    this.disabled(this.nextBtn, true);
                    this.disabled(this.lastBtn, true);
                }
                this.pageInfo.html("第<span style='color:red;'>"+this.index+"</span>页/共"+this.pages+"页");
            }
        }
        $(function () {
            var r = new report({
                items:$("#reportWrap").find("div.reportPageItem"),
                pages:<%=ReportMapPageCount %>
            });
            r.init();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=MapArea %>
        <asp:Label ID="imgWrap" runat="server"></asp:Label>
    </div>
    <div id="reportWrap">
        <%=ReportMapPage%>
    </div>
    <div>
    
        <input type="button" value="首页" id="btnFirstReport"/>
        <input type="button" value="上一页" id="btnPrevReport"/>
        <input type="button" value="下一页" id="btnNextReport"/>
        <input type="button" value="尾页" id="btnLastReport"/>
        &nbsp;&nbsp;
        <span id="reportPageInfo"></span>
    </div>
    </form>
</body>
</html>

