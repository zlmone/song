
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

    <script type="text/javascript" src="<%=basePath%>static/js/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/json/json2.js"></script>

    <script type="text/javascript">
        window.root="<%=basePath%>";
    </script>
</head>
<body>

