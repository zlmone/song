/*
 author:                 王松华
 email:                  songhuaxiaobao@163.com
 namespace:              Song.Base
 content:                基础库
 beforeLoad:             jQuery
 dateUpdated:            2012-07-10
 */
;(function ($) {
    var noop = function () {}, idflg = 0, index = 168888;
    window.song = {
        version: "V2.0.0",
        split: /[^, ]+/g,
        resizeDelay: 100,
        noop: noop,
        href: "javascript:void(0)",
        ie6: window.VBArray && !window.XMLHttpRequest,
        id: function (flg) {
            var d = "_song_";
            if (flg) {
                d += flg + "_";
            }
            return d + (idflg++) + "_";
        },
        zIndex: function () {
            return index++;
        },
        getClass: function (options) {
            var fn = function () {
                $.extend(this, arguments[0] || {});
                this.init && this.init();
            }
            options && (fn.prototype = options);
            return fn;
        },
        extend: function (parent, children, overrides) {
            //控件继承
            if (typeof (parent) != "function") {
                return children;
            }
            children.base = parent.prototype;
            children.base.constructor = parent;
            var target = noop;
            target.prototype = parent.prototype;
            children.prototype = new target();
            children.prototype.constructor = children;
            overrides && $.extend(children.prototype, overrides);
            return children;
        }
    };
    if (song.ie6) {
        try {
            document.execCommand("BackgroundImageCache", false, true);
        } catch (e) {
        }
    }
    //---------------------------------string-prototype-extend---------------------------------
    $.extend(String.prototype, {
        trim: function () {
            return this.replace(/^\s+|\s+$/g, '');
        },
        delTag: function () {
            return this.replace(/<[^>]+>/g, "");
        },
        startWith: function (str) {
            return this.indexOf(str) == 0;
        },
        endWith: function (str) {
            var d = this.length - str.length;
            return d >= 0 && this.lastIndexOf(str) == d;
        },
        truncate: function (len, trun) {
            if (!trun) {
                trun = "..."
            }
            return this.length > len ? this.substring(0, len) + trun : this;
        },
        padLeft: function (len, pad) {
            pad = pad == null ? "0" : pad;
            var str = this;
            if (len > this.length) {
                for (var i = 0; i < len - this.length; i++) {
                    str = pad + str;
                }
            }
            ;
            return str;
        },
        format: function () {
            var str = this, args = arguments;
            if (args.length > 0 && (typeof args[0] == "object")) {
                for (var i in args[0]) {
                    str = this.replace("{" + i + "}", args[0][i]);
                }
            } else {
                for (var i = 0; i < args.length; i++) {
                    str = str.replace("{" + (i) + "}", args[i]);
                }
                ;
            }
            return str;
        },
        delEnd: function (str) {
            return this.endWith(str) ? this.substring(0, this.length - str.length) : this;
        },
        delStart: function (str) {
            return this.startWith(str) ? this.substring(str.length) : this;
        },
        has: function (obj) {
            return this.indexOf(obj) > -1
        },
        replaceAll: function (s1, s2) {
            return this.replace(new RegExp(s1, "gm"), s2);
        },
        cap: function () {
            return this.slice(0, 1).toUpperCase() + this.slice(1);
        },
        escapeHTML: function () {
            return this.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
        },
        unescapeHTML: function () {
            return this.replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/&amp;/g, '&');
        },
        toJson: function () {
            //解析json字符串为json对象
            if (window.JSON && window.JSON.parse) {
                return window.JSON.parse(this);
            }
            return eval("(" + this + ")");
        }
    });
    //---------------------------------object-extend---------------------------------
    $.extend(Object, {
        toParams: function (obj) {
            var p = [];
            for (var i in obj) {
                p.push(i + "=" + obj[i]);
            }
            return p.join("&");
        },
        has: function (obj, key) {
            return !!obj[key];
        },
        count: function (o) {
            var n, count = 0;
            for (n in o) {
                if (o.hasOwnProperty(n)) {
                    count++;
                }
            }
            return count;
        }
    });
    //---------------------------------array-extend---------------------------------
    $.extend(Array, {
        remove: function (arr, index_value) {
            if (typeof (index_value) == "number") {
                arr.splice(index_value, 1);
            } else {
                var i = Array.indexOf(arr, index_value);
                if (i > -1) {
                    arr.splice(i, 1);
                }
            }
            ;
            return arr;
        },
        clear: function (arr) {
            arr.splice(0, arr.length);
        },
        indexOf: function (arr, value) {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == value) {
                    return i;
                }
            }
            ;
            return -1;
        },
        has: function (arr, value) {
            return Array.indexOf(arr, value) > -1;
        },
        max: function (arr) {
            return Math.max.apply(Math, arr);
        },
        min: function (arr) {
            return Math.max.apply(Math, arr);
        },
        sum: function (arr) {
            for (var sum = i = 0; i < arr.length; i++) {
                sum += parseInt(arr[i]);
            }
            return sum;
        },
        distinct: function (arr) {
            var results = arr.sort()
            for (var i = 1; i < results.length; i++) {
                if (results[i] === results[i - 1]) {
                    results.splice(i--, 1);
                }
            }
            return results;
        }
    });
    //---------------------------------song-extend---------------------------------
    $.extend(song, {
        dom: function (el, attrs) {
            if (typeof el === "string") {
                if (/<[^>]+>/.test(el)) {
                    var tag = el.replace(/<|>/g, '');
                    el = document.createElement(tag);
                    if (attrs) {
                        for (var name in attrs) {
                            /cls|class|className/.test(name) ? el.className = attrs[name] : el[name] = attrs[name];
                        }
                    }
                } else {
                    el = document.getElementById(el);
                }
            }
            return el;
        },
        loaded: function (el, callback) {
            el = song.dom(el);
            document.addEventListener ? j(el).bind("load", function () {
                    j(this).unbind("load");
                    callback.call(this);
                    el = null;
                }) : el.onreadystatechange = function () {
                    if (/loaded|complete/.test(this.readyState)) {
                        el.onreadystatechange = null;
                        callback.call(this);
                        el = null;
                    }
                }
        },
        slice: function (args, start) {
            return Array.prototype.slice.call(args).slice(start || 0);
        },
        clearSelection: function () {
            window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty();
        },
        stopEvent: function (e) {
            e.preventDefault();
            e.stopPropagation();
            return false;
        }
    });
    //---------------------------------position---------------------------------
    song.position = {
        dd: function (win) {
            return (win ? win.document.documentElement : document.documentElement);
        },
        db: function (win) {
            return (win ? win.document.body : document.body);
        },
        maxClient: function (win) {
            var doc = song.position.dd(win);
            return {
                width: Math.max(doc.clientWidth, doc.scrollWidth),
                height: Math.max(doc.clientHeight, doc.scrollHeight),
                top: 0, left: 0
            };
        },
        client: function (win) {
            var doc = song.position.dd(win);
            return {
                width: doc.clientWidth,
                height: doc.clientHeight,
                top: 0, left: 0
            };
        },
        scroll: function (win) {
            var dd = song.position.dd(win),
                db = song.position.db(win);
            return {
                left: Math.max(dd.scrollLeft, db.scrollLeft),
                top: Math.max(dd.scrollTop, db.scrollTop)
            }
        },
        screen: function () {
            return {width: screen.availWidth, height: screen.availHeight}
        },
        toNumber: function (value, max) {
            if (value != null && typeof value === "number") {
                return value;
            }
            if (value.endWith("px")) {
                value = parseInt(value);
            } else if (value.endWith("%")) {
                value = parseInt(max * value.split("%")[0] / 100);
            }
            return value;
        },
        setRegion: function (el, options) {
            el = j(el);
            options = $.extend({
                left: "50%",
                top: "50%"
            }, options);
            var parent = $(options.parent || window),
                offset = parent.offset(),
                w = el.outerWidth(),
                h = el.outerHeight(),
                maxWidth = parent.outerWidth(),
                maxHeight = parent.outerHeight(),
                l = song.position.toNumber(options.left, (maxWidth - w)) + parent.scrollLeft(),
                t = song.position.toNumber(options.top, (maxHeight - h)) + parent.scrollTop();
            if (offset) {
                l += offset.left;
                t += offset.top;
            }
            el.css({top: t, left: l});
        },
        getOffsetSize: function (el) {
            el = $(el);
            var offset = el.offset() || {};
            offset["width"] = el.outerWidth();
            offset["height"] = el.outerHeight();
            return offset;
        }
    };
    //---------------------------------builder---------------------------------
    song.builder = function (line) {
        this.arr = [];
        this.line = line || "\n\r"
    }
    song.builder.prototype = {
        add: function (str) {
            this.arr.push(str);
            return this;
        },
        addFmt: function () {
            var arg = arguments;
            for (var i = 1; i < arg.length; i++) {
                arg[0] = arg[0].replace("{" + (i - 1) + "}", arg[i]);
            }
            ;
            this.arr.push(arg[0]);
            return this;
        },
        addLine: function (str) {
            this.arr.push(this.line);
            this.arr.push(str);
            return this;
        },
        toString: function () {
            return this.arr.join("");
        }
    };
    song.kc = {
        tab: 9,
        back: 8,
        enter: 13,
        shift: 16,
        ctrl: 17,
        esc: 27,
        del: 46,
        left: 37,
        up: 38,
        right: 39,
        down: 40,
        zero: 48,
        one: 49,
        nine: 57,
        minus: 189,
        dot: 190,
        empty: 32,
        x: 88,
        c: 67,
        v: 86,
        start: 36,
        end: 35
    };
    //---------------------------------path---------------------------------
    song.path = {
        combine: function (path1, path2) {
            var split = this.getSplit(path1),
                iscomb = true;
            if (path1.endWith(split) || path2.startWidth(split)) {
                iscomb = false;
            }
            return path1 + (iscomb ? "" : split) + path2;
        },
        getSplit: function (url) {
            var splits = ["/", "\\"];
            for (var i = 0; i < splits.length; i++) {
                if (url.lastIndexOf(splits[i]) > -1) {
                    return splits[i];
                }
            }
            return null;
        },
        getFileName: function (url) {
            var split = this.getSplit(url);
            if (split) {
                var arr = url.split(split), name = arr[arr.length - 1], param = name.indexOf("?");
                return param == -1 ? name : name.substring(0, param);
            }
            return url;
        },
        getExtension: function (url) {
            var n = this.getFileName(url), l = n.lastIndexOf(".");
            return (n && l > -1) ? n.substring(l) : n;
        },
        getName: function (url) {
            var n = this.getFileName(url), l = n.lastIndexOf(".");
            return (n && l > -1) ? n.substring(0, l) : n;
        },
        getPath: function (url) {
            var split = this.getSplit(url);
            if (split) {
                var l = url.lastIndexOf(split);
                return url.substring(0, l + 1);
            }
            return null;
        }
    };
    //---------------------------------param---------------------------------
    song.param = function (url, params) {
        this.url = url || window.location.href;
        this.format();
        this.params = {};
        this.get().removeSearch().add(params);
    };
    song.param.prototype = {
        format: function () {
            this.url = this.url.replace("?&", "?").replace(/(&+)/g, "&").replace(/(#+)/g, "").delEnd("&");
            return this;
        },
        stamp: function () {
            this.params["_t"] = new Date().getTime();
            return this;
        },
        getSearch: function () {
            return this.hasSearch() ? this.url.substring(this.url.lastIndexOf("?") + 1) : null;
        },
        hasSearch: function () {
            return this.url.lastIndexOf("?") >= 0;
        },
        removeSearch: function () {
            this.hasSearch() && (this.url = this.url.substring(0, this.url.indexOf("?") + 1));
            return this;
        },
        getUrl: function () {
            if (!this.hasSearch()) {
                this.url += "?";
            } else {
                this.url.endWith("?") || (this.url += "&");
            }
            ;
            for (var i in this.params) {
                this.url += i + "=" + this.params[i] + "&";
            }
            return this.url.delEnd("&");
        },
        has: function (key) {
            return !!this.params[key];
        },
        get: function () {
            var search = this.getSearch();
            if (!search) {
                return this;
            }
            var pairs = search.split("&");
            for (var i = 0; i < pairs.length; i++) {
                var arr = pairs[i].split("=");
                this.params[arr[0]] = arr[1];
            }
            ;
            return this;
        },
        add: function (key, value, isDecode) {
            if (!key) {
                return this;
            }
            if (typeof (key) == "object") {
                for (var i in key) {
                    this.add(i, key[i], isDecode);
                }
            } else {
                this.params[key] = (isDecode == false ? value : encodeURIComponent(value));

            }
            return this;
        },
        addVal: function (id, isDecode) {
            var val = $("#" + id).val();
            return this.add(id, val, isDecode);
        },
        addAttr: function (id, attrName, isDecode) {
            var val = $("#" + id).attr(attrName);
            return this.add(id, val, isDecode);
        }
    }

})(window.jQuery)