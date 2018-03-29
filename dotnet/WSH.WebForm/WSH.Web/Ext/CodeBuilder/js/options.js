//代码生成的一些选项配置
code.options = {
    config: function () {
        var list = ["projectName", "outputPath"];
        var form = k.form({
            id: "config-form", items: [
                { fieldLabel: "项目名称", id: "projectName" },
                {fieldLabel:"导出地址",id:"outputPath",xtype:"textarea"}
            ]
        });
        var win = k.window({
            title: "全局配置", id: "config-window", items: [form], width: 400,
            buttons: [
                { text: "保存", handler: function () {
                    var val = Ext.get("projectName").dom.value;
                }
                }
            ]
        });
        //读取配置
        Ext.Ajax.request({
            url: "data/Config.ashx?action=GetConfig",
            callback: function (opts, success, xhr) {
                //alert(xhr.responseText);
                //var data = eval("("+xhr.responseText+")");
                var data = Ext.decode(xhr.responseText);
                for (var i = 0; i < list.length; i++) {
                    Ext.getCmp(list[i]).setValue(data.msg[list[i]]);
                }
            }
        });
    },
    form: function () {
        //生成form表单时的选项
        var lineStore = new Ext.data.SimpleStore({
            fields: ["text"], data: [["1"], ["2"]]
        });
        var pageStore = new Ext.data.SimpleStore({
            fields: ["text"], data: [["mvc"], ["webform"], ["static"]]
        });
        var controlStore = new Ext.data.SimpleStore({
            fields: ["text"], data: [["helper"], ["server"], ["html"]]
        });
        var formLine = k.combox({ id: "formLine", editable: false, value: "1", displayField: "text", valueField: "text", store: lineStore, fieldLabel: "每行列数" });
        var pageMode = k.combox({ id: "pageMode", editable: false, value: "mvc", displayField: "text", valueField: "text", store: pageStore, fieldLabel: "开发模式" });
        var controlType = k.combox({ id: "controlType", editable: false, value: "helper", displayField: "text", valueField: "text", store: controlStore, fieldLabel: "控件类型" });
        pageMode.on("select", function (combox, record, index) {
            controlType.setDisabled(false);
            switch (record.data.text) {
                case "static":
                    {
                        controlType.setValue("html");
                        controlType.setDisabled(true);
                    }; break;
                case "webform":
                    {
                        controlType.setValue("server");
                    }; break;
                case "mvc":
                    {
                        controlType.setValue("helper");
                    }; break;
            }
        });
        var form = k.form({
            items: [formLine, pageMode, controlType]
        });
        var win = k.window({
            title: "生成form表单选项", width: 200, height: 170, maximizable: false,
            id: "form-options", resizable: false, items: [form], buttons: [
                { text: "生成", handler: function () {
                    var txt = code.aspnet.getForm();
                    win.hide();
                    Ext.getCmp("code-box").setValue(txt);
                    Ext.getCmp("code-tab").setActiveTab(1);
                }
                }
            ]
        });
    }
}