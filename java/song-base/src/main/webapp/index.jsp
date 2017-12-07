<%@ page language="java" import="com.song.net.http.*" pageEncoding="utf-8"%>
<%
String basePath =new HttpRequest(request).getBasePath();
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
      <style type="text/css">

      </style>
      <script type="text/javascript">
function aa(){}
      </script>
  </head>

  <body>
  <form action="<%=basePath%>index/upload" enctype="multipart/form-data" method="post">
      <input type="file" name="fileImage"/>
      <input type="submit" value="上传"/>
  </form>
  </body>
</html>
