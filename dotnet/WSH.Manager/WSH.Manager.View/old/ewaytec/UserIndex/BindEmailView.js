/*
author:         wang song hua
createDate:     2013-4-25
content:        绑定邮箱
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var tpl = require('templateLoad');
    var _ = require('underscore');
    var ens = require('ens');
    var controller = "UserIndex";
    require("jqueryui")($);

    //用户中心信息展示
    var BindEmailView = Backbone.View.extend({
        getUrl: function (action) {
            return require.parsePath("~/" + controller + "/" + action);
        },
        initialize: function () {
            this.time = this.options.time;
            this.timer = this.time;
            this.isSend = true;
            this.render();
            var that = this;
            $("#btnEmailNextStep1").click(function () {
                that.next();
            });
            $("#btEmailPrevStep1").click(function () {
                that.prev();
            });
            //关闭
            $("#js_closeEmail").click(function () {
                that.close();
            });
            //重发
            $("#jsReSendEmail").click(function () {
                that.prev();
                that.next();
            });
            //  this.setEmail(this.options.email);
        },
        getIsNextSend: function () {
            //判断是否可以进行下一次发送，默认一分钟
            var isSend = this.isSend;
            if (!isSend) {
                $("#jsBindEmailError").show().html("您获取激活邮件的频率过高");
                return false;
            }
            return isSend;
        },
        setTimer: function () {
            //配置时间之后才能继续发送
            var that = this;
            that.isSend = false;
            var t = setInterval(function () {
                that.timer--;
                if (that.timer <= 0) {
                    that.timer = that.time;
                    clearInterval(t);
                    that.isSend = true;
                }
            }, 1000);
        },
        openFirst: function () {
            $("#jsSendEmailWrap").dialog({
                title: "绑定邮箱",
                width: 480, resizable: false, modal: false,
                dialogClass: "e_imDialog"
            });
            //$("#jsSendEmailWrap").addClass("e_imDialog");
            //$("#jsSendEmailWrap").parent().addClass("e_imDiaBox");
            //this.close();
        },
        open: function () {
           
            $("#jsSendEmailWrap").dialog({
                title: "绑定邮箱",
                width: 480, resizable: false, modal: true,dialogClass:"e_imDialog"
            });
           
        },
        close: function () {
            $("#jsSendEmailWrap").dialog("close");
        },
        render: function () {
            this.$el.append(tpl.get(controller + "/BindEmail"));
        },
        getEmail: function () {
            return $.trim($("#jsBindEmailValue").val());
        },
        setEmail: function (value) {
            value && $("#jsBindEmailValue").val(value);
        },
        valid: function (email) {
            if (!this.getIsNextSend()) {
                return false;
            }
            var err = $("#jsBindEmailError").hide();
            if (email == "") {
                err.show().html("请输入需要绑定的邮箱");
                return false;
            }
            //验证手机格式
            if (!/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(email)) {
                err.show().html("邮箱格式不正确");
                return false;
            }
            return true;
        },
        hidePanel: function () {
            $("div.jsBindEmailPanel").hide();
        },
        prev: function () {
            this.hidePanel();
            $("#jsBindEmailError").hide();
            $("#jsPrevEmailPanel").show();
        },
        wait: function (enabled) {
            var btn = $("#btnEmailNextStep1");
            enabled ? btn.attr("disabled", "disabled") : btn.removeAttr("disabled");
        },
        next: function () {
            var error = $("#jsBindEmailError").hide();
            var email = this.getEmail();
            var that = this;
            if (this.valid(email)) {
                this.wait(true);
                var url = this.getUrl("UpdateBandingEmail"),
                    params = { newEmail: email, _t: new Date().getTime() },
                    that = this;
                $.post(url, params, function (data) {
                    that.wait(false);
                    if (data.Result) {
                        that.hidePanel();
                        $("#jsCompleteEmailPanel").show();
                        that.setTimer();
                        $("#jsSendBindEmailValue").html(email);
                        //that.options.rebindvalue(email);
                        // that.close();
                    } else {
                        error.show().html(data.Data.ResultHtml);
                    }
                }, "json");
            }
        }
    });

    return BindEmailView;
});