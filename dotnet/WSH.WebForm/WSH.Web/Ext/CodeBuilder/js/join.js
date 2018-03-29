//配置连接
var join={
    url:function(action){
        return "data/Join.ashx?action="+action;
    },
    loaded:false,
    type:[["sqlserver"],["oracle"],["mysql"]],
    mode:[["windows"],["sqlserver"]]
}
join.createControl=function(){
    var jsonFields=[
        {name:"type",mapping:"type"},
        {name:"server",mapping:"server"},
        {name:"source",mapping:"source"},
        {name:"mode",mapping:"mode"},
        {name:"uid",mapping:"uid"},
        {name:"pwd",mapping:"pwd"}
    ]
    var form=k.form({
        labelWidth:70,
        items:[
            k.controlType("combox",{
                fieldLabel:"数据库类型",
                name:"type",
                store:k.dictArrayStore(join.type,["tv"]),
                displayField:"tv",
                valueField:"tv"
            }),
            {fieldLabel:"服务器",name:"server"},
            {fieldLabel:"数据库名称",name:"source"},
            k.controlType("combox",{
                fieldLabel:"验证模式",
                name:"mode",
                store:k.dictArrayStore(join.mode,["tv"]),
                displayField:"tv",
                valueField:"tv"
            }),
            {fieldLabel:"用户名",name:"uid",id:"uid"},
            {fieldLabel:"密码",name:"pwd",inputType:"password",id:"pwd"}
        ],
        reader:new Ext.data.JsonReader({root:'root'},jsonFields)
    })
    var win=k.window({
        title:"连接配置",
        width:320,
        height:245,
        maximizable: false,
        resizable:false,
        items:form,
        buttons:[
            {text:"应用",handler:function(){
                form.getForm().submit({
                    url:join.url("SetConnection"),
                    success:function(){
                        k.alert("应用成功！",function(){
                            win.close();
                            location=location;
                        });
                    },
                    failure:function(){
                        k.alert("设置连接信息失败！");
                    }
                });
            }},
            {text:"取消",handler:function(){
                win.hide();
            }}
        ]
    });
    return {window:win,form:form};
}