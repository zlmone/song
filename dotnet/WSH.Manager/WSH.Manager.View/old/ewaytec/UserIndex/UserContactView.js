/*
author:         wang song hua
createDate:     2013-4-25
content:        联系方式
update:         因南网不支持发送短信，所以暂时屏蔽发短信功能
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    var tpl = require('templateLoad');
    var _ = require('underscore');
    var ens = require('ens');
    var controller = "UserIndex";
    var AreaSelect = require("~/Scripts/src/View/Shared/AreaSelectView.js");
    var BirthdaySelect = require("~/Scripts/src/View/Shared/BirthdaySelectView.js");


    var BindEmail = require("~/Scripts/src/View/UserIndex/BindEmailView.js");
    var BindMoble = require("~/Scripts/src/View/UserIndex/BindMobleView.js");

    var UserPlatform = require("~/Scripts/src/View/UserIndex/UserPlatformView.js");

    var UserContactView = Backbone.View.extend({

        getUrl: function (action) {
            return require.parsePath("~/" + controller + "/" + action);
        },
        initialize: function () {
            var that = this;
            var data = this.options.data;
            this.isAdmin = data.IsAdmin;
            this.isShowMobile = data.IsShowMobile;
            //渲染基本信息
            that.$el.append(_.template(tpl.get('UserIndex/ModifyContact'))(data));
            that.$el.append(_.template(tpl.get('UserIndex/UserName'))(data));
            var UserPlatformView = new UserPlatform({
                el: this.$el, username: data.UserName,
                resetusername: function (username) {
                    that.options.data.UserName = username;
                }
            });
            $("#js_updateUsername").click(function () {
                UserPlatformView.open($("#jsCurrentUserName").html());
            });
            this.bindUpDown("Contact");
            this.bindUpDown("Info");
            that.wrap = $("#jsContactWrap");
            //渲染联系方式
            that.parseValue(data);

            //设置性别
            $("input[name='sex']").each(function () {
                if ($(this).val() == data.Sex) {
                    $(this).attr("checked", "checked");
                }
            });
            //渲染下拉控件,并初始化值
            that.area = new AreaSelect({
                value: data.LiveIn
            });
            that.birthday = new BirthdaySelect({
                value: data.Birthday
            });
            if (!data.IsAdmin) {
                that.renderUserName();
                //渲染绑定手机和邮箱
                $.get(that.getUrl("GetUpdateUserTime"), { _t: new Date().getTime() }, function (data) {
                    that.BindEmailView = new BindEmail({ el: that.$el, email: that.getBindValue("Email"),
                        time: data.UserIndexBindEmailValidateIntervalSendMessageTime,
                        rebindvalue: function (value) {
                            that.reloadBind("Email", value, 1);
                            that.reloadBind("Email", value, 2);
                        }
                    });
                    if (that.isShowMobile) {
                        that.BindMobleView = new BindMoble({ el: that.$el, mobiles: that.getMobiles(),
                            bindMobile: that.getBindValue("Mobile"),
                            time: data.UserIndexBindMobileValidateIntervalSendMessageTime,
                            getMobiles: function () {
                                return that.getMobiles();
                            },
                            rebindvalue: function (value) {
                                that.reloadBind("Mobile", value, 1);
                                that.reloadBind("Mobile", value, 2);
                            }
                        });
                    }
                }, "json");

                this.bindBindEvent(1);
                this.bindBindEvent(2);
            } else {
                $("#jsTabReUserName").hide();
                if (this.isShowMobile) {
                    this.getEl("Mobile", "bindMobile1").hide();
                }
                this.getEl("Email", "bindEmail2").hide();
            }
            //保存修改
            $("#btnModifySave").click(function () {
                that.submit();
            });
            //渲染日期控件
            require("jqueryui")($);
            //日期中文化，暂时方案，到时候移出了单独的js文件可删除
            $.datepicker.regional['zh-CN'] = {
                closeText: '关闭',
                prevText: '&#x3c;上月',
                nextText: '下月&#x3e;',
                currentText: '今天',
                monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
    '七月', '八月', '九月', '十月', '十一月', '十二月'],
                monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月',
    '七月', '八月', '九月', '十月', '十一月', '十二月'],
                dayNames: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
                dayNamesShort: ['周日', '周一', '周二', '周三', '周四', '周五', '周六'],
                dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
                weekHeader: '周',
                dateFormat: 'yy-mm-dd',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: true,
                yearSuffix: '年'
            };
            $.datepicker.setDefaults($.datepicker.regional['zh-CN']);

            $("#jsEntryTime").datepicker({
                dateFormat: "yy-mm-dd"
            });
            //打开上传头像
            this.openUpload();
        },
        openUpload: function () {
            var url = this.getUrl("UserHeadUpload"),
                title = "上传头像";
            var link = $("#jsUserHeadUpload").click(function () {
                ens.dialog.open(url, title, 500, 300, true, function (data) {
                    if (data) {
                        $("img.jsUserHeadImg").attr("src", data.Data.AbsoluteUrl);
                    }
                }, "jsUserHeadUploadDialog");
            });
            $("#jsUserHeadUploadImg").hover(function () {
                link.show();
            }, function () {
                link.hide();
            });
        },
        renderUserName: function () {
            //绑定修改帐号信息tab页的默认邮箱和默认手机
            if (this.isShowMobile) {
                $("#jsUserNameTbody").append(this.getBindHtml("Mobile", this.getBindValue("Mobile"), 2));
            }
            $("#jsUserNameTbody").append(this.getBindHtml("Email", this.getBindValue("Email"), 2));
        },
        bindBindEvent: function (mode) {
            //绑定手机
            var that = this;
            if (this.isShowMobile) {
                this.getEl("Mobile", "bindMobile" + mode).click(function () {
                    that.BindMobleView.open();
                });
            }
            //绑定邮箱
            this.getEl("Email", "bindEmail" + mode).click(function () {
                that.BindEmailView.open();
            });
        },
        getMobiles: function () {
            //获取联系方式里的手机号
            var mobiles = [],
                type = "Mobile";
            var rows = this.wrap.find("tr[contacttype='" + type + "']");
            for (var i = 0; i < rows.length; i++) {
                var row = rows.eq(i),
                    input = row.find("input:text:first"),
                    val = $.trim(input.val());
                if (val != "") {
                    mobiles.push(val);
                }
            }
            return mobiles;
        },
        getEntryTime: function () {
            return $("input.dateselect").val();
        },
        bindUpDown: function (type) {
            //绑定展开和隐藏
            var up = $("#js_packUp" + type),
                down = $("#js_packDown" + type),
                box = $("#js_packContactBox" + type);
            var that = this;
            up.click(function () {
                // box.show();
                that.showContectType(type, "show");
                down.show();
                up.hide();
            });
            down.click(function () {
                // box.hide();
                that.showContectType(type, "hide");
                up.show();
                down.hide();
            });
        },
        showContectType: function (type, method) {
            var ContactItems = type == "Contact" ? ["Fax", "Phone", "Address"] : ["Position", "EntryTime", "EnterpriseName"];
            for (var i = 0; i < ContactItems.length; i++) {
                var el = $("tr[contacttype='" + ContactItems[i] + "']")[method]();
            }
        },
        setNameError: function (name, err) {
            $(window).scrollTop(0);
            name.get(0).focus();
            name.next().next("span.onError").show().html(err);
        },
        getLength: function (str) {
            var realLength = 0, len = str.length, charCode = -1;
            for (var i = 0; i < len; i++) {
                charCode = str.charCodeAt(i);
                if (charCode >= 0 && charCode <= 128) realLength += 1;
                else realLength += 2;
            }
            return realLength;
        },
        submit: function () {
            //提交
            $("span.onError").hide();
            var data = this.options.data,
                that = this,
                realname = $("#txtRealName"),
                realnamevalue = $.trim(realname.val()),
                remark = $("#txtRemark"),
                remarkvalue = $.trim(remark.val()),
                entryTime = $.trim(this.getEntryTime());
            if (realnamevalue == "") {
                this.setNameError(realname, "真实姓名不能为空");
                return false;
            }
            if (this.getLength(realnamevalue) > 20) {
                this.setNameError(realname, "真实姓名不能超过20个字符");
                return false;
            }
            if (this.getLength(remarkvalue) > 100) {
                this.setNameError(remark, "备注不能超过100个字符");

                return false;
            }
            if (entryTime != "") {
                if (!/^(\d{4})(-|\/)(\d{1,2})\2(\d{1,2})$/.test(entryTime)) {
                    this.setNameError($("#jsEntryTime"), "日期格式不正确");
                    return false;
                }
            }
            var contacts = this.getValue();
            if (contacts != null) {
                $("#btnModifySave").attr("disabled", "disabled");
                //获取地市的值,获取生日的值
                var area = this.getArea(),
                    date = this.getDate();
                //赋值基本信息字段
                data["Remark"] = remarkvalue;
                data["RealName"] = realnamevalue;
                data["Birthday"] = date;
                data["LiveIn"] = area;
                data["HeadImg"] = $("#jsUserHeadUploadShowImg").attr("src");
                data["Sex"] = $("input[name='sex']:checked").val();
                data["EntryTime"] = entryTime; //入职时间
                //赋值联系方式
                for (var key in contacts) {
                    data[key] = contacts[key];
                }
                //删除模型不存在的字段
                delete data["ContactContent"];
                var newdata = data;
                var url = this.getUrl("UpdateUserBaseInfo"),
                    params = $.toJSON(data);

                $.ajax({
                    url: url,
                    dataType: "json",
                    type: "post", data: params,
                    contentType: "application/json",
                    success: function (data) {
                        $("#btnModifySave").removeAttr("disabled");
                        if (data.Result) {
                            //刷新基本信息
                            that.addBindValue(newdata);
                            newdata.Emails.reverse();
                            newdata.Mobiles.reverse();
                            that.username && (newdata.UserName = that.username);
                            that.options.reloaduser({ Data: newdata });
                            that.area.setAreaName();
                            $(window).scrollTop(0);
                            ens.dialog.msgbox('success', '保存成功');
                        } else {
                            ens.dialog.msgbox('error', data.Data.ResultHtml);
                        }
                    },
                    error: function () {
                        $("#btnModifySave").removeAttr("disabled");
                        ens.dialog.msgbox('error', '服务器繁忙，请稍后再试');
                    }
                });
            }
        },
        getArea: function () {
            //获取现居住地
            return this.area ? this.area.getValue() : "";
        },
        getDate: function () {
            //获取生日日期
            return this.birthday ? this.birthday.getValue() : "";
        },
        getId: function (code, type) {
            return "jsContactItem-" + code + "-" + type;
        },
        getEl: function (code, type) {
            return $("#" + this.getId(code, type));
        },
        getClass: function (type) {
            return "jsContactItem-" + type;
        },
        getRows: function (type) {
            return this.wrap.find("tr." + this.getClass(type));
        },
        getType: function (tr) {
            return tr.attr("contacttype");
        },
        checkMax: function (type) {
            return this.getRows(type).length >= 3;
        },
        checkMin: function (type) {
            return this.getRows(type).length <= 1;
        },
        getRow: function (btn) {
            return btn.parent().parent();
        },
        addItem: function (btn) {
            var row = this.getRow(btn),
                type = this.getType(row),
                that = this;
            if (!this.checkMax(type)) {
                //如果还可以继续添加改类型
                var parent = $(this.getTemplate(type, null));
                row.after(parent);
                this.bindAddRemove(type, parent);
            }
        },
        removeItem: function (btn) {
            var row = this.getRow(btn),
                type = this.getType(row);
            if (!this.checkMin(type)) { //不需要判断是否保留最后一个
                //如果最后一个就不能移除
                this.getEl(type, "add").unbind("click");
                this.getEl(type, "remove").unbind("click");
                row.remove();
                this.isRepeatType(type) || this.setTitle(type);
            }
        },
        getOptions: function (type, selectedValue) {
            //根据类型获取下拉框
            switch (type) {
                case "Mobile": return this.getOption("常用手机", "Common") + this.getOption("办公手机", "Work") + this.getOption("家庭手机", "Family");
                case "Email": return this.getOption("常用邮箱", "Common") + this.getOption("办公邮箱", "Work") + this.getOption("家庭邮箱", "Family");
                case "IM": return this.getOption("QQ", "QQ") + this.getOption("MSN", "MSN") + this.getOption("飞信号", "Fetion");
                case "Phone": return this.getOption("常用电话", "Common") + this.getOption("办公电话", "Work") + this.getOption("家庭电话", "Family");
                case "Fax": return this.getOption("常用传真", "Common") + this.getOption("办公传真", "Work") + this.getOption("家庭传真", "Family");
                case "Address": return this.getOption("常用地址", "Common") + this.getOption("办公地址", "Work") + this.getOption("家庭地址", "Family");
            }
        },
        getOption: function (text, value) {
            return '<option value="' + value + '">' + text + '</option>';
        },
        getMaxlength: function (type) {
            switch (type) {
                case "Mobile": return "11";
                case "Email": return "50";
                case "IM": return "20";
                case "Phone": return "30";
                case "Fax": return "20";
                case "Address": return "100";
            }
        },
        getTitle: function (type) {
            switch (type) {
                case "Mobile": return "手机";
                case "Email": return "邮箱";
                case "IM": return "IM";
                case "Phone": return "电话";
                case "Fax": return "传真";
                case "Address": return "地址";
            }
        },
        reloadBind: function (type, value, mode) {
            var el = this.getEl(type, "bindrow" + mode);
            this.getEl(type, "bind" + type + mode).unbind("click");
            el.after(this.getBindHtml(type, value, mode));
            el.remove();
            this.bindBindEvent(mode);
        },
        getBindHtml: function (type, value, mode) {
            var bid = this.getId(type, "bind" + type + mode),
                bindId = this.getId(type, "bindrow" + mode);
            //判断是否进行绑定了手机和邮箱
            var htmls = ['<tr id="', bindId, '"><th width="90px">', (mode == 2 ? "绑定" : ""), this.getTitle(type), '：</th><td>'];
            if (value) {
                //如果已经绑定
                htmls.push('<span id="' + this.getId(type, "bind") + '">' + value + '</span>');
                if (mode == 1) {
                    htmls.push('&nbsp;<a href="javascript:void(0)" class="cGreen" style="cursor:default;color:#679A00;text-decoration:none;">[&nbsp;已绑定&nbsp;]</a>');
                    if (!this.isAdmin) {
                        htmls.push('<a href="javascript:void(0)" id="' + bid + '">修改绑定</a>');
                    }
                } else {
                    htmls.push('<a href="javascript:void(0)" id="' + bid + '">修改</a>');
                }
            } else {
                if (mode == 1) {
                    htmls.push('<span class="cGray999">[&nbsp;未绑定&nbsp;]</span>&nbsp;');
                    if (!this.isAdmin) {
                        htmls.push('<a href="javascript:void(0)" id="' + bid + '">立即绑定</a>');
                    }
                } else {
                    htmls.push('未绑定&nbsp;&nbsp;<a href="javascript:void(0)" id="' + bid + '">修改</a>');
                }
            }
            htmls.push('<p class="tip_info jsDisplayTip' + type + '"></p>');
            htmls.push('</td></tr>');
            return htmls.join('');
        },
        getTemplate: function (type, data) {
            //获取增加联系方式的html模板
            var cls = this.getClass(type),
                value = data == null ? "" : data[type],
                selectedValue = data == null ? "" : 'value="' + data.Type + '"';
            return [
                '<tr class="', cls, '" contacttype="', type, '">',
                    '<th width="70px"></th>',
                    '<td contactitem="true">',
                        '<select style="width:120px;margin-right:5px;" ', selectedValue, '>', this.getOptions(type, selectedValue), '</select>',
                        '<input value="', value, '" maxlength="', this.getMaxlength(type), '" style="width:', (type == "Address" ? "400" : "235"), 'px;" type="text"/>',
                        '<span style="cursor:pointer" class="', this.getClass(type + "add"), '"><i class="e_iconAddBlue" ></i>添加</span>',
                        '<span style="cursor:pointer"  class="', this.getClass(type + "remove"), '"><i class="e_icon_NewDel"></i>清除</span>',
                        '<span class="onError" style="display:none"></span>',
                    '</td>',
                '</tr>'
            ].join('');
        },
        getRegex: function () {
            return {
                Email: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
                Mobile: /^(((13|15|18)[0-9])|147)\d{8}$/,
                IM: /[\u4e00-\u9fa5]+/, //非中文
                Fax: /^\d+$/,
                Phone: /^\d+$/
            };
        },
        valid: function (cells) {
            //验证填写的值
            this.wrap.find("span.onError").hide();
            var result = true,
                that = this,
                regex = this.getRegex(),
                repeat = {
                    Mobile: {},
                    Email: {}
                };
            for (var i = 0; i < cells.length; i++) {
                var cell = cells.eq(i),
                    type = that.getType(cell.parent()),
                    title = that.getTitle(type),
                    value = $.trim(cell.find("input:text:first").val());
                if (value == '') {
                    continue;
                }
                //判断是否符合规则
                if (regex[type]) {
                    //IM要求输入非中文
                    if ((type == "IM" && regex[type].test(value)) || (type != "IM" && !regex[type].test(value))) {
                        result = false;
                        that.setError(cell, title + "格式不正确");
                        continue;
                    }
                }
                //                //判断是否有重复的号码
                //                if (that.isRepeatType(type)) {
                //                    if (repeat[type][value]) {
                //                        result = false;
                //                        that.setError(cell, "该" + title + "应经存在");
                //                        continue;
                //                    }
                //                    repeat[type][value] = value;
                //                }
                //                //判断是否跟绑定的帐号重复
                //                if (that.isRepeatType(type)) {
                //                    var bindvalue = that.getBindValue(type);
                //                    if (value == bindvalue) {
                //                        result = false;
                //                        that.setError(cell, "不能和已绑定的" + title + "重复");
                //                        continue;
                //                    }
                //                }
            }
            return result;
        },
        getBindValue: function (type) {
            var el = this.getEl(type, "bind");
            return el.length > 0 ? el.html() : null;
        },
        setError: function (cell, err) {
            $(window).scrollTop(350);
            var input = cell.find("input");
            if (input.length > 0) {
                input.get(0).focus();
            }
            cell.find("span.onError").show().html(err);
        },
        isRepeatType: function (type) {
            //|Mobile
            var regex = this.isShowMobile ? /Email|Mobile/ : /Email/;
            return regex.test(type);
        },
        addBindValue: function (values) {
            //判断是否已经绑定了手机和邮箱
            var types = ["Email"];
            if (this.isShowMobile) {
                types.push("Mobile");
            }
            for (var i = 0; i < types.length; i++) {
                var type = types[i],
                    value = this.getBindValue(type);
                values[type + "s"].push(this.getModel(type, "", value, true));
            }
        },
        getModel: function (type, code, value, isDefault) {
            //获取vm模型
            var model = { Type: code };
            model[type] = value;
            isDefault && (model["IsDefault"] = true);
            return model;
        },
        getValue: function () {
            //获取填写的值
            var cells = $("td[contactitem='true']"),
                that = this;
            if (this.valid(cells)) {
                //如果通过验证
                var values = {},
                    types = this.getTypeList();
                //给模型集合赋初始值
                for (var key in types) {
                    values[key] = [];
                }
                for (var i = 0; i < cells.length; i++) {
                    var cell = cells.eq(i),
                        select = cell.find("select:first"),
                        input = cell.find("input:text:first"),
                        type = that.getType(cell.parent()),
                        code = select.val(),
                        val = $.trim(input.val());
                    //过滤不允许为空的值
                    ///Email|Mobile|IM/.test(type) &&
                    if (val == '') {
                        continue;
                    }
                    //绑定模型集合
                    values[type + "s"].push(this.getModel(type, code, val, false));
                }
                //                //添加默认绑定的手机和邮箱
                //                this.addBindValue(values);//保存不需要传默认手机和邮箱
                return values;
            }
            return null;
        },
        getBind: function (list) {
            //获取绑定的手机和邮箱
            for (var i = 0; i < list.length; i++) {
                if (list[i].IsDefault) {
                    return list[i];
                }
            }
            return null;
        },
        getTypeList: function () {
            return {
                Emails: "Email",
                Mobiles: "Mobile",
                IMs: "IM",
                Phones: "Phone",
                Faxs: "Fax",
                Addresss: "Address"
            };
        },
        setTitle: function (type) {
            var title = this.getTitle(type);
            var rows = this.wrap.find("tr[contacttype='" + type + "']");
            if (rows.length > 0) {
                rows.each(function (i) {
                    var t = i == 0 ? title + "：" : "";
                    rows.eq(i).find("th:first").html(t);
                });
            }
        },
        appendTemplate: function (type, data) {
            var parent = $(this.getTemplate(type, data)).appendTo(this.wrap);
            if (data != null && data.Type) {
                parent.find("select").val(data.Type);
            }
            this.bindAddRemove(type, parent);
        },
        bindAddRemove: function (type, parent) {
            var that = this;
            //绑定添加联系方式
            parent.find("span." + this.getClass(type + "add")).click(function () {
                that.addItem($(this));
            });
            //绑定删除联系方式
            parent.find("span." + this.getClass(type + "remove")).click(function () {
                that.removeItem($(this));
            });
        },
        parseValue: function (data) {
            //解析扩展字段，动态生成联系方式
            if (data != null) {
                var types = this.getTypeList();
                for (var key in types) {
                    var value = types[key],
                        list = data[key],
                        isBind = this.isRepeatType(value);
                    //先绑定默认绑定的手机和邮箱

                    if (isBind) {
                        var bind = this.getBind(list),
                            bindValue = bind == null ? null : bind[value];
                        this.wrap.append(this.getBindHtml(value, bindValue, 1));
                    }
                    //再解析扩展字段的值
                    for (var i = 0; i < list.length; i++) {
                        var item = list[i];
                        if (/Email|Mobile/.test(value) && item.IsDefault) {
                            continue;
                        }
                        this.appendTemplate(value, item);
                    }
                    //如果没有数据则绑定默认
                    if (list.length <= 0 || (bind != null && /Email|Mobile/.test(value) && list.length <= 1)) {
                        this.appendTemplate(value, null);
                    }
                    //设置标题
                    if (!isBind) {
                        this.setTitle(value);
                    }
                }
            }
        }
    });

    return UserContactView;
});