/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
namespace:      Song.DD
content:            拖动缩放
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
;(function (song, j) {
    song.dd = function (el, options) {
        this.el = j(el);
        song.dd.base.constructor.call(this, song.dd.defaults, options);
    };
    song.dd.defaults = {
        proxy: true,
        moveSet: true,
        minWidth: 20,
        minHeight: 20
    };
    song.extend(song.control, song.dd, {
        init: function () {
            var me = this;
            this.handler = this.handler ? j(this.handler) : this.el;
            this.proxy && this.createProxy();
            this.moveEvent = song.bindWithEvent(this, this.move);
            this.stopEvent = song.bind(this, this.stop);
            this.handler.css("cursor", this.cursor).bind("mousedown", song.bindWithEvent(this, this.start));
        },
        createProxy: function () {
            this.proxy = j("<div class='song-dd-proxy'>").appendTo('body');
        },
        start: function (e) {
            this.onStart && this.onStart.call(this, e);
            this.offset = song.position.getOffsetSize(this.el);
            this.proxy && this.proxy.css(this.offset).show();
            j(document).bind("mousemove", this.moveEvent).bind("mouseup", this.stopEvent);
            this.setXY(e);
            song.stopEvent(e);
        },
        move: function () {
        },
        removeEvent: function () {
            j(document).unbind("mousemove", this.moveEvent).unbind("mouseup", this.stopEvent);
            this.proxy && this.proxy.hide();
            this.onStop && this.onStop.call(this);
        },
        destroy: function () {
            this.proxy = null;
            this.el = null;
            this.handler = null;
            this.moveEvent = null;
            this.stopEvent = null;
        }
    });
    //****************************resize**********************************
    song.resize = function (el, options) {
        song.resize.base.constructor.call(this, el, options);
    };
    song.extend(song.dd, song.resize, {
        setXY: function (e) {
            this.x = e.pageX;
            this.y = e.pageY;
        },
        move: function (e) {
            if (!this.lockX) {
                this.width = Math.max(this.offset.width + e.pageX - this.x, this.minWidth);
                this.proxy ? this.proxy.width(this.width) : (this.moveSet && this.el.width(this.width));
            }
            ;
            if (!this.lockY) {
                this.height = Math.max(this.offset.height + e.pageY - this.y, this.minHeight);
                this.proxy ? this.proxy.height(this.height) : (this.moveSet && this.el.height(this.height));
            }
            ;
            this.onMove && this.onMove.call(this, e);
            song.stopEvent(e);
        },
        stop: function () {
            this.removeEvent();
            if (this.proxy) {
                this.lockY || this.el.height(this.height);
                this.lockX || this.el.width(this.width);
            }
        }
    });
    //****************************drag**********************************
    song.drag = function (el, options) {
        var client = song.position.client();
        this.maxBottom = client.height;
        this.maxRight = client.width;
        song.drag.base.constructor.call(this, el, options);
    };
    song.extend(song.dd, song.drag, {
        minLeft: 0,
        minTop: 0,
        limit: true,
        cursor: "move",
        loaded: function () {
            this.el.css({position: "absolute"});
        },
        setXY: function (e) {
            this.x = e.pageX - this.offset.left;
            this.y = e.pageY - this.offset.top;
            this.scroll = song.position.scroll();
            var el = this.handler.get(0);
            el.setCapture && el.setCapture();
        },
        move: function (e) {
            var l = e.pageX - this.x, t = e.pageY - this.y;
            if (!this.lockX) {
                this.left = e.pageX - this.x;
                if (this.limit) {
                    this.left = Math.max(Math.min(this.left, this.maxRight - this.offset.width + this.scroll.left), this.scroll.left + this.minLeft);
                }
                var l = {left: this.left};
                this.proxy ? this.proxy.css(l) : this.el.css(l);
            }
            if (!this.lockY) {
                this.top = e.pageY - this.y;
                if (this.limit) {
                    this.top = Math.max(Math.min(this.top, this.maxBottom - this.offset.height + this.scroll.top), this.scroll.top + this.minTop);
                }
                var t = {top: this.top};
                this.proxy ? this.proxy.css(t) : this.el.css(t);
            }
            song.stopEvent(e);
        },
        stop: function () {
            this.removeEvent();
            if (this.proxy) {
                this.lockX || this.el.css({left: this.left});
                this.lockY || this.el.css({top: this.top});
            }
            var el = this.handler.get(0);
            el.releaseCapture && el.releaseCapture();
        }
    });
})(window.song, window.jQuery);