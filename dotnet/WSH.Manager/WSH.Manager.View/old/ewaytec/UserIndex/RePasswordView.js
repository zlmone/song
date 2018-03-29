/*
author:         wang song hua
createDate:     2013-4-25
content:        修改用户密码
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var tpl = require('templateLoad');
    var _ = require('underscore');
    var ens = require('ens');
    var controller = "UserIndex";

    //修改密码
    var RePasswordView = Backbone.View.extend({
        initialize: function () {
            //添加html模板
            this.$el.append(tpl.get(controller + "/ModifyPwd"));
            var that = this;
            this.oldpwd = $("#jsOldPwd");
            this.newpwd = $("#jsNewPwd");
            this.newrepwd = $("#jsNewRePwd");
            this.pwdintensity = $("#jsPwdIntensity");

            this.newpwd.change(function () {
                that.parseIntension();
            }).keyup(function () {
                that.parseIntension();
            });
            $("#btnModifyPwdSave").click(function () {
                that.validSubmit();
            });
            $("#btnModifyPwdCancel").click(function () {
                that.close();
            });
        },
        show: function () {
            $("#jsRePwdDialog").show();
        },
        open: function () {
            //弹出修改密码框
            $("#jsRePwdDialog").dialog({
                title: "修改个人密码",
                width: 550, resizable: false, modal: true,dialogClass:"e_imDialog"
            });
            
        },
        close: function () {
            // $("#jsRePwdDialog").dialog("close");
            $("div.jsTabContentItem").hide();
            $("#jsTabBaseUserInfo").show();
            $("#jsModifyUserInfo li").removeClass("sel");
            //$("#jsModifyUserInfo li:first").addClass("sel");
        },
        getUrl: function (action) {
            return require.parsePath("~/" + controller + "/" + action);
        },
        validSubmit: function (callback) {
            this.setError(null);
            if (!this.valid()) {
                return false;
            }
            this.submit();
            //            var url = this.getUrl("ValidatePass");
            //            var that = this;
            //            var params = { UserPassword: this.getPwd(), userId: this.userid };
            //            $.post(url, params, function (data) {
            //                if (data.ResultLevel == 0) {
            //                    
            //                } else {
            //                    that.setError("密码格式不匹配");
            //                }
            //            }, "json");
        },
        valid: function () {
            var oldpwd = this.oldpwd.val(),
                newpwd = this.newpwd.val(),
                newrepwd = this.newrepwd.val();
            if ($.trim(oldpwd) == "") {
                this.setError("请输入当前密码"); return false;
            }
            if ($.trim(newpwd) == "") {
                this.setError("请输入新密码"); return false;
            }
            if ($.trim(newrepwd) == "") {
                this.setError("请再次输入新密码"); return false;
            }
            if (newpwd.length < 6 || newpwd.length > 20) {
                this.setError("密码长度应为6~20个字符"); return false;
            }
            if (newpwd != newrepwd) {
                this.setError("您两次输入的密码不一致"); return false;
            }
            if (oldpwd == newpwd) {
                this.setError("新密码必须与旧密码不同"); return false;
            }
            if (this.pwdintensity.attr("intensity") <= 1) {
                this.setError("密码强度不够"); return false;
            }
            return true;
        },
        setError: function (err) {
            var error = $("#jsRePwdError");
            err ? error.show().find("span.onError").show().html(err) : error.hide();
        },
        getPwd: function () {
            return this.newpwd.val();
        },
        parseIntension: function () {
            var url = this.getUrl("ValidatePassLevel"),
                that = this;
            var pwd = this.getPwd();
            if (pwd == "") {
                this.clearIntensity();
            } else {
                $.post(url, { pwd: this.getPwd(), _t: new Date().getTime() }, function (data) {
                    that.setPwd(parseInt(data.result) + 1);
                }, "json");
            }
        },
        setPwd: function (index) {
            //设置密码强度样式
            var pwd = this.clearIntensity();
            this.pwdintensity.attr({ intensity: index });
            pwd.each(function (i) {
                if (i == index) {
                    return false;
                } else {
                    pwd.eq(i).addClass("on");
                }
            });
        },
        clearIntensity: function () {
            this.pwdintensity.attr("intensity", "0");
            //this.setError(null);
            return $("#jsPwdIntensity").find("li").removeClass("on");
        },
        clearValue: function () {
            this.oldpwd.val('');
            this.newpwd.val('');
            this.newrepwd.val('');
            this.clearIntensity();
        },
        submit: function () {
            //            if (this.user == null) {
            //                this.setError("用户信息不存在"); return false;
            //            }
            var that = this,
                url = this.getUrl("UpdateUserPwd"),
                key = this.options.CryptKey || "",
                oldpwd = encMe(this.oldpwd.val(), key),
                newpwd = encMe(this.getPwd(), key);
            $.ajax({
                url: url,
                type: "post",
                dataType: "json",
                data: { oldPwd: oldpwd, newPwd: newpwd,resetPwdCryptKey:key, _t: new Date().getTime() },
                success: function (data) {
                    if (data.Result) {
                        ens.dialog.msgbox("success", "修改密码成功");
                        //修改密码成功之后，要清空值
                        that.clearValue();
                    } else {
                        that.setError(data.Data.ResultHtml || "修改密码失败");
                    }
                },
                error: function () {
                    that.setError("服务器繁忙，请稍后再试");
                }
            });
        }
    });
    return RePasswordView;
});