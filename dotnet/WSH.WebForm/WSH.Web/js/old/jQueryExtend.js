/*
说明：对jQuery的扩展，包括一些常用的操作，和一些插件的封装
作者：王松华
*/
(function($) {
    //==========省市县联动============
    jQuery.fn.extend({
        selectCity: function(opts) {
            this.opts = $.extend({
                path: ""
            }, opts || {});
            var purl = this.opts.path + "Province.xml";
            var obj = this;
            $.get(purl, null, function(xml) {
                $(xml).find("Provinces Province").each(function(i) {
                    var id = $(this).attr("ID");
                    var name = $(this).attr("Name");
                    obj.append("<option value='" + name + "' id='" + id + "'>" + name + "</option>");
                });
            }, "xml");
            if (this.opts.city != undefined) {
                var city = $("#" + this.opts.city);
                city.append("<option value=''>请选择</option>");
                this.change(function() {
                    var pid = $(this).find("option:selected").attr("id");
                    var curl = obj.opts.path + "City.xml";
                    $.get(curl, null, function(xml) {
                        city.find("option").remove();
                        city.append("<option value=''>请选择</option>");
                        $(xml).find("Cities City[PID=" + pid + "]").each(function(i) {
                            var id = $(this).attr("ID");
                            var name = $(this).attr("Name");
                            city.append("<option value='" + name + "' id='" + id + "'>" + name + "</option>");
                        });
                    }, "xml");
                });
            }
            if (this.opts.area != undefined) {
                var area = $("#" + this.opts.area);
                area.append("<option value=''>请选择</option>");
                city.change(function() {
                    var cid = $(this).find("option:selected").attr("id");
                    var aurl = obj.opts.path + "Area.xml";
                    $.get(aurl, null, function(xml) {
                        area.find("option").remove();
                        area.append("<option value=''>请选择</option>");
                        $(xml).find("Areas Area[PID=" + cid + "]").each(function(i) {
                            var id = $(this).attr("ID");
                            var name = $(this).attr("Name");
                            area.append("<option value='" + name + "' id='" + id + "'>" + name + "</option>");
                        });
                    }, "xml");
                });
            }
        },
        rowEdit: function() {
            var cells = this.find("td[type!=null]");
            cells.each(function() {
                var cell = $(this);
                var type = cell.attr("type");
                if (type == "text" || type == "int" || type == "date") {
                    if (cell.find("input:text").length <= 0) {
                        var oldtxt = cell.text(); var h = cell.height() - 2;
                        cell.html("");
                        var txt = $("<input type='text' value='" + oldtxt + "'/>");
                        txt.height(h).css("line-height", h + "px").appendTo(cell);
                    }
                }
            });
        },
        getSelectId: function(cls) {
            var row = this.find("tr[class='" + cls + "']");
            return (row.length == 0) ? "" : row.attr("dataKey");
        },
        checkAll: function(obj) {
            var ChBox = this.find("input[type='checkbox'][multiCheck='true']");
            ChBox.each(function(i) {
                if ($(this).get(0).disabled == false) {
                    $(this).get(0).checked = obj.get(0).checked;
                }
            });
        },
        getMultiId: function() {
            var ChBox = this.find("input:checked[MultiCheck='true']");
            var mid = new Array();
            ChBox.each(function(i) {
                if ($(this).get(0).checked == true) {
                    mid.push($(this).parent().parent().attr("dataKey"));
                }
            });
            return mid;
        },
        clearForm: function() {
            this.find("input:text").val("");
            this.find("textarea").val("");
        },
        enabledForm: function() {
            this.find("input").attr("disabled", true);
            this.find("textarea").attr("disabled", true);
            this.find("select").attr("disabled", true);
        },
        toTab: function(opts) {
            if (!opts) { opts = {} }
            this.attr("class", "tab");

            if (opts.w) { this.css({ width: opts.w }); }

            this.find(">ul").attr("class", "tab-ul");
            var lis = this.find(">ul>li");
            var divs = this.find(">div");

            lis.removeClass("tab-select-li");
            divs.removeClass("tab-select-div");

            if (!opts.idx) { opts.idx = 0; }
            if (!opts.e) { opts.e = "click" }
            if (opts.h) { divs.css({ height: opts.h, overflow: "auto" }); }
            lis.each(function(i) {
                divs.eq(i).addClass("tab-div");
                if (i == opts.idx) {
                    divs.eq(i).addClass("tab-select-div");
                    lis.eq(i).addClass("tab-select-li");
                }
                var l = $(this);
                l.bind("click", function() {
                    lis.removeClass("tab-select-li");
                    l.addClass("tab-select-li");
                    divs.removeClass("tab-select-div");
                    divs.eq(i).addClass("tab-select-div");
                    if (opts.click) {
                        opts.click(i, divs.eq(i));
                    }
                });
            });
        },
        cellEdit: function() {
            var colName = this.attr("colName");
            var editType = this.attr("editType");
            var txtspan = this.find("div");
            if (editType == "Text") {
                var txtbox = this.find("input:text");
                if (txtbox.css("display") == "none") {
                    var w = this.width() - 4, h = this.height() - 1;
                    txtspan.hide();
                    txtbox.css("height", h + "px").css("line-height", h + "px").show();
                    txtbox.get(0).focus();
                    txtbox.get(0).select();
                }
            } else if (editType == "Combobox") {
                var combo = this.find("select");
                if (combo.css("display") == "none") {
                    combo.show().get(0).focus();
                    txtspan.hide();
                }
            }
        },
        blurEdit: function() {
            var editType = this.parent().attr("editType");
            var div = this.parent().find("div");
            div.attr("val", this.val());
            div.html(editType == "Text" ? this.val() : this.find("option:selected").html()).show();
            this.hide();
        },
        saveEdit: function() {
            var p = this.parent();
            p.addClass("editorload");
            var editType = p.attr("editType");
            var colName = p.attr("colName");
            var d = p.find("div");
            setTimeout(function() { d.addClass("editored"); }, 100);
            //发送ajax进行修改
            var url = window.location.href;
            if (url.indexOf("?") == -1) { url += "?"; }
            if (url.lastIndexOf("&") == -1) { url += "&"; }
            url = url.replace("&&", "&").replace("?&", "?");
            var dataKey = this.parent().parent().attr("dataKey");
            var param = { dataKey: dataKey, colName: colName, value: this.val(), CellEditAjaxRequest: "true", time: new Date().getTime() };
            param["cellIndex"] = this.index();
            $.ajax({ type: "post", data: param, dataType: "json", url: url,
                success: function(d) {
                    if (d.error) {
                        alert(d.error);
                    }
                    setTimeout(function() { p.removeClass("editorload"); }, 200);
                },
                error: function() {
                    p.removeClass("editorload");
                }
            });
        },
        getCellValue: function(key, colName) {
            var cell = this.find("tr[dataKey='" + key + "']").find("td[colName='" + colName + "']");
            var isedit = cell.attr("editType") == null ? false : true;
            if (isedit) {
                var d = cell.find("div");
                return { text: d.html(), value: d.attr("val") };
            }
            var t = cell.html();
            return { text: t, value: t };
        },
        accordion: function(opts) {
            var active = true;
            var p = this;
            var opts = $.extend({ index: 0, height:300, width: "100%", border:2, animate: true }, opts || {});
            this.width(opts.width);
         
            //this.height(opts.height-opts.border+1);
            var heads = this.children("div.accordion-title");
            if (heads.length <= 0) { return; }
            var bodys = this.children("div.accordion-body");
            heads.eq(opts.index).find("a:first").attr("class", "accordion-show");
            bodys.eq(opts.index).show();
            var headY = heads.eq(0).outerHeight() * heads.length;
            var bodyY = opts.height - headY - opts.border;
            bodys.height(bodyY);
            heads.each(function(i) {
                $(this).click(function() {
                    if (active == true) {
                        var objbody = bodys.eq(i);
                        if (objbody.css("display") == "none") {
                            active = false;
                            bodys.eq(opts.index).animate({ height: "hide" });
                            heads.eq(opts.index).find("a:first").attr("class", "accordion-hide");
                            heads.eq(i).find("a:first").attr("class", "accordion-show");
                            objbody.animate({ height: "show" }, function() {
                                active = true;
                                opts.index = i;
                            });
                        }
                    }
                });
            });
        },
        extTab: function(opts) {
            var opts = $.extend({
                index: 0,
                height: 300,
                border: true
            }, opts || {});
            var p = this;
            if (opts.width) {
                p.width(opts.width);
            }
            var head = this.children("div.tab-header");
            var bodys = this.children("div.tab-body");
            if (bodys.length > 0) {
                bodys.eq(opts.index).show();
            }
            var headY = head.outerHeight();
            var bodyY = opts.height - headY - (opts.border == true ? 1 : 0);
            bodys.height(bodyY);
            if (opts.border == false) {
                bodys.css({ border: "0px" });
            }
            var heads = head.find("ul.tab-header-ul").children("li");
            if (heads.length > 0) {
                heads.eq(opts.index).addClass("tab-active");
            }
            heads.each(function(i) {
                var obj = $(this);
                obj.width(obj.width());
                obj.click(function() {
                    var h = $(this);
                    if (!h.hasClass("tab-active")) {
                        heads.filter(".tab-active").removeClass("tab-active");
                        h.addClass("tab-active");
                        bodys.filter(":visible").hide();
                        bodys.eq(i).show();
                        opts.index = i;
                    }
                });
                var closeable = $(this).children("a.tab-close");
                if (closeable.length > 0) {
                    closeable.click(function() {
                        heads.eq(i).hide();
                        bodys.eq(i).hide();
                    });
                }
            });
        }
    });
})(jQuery);
