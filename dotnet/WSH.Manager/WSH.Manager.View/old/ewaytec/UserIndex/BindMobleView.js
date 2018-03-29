/*
author:         wang song hua
createDate:     2013-4-25
content:        绑定手机
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var tpl = require('templateLoad');
    var _ = require('underscore');
    var ens = require('ens');
    var controller = "UserIndex";

    //require("~/Scripts/libs/jquery.combobox/1.10.3/jquery.combobox.js")($)
    require("~/Scripts/libs/jquery.combobox/sexy/jquery.sexy-combo.js")($)

    //用户中心信息展示
    var BindMobleView = Backbone.View.extend({
        initialize: function () {

            this.render();
            this.combox = $("#jsBindMobile");
            //绑定
            //  var mobiles = this.options.mobiles || [];
            //this.bindCombox(mobiles);
            this.combox.next("input").val('');
            this.defaultTime = this.options.time;
            this.time = this.defaultTime;
            var that = this;
            this.btn = $("#jsSendMobileCodeBtn");
            this.btn.click(function () {
                if (!$(this).hasClass("disabled")) {
                    that.sendCode();
                }
            });

            //绑定下一步上一步
            $("#btnMobileNextStep1").click(function () {
                that.next();
            });
            $("#btnMobileNextPrev1").click(function () {
                that.prev();
            });
            $("#btnMobileNextStep2").click(function () {
                that.complete();
            });
            //重新绑定
            $("#jsReBindMobileBtn").click(function () {
                that.reBind();
            });
            //关闭
            $("#js_closePhone").click(function () {
                that.close();
            });
        },
        render: function () {
            this.$el.append(tpl.get(controller + "/BindMobile"));
        },
        bindCombox: function (mobiles) {
            this.combox.empty();
            for (var i = 0; i < mobiles.length; i++) {
                this.combox.append('<option value="' + mobiles[i] + '">' + mobiles[i] + '</option>');
            }
            // this.combox.combobox();
            this.combox.sexyCombo({

            });
        },
        open: function () {
            var mobiles = this.options.getMobiles ? this.options.getMobiles() : [];
            this.combox.remove();
            this.combox = null;
            $("#jsBindMobilePanel").html('<select class="js_combobox" id="jsBindMobile"></select>');
            this.combox = $("#jsBindMobile");
            this.bindCombox(mobiles);
            this.combox.next("input").val('');
            $("#jsSendMobileWrap").dialog({
                title: "绑定手机",
                width: 500, resizable: false, modal: true, dialogClass: "e_blueDialog"
            });
            this.prev();
        },
        close: function () {
            $("#jsSendMobileWrap").dialog("close");
        },
        getMobile: function () {
            return $.trim(this.combox.next("input").val());
        },
        setTimer: function () {
            //各多少秒后发送
            var that = this;
            this.timer && clearInterval(this.timer);
            this.timer = setInterval(function () {
                if (that.time <= 0) {
                    clearInterval(that.timer);
                    that.btn.removeClass("disabled");
                    $("#jsSendMobileCodeMsg").hide();
                    that.btn.html("获取验证码");
                    that.time = that.defaultTime;
                } else {
                    that.btn.html(that.time + "秒后重新发送");
                    that.time--;
                }
            }, 1000);
        },
        sendCode: function () {
            //发送手机验证码
            this.btn.addClass("disabled");
            var url = this.getUrl("UpdateBandingMobileOfGetValidateCode"),
                params = { newMobile: this.getMobile(), _t: new Date().getTime() },
                that = this;
            $.get(url, params, function (data) {
                if (data.Result) {
                    that.setTimer();
                } else {
                    that.btn.removeClass("disabled");
                }
                $("#jsSendMobileCodeMsg").show().attr("class", "on" + (data.Result ? "Correct" : "Error")).html(data.Data.ResultHtml);
            }, "json");
        },
        getUrl: function (action) {
            return require.parsePath("~/" + controller + "/" + action);
        },
        validMobile: function (mobile) {
            var err = $("#jsBindMobileError");
            if (mobile == "") {
                err.show().html("请输入需要绑定的手机号码");
                return false;
            }
            if (mobile == this.options.bindMobile) {
                err.show().html("新手机号码必须与旧手机号码不同");
                return false;
            }
            //验证手机格式
            if (!/^(((13|15|18)[0-9])|147)\d{8}$/.test(mobile)) {
                err.show().html("手机号码格式不正确");
                return false;
            } else {
                err.hide();
            }
            return true;
        },
        hidePanel: function () {
            $("div.jsBindMobilePanel").hide();
        },
        next: function () {
            var mobile = this.getMobile();
            if (this.validMobile(mobile)) {
                this.hidePanel();
                $("#jsNextMobilePanel").show();
                $("span.jsNextMobileValue").html(mobile);
            }
        },
        complete: function () {
            //绑定手机
            var error = $("#jsSendMobileCodeError"),
                code = $("#jsSendMobileCode").val();
            if ($.trim(code) == "") {
                error.show().html("请输入手机验证码");
            } else {
                var url = this.getUrl("UpdateBandingMobile"),
                    mobile = this.getMobile(),
                    params = { newMobile: mobile, validateCode: code, _t: new Date().getTime() },
                    that = this;
                $.post(url, params, function (data) {
                    if (data.Result) {
                        that.hidePanel();
                        $("#jsCompleteMobileePanel").show();
                        that.options.rebindvalue(mobile);
                        //that.close();
                    } else {
                        error.show().html(data.Data.ResultHtml);
                    }
                }, "json");
            }
        },
        prev: function () {
            this.hidePanel();
            $("#jsPrevMobilePanel").show();
            $("#jsSendMobileCodeError").hide();
        },
        reBind: function () {
            this.prev();
        }
    });

    return BindMobleView;
});