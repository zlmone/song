/*
author:              wang song hua
namespace:      Song.Controls.Suggest
*/
; (function (song, j) {
    song.suggest = function (el, options) {
        this.el = j(el);
        song.suggest.base.constructor.call(this, song.suggest.defaults, options);
    };
    song.suggest.defaults = {
        
    };
    song.extend(song.control, song.suggest, {
        getType:function(){
            return song.suggest.base.getType()+".suggest";
        },
        render: function () {
            
        },
        destroy:function(){
        }
    });
})(window.song, window.jQuery);