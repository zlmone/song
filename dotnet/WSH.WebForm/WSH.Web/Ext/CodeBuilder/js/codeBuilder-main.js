var codeBuilder={
    readerUrl:function(action){
        return "data/Reader.ashx?action="+action;
    }
}
Ext.onReady(function () {
    //注册配置选项
    var joinControl = join.createControl();
    code.options.form();
    code.options.config();
    //读取所有表名的ComboBox
    var tables = new Ext.data.JsonStore({
        autoLoad: true,
        url: codeBuilder.readerUrl("ReaderTables"),
        fields: [{ name: "name" }, { name: "xtype"}]
    });
    //    var views=new Ext.data.JsonStore({
    //        autoLoad:true,
    //        url:"data/ReaderTables.ashx?xtype=v",
    //        fields:[{name:"name"},{name:"xtype"}]
    //    });
    var tableSelect = k.combox({
        store: tables, name: "tables", displayField: "name", valueField: "name"
    });
    //    var viewSelect=new Ext.form.ComboBox({
    //        store:views,name:"views",displayField:"name",valueField:"name"
    //    });
    var ync = { editable: false, store: k.ynStore() }
    var aligns = new Ext.data.SimpleStore({
        fields: ["align"], data: [["center"], ["left"], ["right"], [""]]
    });
    var controls = new Ext.data.SimpleStore({
        fields: ["control"], data: [["textbox"], ["textarea"], ["combox"], ["int"], ["float"], ["date"], ["checkbox"], ["hidden"]]
    });
    //表格布置
    var sm = new Ext.grid.CheckboxSelectionModel();
    var cm = new Ext.grid.ColumnModel([
        sm,
        { dataIndex: "ID", header: "ID", hidden: true },
        { dataIndex: "Field", header: "列名" },
        { dataIndex: "DataType", header: "数据类型", width: 50 },
        { dataIndex: "Display", header: "列标题", editor: k.editor() },
        { dataIndex: "DataKey", header: "是否主键", width: 50, editor: k.editor("combox", ync), renderer: k.ynRender },
        { dataIndex: "Hide", header: "是否隐藏", width: 50, editor: k.editor("combox", ync), renderer: k.ynRender },
        { dataIndex: "Sort", header: "是否排序", width: 50, editor: k.editor("combox", ync), renderer: k.ynRender },
        { dataIndex: "Query", header: "是否查询", width: 50, editor: k.editor("combox", ync), renderer: k.ynRender },
        { dataIndex: "AllowBlank", header: "允许为空", width: 50, editor: k.editor("combox", ync), renderer: k.ynRender },
        { dataIndex: "Width", header: "列宽", width: 50, editor: k.editor("int", { maxValue: 1000 }) },
        { dataIndex: "Format", header: "格式化", editor: k.editor("combox", {
            editable: false, displayField: "text", valueField: "text", store: k.dictJsonStore(code.formats)
        })
        },
        { dataIndex: "EditType", header: "控件类型", editor: k.editor("combox", {
            valueField: "control", displayField: "control", editable: false, store: controls
        })
        },
        { dataIndex: "Align", header: "对齐", width: 50, editor: k.editor("combox", {
            displayField: "align", valueField: "align", editable: false, store: aligns
        })
        }
    ]);
    var ds = new Ext.data.JsonStore({
        //proxy:new Ext.data.HttpProxy({url:"data/ReaderColumns.ashx"}),
        url: codeBuilder.readerUrl("ReaderColumns"),
        pruneModifiedRecords: true,
        fields: [
            { name: "ID" }, { name: "Field" }, { name: "DataType" }, { name: "Display" }, { name: "DataKey" },
            { name: "Hide" }, { name: "Sort" }, { name: "Query" }, { name: "AllowBlank" }, { name: "Width" },
            { name: "Format" }, { name: "EditType" }, { name: "Align" }
        ],
        totalProperty: "totalProperty", root: "root"
    });
    // ds.load({params:{tableName:"test"}});
    tableSelect.on("select", function (combox, record, index) {
        var name = code.first(record.data.name, "upper");
        code.tableName = name;
        ds.load({ params: { tableName: name} });
        combox.setDisabled(true);
    });
    var checkTableName = function () {
        if (tableSelect.getValue() == "") { k.tt("请先选择表！"); return false; } return true;
    }
    var cols = k.editGrid({
        id: "columnsGrid",
        cm: cm, ds: ds, sm: sm,
        tbar: new Ext.Toolbar([
            "-", "表和视图：", tableSelect, "-",
        //"视图",viewSelect,"-",
            {text: "重新选表", handler: function () { tableSelect.setDisabled(false); } }, "-", {
                text: "保存修改", handler: function () {
                    var d = ds.modified.slice(0);
                    if (d.length > 0) {
                        var jsonData = [];
                        Ext.each(d, function (item) {
                            jsonData.push(item.data);
                        });
                        var data = "data=" + encodeURIComponent(Ext.encode(jsonData));
                        Ext.lib.Ajax.request("POST", "data/EditColumns.ashx", {
                            success: function (xhr) {
                                if (xhr.responseText == "true") {
                                    k.tt("列配置更新成功！"); ds.reload();
                                } else { k.alert("列配置更新失败！"); }
                            }, failure: function () { k.alert("列配置更新失败！"); }
                        }, data);
                    }
                }
            }, "-", {
                text: "删除", handler: function () {
                    k.multiDelete("columns", cols, "ID", "", function () { ds.reload(); });
                }
            }, "-", {
                text: "重新读取列", handler: function () {
                    var tab = tableSelect.getValue();
                    if (tab == "") {
                        k.alert("请选择表名！");
                    } else {
                        k.confirm("确定要重新读取列的信息吗？", function (d, text) {
                            if (d == "no") { return; }
                            var tableName = "tableName=" + tab;
                            Ext.lib.Ajax.request("POST", "data/AddColumns.ashx", {
                                success: function (xhr) {
                                    if (xhr.responseText == "true") {
                                        k.tt("列配置读取成功！"); ds.reload();
                                    } else { k.alert("列配置读取失败！"); }
                                },
                                failure: function () { k.alert("列配置读取失败！"); }
                            }, tableName);
                        });
                    }

                }
            }, "->",
            {
                text: "全局配置", handler: function () { Ext.getCmp("config-window").show(); }
            }, "-",
            {
                text: "配置连接", handler: function () {
                    joinControl.window.show();
                    if (join.loaded == false) {
                        joinControl.form.getForm().load({
                            url: join.url("GetConnection"),
                            waitTitle: "提示",
                            waitMsg: '正在载入数据...',
                            success: function () { join.loaded = true; },
                            failure: function () { k.alert("加载数据库配置文件错误！"); }
                        });
                    }
                }
            }
        ])
    });
    //标签页
    var codeBox = new Ext.form.TextArea({
        anchor: "100% -26", hideLable: true, id: "code-box"
    })
    var codeToolbar = new Ext.Toolbar([{ text: "复制代码", handler: function () {
        if (Ext.isIE || Ext.isGecko) {
            copyToClipboard(codeBox.getValue());
            k.tt("复制成功！");
        } else { k.tt("该浏览器不支持此操作，请手动复制！"); }
    }
    }]);
    var tab = new Ext.TabPanel({
        region: "center", id: "code-tab",
        activeTab: 0,
        items: [{
            title: "数据表配置",
            layout: "fit",
            items: cols
        }, {
            title: "生成的代码",
            layout: "anchor",
            baseCls: "x-plain",
            bodyStyle: "padding:0px;",
            items: [codeToolbar, codeBox]
        }]
    });
    var setCodeValue = function (txt) {
        codeBox.setValue(txt); tab.setActiveTab(1);
    }
    //代码类型树
    var outPutExtGrid = function (type) {
        if (checkTableName()) {
            var grid = code.ext.getGrid(type);
            code.outPut(grid.content, grid.fileName, "js");
        }
    }
    var codeMenu = new Ext.menu.Menu({
        items: [
            { text: "导出实体类", handler: function () {
                if (checkTableName()) {
                    var entity = code.entity.getCommonEntity();
                    code.outPut(entity.content, entity.fileName, "cs");
                }
            }
            },
            { text: "导出Ext-Grid脚本", handler: function () { outPutExtGrid("grid"); } },
            { text: "导出Ext-EditGrid脚本", handler: function () { outPutExtGrid("editGrid"); } }
        ]
    });
    var codeTree = new Ext.tree.TreePanel({
        border: false,
        root: code.tree.data
    });
    codeTree.on("dblclick", function (node, e) {
        if (node.leaf == true) {
            if (checkTableName()) {
                var type = node.text, txt;
                if (node.id == "entity-e") {//普通实体类
                    txt = code.entity.getCommonEntity().content;
                }
                if (node.id == "aspnet-gv") {//asp.net表格视图
                    txt = code.aspnet.getGridView();
                }
                if (node.id == "aspnet-form") {
                    Ext.getCmp("form-options").show(); return;
                }
                if (node.id == "aspnet-mvc-grid") {
                    txt = code.aspnet.getMvcGrid();
                }
                if (node.id == "aspnet-mvc-controller") {
                    txt = code.controller.getMvcWithLinq().content;
                }
                if (node.id == "winform-dgvc") {//winform表格列
                    txt = code.winform.getDataGridViewColumns();
                }
                if (node.id == "ext-g") {//ext表格
                    txt = code.ext.getGrid("grid").content;
                }
                if (node.id == "ext-eg") {//ext编辑表格
                    txt = code.ext.getGrid("editGrid").content;
                }
                if (node.id == "js-gtg") {//gt-grid
                    txt = code.js.getGTGrid();
                }
                if (node.id == "js-fg") {//flexgrid
                    txt = code.js.getFlexGrid();
                }
                setCodeValue(txt);
            }
        }
    });
    codeTree.on("contextmenu", function (node, e) {
        codeMenu.showAt(e.getXY());
        e.preventDefault();
    });
    //框架布局
    var frame = new Ext.Viewport({
        layout: "border",
        items: [{
            region: "west", title: "代码类型(右键导出文件)", split: true, collapsible: true, width: 200, minSize: 175, maxSize: 300, margins: "0 0 0 0",
            defaults: { border: false, layout: "fit" }, items: [codeTree]
        }, tab
    ]
    });
});