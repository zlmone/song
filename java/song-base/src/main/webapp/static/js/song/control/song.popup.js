/*
author:                 王松华
email:                  songhuaxiaobao@163.com
namespace:              Song.Popup
content:                Tip层，遮罩层
beforeLoad:             j,base
createDate:             2012-03-14
*/
; (function (song,j) { 
    /************************popup************************/
    song.popup=function(defaults,options){
        song.popup.base.constructor.call(this,defaults,options);
    };
    song.extend(song.control,song.popup,{
        getType:function(){
            return song.popup.base.getType()+".popup";
        },
        init:function(){
            this.wrap=j("<div>").addClass("song-popup").css({zIndex:song.zIndex()}).appendTo("body");
        },
        show:function(){if(!this.isShow){this.wrap.show();this.isShow=true;}return this;},
        hide:function(){if(this.isShow){this.wrap.hide();this.isShow=false;}return this;},
        destroy:function(){
            this.wrap.html("").remove();this.wrap=null;
        }
    });
    /************************mask************************/
    song.mask=function(options){
        options =options || {};
        var cmp=song.getCmp(options.id);
        if(cmp){
            return cmp;
        }
        song.mask.base.constructor.call(this,song.mask.defaults,options);
    };
    song.mask.defaults={
        opacity:0.3,
        background:"gray"
    };
    song.extend(song.popup,song.mask,{
        getType:function(){
            return song.mask.base.getType()+".mask";
        },
        render:function(){
            this.wrap.css({background:this.background,opacity:this.opacity});
            this.position();
            if(song.ie6){
                this.wrap.html('<iframe frameborder="0" src="about:blank" style="width:100%;height:100%;position:absolute;' +
			'top:0;left:0;z-index:-1;filter:alpha(opacity=0)"></iframe>');
            }
        },
        position:function(p){
            this.wrap.css(p || (this.el ? song.position.getOffsetSize(j(this.el)) : song.position.maxClient()));return this;
        }
    });
    /************************loading************************/
    song.loading=function(options){
        options =options || {};
        var cmp=song.getCmp(options.id);
        if(cmp){
            return cmp;
        }
        var maskoptions={el:options.el,background:options.background,opacity:options.opacity};
        this.mask=new song.mask(maskoptions);
        var cmp=song.loading.base.constructor.call(this,song.loading.defaults,options);
        if(cmp){return cmp;}
    };
    song.loading.defaults={
        msg:"正在努力加载...",top:"50%",left:"50%"
    }
    song.extend(song.popup,song.loading,{
        getType:function(){
            return song.loading.base.getType()+".loading";
        },
        render:function(){
            var temp=[
                '<div class="song-loading-inner">',this.msg,'</div>'
            ];  
            this.wrap.html(temp.join('')).addClass("song-loading");
            this.position();
        },
        position:function(){
            song.position.setRegion(this.wrap,{top:this.top,left:this.left,parent:this.el});
        },
        setMsg:function(msg){
            if(msg){
                this.msg=msg;
                this.wrap.find("div.song-loading-inner").html(this.msg);
                this.position();
            }
        },
        show:function(){
            this.mask.show();this.wrap.show();return this;
        },
        hide:function(){
            this.mask.hide();this.wrap.hide();return this;
        }
    });
    /************************tip************************/
    song.tip=function(options){
//        options=options || {};
//        j.extend(this.follow,song.tip.follow,options.follow);
//        j.extend(this.region,song.tip.region,options.region);
        options =options || {};
        var cmp=song.getCmp(options.id);
        if(cmp){
            return cmp;
        }
        song.tip.base.constructor.call(this,song.tip.defaults,options);
    };
    song.tip.skin = {
        blue: { border: "#7fcdee", background: "#d9f1fb", color: "#1b475a" },
        green: { border: "#b6e184", background: "#f2fdf1", color: "#558221" },
        yellow: { border: "#e9d315", background: "#f9f2ba", color: "#5b5316" }
    };
    song.tip.defaults={
        content:"<div class='song-tip-loading'></div>",
        skin:"blue",
        padding:0,
        margin:10,
        target:false,
        closable:false,
        closeAction:"hide",
        icon:null,
        time:null,
        url:location.href,
        dataType:"text",
        dir:"right",
        fix:5,
        follow:null,
        align:"center",
        top:"50%",
        left:"50%",
        eventType:"hover",
        delay:400,
        tipHover:true
    };
    song.extend(song.popup,song.tip,{
        getType:function(){
            return song.tip.base.getType()+".tip";
        },
        render:function(){
            var wrap=this.wrap,me=this,skin=song.tip.skin[this.skin],dir=this.dir;
            wrap.addClass("radius box-shadow");
            wrap.css({padding:this.padding,backgroundColor:skin.background,border:"1px solid "+skin.border,color:skin.color});
            if(me.target){
                var temp=[
                    '<span style="border-',dir,':5px solid ',skin.border,'" class="target target-',dir,'">',
                        '<span style="border-',dir,':5px solid ',skin.background,'">',
                        '</span>',
                    '</span>'
                ];
                wrap.append(temp.join(''));
            };
            if(me.closable){
                this.closeDom=j('<a class="inline-block song-tip-close"></a>').attr({href:song.href}).appendTo(wrap);
                this.closeDom.bind("click",function(){
                    me.closeAction=="close" ? me.close() : me.hide();
                });
            }
            this.contentDom=j("<div>").css("margin",this.margin).appendTo(wrap);
            me.icon && me.contentDom.addClass("song-tip-icon song-tip-icon-"+me.icon);
            me.cls && me.contentDom.addClass(me.cls);
            me.style && me.contentDom.css(me.style);
            me.setContent().setPosition();
            me.time && me.setTimer(me.time);
            me.eventType && me.follow && me.setEventType();
        },
        load:function(url,dataType,fn){
            if(!this.theRequest){
                var me=this;
                url=url || me.url;
                dataType=dataType || me.dataType;
                j.ajax({type:"get",dataType:dataType,url:url,success:function(data){
                    me.theRequest=true;
                    if(dataType=="text"){
                        me.setContent(data);
                    }else{
                        fn && fn.call(me,data);
                    }
                    me.setPosition();
                },error:function(xhr,err){
                    me.theRequest=true;
                    me.setContent(err);
                }});
            }
        },
        setEventType:function(){
            var me=this,type=me.eventType,follow=j(me.follow);
            if(type=="hover"){
                follow.hover(function(){
                   me.delayOver();
                },function(){
                    me.delayOut();
                });
                if(me.tipHover){
                    me.wrap.hover(function(){
                       me.delayOver();
                    },function(){
                        me.delayOut();
                    });
                }
            }else if(type=="click"){
                follow.bind(type,function(){
                    me.show();
                });
            }
        },
        delayOver:function(){
            var me=this;
            me.clearOver().clearOut();
            if(!me.isShow){
                me.overTimer=setTimeout(function(){
                    me.show().clearOver();
                },me.delay);
            }
        },
        delayOut:function(fn){
            var me=this;
            me.clearOver().clearOut();
            if(me.isShow){
                me.outTimer=setTimeout(function(){
                    me.hide().clearOut();
                },me.delay);
            }
        },
        clearOver:function(){
            this.overTimer && clearTimeout(this.overTimer);return this;
        },
        clearOut:function(){
            this.outTimer && clearTimeout(this.outTimer);return this;
        },
        clearTimer:function(){
            this.timer && clearTimeout(this.timer);
            this.clearOver().clearOut();
        },
        setContent:function(value){
            value=value || this.content;
            if(typeof(value)=="string"){
                this.contentDom.html(value);
            }else{
                this.contentDom.append(value);    
            }
            return this;
        },
        setPosition:function(){
            if(this.follow){
                new song.follow(this.wrap,{follow:this.follow,dir:this.dir,align:this.align,fix:this.fix});
            }else{
                song.position.setRegion(this.wrap,{parent:this.parent,top:this.top,left:this.left});
            };
            return this;
        },
        setTimer:function(second){
            var me=this;
            me.timer && clearTimeout(me.timer);
            if(second) this.timer=setTimeout(function(){
                me.close();
            }, 1000 * second);   
        },
        close:function(){
            if(this.onClose)if(this.onClose.call(this)==false){return;};
            this.clearTimer();
            this.destroy();
            song.deleteCmp(this.id);
        },
        destroy:function(){
            this.contentDom.html("").remove();
            this.closeDom && this.closeDom.unbind().remove();
           // this.targetDom && this.targetDom.remove();
            this.wrap.html("").remove();this.wrap=null;
            this.contentDom=this.closeDom=null;
            //this.targetDom=null;
        }
    }); 
    /************************tip-extend************************/
    song.tip.msg=function(text,icon,options){
        options=options || {};
        if(!options["time"]){options["time"]=2};
        var i = "info", s = "blue";
        if (icon == "error") { i = icon; s = "yellow"; }
        if (icon == "ok") { i = icon; s = "green"; }
        options=j.extend(options,{icon:i,skin:s,content:text});
        return new song.tip(options).show();
    };
    song.tip.valid=function(item,type,valid){
        var tipid=item.attr("data-tipid");
        if(!tipid){
            tipid=song.id();
            item.attr("data-tipid",tipid);
            item.hover(function(){
                item.hasClass("input-error") && song.getCmp(tipid).show();
            },function(){
                song.getCmp(tipid).hide();
            });
            item.change(function(){
               valid && valid.call(this);
            });
        }
        var tip= new song.tip({
            id:tipid,
            content:song.validate.msg[type],
            follow:item,
            dir:"bottom",
            target:true, 
            skin:"yellow",
            padding:0,
            tipHover:false,
            delay:100,
            margin:3,
            eventType:null,
            cls:"song-tip-valid icon-error"
        });
        return tip;
    }
     
})(window.song,window.jQuery);
