<%@ page language="java" contentType="text/html; charset=utf-8" pageEncoding="utf-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%
    String path = request.getContextPath();
    String basePath = request.getScheme() + "://"
            + request.getServerName() + ":" + request.getServerPort()
            + path + "/";
%>

<!DOCTYPE html >
<html>
<head>
    <!--解决 IE6 背景缓存-->
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="format-detection" content="telephone=no">
    <title>错误界面</title>
    <style type="text/css">


        a, fieldset, img {
            border: 0;
        }

        a {
            color: #221919;
            text-decoration: none;
            outline: none;
        }

        a:hover {
            color: #3366cc;
            text-decoration: underline;
        }

        body {
            font-size: 1rem;
            color: #B7AEB4;
        }

        body a.link, body h1, body p {
            -webkit-transition: opacity 0.5s ease-in-out;
            -moz-transition: opacity 0.5s ease-in-out;
            transition: opacity 0.5s ease-in-out;
        }

        #wrapper {
            text-align: center;
            margin: 100px auto;
            width: 594px;
        }

        a.link {
            text-shadow: 0px 1px 2px white;
            font-weight: 600;
            color: #3366cc;
            opacity: 0;
        }

        h1 {
            text-shadow: 0px 1px 2px white;
            font-size: 1rem;
            opacity: 0;
        }

        img {
            -webkit-transition: opacity 1s ease-in-out;
            -moz-transition: opacity 1s ease-in-out;
            transition: opacity 1s ease-in-out;
            height: 9.2rem;
            width: 9rem;
            opacity: 0;
        }

        p {
            text-shadow: 0px 1px 2px white;
            font-weight: normal;
            font-weight: 200;
            opacity: 0;
        }

        .fade {
            opacity: 1;
        }

        @media only screen and (min-device-width: 320px) and
        (max-device-width: 480px) {
            #wrapper {
                margin: 40px auto;
                text-align: center;
                width: 280px;
            }
        }
    </style>
</head>
<body>
<div id="wrapper">
    <a href="#"><img class="fade"
                     src="<%=basePath%>images/404_icon.png">
    </a>
    <div>
        <h1 class="fade">
            温馨提示：
            <c:if test="${not empty errorInfo}">${errorInfo}</c:if>
            <c:if test="${ empty errorInfo}">您访问的地址不存在！</c:if>
        </h1>
        <p class="fade">
            你正在寻找的页面无法找到。
            <a style="opacity: 1;" class="link" href="/czcqw"
               onclick="history.go(-1)">返回?</a>
        </p>

    </div>
</div>
</body>
</html>

