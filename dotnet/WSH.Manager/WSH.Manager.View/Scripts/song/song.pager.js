/*
author:						王松华
email:						songhuaxiaobao@163.com
url:						http://www.netstudio80.com
namespace:					Song.Pager
content:					分页
beforeLoad:					j,base,numberbox
dateUpdated:				2012-04-26
*/
; (function (song, j) {
	song.pager=function(options){
        //song.pager.base.constructor.call(this,song.pager.defaults,options);
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
//	song.pager.defaults = {
//        totalRecord: 0,
//        pageIndex: 1,
//        pageSize: 20,
//        pageCount: 1,
//        pageList:[5,10,20,30,50,100],
//        onMovePage:song.pager.move
//    }
//    //********************纯js分页控件（未完）*************************
//	song.extend(song.control,song.pager,{
//		init:function(){
//			 this.createDom();
//		},
////		movePage:function(pageSize,pageIndex){
////			this.onMovePage.call(this,pageSize,pageIndex);
////		},
//        createDom:function(){
//            var dom=this.dom={},
//                me=this,
//                size=me.pageSize,
//                index=me.pageIndex,
//                list=me.pageList,
//                wrap=j("<div>").html(pagerTemplate).appendTo(this.renderTo || 'body');
//            dom.wrap=wrap;
//            dom.nums=wrap.find("input:first");
//            //初始化数字输入框
//            song.uintbox(dom.nums,{
//                minValue:1,
//                maxValue:me.pageCount,
//                onEnter:function(e){
//                    var value=this.parseValue();
//                    if(value && pageIndex!=value){
//                        me.onMovePage.call(me,index,size);
//                    }
//                }
//            });
//            dom.pageList=wrap.find("select:first");
//            //判断当前页是否存在，不存在则添加
//            Array.has(list,size) || (list[list.length]=size);
//            for (var i = 0,len=list.length; i <len; i++) {
//                dom.pageList.append("<option value='{0}'>{1}</option>".format(list[i],list[i]));
//            }
//            dom.pageList.val(size);
//        },
//        getPage:function(num){
//            if(num===this.pageIndex){
//                return ['<span class="active">',num,'</span>'].join('');
//            }
//            return ['<a href="javascript:',this.onMovePage,'">',num,'</a>'].join('');
//        },
//        getDot:function(){
//            return ['<span class="dot">...</span>'].join('');
//        },
//        destroy:function(){
//            this.num=null;
//        }
//	});
//    var pagerTemplate=[
//        '<div class="song-paging">',
//            '<select onchange=""></select>',
//            '<div class="nums"></div>',
//            '&nbsp;<label>跳转到 </label>',
//            '<input type="text" class="num"/>',
//        '</div>',
//        '<div class="song-clear"></div>',
//    ].join('');
})(window.song,window.jQuery);