code.ext={
    getGrid:function(type){
        var store=code.getStore();
        var fileName=code.first(code.tableName,"lower")+"-ext";
        var arr=new Array(),fields=new Array(),querys=new Array(),forms=new Array();
        var idField="";
        arr.push("Ext.onReady(function(){"+code.br);
        //Global
        arr.push(code.tab1+"Ext.QuickTips.init();"+code.br);
        arr.push(code.tab1+String.format("var winTitle='{0}';",code.tableName)+code.br);
        arr.push(code.tab1+"var pageSize=20;"+code.br);
        //Columns
        arr.push(code.tab1+"var sm=new Ext.grid.CheckboxSelectionModel();"+code.br);
        arr.push(code.tab1+"var cm=new Ext.grid.ColumnModel(["+code.br);
        arr.push(code.tab2+"sm,"+code.br);
        for(var i=0;i<store.length;i++){
            var last=i==(store.length-1) ? "" : ",";
            var record=store[i];
            var field=record.get("Field");
            var display=record.get("Display");
            var hide=record.get("Hide").toLowerCase();
            var width=record.get("Width");
            var w=width=="0" ? "100" : width;
            var edit=record.get("EditType");
            var format=record.get("Format");
            var align=record.get("Align");
            var fmt="";
           // var xtype=edit.replace("combox","combobox").replace("date","datefield");
            var query=record.get("Query").toLowerCase();
            var sort=record.get("Sort").toLowerCase();
            if(idField=="" && record.get("DataKey").toLowerCase()=="true"){
                idField=field;
            }
            //表单集合
            if(hide=="false"){
                forms.push(code.tab3+String.format("k.controlType('{0}',{fieldLabel:'{1}',name:'{2}'})",edit,display,field)+last+code.br);
            }
            //列集合
            fields.push(code.tab3+String.format("{name:'{0}',mapping:'{1}'",field,field));
            if(edit=="date"){
                fmt=String.format("Ext.util.Format.dateRenderer('{0}')",code.getExtFmt("date",format));
                fields.push(String.format(",convert:{0}",fmt));
            }
            fields.push("}"+last+code.br);
            //查询集合
            if(query=="true"){
                querys.push(code.tab2+String.format("'{0}：',k.controlType('{1}'),",display,edit)+code.br);
            }
            //列配置
            arr.push(code.tab2+String.format("{dataIndex:'{0}',header:'{1}',hidden:{2},width:{3},",field,display,hide,w));
            arr.push(String.format("sortable:{0},align:'{1}'",sort,align));
            if(type=="editGrid"){
                arr.push(","+code.br);
                arr.push(code.tab3+String.format("editor:k.editor('{0}',{})",edit));
                //arr.push(code.tab2);
                if(edit=="date"){
                    arr.push(","+code.br);
                    arr.push(code.tab3+String.format("renderer:{0}",fmt));
                    //arr.push(code.br+code.tab2);
                }
                arr.push(code.br+code.tab2);
            }
            arr.push("}"+last+code.br);
        }
        arr.push(code.tab1+"]);"+code.br);
        //JsonFields
        arr.push(code.tab1+"var jsonFields=["+code.br);
        arr.push(fields.join(""));
        arr.push(code.tab1+"]"+code.br);
        //Store
        arr.push(code.tab1+"var store=new Ext.data.JsonStore({"+code.br);
        arr.push(code.tab2+"url:'locaction.href',"+code.br);
        if(type=="editGrid"){
            arr.push(code.tab2+"pruneModifiedRecords:true,"+code.br);
        }
        arr.push(code.tab2+"fields:jsonFields,"+code.br);
        arr.push(code.tab2+"//remoteSort:true,"+code.br);
        arr.push(code.tab2+"totalProperty:'totalProperty',"+code.br);
        arr.push(code.tab2+"root:'root'"+code.br);
        arr.push(code.tab1+"});"+code.br);
        //Form
        arr.push(code.tab1+"var form=k.form({"+code.br);
        arr.push(code.tab2+"reader:new Ext.data.JsonReader({root:'root'},jsonFields),"+code.br);
        arr.push(code.tab2+"items:["+code.br);
        arr.push(forms.join(""));
        arr.push(code.tab2+"]"+code.br);
        arr.push(code.tab1+"});"+code.br);
        //Window
        arr.push(code.tab1+"var win=k.window({"+code.br);
        arr.push(code.tab2+"title:winTitle+'-编辑',"+code.br);
        arr.push(code.tab2+"animateTarget:Ext.getBody(),"+code.br);
        arr.push(code.tab2+"items:form,"+code.br);
        arr.push(code.tab2+"buttons:["+code.br);
        arr.push(code.tab3+"{text:'保存',handler:function(){}},"+code.br);
        arr.push(code.tab3+"{text:'取消',handler:function(){win.hide();}}"+code.br);
        arr.push(code.tab2+"]"+code.br);
        arr.push(code.tab1+"});"+code.br);
        //Toolbar
        arr.push(code.tab1+"var tbar=new Ext.Toolbar(["+code.br);
        arr.push(code.tab2+"//'->',"+code.br);
        arr.push(querys.join(""));
        arr.push(code.tab2+"'-',{text:'查询',handler:function(){store.reload();}},'-',"+code.br);
        arr.push(code.tab2+"{text:'添加',handler:function(){"+code.br);
        arr.push(code.tab3+"win.setTitle(winTitle+'-添加');"+code.br);
        arr.push(code.tab3+"win.show();"+code.br);
        arr.push(code.tab2+"}},'-',"+code.br);
        arr.push(code.tab2+"{text:'修改',handler:function(){}},'-',"+code.br);
        arr.push(code.tab2+"{text:'删除',handler:function(){"+code.br);
        arr.push(code.tab3+"var delUrl='';"+code.br);
        arr.push(code.tab3+String.format("k.multiDelete('{0}',grid,'{1}',delUrl,function(){",code.tableName,idField)+code.br);
        arr.push(code.tab4+"store.reload();"+code.br);
        arr.push(code.tab3+"});"+code.br);
        arr.push(code.tab2+"}},'-'"+code.br);
        arr.push(code.tab1+"]);"+code.br);
        //Paging
        arr.push(code.tab1+"var bbar=k.paging({"+code.br);
        arr.push(code.tab2+"pageSize:pageSize,"+code.br);
        arr.push(code.tab2+"store:store"+code.br);
        arr.push(code.tab1+"});"+code.br);
        //Grid
        arr.push(code.tab1+String.format("var grid=k.{0}({",type)+code.br);
        arr.push(code.tab2+"height:Ext.getBody().getViewSize().height,"+code.br);
        arr.push(code.tab2+"renderTo:Ext.getBody(),"+code.br);
        arr.push(code.tab2+"cm:cm,store:store,sm:sm,"+code.br);
        arr.push(code.tab2+"tbar:tbar,"+code.br);
        arr.push(code.tab2+"bbar:bbar"+code.br);
        arr.push(code.tab1+"});"+code.br);
        //Load
        arr.push(code.tab1+String.format("//store.setDefaultSort('{0}','asc');",idField)+code.br);
        arr.push(code.tab1+"store.load({params:{start:0,limit:pageSize}});"+code.br);
        arr.push("});");
        return {fileName:fileName,content:arr.join("")}
    }
}
