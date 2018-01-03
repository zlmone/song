<%@ page language="java" import="com.song.net.http.HttpRequest" pageEncoding="utf-8" %>
<%
    String basePath = new HttpRequest(request).getBasePath();
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Index</title>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="cache-control" content="no-cache">
    <meta http-equiv="expires" content="0">
    <meta http-equiv="keywords" content="keyword1,keyword2,keyword3">
    <meta http-equiv="description" content="This is my page">

    <script type="text/javascript" src="<%=basePath%>static/js/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="<%=basePath%>static/js/song/base/song.base.js"></script>
    <script type="text/javascript">
        song.basePath = "<%=basePath%>";
    </script>
</head>
<body>


