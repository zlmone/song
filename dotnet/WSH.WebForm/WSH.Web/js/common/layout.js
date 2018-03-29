; (function (j) {
    var count=0;
    //表单column布局
    j.fn.formPanel = function (opts) {
        var panel = this, defaultLableWidth = 80,time=0;
        panel.append("<div class='clear-hide'>");
 
            opts = $.extend({formWidth:panel.innerWidth(), columns: 2, labelWidth: defaultLableWidth, minWidth: 20 }, opts || {});
       
            var itemWidth = parseInt(opts.formWidth / opts.columns - opts.labelWidth);
            if (itemWidth < opts.minWidth) {
                 return;
            }
            if (opts.labelWidth != defaultLableWidth) {
                panel.find("div.form-label").width(opts.labelWidth);
            }
            var items = panel.find(".form-control"), len = items.length, colIndex = 0;
            for (var i = 0; i < len; i++) {
                var item = $(items[i]), isSpace = false, isFull = (item.attr("fullColumn") == "true"), isLast = (i == len - 1), w = itemWidth;
                var cls = item.attr("class");
                colIndex++;
                //填充剩余列的宽度计算
                if (isFull && opts.columns > 1) {
                    isSpace = true;
                    //剩余的列
                    var otherCount = opts.columns - colIndex;
                    w = (otherCount * itemWidth) + (otherCount * opts.labelWidth) + w;
                    colIndex = 0;
                }
                if (cls.indexOf("combox") > -1 || cls.indexOf("form-check") > -1) {
                    item.width(w);
                } else {
                    item.width(w - 2);
                    item.bind("focus",function(){
                        $(this).addClass("input-focus");
                    }).bind("blur",function(){
                        $(this).removeClass("input-focus");
                    });
                }
                if (item.hasClass("form-check")) {
                    //让check和radio元素居中
                    item.append("<span class='inline-block'></span>");
                }
                if (colIndex == opts.columns) {
                    isSpace = true;
                    colIndex = 0;
                }
                if (isSpace && !isLast) {
                    item.after("<div class='clear-hide form-space'>");
                }
            }
//        }
//        function delay(){
//			time && clearTimeout(time);
//            time=setTimeout(function(){
//                count++;
//                j("<div>").html(count+":"+panel.innerWidth()+":"+time).appendTo(parent.document.body);    
//                layout();
//            },200);
//        }
//        delay();
//        j(window).bind("resize",delay);
    }
    //hbox布局
    j.fn.hbox = function (opts) {
        opts = j.extend({ align: "center"}, opts || {});
        var items = this.children(), isCenter = (opts.align == "center"), w = 0;
        for (var i = 0; i < items.length; i++) {
            var item = items.eq(i);
            item.css("float", "left");
            w += item.outerWidth();
            if (i < items.length - 1) {
                item.css("margin-right", opts.margin);
                opts.margin && (w += opts.margin);
            }
        }
        this.wrapInner(j("<div class='hbox " + opts.align + "'></div>"));
        var wrap = this.children("div.hbox").append("<div class='clear-hide'></div>");
        wrap.width(w);
        if (!isCenter && opts.margin) {
            wrap.css("margin-" + opts.align, opts.margin);
        }
        //清除对齐的浮动
        this.append("<div class='clear-hide'></div>");
    }
    //dockPanel布局
    j.fn.dockPanel=function(opts){
         var time=false;
        var me=this;
//         function layout(){
            opts=j.extend({width:me.innerWidth(),height:me.innerHeight()},opts || {});
            var regions=["top","bottom","left","right","center"];
            var centerW=opts.width,centerH=opts.height,centerL=0,centerT=0;
            for (var i = 0; i < regions.length; i++) {
                var dir=regions[i];
                var item=me.find(">div[dock="+dir+"]");
                if(item.length>0){
                    item.addClass("dock-item");
                    var itemH=item.outerHeight(true);
                    var itemW=item.outerWidth(true);
                    if(dir=="top" || dir=="bottom"){
                        var pos=dir=="top" ? {left:0,top:0} : {right:0,bottom:0}
                        item.css(pos).width(opts.width-(itemW-item.width()));
                        centerH-=itemH;
                        if(dir=="top"){
                            centerT=itemH;
                        }
                    }else if(dir=="left" || dir=="right"){
                        var pos=dir=="left" ? {left:0,top:centerT} : {right:0,top:centerT}
                        item.css(pos).height(centerH-(itemH-item.height()));
                        centerW-=itemW;
                        if(dir=="left"){
                            centerL=itemW;
                        }
                    }else{
                        item.css({left:centerL,top:centerT}).width(centerW-(itemW-item.width())).height(centerH-(itemH-item.height()));
                     
                    }
                }
            }
//        }
//        function delay(){
//			time && clearTimeout(time);
//            time=setTimeout(function(){
////                count++;
////                j("<div>").html(count+":"+me.innerWidth()+":"+time).appendTo(parent.document.body);    
//                layout();
//            },200);
//        }
//         delay();
//        j(window).bind("resize",delay);
    }
    j(window).bind("load",function(){
   //     setTimeout(function(){
            j("div.form-panel").each(function(){
                var me=j(this);
                me.formPanel({labelWidth:parseInt(me.attr("labelWidth")),columns:parseInt(me.attr("columns"))});
            });    
            j("div.dock-panel").each(function(){
                j(this).dockPanel();
            });
            
            j("div.stack-panel").each(function(){
                var me=j(this);
                me.hbox({align:me.attr("align"),margin:parseInt(me.attr("margin"))});
            });
      //  },0);
    });
})(window.jQuery);