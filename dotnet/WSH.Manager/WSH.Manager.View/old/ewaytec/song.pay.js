/*
author:                 wang song hua
email:                  songhuaxiaobao@163.com
namespace:              Pay
content:                充值设置以及充值记录查询
beforeLoad:             jQuery
dateUpdated:            2012-06-12
*/
(function (j) {
    window.pay = {
        controller: "RechargePayment",
        url: function (action) {
            return song.root() + pay.controller + "/" + action;
        },
        product: [], rule: [0, 50, 100, 300],
        grid: function () {
            return j("#grid");
        },
        hasGrid: function () {
            return pay.grid().length > 0;
        },
        //获取记录表格中的所有行
        rows: function () {
            return pay.grid().find("tr");
        },
        //判断是否禁用下一步操作
        hasNext: function () {
            pay.hasGrid() || j("#btnNext").attr("disabled");
        },
        //取消支付
        cancel: function () {
            if (confirm("确定要取消支付吗？")) {
                location.href = "";
            }
        },
        //发送手机验证码
        getCode: function () {
            var url = pay.url("SendMobile") + "?_t" + new Date().getTime();
            j.ajax({
                type: "post", dateType: "json", url: url, success: function (data) {
                    alert(data.msg);
                }
            });
        },
        //验证填写金额是否正确
        validMoney: function () {
            var rows = pay.rows(),
                msg = [];

            for (var i = 1; i < rows.length; i++) {
                var row = rows.eq(i);
                var cell = row.find("td");
                if (!pay.validCell(cell, 5) || pay.validDate(cell, 3) || pay.validDate(cell, 4)) {
                    msg.push(cell.eq(2).html());
                }
            }

            if (msg.length > 0) {
                alert("产品名称为“" + msg.join(",") + "”的支付金额、支付开始时间、支付结束时间必须填写");
                return false;
            }
            return true;
        },
        validDate: function (cell, index) {
            return cell.eq(index).find("input:text:first").val().trim() == "";
        },
        //验证当前行的支付金额是否选择或输入
        validCell: function (cell, index) {
            var c = cell.eq(index);
            var check = c.find("input:checked"),
                text = c.find("input:text");
            if (check.length <= 0 || (pay.hasOther(check) && j.trim(text.val()) == "")) {
                return false;
            }
            return true;
        },
        //判断是否是“其他金额”选择框
        hasOther: function (obj) {
            return !!obj.attr("other");
        },
        isChecked: function (obj) {
            return !!obj.attr("checked");
        },
        //选择或输入支付金额
        inputMoney: function () {
            var checks = pay.grid().find("input:radio");
            checks.each(function (i) {
                var ck = checks.eq(i);
                pay.hasEnabled(ck);
                ck.click(function () {
                    pay.hasEnabled(ck);
                });
            });
        },
        hasEnabled: function (ck) {
            if (pay.hasOther(ck)) {
                pay.isChecked(ck) && pay.getTextBox(ck).removeAttr("disabled");
            } else {
                //如果选择金额。则将输入金额清空并禁用
                pay.getTextBox(ck).attr("disabled", "disabled").val("");
            }
        },
        getTextBox: function (obj) {
            return obj.parent().find("input:text");
        },
        //全选产品
        checkAll: function (obj) {
            var cks = pay.grid().find("input:checkbox");
            cks.each(function () {
                this.checked = obj.checked;
            });
        },
        //设置选中的产品集合
        setProduct: function () {
            var cks = pay.grid().find("tbody input:checkbox:checked"), ids = [];
            if (!pay.hasProduct(cks)) { return false; }
            cks.each(function (i) {
                ids.push(this.value);
                // pay.addProduct(this.value, this.getAttribute("productname"), this.getAttribute("productcode"));
            });

            pay.setIds(ids.join(","));
            return true;
        },
        //设置选择产品的支付金额
        setMoney: function () {
            pay.product = [];
            var rows = pay.rows();
            for (var i = 1; i < rows.length; i++) {
                var cells = rows.eq(i).find("td"),
                    code = cells.eq(1).text(),
                    name = cells.eq(2).text(),
                    date1 = cells.eq(3).find("input:text").val(),
                    date2 = cells.eq(4).find("input:text").val(),
                    money = pay.getMoney(cells.eq(5));
                //支付类型(1全额2定额),全额的Amount为：0
                pay.addProduct(i, name, code, money, date1, date2, (money == 0 ? 1 : 2));
            }
            pay.setValue();
        },
        submitToMoney: function () {
          
            if (pay.product.length > 0) {
                return;
            }
            var rows = pay.rows();
            for (var i = 1; i < rows.length; i++) {
                var cells = rows.eq(i).find("td");
                pay.addProduct(i, cells.eq(2).text(), cells.eq(1).text());
            }
            //将值放置在form中
            pay.setValue();
        },
        getMoney: function (cell) {
            var radio = cell.find("input:checked");
            return pay.hasOther(radio) ? pay.getTextBox(radio).val() : radio.val();
        },
        //金额选择的转换
        parseMoney: function () {
            //如果是固定金额
            var len = pay.product.length;
            if (len > 0) {
                var rows = pay.grid().find("tbody tr");
                for (var i = 0; i < len; i++) {
                    if (Array.indexOf(pay.rule, pay.product[i].Amount) > -1) {
                        rows.eq(i).find("input:radio[value='" + pay.product[i].Amount + "']").attr("checked", "checked");
                    } else {
                        rows.eq(i).find("input:radio[other='true']").attr("checked", "checked");
                        //alert(pay.product[i].Amount);
                        rows.eq(i).find("input[otheramount='otheramount']").removeAttr("disabled").val(pay.product[i].Amount);
                    }
                }
            }
        },
        //添加产品
        addProduct: function (orderno, name, code, money, date1, date2, paytype) {
            var vm = {
                OrderNo: orderno,
                ProductName: name,
                ProductCode: code,
                Amount: money || 0
            };
            date1 && (vm.PayBeginDate = date1);
            date2 && (vm.PayEndDate = date2);
            paytype && (vm.PayType = paytype);
            pay.product.push(vm);
        },
        //        //生成选择的产品列表
        //        bindGrid: function () {
        //            if (pay.product.length > 0) {
        //                var sb = new song.builder();
        //                sb.add("<table>");
        //                sb.add("<tr>");

        //                sb.add("</tr>");
        //                for (var i = 0; i < pay.product.length; i++) {
        //                    sb.add("<tr>");

        //                    sb.add("</tr>");
        //                }
        //                sb.add("</table>");
        //                pay.grid().html(sb.toString());
        //            }
        //        },
        validCode: function (next) {

            var pwd = j("#servicePwd").val().trim();
            var code = j("#mobileCode").val().trim();
            if (pwd == "") {
                alert("请输入服务密码"); return false;
            } else if (code == "") {
                alert("请输入短信验证码"); return false;
            }
            var url = pay.url("CheckMobile") + "?_t" + new Date().getTime();
            next.attr("disabled", "disabled");
            j.ajax({
                type: "post", dateType: "json", url: url, data: { pwd: pwd, code: code }, success: function (data) {
                    next.removeAttr("disabled");
                    if (data.result) {
                        pay.submitToMoney();
                        pay.submit(pay.url("SetMoney"));
                    } else {
                        alert(data.msg);
                    }
                }, error: function () { next.removeAttr("disabled"); alert("服务密码验证失败！"); }
            });
        },
        //取消绑定事件，防止内存泄露
        unButton: function () {
            j("#btnPrev").unbind("click");
            j("#btnNext").unbind("click");
            pay.grid().find("input:radio").unbind("click");
        },
        //上一步和下一步设置
        setButton: function () {
            var prev = j("#btnPrev"), next = j("#btnNext"), url;
            prev.click(function () {
                if (pay.step == 1) {
                    //取消设置,跳转到充值设置页面
                    location.href = pay.url("PaymentConfiguration");
                } else if (pay.step == 2) {
                    pay.submit(pay.url("SelectProduct"));
                } else if (pay.step == 3) {
                    pay.setMoney();
                    pay.submit(pay.url("SelectPayMobile"));
                } else if (pay.step == 4) {
                    pay.submit("SetMoney");
                }

            });
            next.click(function () {
                if (pay.step == 1) {
                    if (pay.setProduct()) {
                        //选择产品下一步
                        pay.clearValue();
                        pay.submit(pay.url("SelectPayMobile"));
                    }
                } else if (pay.step == 2) {
                    pay.validCode(next);
                } else if (pay.step == 3) {
                    if (pay.validMoney()) {
                        pay.setMoney();
                        pay.submit(pay.url("ConfirmPaymentItem"));
                    }
                } else if (pay.step == 4) {

                    pay.dialog.open("openDialog");
                }
            });
        },
        //提交表单
        submit: function (url) {
            var form = song.dom("form");
            form.action = url;
            form.submit();
        },
        setValue: function () {
            var json = j.toJSON(pay.product);
            song.dom("payValue").value = json;
        },
        clearValue: function () {
            song.dom("payValue").value = "";
        },
        setIds: function (val) {
            song.dom("ids").value = val;
        },
        parseValue: function () {
            var val = song.dom("payValue").value;
            if (val.length > 0) {
                pay.product = eval("(" + val + ")");
            }
        },
        //是否选择产品
        hasProduct: function (chs) {
            if (chs.length <= 0) {
                alert("请至少选择一个产品");
                return false;
            }
            return true;
        },
        //完成支付设置
        complate: function () {
            pay.dialog.open("");
        },
        //弹出框
        dialog:
        {
            open: function (id) {
                var mainDialog = $(".tipsControl_ctn").dialog({ modal: true, width: 355, resizable: false, title: "查看我的POW值"/*,draggable:false*/ });
                mainDialog.parent().wrap("<div class=\"tipsControl_panel\"></div>");
                mainDialog.parent().wrapInner("<div class=\"tipsControl_jqCtn\"></div>");

                mainDialog.parent().attr("style", "");
                mainDialog.attr("style", "");
                j(".tipsControl_panel").children("div.ui-dialog").css("top", 100);
                //                var el = j("#SONGDIALOG");
                //                if (el.length <= 0) {
                //                    el = j("<div>").attr("id", "SONGDIALOG").css({ position: "absolute", zIndex: song.zIndex(), opacity: 0.3, background: "gray" });
                //                    el.css(song.position.maxClient());
                //                    el.appendTo('body');
                //                }
                //                el.show();
                //                var dialog = j("#" + id);
                //                dialog.css({ position: "absolute", zIndex: song.zIndex() }).show();
                //                song.position.setRegion(dialog, { top: "50%", left: "50%" });
            },
            close: function (id) {
                j(".tipsControl_ctn").dialog("close");
            }
        }
    }
    //页面加载事件
    j(function () {
        //设置按钮的事件
        pay.setButton();
        //转化保存状态的产品列表值
        pay.parseValue();
        if (pay.step == 1) {
            pay.clearValue();
        }
        
        if (pay.step == 1 || pay.step == 2) {
            
            pay.error && alert(pay.error);
            if ((pay.count != null && pay.count <= 0) || (pay.error)) {
                j("#btnNext").attr("disabled", "disabled");
            }
        }
        if (pay.step == 3) {
            pay.inputMoney();
            pay.parseMoney();


        }
    });
})(window.jQuery)