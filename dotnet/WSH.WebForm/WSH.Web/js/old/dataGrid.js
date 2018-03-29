/*
说明：datagrid的js脚本，基于jQuery，请注意引入jQuery源文件
作者：王松华
*/
(function($) {
    $.fn.extend({
        colResize: function(opts) {
            this.x = this.w = 0;
            this.margin = opts.panal.offset().left;
            this.thw = this.tbw = 0;
            this.startLeft = 0;
            this.start = function(e) {
                this.w = opts.column.width();
                this.x = e.pageX;
                this.thw = opts.thead.width() - this.w;
                this.tbw = opts.tbody.width() - this.w;
                this.startLeft = this.offset().left - this.margin;
                opts.line.css("left", this.startLeft + "px").show();
                $(document).bind("mousemove", this.onMove).bind("mouseup", this.onStop);
                j.evt(e).prevent().stop();
            }
            this.move = function(e) {
                //限定拖动范围
                var minMove = this.startLeft + opts.min - this.w;
                var linex = Math.max(e.pageX - this.margin, minMove);
                opts.line.css("left", linex + "px");
            }
            this.stop = function(e) {
                var wid = Math.max(this.w + e.pageX - this.x, opts.min);
                opts.column.width(wid);
                opts.rows.each(function() {
                    $(this).find("td:eq(" + opts.index + ")").width(wid);
                });
                //一定要重新设置table的宽度
                opts.thead.width(this.thw + wid);
                opts.tbody.width(this.tbw + wid);
                //重新设置columns的滚动left
                var scrollleft = opts.tbody.parent().scrollLeft();
                opts.thead.css("margin-left", (-scrollleft) + "px");
                //隐藏参考线
                opts.line.hide();
                $(document).unbind("mousemove", this.onMove).unbind("mouseup", this.onStop);
            }
            this.onMove = j.bindWithEvent(this, this.move);
            this.onStop = j.bindWithEvent(this, this.stop);
            this.bind("mousedown", j.bindWithEvent(this, this.start));
            this.click(function(e) { j.evt(e).prevent().stop(); });
        },
        setPanalHeight: function(height, th, tb, tp, panal) {
            if (height.has("%")) {
                var h = j.pos.y() * (parseInt(height.replace("%", "")) * 0.01);
                var b = h - th.height() - tp.height() - 3;
                tb.parent().height(b);
            }
            //ResizeLine
            var resizeLine = panal.children("div.datagrid-resize-line");
            resizeLine.height(panal.height());
        },
        datagridEditStart: function() {
            var type = this.attr("editType");
            var name = this.attr("colName");
            var txt = this.find("span");
            if (type == "Text") {
                var c = this.find("input:text");
                if (c.css("display") == "none") {
                    var h = this.height() - 2, w = this.width() - 2;
                    c.css("line-height", (h + "px")).height(h).width(w).val(txt.text()).show();
                    c.get(0).focus(); c.get(0).select();
                    txt.hide();
                }
            }
        },
        datagridEditEnd: function() {
            var cell = this.parent();
            var type = cell.attr("editType");
            var name = cell.attr("colName");
            var txt = cell.find("span");
            txt.html(this.val()).show();
            this.hide();
        },
        datagridEditSave: function() {
            var cell = this.parent();
            cell.addClass("editored");
        },
        initDataGrid: function(opts) {
            var thead = this;
            var tpage = $("#" + opts.tPage);
            var tbody = opts.tBody;
            var th = thead.find("td");
            var tr = opts.tBody.find("tr");
            var panal = opts.panal;
            //Height
            this.setPanalHeight(opts.height, thead, tbody, tpage, panal);
            $(window).bind("resize", function() {
                thead.setPanalHeight(opts.height, thead, tbody, tpage, panal);
            });
            //ResizeMin
            var min = 30;
            //Resize
            var resizeLine = panal.children("div.datagrid-resize-line");
            th.each(function(i) {
                var resize = $(this).find("span.datagrid-col-resize");
                $(resize).colResize({ panal: panal, tbody: opts.tBody, rows: tr, thead: thead, line: resizeLine, column: $(this), index: i, min: 32 });
            });
            //Fiexd
            var obj = opts.tBody.parent();
            obj.bind("scroll", function(e) {
                thead.css("margin-left", -$(this).scrollLeft() + "px");
                j.evt(e).prevent().stop();
            });
            //CheckAll
            opts.checkAll.click(function() {
                $(opts.tBody).checkAll($(this));
            });
            //RowEvent
            tr.each(function(i) {
                var row = $(this);
                //                row.mouseover(function() {
                //                    if (!row.hasClass("rowclick")) { row.addClass("rowover"); }
                //                });
                //                row.mouseout(function() {
                //                    if (!row.hasClass("rowclick")) { row.removeClass("rowover"); }
                //                });
                row.click(function() {
                    tr.removeClass("rowclick");
                    //row.removeClass("rowover");
                    row.addClass("rowclick");
                    if (opts.rowClick) {
                        opts.rowClick(row.attr("dataKey"), row);
                    }
                });
                row.dblclick(function() {
                    if (opts.rowDblclick) { opts.rowDblclick(row.attr("dataKey"), row); }
                });
            });
        }
    });
})(jQuery)