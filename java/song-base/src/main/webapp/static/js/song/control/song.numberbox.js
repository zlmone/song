/*
author:               	王松华
email:                 	songhuaxiaobao@163.com
namespace:      		Song.NumberBox
content:            	数字输入框
beforeLoad:     		j,base
dateUpdated:  			2013-01-22
*/
;(function (song, j) {
    song.numberbox = function (el, options) {
        //ie下禁止输入法，chrome无法禁止
        this.el = j(el).css({imeMode: 'disabled'});
        song.numberbox.base.constructor.call(this, song.numberbox.defaults, options);
    };
    song.numberbox.defaults = {
        allowDecimal: true,//是否允许小数
        allowNegative: true,//是否允许负数
        maxValue: Number.MAX_VALUE,
        precision: 4,
        minValue: Number.MIN_VALUE
    };
    song.extend(song.control, song.numberbox, {
        init: function () {
            this.parseValue();
            this.bindEvent();
        },
        bindEvent: function () {
            var me = this;
            this.el.bind("keypress", function (e) {
                var kc = e.which;
                if (me.onEnter && kc == song.kc.enter) {
                    me.onEnter.call(me, e);
                }
                if ((me.allowNegative && kc == 45) || (me.allowDecimal && kc == 46)) {
                    return true;
                } else {
                    if ((kc >= 48 && kc <= 57 && e.ctrlKey == false && e.shiftKey == false) || kc == 0 || kc == 8) {
                        return true;
                    } else {
                        if (e.ctrlKey == true && (kc == 99 || kc == 118)) {
                            return true;
                        } else {
                            return false;
                        }
                    }
                }
            });
            this.el.bind("blur", function () {
                me.parseValue();
            });
        },
        getValue: function () {
            return this.parseValue();
        },
        parseValue: function () {
            var value = this.el.val();
            if (!this.allowNegative) {
                value = value.replaceAll('-', '');
            }
            value = this.allowDecimal ? parseFloat(value) : parseInt(value);
            if (isNaN(value)) {
                value = "";
            } else {
                if (value > this.maxValue) {
                    value = this.maxValue;
                } else if (value < this.minValue) {
                    value = this.minValue;
                } else if (this.precision && value.toString().has(".")) {
                    value = value.toFixed(this.precision);
                }
            }
            this.el.val(value);
            return value;
        },
        destroy: function () {
            this.el = null;
        }
    });
    //正整数输入框
    song.uintbox = function (el, options) {
        j.extend(options || {}, {
            allowDecimal: false,
            allowNegative: true//是否允许负数
        });
        return new song.numberbox(el, options);
    }
    //jQuery扩展方法
    j.fn.numberbox = function (options) {
        return new song.numberbox(this, options);
    }
//    //根据songtype自动绑定
//    j(function(){
//        j("input[songtype='numberbox']").each(function(){
//            j(this).numberbox();
//        });
//    });
})(window.song, window.jQuery);