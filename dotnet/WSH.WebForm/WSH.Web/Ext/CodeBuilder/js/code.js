String.prototype.replaceAll = function (s1, s2) {
    return this.replace(new RegExp(s1, "gm"), s2);
}
var code = {
    nameSpace: "",
    tableName: "",
    br: "\n",
    start: "{\n",
    end: "}\n",
    tab0: "",
    tab1: "    ",
    tab2: "        ",
    tab3: "            ",
    tab4: "                ",
    tab5: "                    ",
    //path: "C:\\Documents and Settings\\Administrator\\桌面\\生成代码\\",
    pageTitle: {
        mvc: '<%@ Page Title="" Language="C#" MasterPageFile="~/Common/{0}Master.Master" Inherits="System.Web.Mvc.ViewPage<{1}>" %>',
        webform: '<%@ Page Title="{0}" Language="C#" MasterPageFile="~/Master/{1}Master.Master" AutoEventWireup="true" CodeBehind="{2}.aspx.cs" Inherits="{3}" %>',
        static: '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">'
    },
    titleContent: '<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">{0}</asp:Content>',
    scriptContentBegin: '<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">',
    mainContentBegin: '<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">',
    contentEnd: '</asp:Content>',
    htmlBegin: '<html xmlns="http://www.w3.org/1999/xhtml" >',
    htmlEnd: '</html>',
    scriptBegin: '<script type="text/javascript">',
    scriptEnd: '</script>',
    styleBegin: '<style type="text/css">',
    styleEnd: '</style>',
    idName: function (id) { return 'id="' + id + '" name="' + id + '"'; },
    id: function (id) { return 'ID="' + id + '"'; },
    required: function (required) { return required == "false" ? ' required="true"' : ""; },
    getModule: function () {
        var ln = code.getLowerTableName();
        var un = code.getUpperTableName();
        var b = new code.builder();
        b.addFmt(1, "var {0}={", ln);
        b.add(2, "url:function(action){");
        b.addFmt(3, 'return "{0}Manager.ashx?action="+action;', un);
        b.add(2, "}");
        b.add(1, "}");
        return { text: b.toString(), lower: ln, upper: un };
    },
    getLowerTableName: function () {
        return code.first(code.tableName, "lower");
    },
    getUpperTableName: function () {
        return code.first(code.tableName);
    },
    getProjectName: function () {
        return Ext.getCmp("projectName").getValue() || "";
    }
}
code.builder=function(){
    this.arr=new Array();
}
code.builder.prototype={
    add:function(tab,txt){this.arr.push(code["tab"+tab]+txt+code.br);return this;},
    addFmt:function(){
        var args=Array.prototype.slice.call(arguments).slice(2);
         for(var i=0;i<args.length;i++){arguments[1]= arguments[1].replace("{" + (i) + "}", args[i]);}
        this.add(arguments[0],arguments[1]);return this;
    },
    addNon:function(){
        for(var i=0;i<arguments.length;i++){this.arr.push(arguments[i]);}return this;
    },
    toString:function(){return this.arr.join("");}
}
code.formats=[
    {text:"",value:""},{text:"yyyy",value:"Y"},{text:"HH:mm:ss",value:"H:i:s"},
    {text:"yyyy-MM-dd",value:"Y-m-d"},{text:"yyyy-MM-dd HH:mm:ss",value:"Y-m-d H:i:s"}
]
code.getExtFmt=function(xtype,format){
    var fmt=xtype=="date" ? "Y-m-d" : "";
    if(format!=""){
        for(var j=0;j<code.formats.length;j++){
            var f=code.formats[j];
            if(format==f.text){
                fmt=f.value;
            }
        }
    }
    return fmt;
}
code.first=function(str,mode){
    var f=str.substring(0,1);var e=str.substring(1,str.length);
    if(mode=="lower"){f=f.toLowerCase();}else{f=f.toUpperCase();}
    return f+e;
}
code.outPut = function (content, fileName, fileType) {
    var path = Ext.getCmp("outputPath").getValue();
    Ext.Ajax.request({
        url: "data/OutPutCode.ashx",
        params: { content: encodeURIComponent(content), fileType: fileType, fileName: fileName, path: escape(path) },
        method: "POST",
        callback: function (opts, success, xhr) {
            k.alert(xhr.responseText);
        }
    });
}
code.getStore = function () {
    var grid = Ext.getCmp("columnsGrid");
    var count = grid.store.getCount();
    return grid.getStore().getRange(0, count);
}
code.eachStore=function(fn){
    var store=code.getStore();
    for(var i=0;i<store.length;i++){
        var record={};
        var last=i==(store.length-1) ? "" : ",";
        record["field"]=store[i].get("Field");
        record["display"]=store[i].get("Display");
        record["dataKey"]=store[i].get("DataKey").toLowerCase();
        record["hide"]=store[i].get("Hide").toLowerCase();
        record["query"]=store[i].get("Query").toLowerCase();
        record["sort"]=store[i].get("Sort").toLowerCase();
        record["width"]=store[i].get("Width");
        record["dataType"]=store[i].get("DataType");
        record["editType"]=store[i].get("EditType");
        record["align"]=store[i].get("Align");
        record["format"]=store[i].get("Format");
        record["allowBlank"]=store[i].get("AllowBlank");
        fn(record,i,last);
    }
};
code.loadXml=function (url) {
    var xmlDoc;
    try { xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); } catch (e) { xmlDoc = document.implementation.createDocument("", "", null); }
    xmlDoc.async = false; xmlDoc.load(url); return xmlDoc;
}
code.js={
    getGTGrid:function(){
         var b=new code.builder(),pk="",ds=new code.builder(),col=new code.builder(),module=code.getModule();
         b.add(0,code.scriptBegin);
         b.addNon(module.text);  
         code.eachStore(function(r,i,last){
            if(pk=="" && r.dataKey=="true"){pk=r.field;}
            ds.addFmt(3,"{name:'{0}',type:'string'}"+last,r.field);
            col.addFmt(2,"{id:'{0}',header:'{1}',editor:{type:'text',validRule:'R,integer'}}"+last,r.field,r.display);
         });
         b.add(1,'var dsConfig={').add(2,"fields : [").addNon(ds.toString()).add(2,"]").add(1,"};");
         b.add(1,"var colsConfig = [").addNon(col.toString()).add(1,"];");
         b.add(1,"var gridConfig={").addFmt(2,'id:"grid{0}",',module.upper);
         b.add(2,'dataset:dsConfig,').add(2,'columns:colsConfig,').addFmt(2,"container:'grid{0}Container',",module.upper);
         b.addFmt(2,'loadURL:{0}.url("GetGrid{1}Data"),',module.lower,module.upper);
         b.add(2,"remotePaging:false,");
         b.addFmt(2,'saveURL:{0}.url("SaveGrid{1}Data"),',module.lower,module.upper);
         b.add(2,"toolbarContent:' reload | add | del | save | state'");
         b.add(1,"};");
         b.addFmt(1,"var grid{0}=new GT.Grid(gridConfig);",module.upper);
         b.add(1,"GT.Utils.onLoad( function(){").addFmt(2,"grid{0}.render();",module.upper).add(1,"});");
         b.add(0,code.scriptEnd);
         b.addNon(code.br,code.br);
         b.addFmt(0,'<div id="grid{0}Container" style="width:500px;height:600px">',module.upper);
         return b.toString();
    },
    getFlexGrid:function(){
        var b=new code.builder(),pk="",module=code.getModule();
        b.add(0,code.scriptBegin);
        b.addNon(module.text);
        b.add(1,"$(function(){");
        b.add(2,'var cm=[');
        code.eachStore(function(r,i,last){
            if(pk=="" && r.dataKey=="true"){pk=r.field;}
            var w=r.width=="0" ? "100" : r.width;
            var sort=r.sort=="true" ? "" : ",sortable:false";
            var hide=r.hide=="true" ? ",hide:true" : "";
            var pro=r.format=="" ? "" : ",process:function(value,id){"+code.br+code.tab4+"var fmt='"+r.format+"';return value;"+code.br+code.tab3+"}";
            b.addFmt(3,'{display:"{0}",name:"{1}",width:{2},align:"{3}"{4}{5}{6}}'+last,r.display,r.field,w,r.align,sort,hide,pro);
        });
        b.add(2,']');
        b.add(2,'$("#flexGrid").flexigrid({');
        b.addFmt(3,'sortname:"{0}",sortorder:"asc",',pk);
        b.add(3,'colModel:cm,');
        b.addFmt(3,'url:{0}.url("GetGrid{1}Data"),',module.lower,module.upper);
        b.add(3,'height:$(window).height()-58,');
        b.add(3,'width:$(window).width()-2,');
        b.add(3,'rowClick:function(id,row){');
        b.add(3,"},");
        b.add(3,'rowDblClick:function(id,row){');
        b.add(3,"}");
        b.add(2,"});");
        b.add(1,'});');
        b.add(0,code.scriptEnd);
        return b.toString();
    }
}