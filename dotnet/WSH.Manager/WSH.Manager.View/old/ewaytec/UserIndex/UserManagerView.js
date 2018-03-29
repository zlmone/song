/*
author:         wang song hua
createDate:     2013-4-25
content:        个人用户管理中心
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var tpl = require('templateLoad');
    var _ = require('underscore');
    var ens = require('ens');
    var m = require("~/Scripts/src/Model/Home/UserManagerModel.js");
    var controller = "UserIndex";
    var RePassword = require("~/Scripts/src/View/UserIndex/RePasswordView.js");
    var UserContact = require("~/Scripts/src/View/UserIndex/UserContactView.js");
    require("jqueryui")($)


    //用户中心信息展示
    var UserCenterInfoView = Backbone.View.extend({
        model: new m.UserCenterInfoModel(),
        initialize: function () {
            this.$el.append(tpl.get("UserIndex/UserInfoWrap"));
          //  this.showDefaultDialog();
            var that = this;
            this.wrap = $("#jsTabUserInfo");
            var userid = this.options.userid;
            this.model.fetch(userid, function (data) {
                //处理数据
                if (data == null || data.Result == false || data.Data == null) {
                    ens.dialog.msgbox("error", "获取用户信息失败");
                } else {
                   // data.Data.IsShowMobile = true;
                    //data.Data.IsAdmin = false;
                    $("#jsModifyUserInfo").show();
                    //点击修改基本信息
                    $("#jsTabReInfo").click(function () {
                        that.selectedTab($(this));
                        that.hideAll();
                        $("#jsTabContact").show();
                    });

                    //修改帐号
                    $("#jsTabReUserName").click(function () {
                        that.selectedTab($(this));
                        that.hideAll();
                        //UserPlatformView.open();
                        $("#jsTabUserName").show();
                    });

                    that.renderData(data);

                    //如果是非当前用户，则只能查看
                    if (!data.Data.IsCurrentUser) {
                        $("#jsModifyUserInfo").hide();
                    } else {
                        //初始化修改用户界面
                        var UserContactView = new UserContact({ el: that.wrap, data: data.Data,
                            reloaduser: function (dataset) {
                                that.renderData(dataset);
                                that.clearSelected();
                            }
                        });
                    }
                    //点击个人资料显示个人资料查看
                    $("#jsUserInfoLi").click(function () {
                        that.hideAll();
                        $("#jsTabBaseUserInfo").show();
                        that.clearSelected();
                    });
                    //添加设置密码，设置帐号，验证邮箱和验证手机的html内容
                    var RePasswordView = new RePassword({ el: that.wrap, CryptKey: data.Data.CryptKey });
                    //修改密码
                    $("#jsTabRePwd").click(function () {
                        that.selectedTab($(this));
                        that.hideAll();
                        RePasswordView.show();
                    });

                    //获取邮箱和手机的提示
                    var url = that.getUrl("GetPersonCenterWarmInfo"),
                        params = {};
                    $.get(url, params, function (data) {
                        if (data.MobileTemplateInfo) {
                            $("p.jsDisplayTipMobile").html(data.MobileTemplateInfo);
                        }
                        if (data.EmailTemplateInfo) {
                            $("p.jsDisplayTipEmail").html(data.EmailTemplateInfo);
                        }
                    }, "json");

                }
            });
        },
        showDefaultDialog: function () {
            $("#jsHideDefaultDialog").dialog({ width: 1, height: 1 });
            $("#jsHideDefaultDialog").addClass("e_imDialog");
            $("#jsHideDefaultDialog").parent().addClass("e_imDiaBox");
            $("#jsHideDefaultDialog").parent().parent().hide();
        },
        getUrl: function (action) {
            return require.parsePath("~/" + controller + "/" + action);
        },
        clearSelected: function () {
            $("#jsModifyUserInfo li").removeClass("sel");
        },
        selectedTab: function (a) {
            var li = a.parent();
            this.clearSelected();
            li.addClass("sel");
        },
        renderData: function (d) {
            var data = d.Data;
            var renderData = this.parseData(data);
            this.render(renderData);
            //没有值的项不显示
            $("table.jsRequiredUserInfo").find("td").each(function () {
                var td = $(this);
                if ($.trim(td.html()) == "") {
                    td.parent().hide();
                }
            });
        },
        hideAll: function () {
            $("div.jsTabContentItem").hide();
        },
        parseData: function (data) {
            var model = {};
            var types = this.model.getTypeList();
            for (var nm in types) {
                model[nm] = [];
            }
            for (var key in types) {
                var list = data[key],
                    type = types[key];
                var regex = data.IsShowMobile ? /Mobiles|Emails/ : /Emails/;
                if (regex.test(key)) {
                    //如果没有绑定
                    if (this.getDefault(list) == null) {
                        model[key].push("未绑定<br>");
                    }
                }
                for (var i = 0; i < list.length; i++) {
                    var value = list[i][type];
                    if (value) {

                        if (list[i].IsDefault) {
                            if (regex.test(key)) {
                                model[key].push(value);
                                model[key].push('<span class="cGreen">[&nbsp;已绑定&nbsp;]</span>');
                                model[key].push("<br>");
                            }
                        } else {
                            model[key].push(value);
                            model[key].push('<span class="cGray999">[&nbsp;' + this.getAttrName(list[i].Type, type) + '&nbsp;]</span>');
                            model[key].push("<br>");
                        }

                    }
                }
            }
            var rows = [];
            for (var k in types) {
                var type = types[k];
                if ((data[type] && data[type].length > 0) || model[k].length > 0) {
                    rows.push('<tr>');
                    rows.push('<th width="70px">' + this.model.getTitle(type) + '：</th>');
                    rows.push('<td>' + model[k].join('') + '</td>');
                    rows.push('</tr>');
                }
            }

            data.ContactContent = rows.join('');
            return data;
        },
        getAttrName: function (attrcode, type) {
            var title = this.model.getTitle(type);
            var attrs = {
                Common: "常用" + title,
                Work: "办公" + title,
                Family: "家庭" + title,
                QQ: "QQ",
                MSN: "MSN",
                Fetion: "飞信号"
            }
            return attrs[attrcode];
        },
        getDefault: function (list) {
            for (var i = 0; i < list.length; i++) {
                if (list[i] && list[i].IsDefault) {
                    return list[i];
                }
            }
            return null;
        },
        render: function (data) {
            this.hideAll();
            $("#jsTabBaseUserInfo").remove();
            this.wrap.append(_.template(tpl.get('UserIndex/BaseInfo'))(data));
        }
    });

    return {
        UserCenterInfoView: UserCenterInfoView
    };
});