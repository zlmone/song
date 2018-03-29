(function(j){
    //-----------------------toolbar-----------------------
    j.toolbar=j.getClass();
    j.toolbar.prototype={
        init:function(opts){
            j.extend(this,opts,{
                id:j.guid(),
                align:"left",
                renderTo:document.body
            });
            this.createToolbar();
        },
        createToolbar:function(){
            //return "<div class='toolbar-{0}'><table><tr id='toolbar-{1}'></tr></table></div>".format(this.opts.skin,this.opts.id);
            var el=j("<div>").attr({cls:"toolbar-ext"});
            el.html("<table cellpadding='0' cellspacing='0' style='float:{0}'><tr id='toolbar-{1}'></tr></table>".format(this.align,this.id));
            j(this.renderTo).append(el);
            this.content=j("toolbar-"+this.id);
        },
        add:function(){
            for(var i=0;i<arguments.length;i++){
                var item=arguments[i];
                if(typeof(item)=="string"){
                    var td=j("<td>");
                    if(item=="-"){
                        td.setClass("toolbar-split");
                        td.html("<div></div>");
                    }else{
                        td.html(item);
                    }  
                    this.content.append(td);
                }else{
                    this.addBtn(item);
                }
            }
            return this;
        },
        addBtn:function(opts){
            //var opts={text:"添加",icon:"add",id:"toolbar-btn-add",handler:function(){},menu:[{}]}
            var td=j("<td>");
            if(j.isEl(opts)){
                td.append(opts);
            }else{
                var cls="toolbar-btn";
                if(opts.selected!=null){cls+=" toolbar-btn-selected";}
                if(opts.cls){cls+=" "+opts.cls;}
                var a=j("<a>").attr({cls:cls,id:j.setDefault(opts.id,"j-toolbar-btn-"+j.guid()),href:j.setDefault(opts.href,j.nullUrl)});
                if(opts.disabled){a.disabled=opts.disabled;}
                if(opts.style){a.cssText(opts.style);}
                if(opts.handler && typeof(opts.handler)=="function"){a.bind("click",opts.handler);}
                var b=new j.builder();
                b.add('<span class="toolbar-btnright">');
                    b.add('<span class="toolbar-btncenter">');
                    var icon=opts.icon;
                    var isText=(opts.text!=null && opts.text!="");
                        if(icon!=null){
                            b.addFmt('<span class="toolbar-btnicon icon-{0}{1}">',j.setDefault(icon,"folder"),isText ? "" : " toobar-notext");
                        }
                            b.addFmt('<span class="toolbar-btntext{0}">',(opts.menu==null ? "" : " toolbar-btnsplit"));
                            if(isText){b.add(opts.text);}
                            b.add('</span>');
                        if(icon!=null){b.add('</span>');}
                    b.add('</span>');
                b.add('</span>');
                var ahtml=b.toString();
                a.html(ahtml);
                td.append(a);a=null;
            }
            this.content.append(td);
        },
        getItems:function(){
            return this.content.tag("td");
        },
        remove:function(index_id){
            var items=this.getItems(),item;
            if(items.length<=0){return;}
            if(typeof(index_id)=="number"){
                item=items[i];
            }else{
                for(var i=0;i<items.length;i++){
                    if(items[i].id==index_id){item=items[i];break;}
                }
            }
            this.removeItem(item);
        },
        removeItem:function(item){
            var btns=item.childNodes;
            for(var j=0;j<btns.length;j++){
                j(btns[j]).unbind("click").remove();j--;
            }
            j(item).remove();
        },
        removeAll:function(){
            var items=this.getItems();
            for(var i=0;i<items.length;i++){
                this.removeItem(items[i]);
                i--;
            }
        }
    }
    //-----------------------paging-----------------------
    j.paging=j.getClass();
    j.paging.prototype={
        init:function(opts){
            this.setOptions(opts);
        },
        setOptions:function(opts){
            j.extend(this,opts,{
                id:j.guid(),
                url:location.href,
                params:{},
                totalProperty:"totalProperty",
                root:"root",
                pageList:["5","10","15","20","30","40","50"],
                splitCount:4,
                pageSize:20,
                pageIndex:1,
                dataKey:"id",
                sortName:"id",
                sortMode:"asc"
            });
        },
        getToolbarConfig:function(){
            var tools={};
            if(this.renderTo!=null){
                tools["renderTo"]=this.renderTo;
            }
            if(this.align!=null){
                tools["align"]=this.align;
            }
            return tools;
        },
        load:function(){
            var params=this.params;
            params["pageSize"]=this.pageSize;
            params["pageIndex"]=this.pageIndex;
            params["dataKey"]=this.dataKey;
            params["sortName"]=this.sortName;
            params["sortMode"]=this.sortMode;
            new j.ajax({
                dataType:"json",
                type:"post",
                data:params,
                url:this.url,
                success:j.bind(this,function(result){
                    if(result!=null){
                        var total=this.totalRecord=result[this.totalProperty];
                        var size=this.pageSize;
                        var index=this.pageIndex;
                        var pageCount=this.pageCount=total%2==0 ? (total/size) : (total/size+1);
                        result["pageCount"]=pageCount;
                        result["pageIndex"]=index;
                        if(this.setPagingInfo){
                            this.setPagingInfo({totalRecord:total,pageIndex:index,pageCount:pageCount});
                        }
                        if(this.success){this.success(result);}
                    }
                }),
                error:function(){
                    if(this.error){this.error();}
                }
            });
        }
    }
    //-----------------------pagingToolbar-----------------------
    j.pagingToolbar=j.getClass();
    j.extend(j.extend(j.pagingToolbar.prototype,j.paging.prototype),{
        init:function(opts){
            this.setOptions(opts);
            this.createToolbar();
        },
        createToolbar:function(){
            var tools=this.getToolbarConfig();
            var tb=new j.toolbar(tools);
            var pl=new j.builder();
            var pagelist=this.pageList;
            var pagesize=this.pageSize;
            if(Array.indexOf(pagelist,pagesize)==-1){
                pagelist.push(pagesize);
            }
            pl.add("<select>");
            for(var i=0;i<pagelist.length;i++){
                var num=pagelist[i];
                var currsize=num==pagesize ? " selected='selected'" : "";
                pl.addFmt("<option value='{0}'{1}>{2}</option>",num,currsize,num);
            }
            pl.add("</select>");
            tb.add(pl.toString());
            tb.add("-");
            tb.add({icon:"first",handler:function(){
            
            }});
            tb.add({icon:"prev",handler:function(){
            
            }});
            tb.add("-");
            tb.add("&nbsp;第");
            tb.add("<input type='text' class='text' style='width:40px' value='{0}'/>".format(0));
            tb.add("页/共{0}页&nbsp;".format(0));
            tb.add("-");
            tb.add({icon:"next",handler:function(){
            
            }});
            tb.add({icon:"last",handler:function(){
                
            }});
            tb.add("-");
            tb.add("&nbsp;共{0}条记录".format(0));
            return tb;
        }
    });
        //-----------------------autoPagingToolbar-------------------
    j.autoPagingToolbar=j.getClass();
    j.extend(j.extend(j.autoPagingToolbar.prototype,j.paging.prototype),{
        init:function(opts){
         
            this.setOptions(opts);
            this.createToolbar();
        },
        createToolbar:function(){
            var tools=this.getToolbarConfig();
            this.tb=new j.toolbar(tools);
        },
        setPagingInfo:function(info){
            //先移除所有分页按钮
            this.tb.removeAll();
            var splitCount=this.splitCount;
            var curr=info.pageIndex;
            var count=info.pageCount;
            //alert(curr+"---"+count);
            for(var i=1;i<=count;i++){
                if(i==2 && curr-splitCount > 1){
                    this.tb.add("<span>...<span>");
                    i=curr-splitCount;
                }else if(i==curr+splitCount && curr+splitCount < count){
                    this.tb.add("<span>...<span>");
                    i=count-1;
                }else{
                    if(curr==i){
                        this.tb.add({text:i,style:"color:red;font-weight:bold;",selected:true});
                    }else{
                        this.tb.add({text:i,handler:
                            (function(i,obj){
                                return function(){
                                    obj.pageIndex=i;
                                    obj.load();
                                    alert(obj.load);
                                }
                            })(i,this)
                        });
                    }
                }
            }
        }
    });
})(wsh)