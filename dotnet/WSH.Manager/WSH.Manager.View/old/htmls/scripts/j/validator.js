/*
title:                      form-validator
content:               表单验证,数据类型处理
author:                 wsh-j-王松华
version:                1.0
updateDate:        2011-7-1
*/
jQuery.fn.extend({
    viewForm: function (mode) {
        var modeValue = $("#" + mode).val();
        if (modeValue == j.editMode.view) {
            this.find("input,select,textarea").attr({ readonly: "true", disabled: "true" });
        }
    },
    validator: function (opts) {
        if (!this.get(0)) { return; }
        var opts = $.extend({
            rang: "*"
        }, opts || {});
        var els = $(opts.rang).find("input[type='text'],textarea");
        els.each(function (i) {
            var obj = $(this);
            var datatype = obj.attr("datatype");
            if (datatype) {
                if (datatype == "datetime") { datatype = "date"; obj.attr({ dateformat: "yyyy-MM-dd HH:mm:ss" }); }
                switch (datatype) {
                    case "int": new j.numberbox(this, { allowNegative: false, allowDecimal: false }); break;
                    case "float": new j.numberbox(this); break;
                    case "date":
                        {
                            var fmt = obj.attr("dateformat") || "yyyy-MM-dd";
                            obj.attr("onfocus", "WdatePicker({dateFmt:'" + fmt + "'});");
                        }; break;
                }
            }
            obj.blur(function () {
                var required = obj.attr("required");
                if (required && required.toString().toLowerCase() == "true") {
                    if ($.trim(obj.val()) != "") {
                        obj.removeClass("text-error");
                    } else {
                        obj.addClass("text-error");
                    }
                }
            });
//            var msg = new j.tip({text:"该项必填！",target:true,el:obj.get(0),dir:"top"}).hide();
//            obj.hover(function () {
//                var required = obj.attr("required");
//                msg.show();
//            }, function () {
//                msg.hide();
//            });
        });
        this.click(function (e) {
            var msg = ""; var isfocus = false;
            els.each(function (i) {
                var el = $(this);
                var required = el.attr("required");
                if (required && required.toString().toLowerCase() == "true" && $.trim(el.val()) == "") {
                    el.addClass("text-error");
                    var pcell = el.parent();
                    var tg = pcell.get(0).tagName.toLowerCase();
                    while (pcell.get(0).tagName.toLowerCase() != "td") {
                        pcell = pcell.parent();
                    }
                    var display = pcell.prev().text().replace("*", "");
                    msg += "--" + display + "必填！\n";
                    if (isfocus == false) { el.get(0).focus(); isfocus = true; };
                }
            });
            if (msg != "") {
                alert(msg);
                e.preventDefault();
            } else {
                j.formSubmit();
            }
        });
    }
});
//ie下面的回车换行
if ($.browser.msie) {
    document.onkeydown = function () {
        var el = event.srcElement;
        var tg = el.tagName.toLowerCase();
        var type = el.type;
        if (event.keyCode == 13 && tg!="textarea" && type!="submit" && type!="button") {
            event.keyCode = 9;
        }
    }
}
//返回动作的处理
var returnAction = {closeDialog:"CloseDialog",clearForm:"ClearForm"}
returnAction.execute = function (flag) {
    if (flag == this.closeDialog) {
        parent.document.forms[0].submit();
        frameElement.lhgDG.cancel();
    } else if (flag == this.clearForm) {
        $(document.forms[0]).find("input[type='text'],textarea").val("");
        window.closeReload=true;
    } 
}