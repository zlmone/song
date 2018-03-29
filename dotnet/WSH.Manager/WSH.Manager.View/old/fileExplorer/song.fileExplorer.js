/*
author:						wang song hua
email:						songhuaxiaobao@163.com
url:						http://www.netstudio80.com
namespace:					Song.fileExplorer
content:					分页
beforeLoad:					j,base
dateUpdated:				2012-10-11
*/
; (function (song, j) {
    j(window).load(function(){
        song.fileExplorer.fixed();
    }).resize(function(){
        setTimeout(function(){
            song.fileExplorer.fixed();
        },song.resizeDelay);
    });
    song.fileExplorer={
        back:function(){
            //判断是否到了根目录
            if(!song.fileExplorer.hasRoot()){
                history.back();
            }
        },
        hasRoot:function(){
            return true;
        },
        fixed:function(){
            var docHeight=song.position.client().height,
                titleHeight=j("div.song-explorer-title").outerHeight(),
                headHeight=j("div.song-explorer-head").outerHeight();
            if(titleHeight<=0){
                titleHeight=j("div.song-explorer-toolbar").outerHeight();
            }
            
            j("div.song-explorer-body").height(docHeight-titleHeight-headHeight);
        },
        folder:function(path){
            var p=new song.param();
            p.removeSearch();
            p.add("path",path);
            location.href=p.getUrl();
        },
        over:function(obj,isimg){
            var tr=j(obj);
            tr.addClass("song-explorer-hover");
            if(isimg){
                var cmd=tr.find("span.song-explorer-cmd");
                cmd && cmd.show();
            }
        },
        out:function(obj,isimg){
            var tr=j(obj);
            tr.removeClass("song-explorer-hover");
            if(isimg){
                var cmd=tr.find("span.song-explorer-cmd");
                cmd && cmd.hide();
            }
        },
        preview:function(file,obj){
           // file=decodeURIComponent(file);
            var tip=new song.tip({content:"<img src='"+file+"'/>",follow:j(obj),fix:10,target:true,dir:"bottom"});
            tip.show();
        },
        select:function(file){
            
        }
    }
})(window.song, window.jQuery)