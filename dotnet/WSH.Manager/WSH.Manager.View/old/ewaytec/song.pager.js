/*
author:						王松华
email:						songhuaxiaobao@163.com
namespace:					Song.Pager
content:					分页
beforeLoad:					j,base,numberbox
dateUpdated:				2012-04-26
*/
; (function (song, j) {
    //--------------------------分页控件------------------------------
	song.pager=function(options){
        song.pager.base.constructor.call(this,song.pager.defaults,options);
    };
    j.extend(song.pager,{
        move: function (pageIndex, pageSize) {
            var p = new song.param();
            p.add({ pageSize: pageSize, pageIndex: pageIndex });
            p.removeSearch();
            location.href = p.getUrl();
        },
        goto:function(pageSize,pageIndex,fn){
            var value=this.parseValue();
            if(value && pageIndex!=value){
                fn(value,pageSize);
            }
        },
        goPage:function(id,pageSize,pageIndex,fn){
            var value=parseInt(j("#"+id).val());
            if(value && pageIndex!=value){
                fn(value,pageSize);
            }
        }
    });
	song.pager.defaults = {
        url:location.href,
        params:{},
        totalRecord: 0,
        pageIndex: 1,
        pageSize: 20,
        pageCount: 1,
        pageList:[10,15,20,30,50,100],
        totalMsg:"显示记录从{begin}到{end}，总数 {totalRecord} 条"
    }
    //********************纯js分页控件 *************************
	song.extend(song.control,song.pager,{
		init:function(){
			 this.createDom();
		},
//		movePage:function(pageSize,pageIndex){
//			this.onMovePage.call(this,pageSize,pageIndex);
//		},
        createDom:function(){
            var dom=this.dom={},
                me=this,
                size=me.pageSize,
                index=me.pageIndex,
                list=me.pageList,
                wrap=j("<div>").html(pagerTemplate).appendTo(this.renderTo || 'body');
            dom.wrap=wrap;
            this.getDom();
            //初始化数字输入框
            song.uintbox(this.dom.pageIndex.val(index),{
                onEnter:function(e){
                    var value=this.parseValue();
                    if(value && me.pageIndex!=value){
                        if(value<=me.pageCount){
                            me.pageIndex=value;
                            me.load();
                        }
                    }
                }
            });
            //判断当前页是否存在，不存在则添加
            Array.has(list,size) || (list[list.length]=size);
            for (var i = 0,len=list.length; i <len; i++) {
                this.dom.pageSize.append("<option value='{0}'>{1}</option>".format(list[i],list[i]));
            }
            this.dom.pageSize.val(size);
        },
        load:function(url){
            if(this.theRequest){return;}
            if(url){
                this.url=url;
            }
            var me=this;
            me.theRequest=true;
            this.beforeLoad && this.beforeLoad.call(this);
            j.extend(this.params,{
                pageIndex:this.pageIndex,
                pageSize:this.pageSize,
                _t:new Date().getTime()
            });
            song.jsonRequest(this.url,this.params,function(result){
                me.setPageInfo(result.totalRecord || 0);
                me.renderHtml && me.renderHtml.call(me,result.data);
            },function(){
                me.afterLoad && me.afterLoad.call(me);
                me.theRequest=false;
            });
        },
        setPageInfo:function(total){
            this.totalRecord=total;
            this.pageCount=this.totalRecord < this.pageSize ? 1 : Math.ceil(this.totalRecord/this.pageSize);
            this.dom.pageCount.html(this.pageCount);
            this.dom.pageIndex.val(this.pageIndex);
            this.dom.totalMsg.html(this.totalMsg.format({
                begin:(this.pageIndex-1)*this.pageSize+1,
                end:this.totalRecord<=this.pageSize ? this.totalRecord :  (this.pageIndex*this.pageSize),
                totalRecord:this.totalRecord
            }));
            this.dom.wrap.find("span[pager='song-btn']").removeClass("l-disabled");
            if(this.pageIndex<=1){
                this.setDisabled("first,prev");
            }
            if(this.pageIndex>=this.pageCount){
                this.setDisabled("next,last");
            }
        },
        setDisabled:function(btns){
            var wrap=this.dom.wrap;
            btns.replace(song.split,function(name){
                wrap.find("div[pager='song-"+name+"'] span:first").addClass("l-disabled");
            });
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
        getDom:function(){
            //获取分页控件的相关元素
            var doms={
                "pageSize":"select",
                "pageIndex":"input",
                "totalMsg":"span",
                "pageCount":"span"
            };
            var me=this;
            for (var domName in doms) {
                this.dom[domName]=this.getElement(doms[domName],domName);
            }
            this.dom.wrap.find("div.l-bar-button").hover(function(){
                j(this).addClass("l-bar-button-over");
            },function(){
                j(this).removeClass("l-bar-button-over");
            }).click(function(){
                if(!j(this).find("span:first").hasClass("l-disabled")){
                    var cmd=j(this).attr("pager").replace("song-","");
                    switch (cmd) {
                        case "first":me.moveFirst();break;
                        case "prev":me.movePrev();break;
                        case "next":me.moveNext();break;
                        case "last":me.moveLast();break;
                        default:me.load();break;
                    }
                }
            });
            this.dom.pageSize.change(function(){
                me.pageSize=parseInt(this.value);
                me.moveFirst();
            });
        },
        getElement:function(tagName,attr){
            return this.dom.wrap.find(tagName+"[pager='song-"+attr+"']");
        },
        destroy:function(){
            this.dom=null;
        }
	});
    var pagerTemplate=[
	" <div class=\"l-panel-bar\">",
	"                <div class=\"l-panel-bbar-inner\">",
	"                    <div class=\"l-bar-group l-bar-selectpagesize\">",
	"                        <select pager=\"song-pageSize\">",
	"                        </select>",
	"                    </div>",
	"                    <div class=\"l-bar-separator\">",
	"                    </div>",
	"                    <div class=\"l-bar-group\">",
	"                        <div class=\"l-bar-button l-bar-btnfirst\" pager=\"song-first\">",
	"                            <span class=\"\" pager=\"song-btn\"></span>",
	"                        </div>",
	"                        <div class=\"l-bar-button l-bar-btnprev\" pager=\"song-prev\">",
	"                            <span class=\"\" pager=\"song-btn\"></span>",
	"                        </div>",
	"                    </div>",
	"                    <div class=\"l-bar-separator\">",
	"                    </div>",
	"                    <div class=\"l-bar-group\">",
	"                        <span class=\"pcontrol\">",
	"                            <input type=\"text\" pager=\"song-pageIndex\" size=\"4\" style=\"width: 20px\" maxlength=\"3\">",
	"                            / <span pager=\"song-pageCount\">1</span></span></div>",
	"                    <div class=\"l-bar-separator\">",
	"                    </div>",
	"                    <div class=\"l-bar-group\">",
	"                        <div class=\"l-bar-button l-bar-btnnext\" pager=\"song-next\">",
	"                            <span class=\"\" pager=\"song-btn\"></span>",
	"                        </div>",
	"                        <div class=\"l-bar-button l-bar-btnlast\" pager=\"song-last\">",
	"                            <span class=\"\" pager=\"song-btn\"></span>",
	"                        </div>",
	"                    </div>",
	"                    <div class=\"l-bar-separator\">",
	"                    </div>",
	"                    <div class=\"l-bar-group\">",
	"                        <div class=\"l-bar-button l-bar-btnload\" pager=\"song-load\">",
	"                            <span class=\"\" pager=\"song-btn\"></span>",
	"                        </div>",
	"                    </div>",
	"                    <div class=\"l-bar-separator\">",
	"                    </div>",
	"                    <div class=\"l-bar-group l-bar-right\">",
	"                        <span class=\"l-bar-text\" pager=\"song-totalMsg\"></span></div>",
	"                    <div class=\"l-clear\">",
	"                    </div>",
	"                </div>",
	"            </div>"
    ].join('');
})(window.song,window.jQuery);