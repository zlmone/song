/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Test
content:            测试相关
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song, j) {
    if(song==undefined){
        song=window.song=function(){};
    };
    song.log=function(){
        var arr=Array.prototype.slice.call(arguments);
        var div=j("#SONGERRORELEMENT");
        if(div.length<=0){
            var cls={position:"absolute",bottom:0,left:0,width:300,textAlign:"left",fontSize:"12px",
                border:"1px solid #e9d315",background:"#f9f2ba",color:"#5b5316",display:"none",
                padding:"6px",lineHeight:"22px"};
            div=j("<div id='SONGERRORELEMENT'>").css(cls).appendTo("body");
        }
        song.error=song.error.concat(arr);
        div.html(song.error.join("<br>"));
        div.slideDown();
        setTimeout(function(){
            div.slideUp();
        },5000);
    };
    song.test=function(){
        this.start();
    };
    song.test.prototype={
        second:function(get_as_float) {
            var now = new Date().getTime() / 1000;
            var s = parseInt(now, 10);
            return (get_as_float) ? now : (Math.round((now - s) * 1000) / 1000) + ' ' + s;
        },
        start:function(){
            this.startTime=new Date().getTime();
            return this;
        },
        end:function(isAlert){
            this.endTime=new Date().getTime();
            isAlert && this.alert();
            return this;
        },
        alert:function(){
            if(!this.endTime){alert("测试器尚未结束！");return;}
            var span=this.endTime-this.startTime;
            alert("耗时："+span+"毫秒");
            return this;
        }
    }
})(window.song, window.jQuery);