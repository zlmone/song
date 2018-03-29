/*
author:         wang song hua
createDate:     2013-4-25
content:        平台帐号
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var ens = require('ens');
    var tpl = require('templateLoad');
    var controller = "UserIndex";

    var UserPlatformView = Backbone.View.extend({
        initialize: function () {
            this.render();
            this.currentname = this.options.username;
            this.username = $("#jsPlatformUserName");
            $("#jsOldPlatformUserName").html(this.currentname);
            this.submitBtn = $("#jsPlatformSubmit");
            this.closeBtn = $("#jsPlatformClose");
            var that = this;
            //            this.username.change(function () {
            //                that.valid(this.value);
            //            });
            this.submitBtn.click(function () {
                if (that.valid()) {
                    that.validRepeat();
                }
            });
            this.closeBtn.click(function () {
                that.close();
            });
        },
        render: function () {
            this.$el.append(tpl.get(controller + "/ModifyAccount"));
        },
        open: function (name) {
            name && $("#jsOldPlatformUserName").html(name);
            this.username.val('');
            this.setError(null);
            $("#jsUpdateUser").dialog({
                width: 405, title: "修改平台帐号", resizable: false, modal: true
            });
            $("#jsUpdateUser").addClass("e_imDialog");
            $("#jsUpdateUser").parent().addClass("e_imDiaBox");
        },
        close: function () {
            $("#jsUpdateUser").dialog("close");
        },
        getUrl: function (action) {
            return require.parsePath("~/" + controller + "/" + action);
        },
        submit: function () {
            var that = this;
            var username = this.getValue();
            $.ajax({
                url: this.getUrl("UpdateUserAccount"),
                type: "post",
                dataType: "json",
                data: { newUserName: username, _t: new Date().getTime() },
                success: function (data) {
                    if (data.Result) {
                        ens.dialog.msgbox("success", "修改平台帐号成功");
                        //修改帐号成功之后关闭弹窗，并刷新帐号
                        $(".jsCurrentUserName").html(username);
                        that.options.resetusername && that.options.resetusername(username);
                        that.close();
                    } else {
                        ens.dialog.msgbox("error", "修改平台帐号失败");
                    }
                },
                error: function () {
                    that.setError("服务器繁忙，请稍后再试");
                }
            });
        },
        getValue: function () {
            return $.trim(this.username.val());
        },
        validRepeat: function () {
            //验证平台帐号是否有重复
            var url = this.getUrl("ValidateUserUserNameExists"), that = this;
            $.post(url, { newUserName: this.getValue(), _t: new Date().getTime() }, function (data) {
                if (!data.Result) {
                    that.setError(data.Data.ResultHtml);
                } else {
                    that.submit();
                }
            }, "json");
        },
        valid: function (val) {
            this.setError(null);
            val = val ? val : this.getValue();
            if (val == "") {
                this.setError("帐号不能为空");
                return false;
            }
            //验证是否是数字，字母，下划线,只能以字母开头，不能以下划线结束
            if (!/^[A-Za-z]{1}[A-Za-z0-9_]{1,13}[A-Za-z0-9]{1}$/.test(val)) {
                this.setError("帐号格式不正确"); return false;
            }
            return true;
        },
        setError: function (err) {
            var error = $("#jsPlatformError");
            err ? error.show().find("span.onError").show().html(err) : error.hide();
        }
    });

    return UserPlatformView;
});