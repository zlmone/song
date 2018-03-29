/*
author:         wang song hua
createDate:     2013-4-17
content:        打开应用视图
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var AppTabView = require("~/Scripts/src/View/App/AppTabView.js");

    var AppView = Backbone.View.extend({
        initialize: function () {
            //初始化应用选项卡相关的元素
            this.appTab = new AppTabView();
        },
        openApp: function (options) {
            //打开应用入口
            this.getAppInfo(options.appcode);
        },
        getAppInfo: function (appCode) {
            var url = require.parsePath("~/Home/GetApp"),
                params = { appCode: appCode },
                that = this;
            $.get(url, params, function (data) {
                that.authApp(data);
            }, "json");
        },
        authApp: function (appinfo) {
            if (appinfo == null || appinfo.AppCode == null) {
                return;
            }
            var authtype = appinfo.AuthType,
                that = this;
            if (authtype != 0) {
                //cookie鉴权
                that.openAppTab(appinfo);
            } else {
                //OAuth2鉴权
                var url = require.parsePath("~/Home/LoginAppWeb"),
                    params = { appCode: appinfo.AppCode, redirectUrl: appinfo.AppUrl };
                $.get(url, params, function (data) {
                    //获取鉴权码成功
                    if (data && data.Code != "") {
                        that.openAppTab(appinfo, "code=" + data.Code);
                    }
                }, "json");
            }
        },
        openAppTab: function (appinfo, params) {
            var url = appinfo.AppUrl;
            //打开应用选项卡
            if (params) {
                if (url.indexOf("?") <= -1) {
                    url += "?" + params;
                } else {
                    url += "&" + params;
                }
            }
            //先打开
            this.appTab.open({
                code: appinfo.AppCode,
                text: appinfo.AppName,
                url: url,
                img: appinfo.AppLogo
            });
        }
    });
    return AppView;
});