/*
author:               	wang song hua
email:                 	songhuaxiaobao@163.com
url:                    http://www.netstudio80.com
namespace:      		Song.Web
content:            	web应用相关
beforeLoad:     		j,base
dateUpdated:  			2012-03-14
*/
;(function(song,j){
	song.newcontrol=function(options){
		song.newcontrol.base.constructor.call(this,song.newcontrol.defaults,options);
	};
	song.newcontrol.defaults={
		
	};
	song.extend(song.control,song.newcontrol,{
		getType:function(){
			return song.newcontrol.base.getType()+".newcontrol";
		},
		init:function(){
			
		},
		render:function(){
		
		},
		destroy:function(){
			
		}
	});
})(window.song,window.jQuery)