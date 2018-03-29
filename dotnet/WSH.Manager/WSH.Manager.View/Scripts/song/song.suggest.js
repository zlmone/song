/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Suggest
content:            搜索建议（自动补全）
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song,j) { 
    song.suggest=function(el,options){
        this.el=j(el);
        song.suggest.base.constructor.call(this,song.suggest.defaults,options);
    };
    song.suggest.defaults={
        selectedIndex:-1,
        max:10,
        delay:500,
        url:location.href,
        name:"suggest",
        width:"equal",
        textField:"text"
    };
    song.extend(song.control,song.suggest,{
        //showLoading:true,
        getType:function(){
            return song.suggest.base.getType()+".suggest";
        },
        render:function(){
            var offset=song.position.getOffsetSize(this.el);
            var css={zIndex:song.zIndex(),top:offset.height+offset.top,left:offset.left};
            css["width"]=this.width=="equal" ? offset.width-2 : this.width;
            this.dropDown=j("<div class='song-suggest-dropdown'>").css(css).appendTo('body');
            this.setEvent();
        },
        showLoading:function(){
            j("<div class='song-suggest-loading'>").appendTo(this.dropDown);
        },
        setEvent:function(){
            var me=this;
            this.onEnter && this.el.bind("keydown",function(e){
                if(e.which==song.kc.enter)this.onEnter.call(this);    
            });
            this.el.bind("keyup",function(){
                if(me.theRequest){return;};
                var val=this.value.trim();
                if(val==""){
                    me.clearTimer();me.clearItem();return;
                }
                me.setTimer(val);
            });
        },
        request:function(val){
            this.theRequest=true;
            var name=this.name,me=this;
            this.show();
            this.showLoading();
           // setTimeout(function(){
            j.ajax({
                type:"get",data:{name:val},url:this.url,dataType:"json",
                success:function(data){
                    me.theRequest=false;
                    me.createItem(data,val);
                },
                error:function(xhr,err){
                    me.theRequest=false;
                    this.clearItem();
                    alert(err);
                }
            });
          //  },1000);
        },
        createItem:function(data,val){
            this.clearItem();
            var me=this;
            if(typeof data=="object" && data.length>0){
                for (var i = 0; i < data.length; i++) {
                    var d=data[i];
                    var a=j("<a>").attr({href:song.href,itemindex:i}).html(d[this.textField].replace(val,"<strong>"+val+"</strong>"));
                    a.click(function(e){
                        me.selectedIndex=this.getAttribute("itemindex");
                        me.selectItem();
                        me.hide();
                    });
                    this.dropDown.append(a);
                    a=null;
                }
            }
            this.show();
        },
        selectItem:function(){
            var index=this.selectedIndex;
            var item=this.dropDown.children("a:eq("+index+")");
            item.addClass("song-suggest-active");
            var value=item.html().delTag();
            this.el.val(value);
        },
        setTimer:function(val){
            var me=this;
            this.clearTimer();
            this.timer=setTimeout(function(){
                me.request(val);
                me.clearTimer();
            },this.delay);
        },
        clearTimer:function(){
            this.timer && clearTimeout(this.timer);
        },
        clearItem:function(){
            var items=this.dropDown.children();
            for (var i = 0; i < items.length; i++) {
                items.eq(i).unbind().html("").remove();
            }
            this.selectedIndex=-1;
            this.hide();
        },
        show:function(){
            this.dropDown.show();
        },
        hide:function(){
            this.dropDown.hide();
        },
        destroy:function(){
            this.clearTimer();
            this.el=null;
            this.dropDown=null;
        }
    });
})(window.song,window.jQuery);