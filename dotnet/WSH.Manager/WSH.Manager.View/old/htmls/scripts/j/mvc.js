; (function (j) { 
    j.mvc={
        returnAction: {
            closeDialog:"CloseDialog",
            clearForm:"ClearForm",
            execute:function (flag) {
                if (flag == this.closeDialog) {
                    parent.document.forms[0].submit();
                    frameElement.lhgDG.cancel();
                } else if (flag == this.clearForm) {
                    $(document.forms[0]).find("input[type='text'],textarea").val("");
                    window.closeReload=true;
                } 
            }
        },
        pager: {
            move: function (pageIndex, id) {
                j(id || "pageindex").val(pageIndex);
                j.formSubmit();
            },
            check: function (obj, pageIndex, pageCount) {
                var page = obj.value.trim();
                if (j.validator.check("int", page) && parseInt(page) > 0) {
                    var pageNum = parseInt(page);
                    if (pageNum > pageCount) {
                        obj.value = pageNum = pageCount;
                    }
                    return { check: true, page: pageNum }
                } else {
                    obj.value = pageIndex;
                }
                return { check: false, page: pageIndex }
            },
            goto: function (obj, pageIndex, pageCount, e) {
                var evt = new j.event(e);
                if (evt.kc == j.kc.enter) {
                    var result = this.check(obj, pageIndex, pageCount);
                    if (result.check && pageIndex!=result.page) {
                        //location.href = location.href.replace("pageindex=" + pageIndex + "", "pageindex=" + result.page + "");
                         j.formSubmit();
                    }
                    return false;
                }
            },
            size: function () {
                //var pageSize = parseInt(obj.value);
                //location.href = location.href.replace("pagesize=" + size + "", "pagesize=" + pageSize + "").replace("pageindex=" + index + "", "pageindex=1");
                j.formSubmit();
            }
        }
    };
    //mvc2 DataGrid
    j.mvc.grid=j.getClass();
    j.extend(j.mvc.grid,{
        init:function(){
            
        }
    },j.grid);
    //-------------------mvc表格插件（其他开发模式可作相应的修改）--------------------------
    j.grid = function (el, opts) {
        j.extend(this, opts, { skin: "Ext", dataKey: "dataKey", checkName: "checkAll",
            ajaxDelete: true, nowarp: true, sortable: true, dirValue: "desc", sortValue: "id",
            imgPath: "../Images/grid",
            selectedRow:null,el:j(el)
        });
        var cls={grid:"_Tab",odd:"_RowOdd",even:"_RowEven",hover:"_RowHover",click:"_RowClick"}
        for (var i in cls) {
            this[i+"Cls"]=this.skin+cls[i];
        }
        this.getRows();
        if (this.rows.length > 0) {
            this.el.addClass(this.gridCls);
            if (this.nowarp) { this.el.addClass("nowarp_table"); }
        }
        this.setStyleEvent(true);
        if (this.ajaxDelete == false) {
            this.createDelIdsField();
        }
        if (this.sortable) {
            this.bindSort();
        }
    }
    j.grid.prototype = {
        bindSort: function () {
            this.sortName = j.setDefault(this.sortName, "sortname");
            this.dirName = j.setDefault(this.dirName, "sortdir");
            var sortfield = j("<input>").attr({ type: "hidden", id: this.sortName, name: this.sortName }).val(this.sortValue);
            var dirfield = j("<input>").attr({ type: "hidden", id: this.dirName, name: this.dirName }).val(this.dirValue);
            this.el.after(sortfield).after(dirfield);
            var headers = j(this.rows[0]).tag("th");
            for (var i = 0; i < headers.length; i++) {
                var h = j(headers[i]);
                var sortField = h.attr("sortField");
                if (sortField != null && sortField != "") {
                    if (this.sortValue == sortField) {
                        h.append(j("<img>").attr("src", this.imgPath + "/s.gif").addClass("sort" + this.dirValue));
                    }
                    h.css("cursor", "pointer").attr("title", "点击列头进行排序").bind("click", this.sort, this);
                }
            }
        },
        createDelIdsField: function () {
            this.delName = this.delName == null ? "del_ids" : this.delName;
            var delfield = j("<input>").attr({ type: "hidden", id: delName, name: delName });
            this.el.after(delfield);
        },
        getRows: function () {
            this.rows = this.el.get() == null ? [] : this.el.tag("tr");
        },
        resetStyle: function () {
            this.selectedRow = null;
            this.getRows(); this.setStyleEvent(false);
        },
        setStyleEvent: function (isEvent) {
            if (this.rows.length <= 0) { return; }
            for (var i = 1; i < this.rows.length; i++) {
                var row = this.rows[i], obj = this;
                row.className = (i % 2 == 0) ? this.oddCls : this.evenCls;
                if (isEvent) {
                    row.setAttribute("tabindex", "0"); row.setAttribute("hidefocus", "true");
                    if (this.allowMouse != false) {
                        row.onmouseover = function () {
                            if (this.className != obj.clickCls) { this.className = obj.hoverCls; }
                            //j(this).addClass(obj.hoverCls);
                        }
                        row.onmouseout = function () {
                            if (this.className != obj.clickCls) { this.className = (this.rowIndex % 2 == 0) ? obj.oddCls : obj.evenCls; }
                            //j(this).removeClass(obj.hoverCls);
                        }
                        // if (j.browser.ie) {
                        row.onkeydown = function (e) {
                            var evt = new j.event(e);
                            switch (evt.kc) {
                                case j.kc.up: { obj.prevRow(); }; break;
                                case j.kc.down: { obj.nextRow(); }; break;
                                case j.kc.enter: { obj.selectedRowEnter && obj.selectedRowEnter(obj.getId(), obj.selectedRow); }; break;
                            }
                        }
                        // }
                    }
                    if (this.allowClick != false) {
                        row.onclick = function () {
                            obj.setSelectedRow(this);
                        };
                    }
                    if (obj.dblclick) { row.ondblclick = function () { obj.dblclick(obj.getId(), this); } }
                }
                row = null;
            }
        },
        setSelectedRow: function (row) {
            if (!row) { return; }
            if (this.selectedRow != row) {
                if (this.selectedRow != null) { this.selectedRow.className = (this.selectedRow.rowIndex % 2 == 0) ? this.oddCls : this.evenCls; }
                row.className = this.clickCls; this.selectedRow = row;
                this.click && this.click(this.getId(), row);
            }
        },
        prevRow: function () {
            if (this.selectedRow == null) { return; }
            var selectedIndex = this.selectedRow.rowIndex;
            if (selectedIndex > 1) {
                this.setSelectedRow(this.rows[selectedIndex - 1]);
            }
        },
        nextRow: function () {
            if (this.selectedRow == null) { return; }
            var selectedIndex = this.selectedRow.rowIndex;
            if (selectedIndex < this.rows.length) {
                this.setSelectedRow(this.rows[selectedIndex + 1]);
            }
        },
        checkAll: function (el) {
            el = dom(el || "checkAll"); var chs = this.el.tag("input"), n = this.checkName;
            el.onclick = function () {
                for (var i = 0; i < chs.length; i++) { if (chs[i].type == "checkbox" && chs[i].name == n) { chs[i].checked = this.checked; } }
            }; el = null;
        },
        getId: function (row) {
            var curr = j.setDefault(row, this.selectedRow);
            return curr == null ? "" : curr.getAttribute(this.dataKey);
        },
        getIds: function () {
            var ids = new Array();
            for (var i = 1; i < this.rows.length; i++) {
                var row = this.rows[i];
                var chs = row.getElementsByTagName("input");
                for (var j = 0; j < chs.length; j++) {
                    if (chs[j].type == "checkbox" && chs[j].name == this.checkName && chs[j].checked == true) {
                        var id = this.getId(row); if (id != "") { ids.push(id); }
                    }
                }
            }; return ids;
        },
        getRowById: function (id) {
            if (typeof id == "object") { return id; }
            if (this.rows.length <= 0) { return null; }
            for (var i = 1; i < this.rows.length; i++) {
                if (this.rows[i].getAttribute(this.dataKey) == id) {
                    return this.rows[i];
                }
            }
        },
        deleteRow: function (id_row) {
            var row = this.getRowById(id_row);
            if (row != null) {
                row.onclick = null; row.ondblclick = null; row.onkeydown = null;
                row.parentNode.removeChild(row);
            }
        },
        showDialog: function (mode, id, action) {
            action = action || "Details";
            var param = new j.map(), obj = this;
            param.add("mode", mode).add("datakey", id);
            var page = "/" + this.editController + "/" + action + "?" + param.toParam();
            //var opts = j.extend({ id: (this.editController + "Edit"), page: page, width: 600,}, this.dialogOptions || {});
            var dg = new $.dialog(j.extend({ id: (this.editController + "Edit"), page: page, width: 600, onXclick: function () {
                dg.cancel();
                //            if (dg.dgWin && dg.dgWin.closeReload == true) {
                //                window.document.forms[0].submit();
                //            }

            }
            }, this.dialogOptions || {}));
            dg.ShowDialog();
        },
        submit: function (url) {
            j.formSubmit(this.formName, url);
        },
        edit: function (id, action, msg) {
            id = id ? id : this.getId();
            if (id == "") {
                j.tip.msg(msg || "请选择一条记录进行操作");
            } else {
                this.showDialog(j.editMode.edit, id, action);
            }
        },
        add: function (action) {
            this.showDialog(j.editMode.add, "", action);
        },
        view: function (id, action) {
            this.showDialog(j.editMode.view, id || this.getId(), action);
        },
        checkdel: function (msg) {
            var check = true;
            var ids = this.getIds().toString();
            ids = ids == "" ? this.getId() : ids;
            if (ids == "") {
                j.tip.msg(msg || "请至少选择一条记录进行操作！");
                check = false;
            } else {
                check = confirm("确定要删除选中的记录吗？");
            }
            return { ids: ids, check: check }
        },
        del: function (action, msg) {
            if (this.ajaxDelete == true) {
                this.ajaxDel(action, msg);
            } else {
                this.submitDel(action, msg);
            }
        },
        submitDel: function (action, msg) {
            var d = this.checkdel(msg);
            if (d.check) {
                var delids = j(this.delName).val(d.ids);
                this.submit("/" + this.editController + "/" + (action || "Del"));
            }
        },
        ajaxDel: function (action, msg) {
            var d = this.checkdel(msg);
            if (d.check) {
                //var load = j.tip.loading("正在提交您的请求，请稍后", true);
                var url = "/" + this.editController + "/" + (action || "AjaxDelete") + "?ids=" + d.ids, obj = this;
                //setTimeout(function () { 
                $.ajax({
                    type: "get", dataType: "json", url: url, success: function (data) {
                        // load.remove();
                        if (data.result == "true") {
                            j.tip.msg("删除成功!" + data.msg);
                            var ids = d.ids.split(",");
                            for (var i = 0; i < ids.length; i++) {
                                obj.deleteRow(ids[i]);
                            }
                            obj.resetStyle();
                        } else {
                            j.tip.msg("删除失败！" + data.msg, "error", 3, true);
                        }
                    }, error: function (xhr) {
                        //load.remove();
                        j.tip.msg("删除失败！", "error", 3, true);
                    }
                });
                // }, 200);
            }
        },
        query: function (action) {
            dom("pageindex").value = 1;
            this.submit();
        },
        sort: function (e, obj) {
            dom(obj.sortName).value = this.getAttribute("sortField");
            var dir = dom(obj.dirName);
            dir.value = dir.value == "desc" ? "asc" : "desc";
            obj.submit();
        }
    }
})(j)



iframe.load=function (id, fn) { 
    el = document.getElementById(id); 
    el.onload = el.onreadystatechange = function () { 
        if (this.readyState && this.readyState !== 'complete') { 
            return; 
        } 
        fn(); 
        };
        el = null; 
}