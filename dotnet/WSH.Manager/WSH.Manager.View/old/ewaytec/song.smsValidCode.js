/*
author:                 王松华
email:                  shwang@163.com
namespace:              song.smsValidCode
content:                短信验证码
beforeLoad:             jQuery,song
dateUpdated:            2014-11-26
*/
; (function (song, j) {
    song.smsValidCode = function (el, mobile) {
        debugger;
        this.time = 120;
        this.el = j(el);
        this.msg = "{0}秒后重新获取";
        var that = this;
        this.value = this.el.val();
        this.el.click(function () {
            that.getCode(mobile);
        });
    }
    song.smsValidCode.prototype = {
        getCode: function (mobile) {
            //设置按钮不可用
            this.setDisabled(true);
            var url = song.url("MsgValidate", "GetMsgValidate").getUrl(),
                param = {Mobiles:mobile},
                that = this;
            song.ajax(url, param, function (result) {
                if (result.isSuccess) {
                    that.code = result.code;
                    that.countDown();
                } else {
                    song.topAlert();
                }
            }, function () {
                //清楚按钮不可用
                that.setDisabled(false);
            });
        },
        valid: function (text) {
            if(text.trim()==""){
                return true;
            }
            return text == this.code;
        },
        setValue: function (val) {
            this.el.val(this.msg.format(val));
        },
        setDisabled: function (isDisabled) {
            this.el.disabled(isDisabled);
            //设置按钮样式
        },
        clearTimer: function () {
            if (this.timer != null) {
                clearInterval(this.timer);
            }
            this.setDisabled(false);
        },
        countDown: function () {
            //倒计时
            this.clearTimer();
            this.setDisabled(true);
            var that = this,
                t = this.time;
            that.setValue(t);
            this.timer = setInterval(function () {
                if (t <= 0) {
                    that.clearTimer();
                    that.el.val(that.value);
                } else {
                    //倒计时
                    t--;
                    that.setValue(t);
                }
            }, 1000);
        }
    }
})(window.song, window.jQuery)
