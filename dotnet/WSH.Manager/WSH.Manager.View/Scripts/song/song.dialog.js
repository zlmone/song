/*
author:               	wang song hua
email:                 	songhuaxiaobao@163.com
url:                    http://www.netstudio80.com
namespace:      		Song.Dialog
content:            	web应用相关
beforeLoad:     		j,base,popup
dateUpdated:  			2012-07-10
*/
; (function (song, j) {
    song.popup = function (options) {
        song.popup.base.constructor.call(this, song.popup.defaults, options);
    };
    song.popup.defaults = {
        content:"<div class='song-popup-loading'></div>",
        closable:true,
        time:null,
        delay:400,
        top:"50%",
        left:"50%"
    };
    song.extend(song.control, song.popup, {
        init: function () {
            
        },
        render: function () {
            this.dom=this._getDom();
        },
        content:function(){
            
        },
        setTitle:function(text){
            var title=this.dom.title;
            if(text==false){
                title.hide().html('');
            }else{
                title.show().html(text || '');
            }
        },
        setSize:function(){
            
        },
        setPosition:function(options){
            song.position.setRegion(this.dom.wrap,options);return this;
        },
        button:function(){
            
        },
        show:function(){
        
        },
        hide:function(){
        
        },
        close:function(){
        
        },
        time:function(){
            
        },
        focus:function(){
        
        },
        zIndex:function(){
            
        },
        _getDom:function(){
            var dom={};
            dom.wrap=j("<div>").appendTo('body');
            
            return dom;
        },
        destroy: function () {

        }
    });
    song.dialog._template="";
})(window.song, window.jQuery)