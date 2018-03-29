/*
author:                 王松华
email:                  songhuaxiaobao@163.com
namespace:              Song.Adc.Rule
content:                产品落地配置产品依赖规则
beforeLoad:             jQuery,song,[adc]
dateUpdated:            2012-05-11
*/
(function (j, song) {
    window.rule = {
        //保存当前选择的产品,格式如：{"code":{code:"code",name:"name"}}
        checkedCode: {},
        //保存选择之后的产品，删除选择之后则删除对应的产品
        disabledCode: [],
        //弹出帮组页面窗口
        helper: function () {
            var url = rule.url("SaleDependencyRuleHelper");
            adc.open({ url: url, width: 800, height: 500 });
        },
        //获取当前页面的规则类型
        getType: function () {
            return song.dom("ruleType").value;
        },
        //设置当前页面的规则类型
        setType: function () {
            song.dom("ruleType").value = rule.type;
        },
        getCode: function (el) {
            return j(el).attr("productcode");
        },
        getName: function (el) {
            return j(el).attr("productname");
        },
        attr: function (el, type, value) {
            value ? el.attr(type, type) : el.removeAttr(type);
        },
        query: function (el) {
            return j(typeof el == "string" ? ("#" + el) : el);
        },
        controller: "Product/ProductSalePacketConfig",
        url: function (action, params) {
            return song.url(this.controller, action, params).getUrl();
        },
        productMovePage: function (pageIndex, pageSize) {
            //自己写的Pagination分页模式
            var param = new song.param().params;
            //获取当前页面的参数
            param = j.extend(param, { pageIndex: pageIndex, pageSize: pageSize, isRadio: rule.isRadio });
            var url = rule.url("RuleProductList", param),
                wrap = $("#productList"),
                loading = j("#loading");
            loading.show();
            wrap.load(url, null, function () {
                rule.set125();
                rule.pageSaveState();
                rule.disabledChecked(false, true);
                loading.hide();
            });
        },
        pageSaveState: function () {
            //保存分页的选择状态
            if (rule.isEdit && rule.is125()) {
                rule.RuleNote = null;
            }
            for (var code in rule.checkedCode) {
                rule.getCheckbox(code).attr("checked", "checked");
            }
        },
        set125: function () {
            var type = rule.getType();
            //加载时转化已经选择的复选框到对象中
            if (/1|2|5/.test(type) && rule.RuleFormula) {
                rule.getCheckbox(rule.RuleFormula).attr("checked", "checked");
                j("#producttable").find("input:checked").each(function () {
                    var code = rule.getCode(this),
                    name = rule.getName(this);
                    rule.checkedCode[code] = { code: code, name: name };
                });
            }
        },
        getCheckbox: function (code) {
            return j("input[productcode='" + code + "']");
        },
        checkHanlder: function (obj, code, name) {
            if (obj.checked) {
                if (rule.isEdit && rule.is125()) {
                    rule.RuleFormula = code;
                    rule.RuleNote ="【"+name+"("+code+")】";
                    rule.checkedCode = {};
                    Array.clear(rule.disabledCode);
                }
                rule.checkedCode[code] = { code: code, name: name };
            } else {
                delete rule.checkedCode[code];
            }
        },
        hasCode: function () {
            //检测当前是否选择产品
            for (var i in this.checkedCode) {
                if (i) { return true; }
            }
            alert("请选择附加产品！");
            return false;
        },
        disabledChecked: function (checked, disabled, code) {
            if (code) {
                //禁用或者恢复选择的产品
                var cb = rule.getCheckbox(code);
                rule.attr(cb, "checked", checked);
                var type = rule.getType();
                //判断是否需要灰掉选中的产品
                if (/3|4|6|7/.test(type)) {
                    rule.attr(cb, "disabled", disabled);
                }
            } else {
                var disCodes = Array.distinct(rule.disabledCode);
                for (var i in disCodes) {
                    rule.disabledChecked(checked, disabled, disCodes[i]);
                }
            }
        },
        //是否删除分组delGroup
        removeItem: function (obj, code, delGroup) {
            //删除选择的附加产品
            if (confirm("确认移除当前附加产品?")) {
                var close = j(obj),
                    li = close.parent(),
                    ul = li.parent();
                //如果是分组删除的话，删除所有组员之后则删除该分组的dd和ul元素
                if (delGroup && ul.find("li").length <= 1) {
                    ul.parent().remove();
                } else {
                    li.remove();
                    ul.find(">li").length <= 0 && ul.hide();
                }
                //删除还原状态
                if (/3|4|6|7/.test(rule.getType())) {
                    Array.remove(rule.disabledCode, code);
                    rule.disabledChecked(false, false, code);
                }
                rule.reStyle(j("table.newAddPart"));
            }
        },
        HideChecked: function () {
            if (rule.getType() == "3" || rule.getType() == "6") {
                $("#spCk1").html("单组");
                $("#spCk2").html("多组");
                $("#spTip").text("温馨提示：多组-选择多个套餐时，每个套餐是以一组方式增加，单组-选择的多个套餐是以一组方式增加");
                $("#rmtd").show();
            } else if (rule.getType() == "7") {
                $("#spCk1").html("必选部分单组");
                $("#spCk2").html("必选部分多组");
                $("#spTip").text("温馨提示：必选部分多组-选择多个套餐时，每个套餐是以一组方式增加，必选部分单组-选择的多个套餐是以一组方式增加");
                $("#rmtd").show();
            }
        },
        reStyle: function (container) {
            container.find("ul:odd").removeClass("group-even").addClass("group-odd");
            container.find("ul:even").removeClass("group-odd").addClass("group-even");
        },
        //container容器；delGroup：是否删除分组；existsWhere：是否验证已选的条件是否存在
        addItem: function (container, delGroup, existsWhere) {
            //添加组员
            if (rule.hasCode()) {
                container = rule.query(container).show();
                var codes = rule.checkedCode, exists = [];
                for (var code in codes) {
                    var name = codes[code].name;
                    //条件必选部分，添加条件的时候，判断是否存在，存在的不添加
                    if (existsWhere && j("#where").find("li[productcode='" + code + "']").length > 0) {
                        exists.push(name);
                        Array.remove(rule.disabledCode, code);
                    } else {
                        //默认截断30字符
                        var text = '{0}({1})'.format(name, code),
                        trunText = '<span title="{0}">{1}</span>'.format(text, text.truncate(100));
                        container.append('<li productcode="{0}" productname="{1}"><span class="right" onclick="rule.removeItem(this,\'{2}\',{3})"><a href="javascript:void(0)" class="close" ></a></span>{4}</li>'.format(code, name, code, delGroup, trunText));
                        rule.disabledCode.push(code);
                        //添加完之后删除选中的值
                        delete rule.checkedCode[code];
                    }
                }
                //还原选中和禁用状态
                rule.disabledChecked(false, true);
                //条件必选部分的存在条件提示,已存在的不添加
                if (exists.length > 0) {
                    for (var i = 0; i < exists.length; i++) {
                        exists[i] = "【" + exists[i] + "】";
                    }
                    alert("当前选择的" + exists.join(",") + "已在条件组中存在！");
                }
            }
        },
        addGroup: function (container) {
            //添加分组
            if (container != "rm" || $("#radio1").attr("checked") == "checked") {
                container = rule.query(container);
                if (rule.hasCode() && !rule.hasGroup(container)) {
                    var dd = j("<dd>"),
                    ul = j("<ul>");
                    container.append(dd.append(ul));
                    rule.addItem(ul, true);
                }
                rule.reStyle(container);
            } else {
                rule.addSingleGroup(container);
            }
        },
        addSingleGroup: function (container) {
            //添加分组
            container = rule.query(container);
            if (rule.hasCode() && !rule.hasGroup(container)) {
                //                var dd = j("<dd>"),
                //                    ul = j("<ul>");
                //   container.append(dd.append(ul));
                rule.addSingleItem(container, true);
            }
            rule.reStyle(container);
        },  //container容器；delGroup：是否删除分组；existsWhere：是否验证已选的条件是否存在
        addSingleItem: function (container, delGroup, existsWhere) {
            //添加组员
            if (rule.hasCode()) {
                container = rule.query(container).show();
                var codes = rule.checkedCode, exists = [];
                for (var code in codes) {
                    var dd = j("<dd>"),
                    ul = j("<ul>");
                    var name = codes[code].name;
                    //条件必选部分，添加条件的时候，判断是否存在，存在的不添加
                    if (existsWhere && j("#where").find("li[productcode='" + code + "']").length > 0) {
                        exists.push(name);
                        Array.remove(rule.disabledCode, code);
                        container.append(dd.append(ul));
                    } else {
                        if (j("#rm").find("li[productcode='" + code + "']").length <= 0) {
                            //默认截断30字符
                            var text = '{0}({1})'.format(name, code),
                        trunText = '<span title="{0}">{1}</span>'.format(text, text.truncate(100));
                            ul.append('<li productcode="{0}" productname="{1}"><span class="right" onclick="rule.removeItem(this,\'{2}\',{3})"><a href="javascript:void(0)" class="close" ></a></span>{4}</li>'.format(code, name, code, delGroup, trunText));
                            rule.disabledCode.push(code);
                            //添加完之后删除选中的值
                            delete rule.checkedCode[code];
                            container.append(dd.append(ul));
                        }
                    }

                }
                //还原选中和禁用状态
                rule.disabledChecked(false, true);
                //条件必选部分的存在条件提示,已存在的不添加
                if (exists.length > 0) {
                    for (var i = 0; i < exists.length; i++) {
                        exists[i] = "【" + exists[i] + "】";
                    }
                    alert("当前选择的" + exists.join(",") + "已在条件组中存在！");
                }
            }
        },
        hasGroup: function (container) {
            //判断当前组是否存在，不区分顺序
            var codes = Object.keys(rule.checkedCode)
            groups = rule.getGroups(container).codes;
            var result = rule.arrayRepeat(groups, codes);
            if (result) {
                //alert("当前选择的附加产品组已存在！");
                var exists = [];
                //拼接存在产品提示
                for (var code in rule.checkedCode) {
                    exists.push("【" + rule.checkedCode[code].name + "】");
                }
                //当前选择的 产品 已在必选部分组中存在！
                alert("当前选择的{0}已在{1}组中存在！".format(exists.join(','), (rule.getType() == 7 ? "必选部分" : "必选互斥")));
            }
            return result;
        },
        arrayEqual: function (arr1, arr2) {
            //判断两个数组是否相等,不区分顺序
            return arr1.sort().join('') == arr2.sort().join('');
        },
        getGroups: function (container) {
            //返回当前所有组的编码数组
            container = rule.query(container);
            var groups = [], names = [];
            container.find("ul").each(function (i) {
                var obj = rule.getItems(this);
                groups.push(obj.codes);
                names.push(obj.names);
            });
            return { codes: groups, names: names };
        },
        arrayRepeat: function (arrs, arr) {
            //判断一个数组在另一个二维数组中是否有重复
            for (var i = 0; i < arrs.length; i++) {
                if (rule.arrayEqual(arr, arrs[i])) {
                    return true;
                }
            }
            return false;
        },
        twoArrayRepeat: function (arrs) {
            //判断一个二维数组中是否有重复的数组
            var news = [];
            for (var i = 0; i < arrs.length; i++) {
                news.push(arrs[i].sort().join(''));
            }
            return Array.hasRepeat(news);
        },
        //根据容器获取里面的附加产品编码数组
        getItems: function (container) {
            var items = rule.query(container).find("li"), codes = [], names = [];
            items.each(function (i) {
                codes.push(rule.getCode(this));
                names.push(rule.getName(this));
            });
            return { codes: codes, names: names };
        },
        getNote: function (code, name) {
            return "{0}({1})".format(name, code);
        },
        getCodeName: function (obj) {
            var arr = [];
            for (var i = 0; i < obj.codes.length; i++) {
                arr.push(rule.getNote(obj.codes[i], obj.names[i]));
            }
            return "【" + arr.join(",") + "】";
        },
        //获取分组的产品编码名称组合
        getCodeNames: function (obj) {
            var arr = [];
            for (var i = 0; i < obj.codes.length; i++) {
                var sub = [], c = obj.codes[i];
                for (var j = 0; j < c.length; j++) {
                    sub.push(rule.getNote(c[j], obj.names[i][j]));
                }
                arr.push((i + 1) + "、【" + sub.join(",") + "】&lt;br/&gt;");
            }
            return arr.join('');
        },
        //根据选择的附加产品，获取规则的字符串和规则名称编码组合字符串
        parseValue: function (type) {
            //必选，默认，隐藏
            if (/1|2|5/.test(type)) {
                if (rule.RuleNote) {
                    return { code: rule.RuleFormula, note: rule.RuleNote };
                } else {
                    var codes = [], names = [];
                    for (var code in rule.checkedCode) {
                        codes.push(code);
                        names.push(rule.getNote(code, "【" + rule.checkedCode[code].name) + "】");
                    }
                    return { code: codes.join(","), note: names.join(",") }
                }
            }
            //条件必选
            if (/4/.test(type)) {
                var flag = type == 3 ? "mutex" : "required";
                var cn1 = rule.getItems(flag + "1"),
                    cn2 = rule.getItems(flag + "2");
                return { code: cn1.codes.join(",") + ":" + cn2.codes.join(","), note: "条件：" + rule.getCodeName(cn1) + "&lt;br/&gt;必选：" + rule.getCodeName(cn2) }
            }
            var groups = rule.getGroups("rm"), t = [];
            if (/3|6|7/.test(type)) {
                //判断当前组集合是否有重复组
                if (rule.twoArrayRepeat(groups.codes)) {
                    alert("已选择{0}组有重复组！".format(type == 3 ? "互斥" : (type == 6 ? "必选互斥" : "必选部分")));
                    return null;
                }
            }
            for (var i = 0; i < groups.codes.length; i++) {
                t.push(groups.codes[i].join(","));
            }
            //必选互斥
            if (/3|6/.test(type)) {

                if (groups.codes.length <= 1) {
                    alert("{0}必须选择两个组以上！".format(type == 3 ? "互斥" : "必选互斥"));
                    return null;
                }
                return { code: t.join(":"), note: rule.getCodeNames(groups) };
            }
            //条件必选部分
            if (/7/.test(type)) {
                var wi = rule.getItems("where");
                return { code: wi.codes.join(',') + ":" + t.join(";"), note: "条件：" + rule.getCodeName(wi) + "&lt;br/&gt;必选部分：&lt;br/&gt;" + rule.getCodeNames(groups) };
            }
        },
        setWhere: function () {
            //初始化数据(转换累加值)
            var where = rule.getWhere(),
                box = rule.getWhereBox();
            for (var i in where) {
                if (where[i] <= 0) {
                    box[i].removeAttr("checked");
                } else if (where[i] == 3) {
                    box[i].attr("checked", "checked");
                } else {
                    //如果是1或者2，对应赋值选中1或者2
                    box[i].eq(where[i] - 1).attr("checked", "checked");
                }
            }
        },
        parseWhere: function () {
            //保存之前，转换数据(转换累加值)
            var box = rule.getWhereBox(),
                where = rule.getWhere();
            for (var i in box) {
                var val = 0;
                box[i].filter(":checked").each(function (i) {
                    val += parseInt(j(this).val());
                });
                j("#" + i).val(val);
            }
        },
        getWhere: function () {
            //获取隐藏域中的必选条件
            return {
                RuleScene: j("#RuleScene").val(),
                AcceptChannelScope: j("#AcceptChannelScope").val(),
                EcTypeScope: j("#EcTypeScope").val(),
                SaleMode: j("#SaleMode").val()
            }
        },
        getWhereBox: function () {
            return {
                RuleScene: j("input[flag='RuleScene']"),
                AcceptChannelScope: j("input[flag='AcceptChannelScope']"),
                EcTypeScope: j("input[flag='EcTypeScope']"),
                SaleMode: j("input[flag='SaleMode']")
            }
        },
        CheckBoxCheck: function (chk) {
            //            for (var i = 1; i <= 2; i++) {
            //                var chkObj = document.getElementById("radio" + i);
            //                if (chkObj != chk) {
            //                    chkObj.checked = false;
            //                }
            //            }
            var rdolist = document.getElementsByName("radioGroup");
            if (rdolist[0].checked) rdolist[1].checked = false;
            else rdolist[1].checked = true;

        },
        getSaleAreas: function () {
            var areacode = "";
            var areaName = "";
            j("input[flag='SaleArea']").filter(":checked").each(function (i) {
                areacode += j(this).attr("id") + ";";
                areaName += j(this).val() + "、";

            });
            if (areacode != "") {
                return areacode.substr(0, areacode.length - 1) + "|" + areaName.substr(0, areaName.length - 1);
            }
            return "";
        },
        is125: function (type) {
            type = type || rule.getType();
            return /1|2|5/.test(type);
        },
        //获取各种规则的action
        getAction: function (type, isSave) {
            if (isSave) {
                return (/1|2|5/.test(type)) ? "HideRequiredDefalutRuleConfigPost" : "MutexRuleConfigPost";
            }
            if (type == 3) {
                return "MutexRuleConfig";
            } else if (type == 4) {
                return "ConditionRequiredRuleConfig";
            } else if (type == 6) {
                return "RequiredExclusionRuleConfig";
            } else if (type == 7) {
                return "ConditionsSelectedPartRuleConfig";
            } else {
                return "HideRequiredDefalutRuleConfig";
            }
        },
        //页面跳转
        change: function (combox) {
            //保存原有页面的地址栏参数
            j("#loading").show();
            var type = combox.value,
                params = new song.param().params;
            params["t"] = type;
            var action = rule.getAction(type);
            location.href = rule.url(action, params);
            // }
        },
        //规则的通用保存方法
        save: function (obj) {
            rule.parseWhere();
            var type = rule.getType(), ruleValue, action,
                v = new rule.valid(), btn = j(obj);
            if (type == 3) {
                //保存互斥
                v.isItem("rm", null, "请增加互斥的各个组！");
            } else if (type == 4) {
                //保存条件必选
                v.isItem("required1", "条件");
                v.isItem("required2", "必选");
            } else if (type == 6) {
                v.isItem("rm", null, "请增加必选互斥的各个组！");
                // v.isOnlyItem("rm");
            } else if (type == 7) {
                v.isItem("where", null, "请增加条件组！");
                v.isItem("rm", null, "请增加必选部分组！");
            } else {
                //必选，隐藏，默认
                v.isCode();
            }
            if (v.isValid()) {
                var p = new song.param().params,
                    vm = rule.getWhere(),
                    action = rule.getAction(type, true);
                //获取规则字符
                var rv = rule.parseValue(type);
                if (rv == null) {
                    return;
                }
                vm.RuleFormula = rv.code;
                //如果获取规则字符不成功，则不保存
                if (!vm.RuleFormula) {
                    return;
                }
                vm.RuleNote = rv.note;
                vm.RuleType = type;
                vm.SaleDependencyRuleId = p.r;
                vm.ProductSalePacketId = p.p;
                var area = rule.getSaleAreas();
                vm.AreaScope = area.split('|')[0];
                vm.AreaScopeName = area.split('|')[1];
                //alert(vm.RuleFormula);
                btn.attr("disabled", "disabled");
                j.ajax({
                    type: "post",
                    url: rule.url(action),
                    data: vm,
                    dataType: "json",
                    success: function (data) {
                        btn.removeAttr("disabled");
                        if (data.isOk == 1) {
                            if (rule.isEdit) {
                                alert("保存规则成功!");
                                window.close();
                            } else {
                                if (window.confirm('保存成功,是否继续配置商品规则？')) {
                                    window.location.href = window.location.href.replace("#", "");
                                } else {
                                    window.close()
                                }

                            }
                            window.opener.location.reload();
                        } else {
                            alert(data.msg);
                        }
                    },
                    error: function (xhr, err) {
                        alert("服务器繁忙，请稍后再试！" + err);
                        btn.removeAttr("disabled");
                    }
                });
            }
        }
    }
    //提交数据验证部分
    rule.valid = function () {
        this.msg = [];
        this.required();
    }
    rule.valid.prototype = {
        requiredMsg: {
            RuleScene: "请选择应用场景！",
            AcceptChannelScope: "请选择受理渠道范围！",
            EcTypeScope: "请选择客户类型！",
            SaleMode: "请选择销售模式！"
        },
        addMsg: function (text) {
            this.msg.push(text);
        },
        required: function () {
            //验证必选的条件
            var where = rule.getWhere();
            for (var i in where) {
                if (where[i] <= 0) { this.addMsg(this.requiredMsg[i]); }
            }
        },
        isItem: function (container, text, replaceText) {
            //验证是否选择了附加产品
            container = rule.query(container);
            var has = container.find("li").length > 0;
            has || this.addMsg(replaceText || "请选择作为{0}的附加产品！".format(text));
        },
        isOnlyItem: function (container) {
            container = rule.query(container);
            var itemCount = container.find("ul").length;
            if (itemCount) {
                this.addMsg("必须互斥必须存在多个组!");
            }
        },
        isCode: function () {

            //验证附加产品列表中是否有选择
            //alert(rule.RuleNote);
            if (!rule.RuleNote) {
                if (Object.keys(rule.checkedCode).length <= 0) { this.addMsg("请选择附加产品！"); }
            }
        },
        isValid: function () {
            var msg = this.msg;
            var obj = rule.getSaleAreas();
            if (msg.length <= 0 && obj != "") {
                return true;
            } else {
                if (obj == "" || obj == null) {
                    msg.push("销售地市不能为空");
                }
            }
            var s = new song.builder();
            for (var i = 0, len = msg.length; i < len; i++) {
                s.addLine("--" + msg[i]);
            }
            alert(s.toString());
            return false;
        }
    };


    //加载事件部分
    j(function () {
        //页面加载，首先清空选中和灰掉的复选框(ff刷新会保留状态)
        if (!rule.isEdit) {
            // j("input:checkbox[name=product]").removeAttr("checked").removeAttr("disabled");
        }

        //设置当前的规则类型
        //  $("#rmtd")
        rule.setType();
        //如果不是互斥那么隐藏单组与多组
        rule.HideChecked();
        //解决ul没有内容的白色问题
        var uls = j("ul");
        uls.each(function (i) {
            var ul = uls.eq(i);
            ul.find(">li").length <= 0 && ul.hide();
        });
        //修改模式下，规则类型不能编辑
        if (rule.isEdit) {
            j("#ruleType").attr("disabled", "disabled");
        }
        //读取已经存在的code
        var type = rule.getType();
        if (/3|4|6|7/.test(type)) {
            "rm,where,required1,required2".replace(song.split, function (name) {
                var codes = rule.getItems(name).codes;
                rule.disabledCode = rule.disabledCode.concat(codes);
            });
            rule.disabledChecked(false, true);
        }
        rule.set125();
        //转换必选条件
        rule.setWhere();
        $("#checkboxAll").change(function () {
            var check = $("#checkboxAll").attr("checked");
            if (check) {
                j("input[flag='SaleArea']").each(function () {
                    $(this).attr("checked", true).attr("disabled", "disabled");
                    $("#checkboxAll").removeAttr("disabled");
                });
            } else {
                j("input[flag='SaleArea']").each(function () {
                    $(this).attr("checked", false).removeAttr("disabled");
                });
            }
        });

        rule.reStyle(j("table.newAddPart"));
    });
})(window.jQuery, window.song);