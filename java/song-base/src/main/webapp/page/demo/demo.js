/**
 * Created by song on 2017/8/30.
 */
window.demoView = new cmp.view({
    builder:function () {
        cmp.builder.queryPanel("queryDemo",{
            items:[
                {field:"code",label:"流程编码",control:"textbox"},
                {field:"name",label:"流程名称",control:"textbox"},
                {field:"project",label:"项目名称",control:"textbox"},
                {field:"comment",label:"说明",control:"textbox"}
            ]
        }).gridPanel("gridDemo").dialogForm("dialogDemo","formDemo",{
            column:1,
            items:[
                {field:"code",label:"流程编码",control:"textbox",value:""},
                {field:"name",label:"流程名称",control:"textbox",value:"",dataOptions:{required:true}},
                {field:"project",label:"项目名称",control:"textbox",value:"",colspan:2},
                {field:"comment",label:"说明",control:"textbox",value:""},
                {field:"comment1",label:"说明",control:"textbox",value:""},
                {field:"comment2",label:"说明",control:"textbox",value:""},
                {field:"comment3",label:"说明",control:"textbox",value:""},
                {field:"comment4",label:"说明",control:"textbox",value:""}
            ],
            hidden:[
                {field:"id"}
            ]
        });
        return this;
    },
    ready: function () {
        var that=this;
        this.query=new cmp.query("#queryDemo",{
            onQuery:function () {
                that.grid.load();
            }
        });
        cmp.layout('body');
        this.dialog=new cmp.dialog("#dialogDemo",{
            width:"600",
            onClose:function () {
                that.form && that.form.reset();
            }
        });
        this.grid = new cmp.grid("#gridDemo", {
            url: that.routeUrl("loadGrid"),
            datakey:"id",
            onBeforeLoad:function (params) {
                $.extend(params,that.query.getValues());
            },
            toolbar:[
                {action:"add",onClick:function () {
                    that.dialog.open("新增流程");
                }},"-",
                {action:"remove",onClick:function () {
                    that.grid.removeChecked(that.routeUrl("removeRows"));
                }}
            ],
            operateColumn: {
                menu:[
                    {action:"edit",onClick:function (id) {
                        that.dialog.open("修改流程");
                        that.form.load(that.idRouteUrl("loadForm",id));
                    }},
                    {action:"remove",onClick:function (id) {
                        that.grid.removeRow(that.idRouteUrl("removeRows",id));
                    }}
                ]
            },
            columns: [[
                {field: "code", title: "流程编码", width: 100},
                {field: "name", title: "流程名称", width: 100},
                {field: "project", title: "项目名称", width: 100}
            ]]
        });
        this.form=new cmp.form("#formDemo",{
            url:that.routeUrl("submitForm"),
            button:[
                {action:"save",onClick:function () {
                    that.form.submit();
                }},
                {action:"cancel",onClick:function () {
                    that.dialog.close();
                }}
            ],
            onAfterSubmit:function (isSuccess) {
                if(isSuccess){
                    that.dialog.close();
                    that.grid.reload();
                }
            }
        });
    }
});