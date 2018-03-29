/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Toolbar
content:            工具条
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song, j) {
    //***********************************toolbar***********************************
    song.toolbar = function (options) {
        song.toolbar.base.constructor.call(this,song.toolbar.defaults,options);
    };
    song.toolbar.defaults = {
        renderTo:'body',
        title:"标题",
        align:"right",
        border:"1px 1px 1px 1px",
        enabledClass:"song-toolbar-btn-enabled",
        activeClass:"song-toolbar-btn-active",
        hoverClass:"song-toolbar-btn-hover"
    };
    song.extend(song.control, song.toolbar, {
        getType: function () {
            return song.toolbar.base.getType() + ".toolbar";
        },
        render:function(){
            this.wrap=j("<div class='song-toolbar'>").css("border-width",this.border).appendTo(this.renderTo);
            if(this.title!=false){
                this.titleText=j("<span class='song-toolbar-title'></span>").appendTo(this.wrap).html(this.title);
            }
            this.table=j("<table class='song-toolbar-table'>").css("float",this.align).appendTo(this.wrap);
            this._items=j("<tr>").appendTo(this.table);
            var items=this.items;
            if(items){
                for (var i = 0; i < items.length; i++) {
                    this.add(items[i]);
                }
            }
        },
        setTitle:function(title){
            if(this.titleText){
                this.title=title || this.title;
                this.titleText.html(this.title);
            }
        },
        add:function(){
             for(var i=0;i<arguments.length;i++){
                var item=arguments[i];
                if(!item){continue;}
                if(typeof(item)=="string"){
                    var td=j("<td>");
                    if(item=="-"){
                        td.addClass("song-toolbar-split").html("<div></div>");
                    }else{
                        td.html(item);
                    }  
                    this._items.append(td);
                }else if(item!=null && song.isEl(item) || (item instanceof j)){
                    this._items.append(j("<td>").append(item));
                }else{
                    this.addButton(item);
                }
            }
            return this;
        },
        getEnabled:function(a_id){
            return this.getButton(a_id).hasClass(this.enabledClass);
        },
        setEnabled:function(a_id,enabled){
            var btn=this.getButton(a_id);
            enabled ? btn.addClass(this.enabledClass) : btn.removeClass(this.enabledClass);
        },
        toggleIconClass:function(btn,toggle,cls){
              var btn=this.getButton(btn);
              btn.find("span.song-toolbar-btnicon")[(toggle ? "add" : "remove")+"Class"](cls);
        },
        addButton:function(opts){
            var td=j("<td>").appendTo(this._items),me=this;
            opts.id=opts.id || song.id();
            var b=new song.builder();
            var a=j("<a>").addClass("song-toolbar-btn").attr({href:"javascript:void(0)",id:opts.id}).appendTo(td);
            b.add('<span class="song-toolbar-btnright">');
            b.add('<span class="song-toolbar-btncenter">');
            var icon=opts.iconClass;
            var isText=(opts.text!=null && opts.text!="");
            if(icon!=null){
                b.addFmt('<span class="song-toolbar-btnicon {0}{1}">',icon,(isText ? "" : " song-toobar-notext"));
            }
            b.addFmt('<span class="song-toolbar-btntext{0}">',(opts.menu==null ? "" : " song-toolbar-btnsplit"));
            if(isText){b.add(opts.text);}
            b.add('</span>');
            if(icon!=null){b.add('</span>');}
            b.add('</span>');
            b.add('</span>');
            var ahtml=b.toString();
            a.html(ahtml);

            this.setEnabled(a,opts.enabled);
            a.bind("mousedown",function(e){
                var obj=j(this);
                !me.getEnabled(obj) && obj.addClass(me.activeClass);
            }).bind("mouseup",function(){
                var obj=j(this);
                !me.getEnabled(obj) && obj.removeClass(me.activeClass);
            }).hover(function(){
                var obj=j(this);
                !me.getEnabled(obj) && obj.addClass(me.hoverClass);
            },function(){
                var obj=j(this);
                obj.hasClass(me.hoverClass) &&  obj.removeClass(me.hoverClass);
            });
            
            a.bind("click",function(e){
                var obj=j(this);
                if(me.getEnabled(obj)){return;};
                if(opts.menu!=null){
                    obj.addClass(me.activeClass);
                    song.hideCmp(song.menu);
                    if(!obj.attr("isSetPosition")){
                        opts.menu.onHide=function(){
                            obj.removeClass(me.activeClass);
                        }
                        opts.menu.showEl({align:"left",follow:obj});
                        obj.attr("isSetPosition","true");
                    }
                    opts.menu.show();
                    e.stopPropagation();
                }else{
                    opts.onClick &&  opts.onClick.call(me,opts);
                }
            });
            return a;
        },
        getButton:function(a_id){
            return  j(typeof(a_id)=="string" ? ("#"+a_id) : a_id);
        },
        removeButton:function(a_id){
            var a=this.getButton(a_id),p=a.parent();
            a.unbind().html("").remove();
            p.remove();
        },
        destroy:function(){
            this.wrap=this.table=this._items=this.title=null;this.renderTo=null;
        }
    });
    //***********************************pagingToolbar***********************************
    song.pagingToolbar=function(options){
        options=j.extend(song.pagingToolbar.defaults,options);
        song.pagingToolbar.base.constructor.call(this,options);
    };
    song.pagingToolbar.defaults={
        title:false,
        align:"left",
        simple:false,
        isRemote:true,
        url:location.href,
        pageSize:20,
        pageIndex:1,
        pageCount:1,
        totalRecord:0,
        pageList:["5","10","15","20","30","40","50"],
        params:{},
        totalProperty:"totalRecord",
        root:"rows",
        autoLoad:false,
        totalText:"&nbsp;共有{totalRecord}条数据",
        pageText:"页/共{0}页&nbsp;"
    };
    song.extend(song.toolbar,song.pagingToolbar,{
        theRequest:false,
        getType: function () {
            return song.pagingToolbar.base.getType() + ".pagingToolbar";
        },
        loaded:function(){
            var me=this;
            if(!this.simple){
                var list=this.pageList;
                var size=this.pageSize;
                Array.has(list,size) || list.push(size);
                this.listDom=j("<select>");
                for (var i = 0; i < list.length; i++) {
                    var num=list[i];
                    var opt=j("<option value='{0}'>{1}</option>".format(num,num)).appendTo(this.listDom);
                    if(num==size)opt.attr("selected",true);
                }
                this.listDom.bind("change",function(){
                    me.pageIndex=1;
                    me.pageSize=this.value;
                    
                    me.load();
                });
                this.add(this.listDom,"-");
            };
            this.firstBtn=this.addButton({iconClass:"icon-first",onClick:function(){
                me.moveFirst();
            }});
            this.prevBtn=this.addButton({iconClass:"icon-prev",onClick:function(){
                me.movePrev();
            }});
            this.add("-","&nbsp;第");
            this.numDom=j("<input type='text' class='textbox'>").width(40).val(this.pageIndex);
            this.numDom.bind("change",function(){
                me.checkPage(this);
            }).bind("keydown",function(e){
                me.gotoPage(e,this);
            });
            this.add(this.numDom);
            this.add("<span id='"+this.id+"pageCount'>"+this.pageText.format(this.pageCount)+"</span>","-");
            this.nextBtn=this.addButton({iconClass:"icon-next",onClick:function(){
                me.moveNext();
            }});
            this.lastBtn=this.addButton({iconClass:"icon-last",onClick:function(){
                me.moveLast();
            }});
            if(!this.simple){
                this.add("-");
                this.reloadBtn=this.addButton({iconClass:"icon-reload",onClick:function(){
                    me.load();
                }});
                this.add("-","<span id='"+this.id+"totalRecord'></span>");
            }
            this.setPageInfo();
            this.autoLoad && this.load();
        },
        checkPage:function(obj){
            var value=parseInt(obj.value.trim()),check=false;
             if (!isNaN(value) && value> 0) {
                if (value > this.pageCount) {
                     value=this.pageCount;
                };
                check=true;
            } else {
                value = this.pageIndex;
                check=false;
            }
            obj.value = value;
            return { check: check, value: value }
        },
        gotoPage:function(e,obj){
            var r=false;
            switch (e.which) {
                case song.kc.enter : {
                    r=this.checkPage(obj);
                };break;
                case song.kc.right:
                case song.kc.left:{
                    var v=parseInt(obj.value);
                    obj.value=e.which==song.kc.right ? v+1 : v-1;
                    r=this.checkPage(obj);
                };break;
            }
            if(r!==false && (r.check && r.value!=this.pageIndex)){
                this.pageIndex=r.value;
                this.load();
            }
        },
        moveFirst:function(){
            this.pageIndex=1;
            this.load();
        },
        movePrev:function(){
            this.pageIndex--;
            this.load();
        },
        moveNext:function(){
            this.pageIndex++;
            this.load();
        },
        moveLast:function(){
            this.pageIndex=this.pageCount;
            this.load();
        },
        load:function(){
            if(this.theRequest){return;}
            this.beforeLoad && this.beforeLoad.call(this);
            var me=this;
            if(this.isRemote){
                this.theRequest=true;
                this.setLoading(true);
                j.extend(this.params,{
                    sortName:this.sortName || "",sortMode:this.sortMode || "",pageIndex:this.pageIndex,pageSize:this.pageSize,
                    WSHAJAXCHCHE:new Date().getTime()
                });
                j.ajax({
                    url:this.url,
                    type:"post",dataType:"json",data:this.params,
                    success:function(data){
                        me.setPageCount(data[me.totalProperty]);
                        me.setPageInfo();
                        me.afterLoad && me.afterLoad.call(me,true,data[me.root]);
                        me.setLoading(false);
                        me.theRequest=false;
                    },
                    error:function(xhr,err){
                        me.afterLoad && me.afterLoad.call(me,false,err);
                        me.setLoading(false);
                        me.theRequest=false;
                    }
                });
            }else{
                me.afterLoad && me.afterLoad.call(me,true);
            }
        },
        setPageCount:function(total){
            this.totalRecord=total;
            var size=this.pageSize;
            this.pageCount=this.totalRecord < size ? 1 : Math.ceil(this.totalRecord/size);
        },
        setPageInfo:function(){
            var index=this.pageIndex,count=this.pageCount,isFirst=index==1,isLast=index==count;
            this.toggleIconClass(this.firstBtn,isFirst,"icon-firstdisabled");
            this.setEnabled(this.firstBtn,isFirst);
            this.toggleIconClass(this.prevBtn,isFirst,"icon-prevdisabled");
            this.setEnabled(this.prevBtn,isFirst);
            this.toggleIconClass(this.nextBtn,isLast,"icon-nextdisabled");
            this.setEnabled(this.nextBtn,isLast);
            this.toggleIconClass(this.lastBtn,isLast,"icon-lastdisabled");
            this.setEnabled(this.lastBtn,isLast);
            this.numDom.val(this.pageIndex);
            j("#"+this.id+"pageCount").html(this.pageText.format(this.pageCount));
            this.simple || j("#"+this.id+"totalRecord").html(this.totalText.format({totalRecord:this.totalRecord}));
        },
        setLoading:function(isLoading){
            this.reloadBtn && this.toggleIconClass(this.reloadBtn,isLoading,"icon-loading");
        },
        destroy:function(){
            song.pagingToolbar.base.destroy.call(this);
            this.listDom=null;
            this.numDom=null;
            this.reloadBtn=null;
            this.firstBtn=null;
            this.prevBtn=null;
            this.nextBtn=null;
            this.lastBtn=null;
        }
    });
})(window.song, window.jQuery);