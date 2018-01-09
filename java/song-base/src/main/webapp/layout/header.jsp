
<%@ page contentType="text/html;charset=UTF-8" import="com.song.net.http.HttpRequest" language="java" %>
<%
    String basePath = new HttpRequest(request).getBasePath();
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>开发者平台</title>
    <link rel="stylesheet" href="<%=basePath%>static/style/layout.css"/>
    <link rel="stylesheet" href="<%=basePath%>static/js/easyui/themes/default/easyui.css"/>
    <link rel="stylesheet" href="<%=basePath%>static/js/easyui/themes/icon.css"/>

    <script type="text/javascript" src="<%=basePath%>static/js/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/json/json2.js"></script>


    <script type="text/javascript" src="<%=basePath%>static/js/easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/easyui/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/extend/easyui.defaults.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/extend/easyui.validate.js"></script>

    <script type="text/javascript" src="<%=basePath%>static/js/song/base/song.base.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/song/common/song.iframe.js"></script>

    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.view.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.query.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.grid.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.dialog.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.form.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.tabs.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.combobox.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.tree.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.builder.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/cmp/cmp.builder.easyui.js"></script>

    <script type="text/javascript">
        $.extend(cmp.view, {
            debug:true,
            root: "<%=basePath%>"
        });
    </script>
</head>
<body>

