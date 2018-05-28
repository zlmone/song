/*
author:                 王松华
email:                  songhuaxiaobao@163.com
namespace:              Song.Grid
content:                数据网格
beforeLoad:             jQuery,Song.Base,Song.Toolbar,Song.Popup,Song.Drag
createDate:             2012-03-14

updatelist:
2013-02-26  新增：支持本地数据加载模式
2013-02-27  修复：popup.song.loading和project.song.loading的冲突
2013-03-20  新增：如果设置主键，则翻页保持选中状态。增加选择模式参数
2013-05-29  新增：可设置空数据显示内容
2013-06-01  新增：拖动列头，可改变列宽
2013-06-02  新增：支持点击列头排序；修复：表格大小变化时更新loading的大小
2013-06-10  新增：支持行详情展示，支持自适应高度，支持无分页条加载数据

待修复：
1.grid拖动改变宽度优化
2.删除行时考虑移除单元格事件
3.事件移植到行事件
4.删除行应该删除details
5.改变列宽应该两条基准线
6.重新load的时候判断数据是否发生改变
7.多表头错乱问题
*/
;(function (song, j) {
    song.grid = function (options) {
        song.grid.base.constructor.call(this, song.grid.defaults, options);
    };
    song.grid.defaults = {
        columns: [],                               //字段集合
        pagination: true,                          //是否分页
        pageSimple: false,                         //是否显示简单分页模式
        selectionMode: "single",                   //选择模式，single=单行,multi=多行,false=不选择
        stripe: true,                              //是否显示斑马线
        renderTo: 'body',                          //表格渲染的容器
        nowrap: true,                              //单元格是否换行显示
        autoLoad: true,                            //是否自动加载数据
        readOnly: false,                           //表格是否只读
        params: {},                                //请求后台数据的参数集合
        pageSize: 15,                              //页大小
        margin: "0px",                             //表格外边距
        width: "100%",                             //表格宽度
        height: "auto",                            //表格高度
        dataKey: null,                             //表格数据主键名
        modelType: "remote",                       //数据模式，remote=服务器后台加载，local=本地数据
        localData: null,                           //本地数据
        loadMsg: "正在努力加载数据...",             //loading提示文字   
        sortName: "",                              //默认排序的字段名
        sortMode: "asc",                           //默认排序方式
        rowsProperty: "rows",
        totalProperty: "totalRecord",
        emptyMsg: "<span style='color:red;' class='song-grid-empty'>暂无数据</span>",
        detailsMsg: "<div class='song-grid-detailsloading'></div>"
    };
    j.extend(song.grid, {
        truncate: function (content, len) {
            return "<span title='" + content + "'>" + String(content).truncate(len) + "</span>";
        }
    });
    song.extend(song.control, song.grid, {
        _columns: [],
        _data: [],
        _rows: [],
        _dataKeyValues: [],
        _modifyData: null,
        _activeCls: "song-grid-row-active",
        _hoverCls: "song-grid-row-hover",
        _evenCls: "song-grid-row-even",
        _boxWidth: 0,
        getType: function () {
            return song.grid.base.getType() + ".grid";
        },
        init: function () {
            this.dom = this._getDom();
            var wrap = this.dom.wrap, me = this;
            if (this.toolbar) {
                this.dom.ttb = j("<div>").prependTo(wrap);
                this.tb = new song.toolbar({
                    renderTo: this.dom.ttb,
                    title: this.title || "列表",
                    items: this.toolbar,
                    border: "1px 1px 0px 1px"
                });
            }
            if (this.pagination) {
                this.dom.btb = j("<div>").appendTo(wrap);
                this.paging = new song.pagingToolbar({
                    border: "0px 1px 1px 1px",
                    renderTo: this.dom.btb,
                    simple: this.pageSimple,
                    url: this.url,
                    rowsProperty: this.rowsProperty,
                    totalProperty: this.totalProperty,
                    isRemote: this.modelType === "remote",
                    pageSize: this.pageSize,
                    beforeLoad: function () {
                        if (me._beforeLoad() === false) {
                            return false;
                        }
                        this.sortName = me.sortName;
                        this.sortMode = me.sortMode;
                        j.extend(this.params, me.params);
                        me.theRequest = true;
                    },
                    afterLoad: function (isSuccess, data) {
                        //如果是本地数据模式
                        if (me.modelType == "local" && me.localData != null) {
                            //本地数据分页
                            this.setPageCount(me.localData.length);
                            this.setPageInfo();
                            data = me._localPaging(this.pageIndex, this.pageSize);
                        }
                        me._afterLoad(isSuccess, data);
                    }
                });
            }
        },
        _beforeLoad: function () {
            var me = this;
            if (me.beforeLoad) {
                if (me.beforeLoad.call(me) === false) {
                    return false;
                }
            }
            me._showMask();
            return true;
        },
        _afterLoad: function (isSuccess, data) {
            var me = this;
            if (isSuccess) {
                me.clearRow();
                me._data = data;
                me._initData();
                me._setEmptyInfo();
            } else {
                me._setEmptyInfo("系统繁忙，请稍后再试！");
            }
            me._hideMask();
            me.theRequest = false;
            me.afterLoad && me.afterLoad.call(me, isSuccess);
        },
        getCellValue: function (rowIndex, colName) {
            //获取单元格数据
            return this.getRowData(rowIndex)[colName];
        },
        _getCellDom: function (rowIndex, colName) {
            return this._getRowDom(rowIndex).find("td[data-columnname='" + colName + "']");
        },
        updateCell: function (rowIndex, colName, content) {
            //更新单元格
            var innerEl = this._getCellInner(this._getCellDom(rowIndex, colName));
            innerEl.html(content).show();
            var value = String(content).delTag();
            this.getRowData(rowIndex)[colName] = value;//更新
        },
        _getCellInner: function (cell) {
            //获取单元格的展示元素
            return cell.find("div.song-grid-cell-inner");
        },
        _addModifyData: function (type, data) {
            //保存修改数据到临时对象
            if (this._modifyData == null) {
                this._modifyData = {};
            }
            if (!this._modifyData.hasOwnProperty(type)) {
                this._modifyData[type] = [];
            }
            switch (type) {
                case "add" :
                case "remove" :
                    this._modifyData[type].push(data);
                    break;
                case "modify":
                    var modify = this._modifyData[type],
                        datakey = data[this.dataKey],
                        isModify = false;
                    if (datakey && modify.length > 0) {
                        for (var i = 0; i < modify.length; i++) {
                            if (modify[i][this.dataKey] == datakey) {
                                isModify = true;
                                j.extend(modify[i], data);
                                break;
                            }
                        }
                    }
                    isModify || this._modifyData[type].push(data);
                    break;
            }
        },
        getChanges: function () {
            //获取修改数据集合
            return this._modifyData;
        },
        editCell: function (rowIndex, colName) {
            //编辑单元格
            var col = this.getColumn(colName),
                me = this;
            if (col.editor != null) {
                var isEdit = true,
                    cellValue = this.getCellValue(rowIndex, colName);
                if (this.onBeforeEditCell) {
                    isEdit = this.onBeforeEditCell.call(this, rowIndex, colName, cellValue);
                }
                if (isEdit !== false) {
                    //开启单元格编辑
                    var cell = this._getCellDom(rowIndex, colName),
                        editorEl = cell.find(".song-editor"),
                        innerEl = this._getCellInner(cell),
                        width = cell.width() - 2;
                    innerEl.hide();
                    if (editorEl.length > 0) {
                        editorEl.width(width).show().get(0).select();
                    } else {
                        var height = cell.height() - 2;
                        editorEl = j("<input style='border:1px solid #99bbe8;padding:0px;margin:0px;line-height:" + height + "px;width:" + width + "px;height:" + height + "px' class='song-editor' value='" + cellValue + "'/>");
                        editorEl.bind("blur", function () {
                            var val = this.value.trim();
                            editorEl.hide();
                            if (val != cellValue) {
                                //如果数据发生改变
                                //innerEl.html(val).show();
                                me.updateCell(rowIndex, colName, val);
                                var modifyData = me.getRowData(rowIndex);
                                me._addModifyData("modify", modifyData);
                                innerEl.addClass("cellModify");
                            } else {
                                innerEl.show();
                            }
                        });
                        editorEl.appendTo(cell);
                        editorEl.get(0).select();
                    }
                    this.onAfterEditCell && this.onAfterEditCell.call(this, rowIndex, colName);
                }
            }
        },
        _setEmptyInfo: function (msg) {
            //设置空数据样式
            if (this._data == null || this._data.length <= 0) {
                this.dom.body.find("table.song-grid-emptyBox").show().find("td:first").html(msg || this.emptyMsg);
            }
        },
        getColumn: function (colName) {
            //根据列的字段名，获取列的配置信息
            var cols = this._columns;
            if (cols == null) {
                return null;
            }
            for (var i = 0; i < cols.length; i++) {
                var col = cols[i];
                if (col.field == colName) {
                    return col;
                }
            }
            return null;
        },
        _sorting: function (colName, sortMode) {
            if (this.localData != null) {
                //本地数据排序                
                if (colName == this.sortName) {
                    this.localData.reverse();
                } else {
                    var colType = this.getColumn(colName).dataType;
                    this.localData.sort(function (data1, data2) {
                        switch (colType) {
                            case "int":
                                var intValue1 = parseInt(data1[colName]),
                                    intValue2 = parseInt(data2[colName]);
                                return intValue1 < intValue2 ? -1 : intValue1 > intValue2 ? 1 : 0;
                            case "float":
                                var floatValue1 = parseFloat(data1[colName]),
                                    floatValue2 = parseFloat(data2[colName]);
                                return floatValue1 < floatValue2 ? -1 : floatValue1 > floatValue2 ? 1 : 0;
                            case "date":
                                return data1[columnName] < data2[columnName] ? -1 : data1[columnName] > data2[columnName] ? 1 : 0;
                        }
                        return String(data1[colName]).localeCompare(data2[colName]);
                    });
                }
            }
            this.sortName = colName;
            this.sortMode = sortMode;
            this.load();
        },
        _localPaging: function (pageIndex, pageSize) {
            //本地分页
            var data = this.localData,
                pageData = [];
            if (data != null) {
                for (var i = 0; i < pageSize; i++) {
                    var index = (pageIndex - 1) * pageSize + i;
                    if (index >= data.length) {
                        break;
                    }
                    pageData.push(data[index]);
                }
            }
            return pageData;
        },
        render: function () {
            this._initColumns(this.columns);
            this._checkAll();
            this.setWidth().setHeight();
            this._initWidth();
            this._fixedHeader();
            this.loading = new song.loading({msg: this.loadMsg, el: this.dom.wrap});
            this.autoLoad && this.load();
            var me = this;

//            j(window).resize(function(){
//                setTimeout(function(){
//                    me.resize();
//                },song.resizeDelay);
//            });
        },
        hide: function () {
            this.dom.wrap.hide();
            return this;
        },
        show: function () {
            this.dom.wrap.show();
            return this;
        },
        _showMask: function () {
            if (this.loading) {
                this.height == "auto" && this.loading.position();
                this.loading.show();
            }
        },
        _hideMask: function () {
            this.loading && this.loading.hide();
        },
        reload: function (params) {
            //分页页码移动到第一页
            this.pagination && (this.paging.pageIndex = 1);
            this.load(params);
        },
        load: function (params) {
            //加载数据
            params && this.setParams(params);
            if (this.pagination) {
                this.paging.load(params);
            } else {
                if (this._beforeLoad() !== false) {
                    if (this.modelType == "local") {
                        this._afterLoad(true, this._localPaging(1, this.localData.length));
                    } else {
                        var me = this;
                        this.setParams({sortName: this.sortName, sortMode: this.sortMode});
                        j.ajax({
                            url: this.url,
                            type: "post", dataType: "json", data: this.params,
                            success: function (data) {
                                me._afterLoad(true, data[me.rowsProperty]);
                            },
                            error: function (xhr, err) {
                                me._afterLoad(false);
                            }
                        });
                    }
                }
            }
            return this;
        },
        setParams: function (params) {
            //设置查询参数
            params && j.extend(this.params, params);
        },
        reStyle: function () {
            //重新设置表格行的样式
            this._initRow(false);
            return this;
        },
        _initColumns: function (cols) {
            if (!cols) {
                return;
            }
            ;
            var dom = this.dom, thead = dom.thead, me = this;
            var tr = j("<tr>").appendTo(thead);
            var len = cols.length, i = 0, col, td, ec = this.expandColumn;
            for (; i < len; i++) {
                col = cols[i];
                td = j('<td class="song-grid-column" data-columnname="' + (col.field ? col.field : "") + '">').appendTo(tr);
                if (col.showDetails || col.checkbox) {
                    col.width = col.width || 30;
                    col.align = "center";
                }
                //如果是复选框列
                if (col.checkbox) {
                    this.isCheckColumn = true;
                    col.resizable = false;
                    col.sortable = false;
                    if (this.selectionMode != "single") {
                        this.dom.checkAll = j("<input type='checkbox'>").appendTo(td);
                    } else {
                        //修复ie无内容不显示边框问题
                        td.append("&nbsp;");
                    }
                } else {
                    //oncontextmenu="return false;"
                    col.header = col.header == null ? "&nbsp" : col.header;
                    var inner = j('<div class="song-grid-column-inner">{0}</div>'.format(col.header));
                    //防止拖动列宽时事件冒泡
                    if (col.resizable) {
                        inner.bind("mousedown", function () {
                            return false;
                        });
                    }
                    //是否开启列头排序
                    if (col.sortable) {
                        inner.css("cursor", "pointer").bind("click", function (e) {
                            var innerEl = j(this),
                                sortname = innerEl.parent().attr("data-columnname"),
                                sortMode = "asc";
                            if (innerEl.hasClass("sortasc")) {
                                sortMode = "desc";
                            }
                            //设置排序的箭头样式
                            me.dom.thead.find("div.song-grid-column-inner").removeClass("sortasc sortdesc");
                            innerEl.addClass("sort" + sortMode);
                            //重新加载数据
                            me._sorting(sortname, sortMode);
                        });
                    }
                    td.append(inner);
                    col.dom = td;
                    if (ec && ec == col.field) {
                        this.expandColumn = this._columns.length;
                    }
                    col.width = col.width || 100;
                }
                if (col.rowspan) {
                    td.attr("rowspan", col.rowspan);
                    //var hl=col.rowspan*22+1;
                    //td.find(">div").css({height:hl,lineHeight:hl+"px"});
                }
                col.align && td.css("text-align", col.align);
                if (!col.columns || col.columns.length < 0) {
                    td.width(col.width);
                    this._boxWidth += col.width + 5;
                    if (col.resizable) {
                        //设置列可以拖动改变宽度
                        var offsetx = dom.body.offset().left;
                        new song.resize(td, {
                            moveSet: false,
                            proxy: false,
                            lockY: true,
                            cursor: "e-resize",
                            onStart: function (e) {
                                this.scrollLeft = dom.body.scrollLeft();
                                if (me.height == "auto") {
                                    me.dom.separator.css({
                                        height: me.dom.header.outerHeight() + me.dom.body.outerHeight(),
                                        zIndex: song.zIndex(),
                                        top: me._getToolbarHeight()
                                    });
                                }
                                dom.separator.css({left: e.pageX - offsetx + this.scrollLeft}).show();
                            },
                            onMove: function (e) {
                                dom.separator.css({left: e.pageX - offsetx + this.scrollLeft});
                            },
                            onStop: function (e) {
                                dom.separator.hide();
                                this.el.width(this.width);
                                //设置body的单元格的宽度
                                var colname = this.el.attr('data-columnname');
                                if (colname) {
                                    me.dom.tbody.find("td[data-columnname='" + colname + "']").width(this.width);
                                    //更新到列配置里面去，防止翻页的时候，body和表头宽度不一致
                                    me.getColumn(colname).width = this.width;
                                }
                            }
                        });
                    }
                    this._columns.push(col);
                } else {
                    //支持多表头
                    var spanlen = col.columns.length;
                    td.attr("colspan", spanlen);
                    td.addClass("song-grid-multicolumn");
                    this._initColumns(col.columns);
                }
            }
        },
        _initWidth: function () {
            var dom = this.dom,
                w = this._boxWidth,
                expandIndex = this.expandColumn,
                scroll = this.height == "auto" ? 0 : 18;//保留滚动条的宽度
            if (expandIndex != null) {
                //扩张列宽度算法：总宽度-滚动条预算宽度-所有的列宽+扩张列的原宽
                var ec = this._columns[expandIndex],
                    ow = ec.width,
                    ew = dom.header.width() - scroll - w + ow;
                ew = ew < 0 ? 10 : ew;
                ec.dom.width(ew);
                ec.width = ew;
                //重新计算box的宽度
                w = w - ow + ew;
            }
            dom.headerBox.width(w);
            dom.bodyBox.width(w);
        },
        _initData: function () {
            var data = this._data;
            if (data != null) {
                var len = data.length, i = 0;
                for (; i < len; i++) {
                    this._createRow(data[i], i);
                }
                this._initRows(true);
            }
        },
        _initRows: function (isEvent) {
            var me = this,
                rows = this._rows,
                len = rows.length,
                i = 0, row,
                evenCls = this._evenCls,
                s = this.stripe;
            for (; i < len; i++) {
                //设置行样式
                row = rows[i];
                if (s && i % 2 != 0) {
                    row.addClass(evenCls);
                } else {
                    row.hasClass(evenCls) && row.removeClass(evenCls);
                }
                //设置行事件
                if (!isEvent) {
                    return;
                }
                ;
                var hoverCls = this._hoverCls;
                row.hover(function () {
                    $(this).addClass(hoverCls);
                }, function () {
                    $(this).removeClass(hoverCls);
                });
                this.onRowContextmenu && row.bind("contextmenu", function (e) {
                    var row = j(this);
                    me.onRowContextmenu.call(me, e, me._convertRow(row));
                    e.preventDefault();
                });
                this.onRowDblclick && row.bind("dblclick", function (e) {
                    me.onRowDblclick.call(me, me._convertRow(j(this)));
                });
                row.bind("click", function (e) {
                    var result = me._expandDetails(e);
                    //if(!result){return false;}
                    me._rowClickHandler(this);
                });
            }
        },
        _rowClickHandler: function (obj) {
            var r = j(obj), me = this,
                activeCls = this._activeCls;
            if (me.selectionMode) {
                var sRow = me._selectedRow,
                    ck = me.isCheckColumn;
                if (me.selectionMode == "single") {
                    if (sRow && sRow[0] == obj) {
                        me._setCheck(r, true);
                    } else {
                        //首先清空选中的行
                        sRow && me.selectRow(sRow, false);
                        //选中当前行
                        me.selectRow(r, true);
                    }
                } else {
                    r.hasClass(activeCls) ? me.selectRow(r, false) : me.selectRow(r, true);
                }
            }
            me.onRowClick && me.onRowClick.call(me, me._convertRow(r));
        },
        _isTarget: function (target, tagName, className) {
            return (target.tagName.toLowerCase() == tagName && target.className.has(className));
        },
        _expandDetails: function (e) {
            //点击展开明细内容
            var target = e.target;
            if (this._isTarget(target, "span", "song-grid-showDetails")) {
                var el = j(target);
                var rowIndex = el.attr("data-detailindex"),
                    renderAttr = "data-renderdetails",
                    isRender = el.attr(renderAttr),
                    detailsRow = this.dom.tbody.find("tr[data-detailindex='" + rowIndex + "']"),
                    isHide = detailsRow.is(":hidden"),
                    showCls = "song-grid-detailsshow",
                    hideCls = "song-grid-detailshide";
                if (isHide) {
                    detailsRow.show();
                    el.removeClass(hideCls).addClass(showCls);
                    //如果第一次点击，则渲染明细内容
                    if (!isRender) {
                        //加载loading
                        var detailsInner = detailsRow.find("td:first");
                        detailsInner.html(this.detailsMsg);
                        var content = this.showDetails.call(this, detailsInner, rowIndex);
                        content && detailsInner.html(content);
                        el.attr(renderAttr, "true")
                    }
                } else {
                    detailsRow.hide();
                    el.removeClass(showCls).addClass(hideCls);
                }
                return false;
            }
            return true;
        },
        setSelectedRow: function (row_index) {
            this.clearSelection().selectRow(row_index, true, true);
            return this;
        },
        _clearDataKeyValues: function () {
            this._dataKeyValues = [];
        },
        selectRow: function (row_index, selected, autoScroll) {
            var row = typeof row_index == "number" ? this._getRowDom(row_index) : row_index;
            if (!row) {
                return;
            }
            if (this.selectionMode == "single" && selected) {
                this.clearSelection();
                this._selectedRow = row;
            }
            this._setCheck(row, selected);
            row[(selected ? "add" : "remove") + "Class"](this._activeCls);
            //设置或移除选中的主键值
            if (this.dataKey) {
                var data = this.getRowData(this.getRowIndex(row)),
                    datakey = data[this.dataKey];
                if (datakey) {
                    var hasDatakey = Array.has(this._dataKeyValues, datakey);
                    if (selected) {
                        hasDatakey || this._dataKeyValues.push(datakey);
                    } else {
                        hasDatakey && Array.remove(this._dataKeyValues, datakey);
                    }
                }
            }
            if (selected && autoScroll != false) {
                //自动调节滚动条，以确保设置的行可见
                var dom = this.dom,
                    hh = dom.header.outerHeight(),
                    body = dom.body,
                    top = row.position().top - hh,
                    rh = row.outerHeight(),
                    bs = body.scrollTop(),
                    bh = body.height(),
                    fix = 18;
                if (this.toolbar) {
                    top -= dom.ttb.outerHeight();
                }
                if (top <= 0) {
                    body.scrollTop(bs + top - fix);
                } else {
                    if (top + rh > bh - fix) {
                        body.scrollTop(bs + top + rh - bh + fix);
                    }
                }
            }
            return this;
        },
        clearSelection: function () {
            if (this.selectionMode == "single") {
                var sRow = this._selectedRow;
                sRow && this.selectRow(sRow, false);
                this._selectedRow = null;
            } else {
                var i = 0, rows = this._rows;
                len = this._rows.length;
                for (; i < len; i++) {
                    this.selectRow(rows[i], false);
                }
            }
            this._clearDataKeyValues();
            return this;
        },
        _setCheck: function (row, checked) {
            this.isCheckColumn && this._getCheck(row).attr("checked", checked);
        },
        _getCheck: function (row) {
            return row.find("input[type='checkbox'][multi='true']");
        },
        _checkAll: function () {
            var all = this.dom.checkAll, me = this;
            all && all.click(function (e) {
                if (me.selectionMode != "single") {
                    var rows = me._rows,
                        len = rows.length,
                        i = 0,
                        cls = me._activeCls;
                    for (; i < len; i++) {
                        this.checked ? (rows[i].hasClass(cls) || me.selectRow(i, true, false)) : (rows[i].hasClass(cls) && me.selectRow(i, false));
                    }
                } else {
                    e.preventDefault();
                }
            });
        },
        _createRow: function (data, rowIndex) {
            var tbody = this.dom.tbody,
                len = this._columns.length,
                i = 0, col, w,
                cols = this._columns, d, me = this;
            //判断是否需要选中，如果设置了主键，则需要选中
            var isSelected = false;
            if (this.dataKey) {
                var datakey = data[this.dataKey];
                if (datakey) {
                    isSelected = Array.has(this._dataKeyValues, datakey);
                }
            }
            var tr = j("<tr class='song-grid-row' data-rowindex='" + rowIndex + "'>").appendTo(tbody);
            for (; i < len; i++) {
                col = cols[i];
                var td = j('<td class="song-grid-cell" data-columnname="' + (col.field ? col.field : "") + '">').width(col.width).appendTo(tr);
                if (col.showDetails) {
                    td.html("<span data-detailindex='" + rowIndex + "' class='song-grid-showDetails song-grid-detailshide'>&nbsp;</span>");
                    j("<tr data-detailindex='" + rowIndex + "' style='display:none'><td colspan='" + len + "' class='song-grid-cell'></td></tr>").appendTo(tbody);
                } else if (col.checkbox) {
                    td.html("<input type='checkbox' multi='true' " + (isSelected ? "checked='checked'" : "") + "/>");
                } else {
                    d = data[col.field];
                    if (col.render) {
                        d = col.render.call(this, d, this._convertRow(tr));
                    }
                    var inner = j('<div class="song-grid-cell-inner">{0}</div>'.format(d == null ? "&nbsp;" : d));
                    td.append(inner);
                    //是否启动编辑
                    if (col.editor) {
                        inner.bind("click", function () {
                            var cell = j(this).parent(),
                                colName = cell.attr("data-columnname"),
                                rindex = cell.parent().attr("data-rowindex");
                            me.editCell(rindex, colName);
                        });
                    }
                }
                col.align && td.css("text-align", col.align);
            }
            if (isSelected) {
                tr.addClass(this._activeCls);
                if (this.selectionMode == "single") {
                    this._selectedRow = tr;
                }
            }
            this._rows.push(tr);
        },
        getRowData: function (rowIndex) {
            return this._data[rowIndex];
        },
        getRowIndex: function (dom) {
            var i = dom.attr("data-rowindex");
            return i ? parseInt(i) : -1;
        },
        _convertRow: function (dom) {
            if (!dom) {
                return null;
            }
            var i = this.getRowIndex(dom),
                rowType = dom.attr("data-rowtype") || "datarow";
            return {rowIndex: i, data: this.getRowData(i), rowType: rowType};
        },
        addRow: function (data) {
            this._data.push(data);
            this._createRow(data, this._rows.length);
            return this;
        },
        getSelectedRow: function () {
            return this.selectionMode == "single" ? this._convertRow(this._selectedRow) : (this.getSelectedRows()[0] || null);
        },
        getSelectedRows: function () {
            var rows = this._rows,
                i = 0, len = rows.length,
                sRows = [], row,
                activeCls = this._activeCls;
            for (; i < len; i++) {
                row = rows[i];
                if (row.hasClass(activeCls)) {
                    sRows.push(this._convertRow(row));
                }
            }
            return sRows;
        },
        getDataKeyValues: function () {
            return this._dataKeyValues;
        },
        getRows: function () {
            var rows = [];
            for (var i = 0; i < this._rows.length; i++) {
                rows.push(this._convertRow(this._rows[i]));
            }
            return rows;
        },
        _getRowDom: function (rowIndex) {
            return this._rows[rowIndex];
        },
        getRow: function (rowIndex) {
            return this._convertRow(this._getRowDom(rowIndex));
        },
        clearRow: function () {
            var rows = this.dom.tbody.find("tr");
            for (var i = 0; i < rows.length; i++) {
                this._deleteRowDom(rows.eq(i));
            }
            this._destroyRowData();
            return this;
        },
        deleteRow: function (rowIndex) {
            var data = this.getRowData(rowIndex);
            this._deleteRow(rowIndex);
            this._addModifyData("remove", data);
            this.reStyle();
            return this;
        },
        _deleteRowDom: function (row) {
            row.unbind().html('').remove();
            row = null;
        },
        _destroyRowData: function () {
            var rows = this._rows;
            for (var i = 0; i < rows.length; i++) {
                this._deleteRow(i);
                i--;
            }
            delete this._data;
            delete this._rows;
        },
        _deleteRow: function (rowIndex) {
//            if(this.selectionMode=="single"){
//                this.clearSelection();
//            }
            var row = this._rows[rowIndex];
            if (row) {
                this._deleteRowDom(row);
                delete this._rows[rowIndex];
                Array.remove(this._rows, rowIndex);
                delete this._data[rowIndex];
                Array.remove(this._data, rowIndex);
                //删除本地数据
                if (this.modelType == "local" && this.localData != null) {
                    //....
                }
            }
            return this;
        },
        _getDom: function () {
            var to = j(this.renderTo);
            var wrap = j("<div class='song-grid-wrap' >").html(song.grid._template).appendTo(to);
            this.margin && wrap.css("margin", this.margin);
            var els = wrap.find("div"), name, i = 0, len = els.length, dom = {};
            for (; i < len; i++) {
                name = els[i].className.split("song-grid-")[1];
                dom[name] = els.eq(i);
            }
            dom.parent = to;
            dom.win = j(window);
            dom.doc = j(document);
            dom.thead = dom.headerBox.find("thead:first");
            dom.tbody = dom.bodyBox.find("tbody:first");
            if (this.readOnly) {
                wrap.addClass("noselect").bind("selectstart", function () {
                    return false;
                });
            }
            //wrap.addClass("noselect");
            dom.wrap = wrap;
            return dom;
        },
        _fixedHeader: function () {
            var body = this.dom.body, head = this.dom.headerBox;
            body.bind("scroll", function () {
                head.css("left", -$(this).scrollLeft());
            });
        },
        _toNumberSize: function (val, dom, wh) {
            if (typeof val == "string") {
                if (val.has("%")) {
                    var rate = val.split("%")[0];
                    var max = this.renderTo == "body" ? dom.win["inner" + wh]() : dom.parent["inner" + wh]();
                    val = parseInt(max * rate / 100);
                } else {
                    val = parseInt(val) || 0;
                }
            }
            return val;
        },
        setWidth: function (width) {
            var w = this.width = width || this.width, pw, dom = this.dom;
            if (w == "auto") {
                return this;
            }
            pw = this._toNumberSize(w, dom, "Width");
            var wrap = dom.wrap,
                m = song.getSpace(wrap, ["ml", "mr"]),
                bw = pw - m,
                hbw = bw - 2;
            wrap.width(bw);
            dom.body.width(hbw);
            dom.header.width(hbw);
            return this;
        },
        _getToolbarHeight: function () {
            return this.toolbar ? this.dom.ttb.outerHeight() : 0;
        },
        setHeight: function (height) {
            var h = this.height = height || this.height, ph,
                dom = this.dom;
            if (h == "auto") {
                //防止ie长度过长出现滚动条
                dom.body.css("overflow-y", "hidden");
                return this;
            }
            ph = this._toNumberSize(h, dom, "Height");
            var wrap = dom.wrap,
                hh = dom.header.outerHeight(),
                m = song.getSpace(wrap, ["mt", "mb"]),
                bh = ph - hh - m - 1,
                t = this._getToolbarHeight(), zIndex = song.zIndex();
            if (this.pagination) {
                bh -= dom.btb.outerHeight();
            }
            bh -= t;
            dom.body.height(bh);
            dom.separator.css({height: bh + hh, zIndex: zIndex, top: t});
            return this;
        },
        resize: function (width, height) {
            this.setWidth(width).setHeight(height);
            //更新遮罩的宽度
            this.loading && this.loading.position();
            return this;
        },
        destroy: function () {
            this.paging = null;
            this.tb = null;
            this.dom = null;
            this.loading = null;
            delete this._columns;
            delete this._dataKeyValues;
            delete this._modifyData;
            this.localData && (delete this.localData);
            this._destroyRowData();
        }
    });
    song.grid._template =
        '<div class="song-grid-separator"></div>'
        //+'<div class="song-grid-ttb">'
        + '<div class="song-grid-header">'
        + '<div class="song-grid-headerBox">'
        + '<table border="0" cellpadding="0" cellspacing="0" class="song-grid-table">'
        + '<thead>'
        + '</thead>'
        + '</table>'
        + '</div>'
        + '</div>'
        + '<div class="song-grid-body">'
        + '<table class="song-grid-emptyBox"><tr><td></td></tr></table>'
        + '<div class="song-grid-bodyBox">'
        + '<table border="0" cellpadding="0" cellspacing="0" class="song-grid-table">'
        + '<tbody>'
        + '</tbody>'
        + '</table>'
        + '</div>'
        + '</div>';
//+'<div class="song-grid-btb">';
})(window.song, window.jQuery);