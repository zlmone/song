/*
author:						王松华
email:						songhuaxiaobao@163.com
namespace:					Song.SimpleGrid
content:					分页
beforeLoad:					j,base,numberbox,pager
createDate:				    2012-06-16
updateDate:				    2012-06-16
*/
; (function (song, j) {
    j.extend(Number,{
        is:function(n){
            return n===+n;
        }
    });
    //--------------------------自定义列表------------------------------
    song.simpleGrid=function(options){
        song.simpleGrid.base.constructor.call(this,song.simpleGrid.defaults,options);
    }
    j.extend(song.simpleGrid,{
        defaults:{
            pageSize:20,
            datakey:"id",
            params:{}
        },
        getGridHtml:function(data,isdetails,renderRow,datakey){
            //生成table
            //格式：{columns:[{width:120,name:"rownumber",text:"行号"}],rows:[{rownumber:1}]}
            var cols=data.columns || [],
                rows=data.rows || [],
                showCols=0;
            var b=new song.builder();
            b.add('<table class="song-grid-table">');
            b.add("<tr>");
            if(isdetails){
                showCols++;                
                b.add('<th class="song-grid-header song-grid-detailsbtn">&nbsp;</th>');
            }
            var rowContent=[];
            for (var i = 0; i < cols.length; i++) {
                var col=cols[i];
                if(col.hidden==undefined){
                    col.hidden=false;
                }
                if(!col.hidden){
                    showCols++;
                    col.width=(col.width && col.width!="") ? (/em|px|%/.test(String(col.width)) ? col.width : (col.width+'px')) : null;
                    var headwidth=col.width ? 'width="'+col.width+'"' : '';
                    b.add('<th class="song-grid-header song-nowrap" '+headwidth+'><span title="'+col.text+'">'+col.text+'</span></th>');
                }
            }
            b.add("</tr>");
            if(rows && rows.length>0){
                for (var n = 0; n < rows.length; n++) {
                    var row=rows[n],
                        detailsId=song.id()+"-simpleGrid-details-"+n,
                        detailsWrap=detailsId+"-wrap",
                        pk=row[datakey];
                    if(renderRow){
                        row=renderRow.call(this,row);
                    }
                    b.add('<tr class="song-grid-datarow">');
                    if(isdetails){
                        b.add('<td class="song-grid-detailsbtn"><span class="song-details-btn song-details-up" datakey="'+pk+'" detailsWrap="'+detailsWrap+'" onclick="song.simpleGrid.showDetailBtn(this,\''+detailsId+'\')"></span></td>');
                    }
                    for (var k = 0; k < cols.length; k++) {
                        var column=cols[k];
                        if(!column.hidden){
                            var rowwidth=column.width ? 'width="'+column.width+'"' : '';
                            b.add('<td class="song-grid-cell song-grid-header song-nowrap" '+rowwidth+'>');
                            b.add('<span title="'+row[column.name].delTag()+'">'+row[column.name]+'</span>');
                            b.add('</td>');
                        }
                    }    
                    b.add("</tr>");
                    if(isdetails){
                        b.add('<tr style="display:none" class="song-grid-row" id="'+detailsId+'"><td colspan="'+showCols+'"  id="'+detailsWrap+'"></td></tr>');
                    }
                }
            }else{
                b.add('<tr><td class="song-grid-nodata" colspan="'+showCols+'">暂无数据</td></tr>');
            }
            b.add("</table>");
            return b.toString();
        },
        restyle:function(rows){
            var rows= rows.removeClass("song-grid-oddrow").each(function(i){
                var row=$(this);
                if(i%2!=0){
                    row.addClass("song-grid-oddrow");   
                }
                row.unbind("hover").hover(function(){
                    $(this).addClass("song-grid-hover");
                },function(){
                    $(this).removeClass("song-grid-hover");
                });
                row.unbind("click.selected").bind("click.selected",function(){
                    rows.removeClass("song-grid-selected");
                    $(this).addClass("song-grid-selected");
                });
            });
        },
        showDetailBtn:function(btn,wrapid){
            //显示明细内容
            var wrap=j("#"+wrapid),
                obj=j(btn);
            //修改按钮样式
            if(wrap.is(":hidden")){
                wrap.show();
                obj.removeClass("song-details-up").addClass("song-details-down");
            }else{
                wrap.hide();
                obj.removeClass("song-details-down").addClass("song-details-up");
            }
        }
    });
    song.extend(song.control,song.simpleGrid,{
        init:function(){
            this.wrap=j("<div class='song-grid-wrap'>").html("<div class='l-grid' grid=\"song-grid\"></div><div grid=\"song-pager\"></div>").appendTo(this.renderTo || 'body');
            var me=this;
            this.pager=new song.pager({
                renderTo: me.wrap.find("div[grid='song-pager']"),
                url:this.url,
                pageSize:this.pageSize,
                beforeLoad: function () {
                    song.loading.show();
                    me.beforeLoad && me.beforeLoad.call(me);
                    if(me.params){
                        j.extend(this.params,me.params);
                    }
                },
                afterLoad: function () {
                    me.afterLoad && me.afterLoad.call(me);
                    song.loading.hide();
                },
                renderHtml: function (data) {
                    var htmls;
                    if(!data){
                        this.dom.wrap.hide();
                        htmls= '<div style="padding:10px;text-align:center">系统繁忙，点击<a href="javascript:location.href=location.href">刷新</a>重试</div>';
                    }else{
                        this.dom.wrap.show();
                        me.data=data ? data.rows : [];
                        htmls=song.simpleGrid.getGridHtml(data,!!me.details,me.renderRow,me.datakey);
                    }
                    me.removeRows();
                    me.wrap.children("div[grid='song-grid']").html(htmls);
                    song.simpleGrid.restyle($("tr.song-grid-datarow",me.wrap));
                    me.showDetails();
                    me.afterRender && me.afterRender.call(me);
                }
            });
            this.pager.dom.wrap.hide();
        },
        showDetails:function(){
            var me=this;
            this.wrap.find("span.song-details-btn").click(function(e){
                e.preventDefault();
                var obj=$(this),
                    isload=obj.attr("isload");            
                if(!isload){
                    //第一次点击才加载明细，确保性能
                    obj.attr("isload","true");
                    me.details && me.details.call(me,obj.attr("detailsWrap"),obj.attr("datakey"));
                } 
            });
        },
        getRowData:function(datakey){
            if(this.data){
                var rows=this.data.rows || this.data;
                for (var i = 0; i <rows.length; i++) {
                    if(rows[i][this.datakey]==datakey){
                        return rows[i];
                    }
                }
            }
            return {};
        },
        removeRows:function(){
            var rows=this.wrap.find("tr").each(function(){
                $(this).unbind().remove();
            });
        },
        query:function(){
            this.pager.moveFirst();
        },
        load:function(){
            this.pager.load();
        },
        destroy:function(){
            this.wrap=null;
            this.pager=null;
            this.data=null;
        }
    });
})(window.song,window.jQuery);