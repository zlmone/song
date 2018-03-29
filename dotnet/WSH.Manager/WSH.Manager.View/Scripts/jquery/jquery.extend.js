/*
author:						wang song hua
email:						songhuaxiaobao@163.com
url:						http://www.netstudio80.com
namespace:					jQuery.Extend
content:					jQuery扩展
beforeLoad:					j,base
dateUpdated:				2012-07-1
*/
; (function (j) { 
    j.extend({
        getWindowSize:function(){
            var win=j(window);
            return {top:win.scrollTop(),left:win.scrollLeft(),width:win.width(),height:win.height()}
        },
        rowspanColumn:function(rows, colIndex){
            var begin;
            rows.each(function (i) {
                var cell = $("td:eq(" + colIndex + ")", this);
                if (begin != null && cell.text().toLowerCase().trim() == begin.text().toLowerCase().trim()) {
                    var rs = Number(begin.attr("rowspan") || 1) + 1;
                    begin.attr("rowspan", rs);
                    cell.hide();
                } else {
                    begin = cell;
                }
            });
        }
    });
    j.fn.extend({
        disabled:function(value){
            value ? this.attr("disabled","disabled") : this.removeAttr("disabled");
        },
        checked:function(value){
            value ? this.attr("checked","checked") : this.removeAttr("checked");
        },
        isChecked:function(){
            return this.get(0).checked;
        },
        checkAll:function(wrap,name){
            var chs=name ? wrap.find("input[name='"+name+"']") : wrap.find("input:checkbox");
            this.click(function(){
                var ck=this.checked;
                chs.each(function(){
                    this.checked=ck;
                });
            });
        },
        clearForm:function(){
            this.find("input:text,textarea").val("");
        },
        enabledForm:function(isEnabled){
            var els=this.find("input,textarea,select");
            isEnabled ? els.removeAttr("disabled") : els.attr("disabled","disabled");
        },
        getElements:function(){
            return this.find("input,textarea,select");
        },
        toParams:function(){
            var items=this.find("input,textarea,select"),
                result={};
            items.each(function(i,item){
                var item=items.eq(i),
                    id=item.attr("id"),
                    tagName=this.tagName.toLowerCase(),
                    notypes = ["button", "file", "image", "reset", "submit"];
                if(id){
                    id=id.delStart("query-");
                    var type=(item.attr("type") || "text").toLowerCase();
                    //过滤按钮，上传控件
                    if(!Array.has(notypes, type)){
                        if(tagName=="input" && type=="checkbox"){
                            result[id]=item.isChecked() ? "true" : "false";
                        }else{
                            var val=item.val().trim(); 
                            if(val!=""){
                                result[id]=val;
                            }
                        }
                    }
                }
            });
            return result;
        },
        formFocus:function(){
            var items=this.getElements();
            for (var i = 0; i < items.length; i++) {
                if(!items.eq(i).is(":hidden")){
                    items.get(i).focus();
                    return;
                }
            }
        },
        rowspan:function(columns){
            if(columns){
                for (var i = 0; i < columns.length; i++) {
                    j.rowspanColumn(rows, columns[i]);
                }
            }
        }
    });
})(window.jQuery);