/**
 * Created by song on 2017/9/11.
 */
;(function (song, $) {
    $.extend(song, {
        mgr: {},
        addCmp: function (cmp) {
            if (!song.mgr[cmp.id]) {
                song.mgr[cmp.id] = cmp;
            }
            ;
        },
        getCmp: function (id) {
            return song.mgr[id] || null;
        },
        deleteCmp: function (id) {
            var cmp = song.mgr[id];
            if (cmp) {
                delete song.mgr[id];
            }
        },
        hideCmp: function (type) {
            for (var i in song.mgr) {
                var cmp = song.mgr[i];
                (cmp instanceof type) && cmp.hide && cmp.hide();
            }
        },
        control: function (defaults, options) {
            //控件基类
            this.setOptions(defaults, options);
            this.init && this.init();
            this.render && this.render();
            this.loaded && this.loaded();
            song.addCmp(this);
        },
        destroy: function () {
            //控件销毁
            for (var id in song.mgr) {
                var cmp = song.getCmp(id);
                cmp.destroy && cmp.destroy();
                delete song.mgr[id];
            }
            delete song.mgr;
        }
    });
    $.extend(song.control.prototype, {
        events: {},
        getType: function () {
            return "song.control";
        },
        setOptions: function (defaults, options) {
            this.type = this.getType();
            this.id = song.id();
            $.extend(this, defaults, options);
        },
        fire: function (eventName) {
            if (this[eventName]) {
                var args = song.slice(arguments, 1);
                this[eventName].apply(this, args)
            }
        },
        destroy: function () {
        }
    });
    //执行销毁
    $(window).bind("unload", song.destroy);
    $.extend(song, {
        getSpace: function (el, items) {
            var len = items.length, num = 0;
            for (var i = 0; i < len; i++) {
                switch (items[i]) {
                    case "mt":
                        num += parseInt(el.css("margin-top")) || 0;
                        break;
                    case "mb":
                        num += parseInt(el.css("margin-bottom")) || 0;
                        break;
                    case "ml":
                        num += parseInt(el.css("margin-left")) || 0;
                        break;
                    case "mr":
                        num += parseInt(el.css("margin-right")) || 0;
                        break;
                    case "pt":
                        num += parseInt(el.css("padding-top")) || 0;
                        break;
                    case "pb":
                        num += parseInt(el.css("padding-bottom")) || 0;
                        break;
                    case "pl":
                        num += parseInt(el.css("padding-left")) || 0;
                        break;
                    case "pr":
                        num += parseInt(el.css("padding-right")) || 0;
                        break;
                    case "bt":
                        num += parseInt(el.css("border-top-width")) || 0;
                        break;
                    case "bb":
                        num += parseInt(el.css("border-bottom-width")) || 0;
                        break;
                    case "bl":
                        num += parseInt(el.css("border-left-width")) || 0;
                        break;
                    case "br":
                        num += parseInt(el.css("border-right-width")) || 0;
                        break;
                }
            }
            return num;
        }
    });
})(window.song, window.jQuery)