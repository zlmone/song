/**
 * Created by 王松华 on 2017/8/25.
 */
;(function (cmp, $, song) {
    cmp.view = song.getClass({
        init: function () {
            var that = this;
            this.ready && $(window.document).bind("ready", function () {
                //在ie下，dom渲染比较慢，页面初始化时先显示loading
                //cmp.loading.show();
                var isie = $.browser.msie;
                if (isie) {
                    //因里面有布局操作，ie下不延迟有高度差异。页面控件渲染完毕，则隐藏页面loading
                    //setTimeout(function () {
                    that.ready.call(that);
                    hideLoading();
                    // }, 0);
                } else {
                    that.ready.call(that);
                    hideLoading();
                }
            });
        },
        val: function (selector) {
            return $(selector).val().trim();
        },
        url: function (url, params) {
            return this.param(url, params).getUrl();
        },
        param: function (url, params) {
            return new song.param(cmp.view.root + url, params).stamp();
        },
        setObject: function (obj, opt) {
            if (!this[obj]) {
                this[obj] = {};
            }
            for (var key in opt) {
                this[obj][key] = opt[key];
            }
        },
        setRoute: function (opt) {
            this.setObject("route", opt);
            return this;
        },
        routeUrl: function (routeName, params) {
            return this.url(this["route"][routeName], params);
        },
        idRouteUrl: function (routeName, params_id) {
            return this.routeUrl(routeName, cmp.param.id(params_id));
        },
        setConfig: function (opt) {
            this.setObject("config", opt);
        },
        getConfig: function (key) {
            return this.config[key];
        }
    });
    function hideLoading() {
        if (window.top && window.top.cmp.loading) {
            window.top.cmp.loading.hide();
        }
    }
    $.extend(cmp.view, {
        root: "/",
        rootUrl:function (url) {
            return cmp.view.root+url;
        }
    });
})(window.cmp, window.jQuery, window.song)