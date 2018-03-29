/*
内容：jQuery-Extend
作者：王松华
时间：{createDate}
*/
(function($) {
	jQuery.fn.extend({
		myExtend:function(opts){
			var that=this;
			this.opts=$.extend({
				
			},opts || {});
		}
	});
})(jQuery)