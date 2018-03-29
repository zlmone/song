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
        tip: function() {
            $("<div class='tip' id='tip'>").appendTo(document.body);
            this.each(function() {
                $(this).hover(function(e) {
                    $("#tip").html($(this).attr("tipText")).css({ top: e.pageY + "px", left: e.pageX + 20 + "px" }).show();
                }, function() {
                    $("#tip").hide();
                });
                $(this).bind("mousemove", function(e) {
                    $("#tip").css({ top: e.pageY + "px", left: e.pageX + 20 + "px" });
                });
            });
        },
        getPos: function() {
            var off = this.offset();
//            var bl = parseInt(this.css("border-left-width")) || 0;
//            var br=parseInt(this.css("border-right-width")) || 0;
//            var bt=parseInt(this.css("border-top-width")) || 0;
//            var bb=parseInt(this.css("border-bottom-width")) || 0;
//            var w = this.innerWidth() + bl+br;
//            var t = this.innerHeight() + off.top + bt+bb;
            var w=this.outerWidth();
            var t=this.outerHeight()+off.top;
            var l = off.left;
            return { width: w, top: t, left: l }
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
        combox: function() {

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
        setGridStyle: function(opts) {
            var rows = this.find("tr[rowType='dataRow']");
            rows.each(function(i) {
                var row = $(this);
                row.attr("class", ((i % 2 == 0) ? opts.oddClass : opts.evenClass));
                row.mouseover(function() {
                    if (row.attr("class") != opts.clickClass) {
                        row.attr("class", opts.hoverClass);
                    }
                });
                row.mouseout(function() {
                    if (row.attr("class") != opts.clickClass) {
                        row.attr("class", ((i % 2 == 0) ? opts.oddClass : opts.evenClass));
                    }
                });
                row.click(function() {
                    rows.each(function(j) {
                        $(this).attr("class", ((j % 2 == 0) ? opts.oddClass : opts.evenClass));
                    });
                    row.attr("class", opts.clickClass);
                    if (opts.click) { opts.click(row.attr("dataKey"), row.get(0)); }
                });
                row.dblclick(function() {
                    if (opts.dblclick) { opts.dblclick(row.attr("dataKey"), row.get(0)); }
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
        toBody: function() {
            $(document.body).append(this); return this;
        },
        accordion: function(opts) {
            var active = true;
            var p = this;
            var opts = $.extend({ index: 0, height: j.pos.y(), width: "100%", border:2, animate: true }, opts || {});
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
//======================进度条========================
(function($) {
    $.fn.progress = function(val, maxVal) {
        var max = 100;
        if (maxVal)
            max = maxVal;
        return this.each(
			function() {
			    var div = $(this);
			    var innerdiv = div.find(".progress");

			    if (innerdiv.length != 1) {
			        innerdiv = $("<div class='progress'></div>");
			        div.append("<div class='text'>&nbsp;</div>");
			        $("<span class='text'>&nbsp;</span>").css("width", div.width()).appendTo(innerdiv);
			        div.append(innerdiv);
			    }
			    var width = Math.round(val / max * 100);
			    innerdiv.css("width", width + "%");
			    div.find(".text").html(width + " %");
			}
		);
    };
})(jQuery);
//===========================自动补全================================
(function($) {
    $.fn.autoComplete = function(url, opts) {
        this.opts = $.extend({
            max: 10
        }, opts || {});
        var idx = -1;
        var ofs = $(this).getPos();
        var panal = $("<div class='j-ac'>").width(ofs.width-2).css({ top: ofs.top, left: ofs.left }).appendTo(document.body);
        var ac = this.attr("autoComplete","off");
        var hidePanal = function() {
            panal.hide(); idx = -1;
        }
        var selected = function(chs) {
            chs.removeClass("selected").eq(idx).addClass("selected");
        }
        $(document).bind("click", hidePanal);
        var autoCompleteItemClick = function(e) {
            var txt = $(this).text();
            ac.val(txt);
            hidePanal();
            ac.opts.onSelect && ac.opts.onSelect({ text: txt });
        }
            ac.keyup(function(e) {
                var v = $.trim(ac.val());
                if (e.keyCode == 40) {
                    idx++;
                    var chs = panal.find("a");
                    if (idx == chs.length) {
                        idx = 0;
                    }
                    selected(chs);
                } else if (e.keyCode == 38) {
                    var chs = panal.find("a");
                    if (idx == 0 || idx == -1) {
                        idx = chs.length;
                    }
                    idx--;
                    selected(chs);
                }else  if(e.keyCode==13 && idx>-1){
                var item=panal.children("a").get(idx);
                autoCompleteItemClick.call(item,e);
             }else {
                    if (v != "") {
                        setTimeout(function() {
                            $.post(url, { ac: v }, function(d) {
                                var chs = panal.find("a").each(function() {
                                    $(this).unbind("click", autoCompleteItemClick);
                                    $(this).remove();
                                });
                                for (var i in d) {
                                    if (i >= ac.opts.max) { break; }
                                    var t = d[i][ac.opts.textField].replace(v, "<b>" + v + "</b>");
                                    var item = $("<a>").attr("href", "javascript:void(0)").html(t).appendTo(panal);
                                    item.bind("click", { ac: ac }, autoCompleteItemClick);
                                }
                                panal.show();
                            }, "json");
                        }, 100);
                    } else {
                        hidePanal();
                    }
                }
            });
    }
})(jQuery)
