var k=new Object();
k.msgTitle="信息提示";
k.ynData=[["是","true"],["否","false"]];
k.sexData=[["男","true"],["女","false"]];
(function(Ext) {
    k.extend = function(base, n) {
        for (var i in n) {
            base[i] = n[i];
        }
        return base;
    }
    k.extend(k, {
        mode: {
            add: "Add", view: "View", edit: "Edit"
        },
        dictArrayStore: function(data, fields) {
            fields = fields ? fields : ["text", "value"];
            return new Ext.data.SimpleStore({
                fields: fields, data: data
            });
        },
        dictJsonStore: function(data, fields) {
            fields = fields ? fields : ["text", "value"];
            return new Ext.data.JsonStore({
                fields: fields, data: data
            });
        },
        ynStore: function() {
            return k.dictArrayStore(k.ynData);
        },
        sexStore: function() {
            return k.dictArrayStore(k.sexData);
        },
        ynRender: function(val) {
            var value = val.toLowerCase();
            return value == "true" ? "是" : "否";
        },
        actionUrl: function(url, action, params) {
            if (url.indexOf("?") == -1) { url += "?"; }
            url += "action=" + action;
            if (params) {
                var p = Ext.urlEncode(params);
                if (p != "") { url += "&" + p; }
            }
            return url;
        },
        alert: function(msg, fn) {
            Ext.Msg.alert(k.msgTitle, msg || "温馨提示", fn);
        },
        confirm: function(msg, fn) {
            Ext.Msg.confirm(k.msgTitle, msg || "确定要删除吗？", fn);
        },
        prompt: function(msg, fn, multi, value) {
            Ext.Msg.prompt(k.msgTitle, msg || "请输入内容", fn, null, multi, value);
        },
        tt: function(msg) {
            Ext.example.msg(k.msgTitle, msg);
        },
        multiLine: function(opts) {
            var options = k.extend({
                width: 400,
                buttons: Ext.Msg.OKCANCEL,
                multiline: true,
                title: k.msgTitle,
                msg: "请输入内容"
            }, opts || {});
            Ext.Msg.show(options);
        },
        wait: function(msg) {
            Ext.Msg.show({
                msg: msg || "正在处理你的请求",
                wait: true,
                title: "请稍候",
                width: 250,
                waitConfig: { interval: 200 }
            });
        },
        loading: function(obj, msg) {
            return new Ext.LoadMask(obj || Ext.getBody(), { msg: (msg || "正在处理你的请求..."), removeMask: true });
        },
        hideMsg: function() {
            Ext.Msg.hide();
        },
        getGridIds: function(grid, idField) {
            if (typeof grid == "string") { grid = Ext.getCmp(grid); };
            var rows = grid.getSelectionModel().getSelections();
            if (rows.length <= 0) { k.tt("请至少勾选一条记录进行操作！"); return ""; }
            var ids = [];
            for (var i = 0; i < rows.length; i++) {
                ids.push(rows[i].get(idField));
            }
            return ids.join(",");
        },
        getGridId: function(grid, idField) {
            if (typeof grid == "string") { grid = Ext.getCmp(grid); }
            var row = grid.getSelectionModel().getSelected();
            if (row == null) { k.tt("请至少选择一条记录进行操作！"); return ""; }
            return row.get(idField);
        },
        multiDelete: function(tableName, grid, idField, url, fn) {
            var ids = k.getGridIds(grid, idField);
            if (ids == "") { return; }
            //alert(ids);
            k.confirm("确定删除选择的记录吗？", function(val) {
                if (val == "no") { return; }
                var conn = new Ext.data.Connection();
                conn.request({
                    method: "post",
                    url: "../Common/Del.ashx",
                    params: { tableName: tableName, idField: idField, ids: ids },
                    callback: function(opts, success, response) {
                        if (response.responseText == "true") {
                            k.tt("删除成功！"); fn();
                        } else {
                            k.alert("记录删除失败！");
                        }
                    }
                });
            });
        },
        controlType: function(xtype, opts) {
            var cType, options = opts || {};
            switch (xtype) {
                case "combox": cType = k.combox(opts); break;
                case "checkbox": cType = new Ext.form.Checkbox(opts); break;
                case "textarea" : cType=new Ext.form.TextArea(opts);break;
                case "hidden" : cType=new Ext.form.Hidden(opts);break;
                case "date":
                    {
                        opts = k.extend({ format: "Y-m-d" }, options);
                        cType = new Ext.form.DateField(opts);
                    } break;
                case "float":
                    {
                        cType = new Ext.form.NumberField(opts);
                    } break;
                case "int":
                    {
                        opts = k.extend({ allowNegative: false, allowDecimals: false }, options || {});
                        cType = new Ext.form.NumberField(opts);
                    } break;
                default:
                    {
                        // opts=k.extend({allowBlank:false},options);
                        cType = new Ext.form.TextField(opts);
                    } break;
            }
            return cType;
        },
        editor: function(xtype, opts) {
            return new Ext.grid.GridEditor(k.controlType(xtype, opts));
        },
        combox: function(opts) {
            var options = k.extend({
                mode: "local",
                triggerAction: "all",
                displayField: "text",
                valueField: "value"
            }, opts || {});
            return new Ext.form.ComboBox(options);
        },
        getGridConfig: function(opts) {
            return k.extend({
                border: false,
                loadMask: true,
                clicksToEdit: 1,
                trackMouseOver: false,
                stripeRows: true,
                autoScroll: true,
                viewConfig: { forceFit: true },
                enableColumnMove: false
            }, opts || {});
        },
        grid: function(opts) {
            return new Ext.grid.GridPanel(k.getGridConfig(opts));
        },
        editGrid: function(opts) {
            return new Ext.grid.EditorGridPanel(k.getGridConfig(opts));
        },
        paging: function(opts) {
            var options = k.extend({
                pageSize: 20,
                displayInfo: true,
                displayMsg: "显示第 {0} 到 {1} 条记录，共 {2} 条",
                emptyMsg: "没有记录"
            }, opts || {});
            return new Ext.PagingToolbar(options);
        },
        window: function(opts) {
            var options = k.extend({
                layout: "fit",
                modal: true,
                frame: true,
                buttonAlign: "center",
                plain: true,
                constrain: true,
                resizable: false,
                closeAction: "hide",
                maximizable: false,
                bodyStyle: "padding:10px;",
                width: 600,
                height: 300
            }, opts || {});
            return new Ext.Window(options);
        },
        form: function(opts) {
            var options = k.extend({
                labelWidth: 60,
                defaultType: "textfield",
                labelAlign: "left",
                baseCls: "x-plain",
                defaults: { anchor: "100%" },
                layout: "form"
            }, opts || {});
            return new Ext.form.FormPanel(options);
        }
    });
})(Ext)