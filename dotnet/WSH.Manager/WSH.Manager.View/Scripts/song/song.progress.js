/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Progress
content:            进度条
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song,j) { 
    song.progress=function(options){
        song.progress.base.constructor.call(this,song.progress.defaults,options);
    };
    song.progress.defaults={
        max:100,
        value:0,
        rate:0,
        width:"auto",
        height:18,
        text:"{rate}",
        renderTo:"body"
    };
    song.extend(song.control,song.progress,{
        getType:function(){
            return song.progress.base.getType()+".progress";
        },
        render:function(){
            this.wrap=j("<div class='song-progress-wrap'>").css({height:this.height,lineHeight:this.height+"px"}).append("<div class='song-progress-text'>&nbsp;</div>").appendTo(this.renderTo);
            if(this.width && this.width!="auto"){
                this.wrap.width(this.width);
            };
            this.inner=j("<div class='song-progress-inner'>").appendTo(this.wrap);
            $("<div class='song-progress-text'>&nbsp;</div>").css("width", this.wrap.width()).appendTo(this.inner);
            this.value && this.setValue();
        },
        setValue:function(value){
            if(value) {this.value=value}else{this.value++;}
            this.rate= Math.round(this.value / this.max * 100);
            this.inner.css("width", this.rate + "%");
            this.setText();
            return true;
        },
        setText:function(text){
            if(text) this.text=text;
            this.wrap.find(".song-progress-text").html(this.text.replace("{max}",this.max).replace("{value}",this.value).replace("{rate}",this.rate+"%"));
        },
        destroy:function(){
            this.wrap=this.inner=null;
        }
    });
})(window.song,window.jQuery);