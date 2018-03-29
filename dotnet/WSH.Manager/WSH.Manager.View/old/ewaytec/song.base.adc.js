/*
author:                 王松华
email:                  songhuaxiaobao@163.com
namespace:              Song.Base
content:                基础库
beforeLoad:             jQuery
dateUpdated:            2012-05-11
*/
(function (j) {
    var noop = function () { }, guid = 0, index = 1989;
    window.song = {
        version: "V1.0.0",
        //blankImg:"../Images/s.gif",
        mgr: {}, error: [], split: /[^, ]+/g,
        noop: noop,
        href: "javascript:void(0)",
        ie6: window.VBArray && !window.XMLHttpRequest,
        addCmp: function (cmp) {
            if (!song.mgr[cmp.id]) { song.mgr[cmp.id] = cmp; };
        },
        getCmp: function (id) {
            return song.mgr[id] || null;
        },
        deleteCmp: function (id) {
            var cmp = song.mgr[id];
            if (cmp) { delete song.mgr[id]; }
        },
        hideCmp: function (type) {
            for (var i in song.mgr) {
                var cmp = song.mgr[i];
                (cmp instanceof type) && cmp.hide && cmp.hide();
            }
        },
        id: function () {
            return "song-" + guid++;
        },
        zIndex: function () {
            return index++;
        },
        getClass: function () {
            return function () {
                this.init.apply(this, arguments);
            }
        },
        extend: function (parent, children, overrides) {
            //控件继承
            if (typeof (parent) != "function") { return children; };
            children.base = parent.prototype;
            children.base.constructor = parent;
            var target = noop;
            target.prototype = parent.prototype;
            children.prototype = new target();
            children.prototype.constructor = children;
            overrides && j.extend(children.prototype, overrides);
            return children;
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
        },
        log: function () {
            var arr = Array.prototype.slice.call(arguments);
            var div = j("#SONGERRORELEMENT");
            if (div.length <= 0) {
                var cls = { position: "absolute", bottom: 0, left: 0, width: 300, textAlign: "left", fontSize: "12px",
                    border: "1px solid #e9d315", background: "#f9f2ba", color: "#5b5316", display: "none",
                    padding: "6px", lineHeight: "22px"
                };
                div = j("<div id='SONGERRORELEMENT'>").css(cls).appendTo("body");
            }
            song.error = song.error.concat(arr);
            div.html(song.error.join("<br>"));
            div.slideDown();
            setTimeout(function () {
                div.slideUp();
            }, 5000);
        }
    };
    j.extend(song.control.prototype, {
        events: {},
        getType: function () {
            return "song.control";
        },
        setOptions: function (defaults, options) {
            this.type = this.getType();
            this.id = song.id();
            j.extend(this, defaults, options);
        },
        fire: function (type) {
            //未完....
        },
        on: function (type, fn) {
            this.events[type] = fn;
            //未完....
        },
        hasEvent: function (type) {
            return this.events[type] === undefined;
        },
        unon: function (type) {
            if (type) {
                this.hasEvent(type) && delete this.events[type];
            } else {
                //未完....
            }
        },
        destroy: function () { }
    });
    //执行销毁
    j(window).bind("unload", song.destroy);
    try { document.execCommand("BackgroundImageCache", false, true); } catch (e) { }
    //---------------------------------string-prototype-extend---------------------------------
    j.extend(String.prototype, {
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
            var d = this.length - str.length; return d >= 0 && this.lastIndexOf(str) == d;
        },
        truncate: function (len, trun) {
            if (!trun) { trun = "..." }; return this.length > len ? this.substring(0, len) + trun : this;
        },
        removeNumber: function () {
            return this.replace(/[^d]/g, "");
        },
        padLeft: function (len, pad) {
            pad = pad == null ? "0" : pad; var str = this;
            if (len > this.length) { for (var i = 0; i < len - this.length; i++) { str = pad + str; } }; return str;
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
                };
            }
            return str;
        },
        delEnd: function (str) {
            return this.endWith(str) ? this.substring(0, this.length - str.length) : this;
        },
        delStart: function (str) {
            return this.startWith(str) ? this.substring(str.length) : this;
        },
        subRight: function (len) {
            return this.slice(this.length - len);
        },
        subLeft: function (len) {
            return this.slice(0, len);
        },
        has: function (obj) {
            return this.indexOf(obj) > -1
        },
        toDate: function () {
            return new Date(Date.parse(this.replace(/-/g, "/")));
        },
        replaceAll: function (s1, s2) {
            return this.replace(new RegExp(s1, "gm"), s2);
        },
        cap: function () {
            return this.slice(0, 1).toUpperCase() + this.slice(1);
        }
    });
    //---------------------------------number-prototype-extend---------------------------------
    j.extend(Number.prototype, {

});
j.extend(Object, {
    count: function (obj) {
        var count = 0;
        for (var i in obj) {
            count++;
        }
        return count;
    },
    keys: function (obj) {
        var k = [];
        for (var i in obj) {
            k.push(i);
        }
        return k;
    }
});
//---------------------------------date-prototype-extend---------------------------------
j.extend(Date.prototype, {
    format: function (format) {
        var o = {
            "M+": this.getMonth() + 1, //month
            "d+": this.getDate(),    //day
            "H+": this.getHours(),   //hour
            "m+": this.getMinutes(), //minute
            "s+": this.getSeconds(), //second
            "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
            "S": this.getMilliseconds() //millisecond
        }
        if (/(y+)/.test(format)) format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
            }
        }
        return format;
    }
});
//---------------------------------array-extend---------------------------------
j.extend(Array, {
    remove: function (arr, index_value) {
        if (typeof (index_value) == "number") {
            arr.splice(index_value, 1);
        } else { var i = Array.indexOf(arr, index_value); if (i > -1) { arr.splice(i, 1); } }; return arr;
    },
    clear: function (arr) { arr.splice(0, arr.length); },
    indexOf: function (arr, value) {
        for (var i = 0; i < arr.length; i++) { if (arr[i] == value) { return i; } }; return -1;
    },
    has: function (arr, value) { return Array.indexOf(arr, value) > -1; },
    max: function (arr) {
        //正常用法
        //            for (var i = 0, maxValue = Number.MIN_VALUE; i < arr.length; i++){
        //                parseInt(arr[i]) > maxValue && (maxValue = arr[i]);
        //            }
        //	        return maxValue;
        //2B用法
        return Math.max.apply(Math, arr);
    },
    min: function (arr) {
        //正常用法
        //            for (var i = 0, minValue = Number.MAX_VALUE; i < arr.length; i++){
        //                parseInt(arr[i]) < minValue && (minValue = arr[i]);
        //            }
        //	        return minValue;
        //2B用法
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
    },
    hasRepeat: function (arrs) {
        var a = arrs.sort();
        for (var i = 0; i < a.length; i++) {
            if (a[i] == a[i + 1]) {
                return true;
            }
        }
        return false;
    }
});
//---------------------------------song-extend---------------------------------
j.extend(song, {
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
    domName: function (name) {
        return document.getElementsByName(name);
    },
    getType: function (val) {
        if (val.getType) { return val.getType(); };
        if (val == null) { return "null"; };
        if (val.nodeType && val.nodeType == 1) { return "element"; };
        return Object.prototype.toString.apply(val).replace("[object ", "").replace("]", "").toLowerCase();
    },
    isEl: function (obj) {
        return song.getType(obj) == "element";
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
    clearSelection: function () {
        window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty();
    },
    bind: function (obj, fun) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function (result) { if (result) { args.push(result); } return fun.apply(obj, args); }
    },
    bindWithEvent: function (obj, fun) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function (event) { return fun.apply(obj, [event || window.event].concat(args)); }
    },
    stopEvent: function (e) {
        e.preventDefault(); e.stopPropagation();
    },
    getSpace: function (el, items) {
        var len = items.length, num = 0;
        for (var i = 0; i < len; i++) {
            switch (items[i]) {
                case "mt": num += parseInt(el.css("margin-top")) || 0; break;
                case "mb": num += parseInt(el.css("margin-bottom")) || 0; break;
                case "ml": num += parseInt(el.css("margin-left")) || 0; break;
                case "mr": num += parseInt(el.css("margin-right")) || 0; break;
                case "pt": num += parseInt(el.css("padding-top")) || 0; break;
                case "pb": num += parseInt(el.css("padding-bottom")) || 0; break;
                case "pl": num += parseInt(el.css("padding-left")) || 0; break;
                case "pr": num += parseInt(el.css("padding-right")) || 0; break;
                case "bt": num += parseInt(el.css("border-top-width")) || 0; break;
                case "bb": num += parseInt(el.css("border-bottom-width")) || 0; break;
                case "bl": num += parseInt(el.css("border-left-width")) || 0; break;
                case "br": num += parseInt(el.css("border-right-width")) || 0; break;
            }
        }
        return num;
    }
});
//---------------------------------position---------------------------------
song.position = {
    dd: function (win) { return (win ? win.document.documentElement : document.documentElement); },
    db: function (win) { return (win ? win.document.body : document.body); },
    maxClient: function (win) {
        var doc = song.position.dd(win);
        return { width: Math.max(doc.clientWidth, doc.scrollWidth), height: Math.max(doc.clientHeight, doc.scrollHeight), top: 0, left: 0 };
    },
    client: function (win) { var doc = song.position.dd(win); return { width: doc.clientWidth, height: doc.clientHeight, top: 0, left: 0 }; },
    scroll: function (win) {
        var dd = song.position.dd(win), db = song.position.db(win);
        return { left: Math.max(dd.scrollLeft, db.scrollLeft), top: Math.max(dd.scrollTop, db.scrollTop) }
    },
    screen: function () { return { width: screen.availWidth, height: screen.availHeight} },
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
        var parent = j(options.parent || window), offset = parent.offset();

        var w = el.width(), h = el.height(), maxWidth = parent.width(), maxHeight = parent.height();
        //            if(options.left=="100%"){
        //                el.width(w);
        //            };
        //            if(options.top=="100%"){
        //                el.height(h);
        //            };
        var l = song.position.toNumber(options.left, (maxWidth - w)) + parent.scrollLeft();
        var t = song.position.toNumber(options.top, (maxHeight - h)) + parent.scrollTop();
        if (offset) {
            l += offset.left; t += offset.top;
        }
        el.css({ top: t, left: l });
    },
    getOffsetSize: function (el) {
        el = j(el);
        var offset = el.offset() || {};
        offset["width"] = el.outerWidth();
        offset["height"] = el.outerHeight();
        return offset;
    }
};
//---------------------------------follow---------------------------------
song.follow = function (el, opts) {
    this.el = j(el).css("position", "absolute");
    this.auto = false;
    this.elW = this.el.outerWidth();
    this.elH = this.el.outerHeight();
    this.client = song.position.client();
    j.extend(this, { autoDir: true, align: "left", dir: "bottom", autoSet: true, top: 0, left: 0, fix: 0 }, opts);
    this.offset = song.position.getOffsetSize(j(this.follow));
    if (this.autoSet == true) { this.set(); }
}
song.follow.prototype = {
    set: function () {
        this["get" + this.dir]();
        this.el.css({ left: this.left, top: this.top });
    },
    getbottom: function () {
        var t = this.offset.top + this.offset.height;
        //防止底部溢出
        if (this.autoDir == true && this.auto == false && (t + this.elH + this.fix) > this.client.height) {
            this.auto = true; this.gettop();
        } else {
            this.top = t + this.fix; this.getLeftForBT();
        }
    },
    gettop: function () {
        var t = this.offset.top - this.elH;
        //防止头部溢出
        if (this.autoDir == true && this.auto == false && t - this.fix < 0) {
            this.auto = true; this.getbottom();
        } else {
            this.top = t - this.fix; this.getLeftForBT();
        }
    },
    getleft: function () {
        var l = this.offset.left - this.elW;
        //防止左边溢出
        if (this.autoDir == true && this.auto == false && l - this.fix < 0) {
            this.auto = true; this.getright();
        } else {
            this.left = l - this.fix; this.getTopForLR();
        }
    },
    getright: function () {
        var l = this.offset.left + this.offset.width;
        //防止右边溢出
        if (this.autoDir == true && this.auto == false && (l + this.elW + this.fix) > this.client.width) {
            this.auto = true; this.getleft();
        } else {
            this.left = l + this.fix; this.getTopForLR();
        }
    },
    getLeftForBT: function () {
        this.left = this.offset.left;
        if (this.align == "center") {
            this.left = this.offset.left + (this.offset.width - this.elW) / 2;
        }
        if (this.align == "right" || (this.left + this.elW) > this.client.width) {
            this.left = this.offset.left + this.offset.width - this.elW - 1;
        }
        if (this.left < 0) { this.left = 0; }
    },
    getTopForLR: function () {
        this.top = this.offset.top;
        if (this.align == "center") {
            this.top = this.offset.top + (this.offset.height - this.elH) / 2;
        }
        if (this.align == "right" || (this.top + this.elH) > this.client.height) {
            this.top = this.offset.top + this.offset.height - this.elH;
        }
        if (this.top < 0) { this.top = 0; }
    }
}
//---------------------------------builder---------------------------------
song.builder = function (line) { this.arr = []; this.line = line || "\n\r" }
song.builder.prototype = {
    add: function (str) { this.arr.push(str); return this; },
    addFmt: function () {
        // var arg = Array.prototype.slice.call(arguments).slice(1);
        var arg = arguments;
        for (var i = 1; i < arg.length; i++) {
            arg[0] = arg[0].replace("{" + (i - 1) + "}", arg[i]);
        };
        this.arr.push(arg[0]);
        return this;
    },
    addLine: function (str) { this.arr.push(this.line); this.arr.push(str); return this; },
    toString: function () { return this.arr.join(""); }
};
song.kc = {
    tab: 9, back: 8, enter: 13, shift: 16, ctrl: 17, esc: 27, del: 46, left: 37, up: 38, right: 39, down: 40,
    f1: 112, f2: 113, f3: 114, f4: 115, f5: 116, f7: 118, f8: 119, f9: 120, f10: 121, f11: 122, f12: 123,
    zero: 48, one: 49, nine: 57, minus: 189, dot: 190, empty: 32, a: 65, z: 90, x: 88, c: 67, v: 86, start: 36, end: 35
};
song.key = function (el, options) {
    this.el = j(el);
    j.extend(this, song.key.defaults, options);
    var me = this;
    this.el.bind(this.eventType, function (e) {
        for (var i in me.items) {
            if (e.kc == song.kc[i] || i == "all") {
                if (me.items[i].call(me.scope || me, e) == false) {
                    e.stopProparption(); e.preventDefault();
                }
            }
        }
    });
};
song.key.defaults = {
    eventType: "keydown", items: []
};
//---------------------------------path---------------------------------
song.path = {
    has: function (url) {
        return url.indexOf("/") > -1;
    },
    getFileName: function (url) {
        if (this.has(url)) {
            var arr = url.split("/"), name = arr[arr.length - 1], param = name.indexOf("?");
            return param == -1 ? name : name.substring(0, param);
        } return url;
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
        var l = url.lastIndexOf("/");
        if (l > -1) {
            return url.substring(0, l + 1);
        } return null;
    },
    parse: function (url) {
        var m = String(url).replace(/^\s+|\s+$/g, '').match(/^([^:\/?#]+:)?(\/\/(?:[^:@]*(?::[^:@]*)?@)?(([^:\/?#]*)(?::(\d*))?))?([^?#]*)(\?[^#]*)?(#[\s\S]*)?/);
        return (m ? {
            href: m[0] || '',
            protocol: m[1] || '',
            authority: m[2] || '',
            host: m[3] || '',
            hostname: m[4] || '',
            port: m[5] || '',
            pathname: m[6] || '',
            search: m[7] || '',
            hash: m[8] || ''
        } : null);
    },
    abs: function (url) {
        var a = document.createElement("img");
        a.src = url; url = a.src; a.src = null; a = null;
        return url;
    },
    hasFile: function (url) {
        var isjs = this.getExtension(url) == ".js",
            type = isjs ? "src" : "href",
            files = document.getElementsByTagName(isjs ? "script" : "link"), len = files.length, file;
        for (var i = 0; i < len; i++) {
            file = files[i][type];
            if (file && (this.abs(url) == this.abs(file))) {
                return true;
            }
        }
    }
};
//---------------------------------param---------------------------------
song.param = function (url, params) {
    this.url = url || window.location.href;
    this.format();
    this.params = {};
    this.get().add(params);
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
    },
    getUrl: function () {
        this.removeSearch();
        if (!this.hasSearch()) { this.url += "?"; } else {
            this.url.endWith("?") || (this.url += "&");
        };
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
        if (!search) { return this; }
        var pairs = search.split("&");
        for (var i = 0; i < pairs.length; i++) {
            var arr = pairs[i].split("=");
            this.params[arr[0]] = arr[1];
        };
        return this;
    },
    add: function (key, value, isDecode) {
        if (!key) { return this; }
        if (typeof (key) == "object") {
            for (var i in key) {
                this.add(i, key[i], isDecode);
            }
        } else {
            this.params[key] = (isDecode == false ? value : decodeURIComponent(value));

        }
        return this;
    },
    addVal: function (id, isDecode) {
        var val = j("#" + id).val();
        return this.add(id, val, isDecode);
    },
    addAttr: function (id, attrName, isDecode) {
        var val = j("#" + id).attr(attrName);
        return this.add(id, val, isDecode);
    }
}
//*******************************************iframe*******************************************
var dataName = '@SONG.DATANAME';
song.top = function () {
    //获取最外层的window
    var top = window,
        test = function (name) {
            try {
                var doc = window[name].document;
                doc.getElementsByTagName; // chrome 本地安全限制
            } catch (e) {
                return false;
            }
            return window[name] && doc.getElementsByTagName('frameset').length === 0;
        }
    if (test('top')) {
        top = window.top;
    } else if (test('parent')) {
        top = window.parent;
    };
    return top;
} ();
//跨框架传递数据
song.data = function (name, value) {
    var top = song.top, cache = top[dataName] || {};
    top[dataName] = cache;
    if (value != undefined) {
        cache[name] = value;
    } else {
        return cache[name];
    }
    return cache;
};
song.removeData = function (name) {
    var cache = song.top[dataName];
    if (cache && cache[name]) delete cache[name];
};
song.clearData = function () {
    if (song.top[dataName]) { delete song.top[dataName]; }
};
j(window).bind("unload", song.clearData);
//iframe操作
song.iframe = {
    //自适应高度和宽度
    auto: function (id, isWidth) {
        var frame = song.dom(id);
        frame.height = "10px";
        song.loaded(id, function () {
            var pos = song.position.maxClient(this.contentWindow);
            this.height = pos.height + "px";
            isWidth && (this.width = pos.width + "px")
        });
    }
}
})(window.jQuery);

/*
author:                 王松华
email:                  songhuaxiaobao@163.com
url:                    http://www.netstudio80.com
namespace:              Cmp
content:                项目扩展
beforeLoad:             jQuery,song,ligerui,adc
dateUpdated:            2012-05-11
*/
(function (song, j) {
    //if(song==undefined){throw new Error("song is not using");}
    j.extend(song, {
        root: function () {
            return clsMainMaster.sHeadUrl;
            return "";
        },
        jsonRequest:function(url,data,success,end){
            success=success || function(data){
                alert(data.msg);
                if (data.result) {
                    location.href.reload();
                }
            }
            $.ajax({
                url: url,
                data:data,
                type: "post", dataType: "json",
                success:function(data){
                    success(data);
                    end && end();
                },
                error: function (xhr, err) {
                    alert("服务器繁忙，请稍后再试！"+err);
                    end && end();
                }
            });
        },
        url: function (controller, action, params) {
            return new song.param(song.root() + controller + "/" + action, params);
        },
        open: function (url, width, height) {
            //            j.extend(this,{ width: 600, height: 300, left: 0, top: 0, target: "_blank" },opts); //_blank
            //            this.top = ((screen.height - this.height) / 2) - 40; this.left = (screen.width - this.width) / 2; 
            //            var sb = new song.builder();
            //            sb.add("toolbar=no,location=no,directions=no,status=no,revisable=no,scrollbars=yes,menubar=no,");
            //            sb.addFmt("width={0}px,height={1}px,top={2}px,left={3}px", this.width, this.height, this.top, this.left);
            //            window.open(this.url, this.target, sb.toString());
            adc.open({ url: url, width: width || 850, height: height || 450 });
        },
        //获取已经实例化的ui对象
        getLiger: function (id, type) {
            return LigerUIManagers[id + "_" + type];
        },
        grid: function (id, options) {
            //如果传入id则返回grid实例
            var dg;
            if (!options) {
                dg = this.getLiger(options, "Grid");
            }
            if (!dg) {
                //添加默认配置
                options=j.extend({
                    allowHideColumn: false,
                    switchPageSizeApplyComboBox: false,
                    enabledSort: false,
                    pageSizeOptions: [5,8, 10, 15, 20, 30],
                    onError: function () {
                        adc.showGridError({ grid: '#' + id, msg: "网络繁忙请稍候再试！" });
                    },
                    onAfterShowData: function (grid, data) {
                        var rowLength = j(".l-grid-row", grid).length;
                        if (rowLength == 0) {
                            adc.showGridMsg({ grid: '#' + id, msg: "找不到数据！" });
                        }
                        options.afterLoad && options.afterLoad.call(grid, rowLength);
                    }
                },options);
                dg = j("#" + id).ligerGrid(options);
            }
            return dg;
        },
        combox: function (id, options) {
            var cbo;
            if (!options) {
                cbo = this.getLiger(id, "ComboBox");
            }
            if (!cbo) {
                options = j.extend({
                    slide: false,
                    width: 200
                }, options || {});
                cbo = j("#" + id).ligerComboBox(options);
            }
            return cbo;
        },
        toolbar: function (id, items) {
            var tb;
            if (!items) {
                cbo = this.getLiger(id, "ToolBar");
            }
            if (!tb) {
                tb = j('#' + id).ligerToolBar({ items: items });
            }
            return tb;
        },
        datePicker: function (id, options) {
            j.extend(options, {
                format: "yyyy-MM-dd"
            });
            return j("#" + id).ligerDateEditor(options);
        }
    });
    //扩展grid
    j.extend(song.grid, {
        text: function (id, msg) {
            j('#' + id).html('<div class="orange_tip">{0}</div>'.format(msg));
        },
        reload: function (id, url, isFirst) {
            var grid = song.grid(id);
            if (url) {
                grid.setOptions({ url: url });
            }
            if (isFirst) {
                grid.changePage("first");
            }
            grid.loadData(true);
        },
        view: function (id, url) {
            j("#" + id).wait().load(j.url(url, { _: String.guid() }));
        },
        //得到选中行的数据
        getId: function (id, key) {
            var rowData = song.grid(id).getSelectedRow();
            if (rowData) {
                return key ? rowData[key] : rowData;
            }
            return null;
        },
        //得到复选框选中的数据
        getIds: function (id, key) {
            var rowsData = song.grid(id).getCheckedRows();
            if (key) {
                var ids = [], i = 0, len = rowsData.length;
                for (; i < len; i++) {
                    ids.push(rowsData[i][key]);
                }
                return ids.join(",");
            }
            return rowsData;
        },
        //判断是否选择了数据
        checkId: function (id, nullMsg, removeMsg) {
            var idValid = ((typeof id == "string") ? id == "" : id.length <= 0);
            if (id != null && idValid) {
                j.ligerDialog.warn(nullMsg || "请至少选择一条记录进行操作！");
                return false;
            }
            if (removeMsg) {
                return confirm(removeMsg == "default" ? "确定删除选中的记录吗？" : removeMsg);
            }
        },
        detailGrid: function () {
            
        }
    });
    //扩展列渲染器
    song.render = {
        //截断字符指定长度渲染器
        truncate: function (data, len) {
            var val = data.toString().truncate(len);
            return '<span title="{0}">{1}</span>'.format(data, val);
        },
        //链接渲染器
        link: function (text, fnName, args) {
            var param = "", i = 0;
            if (args && args.length > 0) {
                var len = args.length;
                for (; i < len; i++) {
                    if (typeof args[i] == "string") args[i] = "'" + args[i] + "'";
                }
                param = args.join(",");
            }
            return '<a href="javascript:void(0)" onclick="{0}({1});">{2}</a>'.format(fnName, param, text);
        },
        //编辑列和删除渲染器
        cmd: function (id, editFnName, delFnName, editText, delText) {
            return this.edit(id, editFnName, editText) + "&nbsp;" + this.del(id, delFnName, delText);
        },
        //修改列渲染器
        edit: function (id, editFnName, editText) {
            return this.link(editText || "修改", editFnName, [id]);
        },
        //删除列渲染器
        del: function (id, delFnName, delText) {
            return tihs.link(delText || "删除", delFnName, [id]);
        },
        yesno:function(property){
            return function(data){
                return data[property]==1 ? "是" : "否";
            }
        }
    };
    //ADC平台分页扩展
    song.pager = {
        init: function (url) {
            j("a[pageLink='True']").live("click", function () {
                j("#" + this.target).wait().load(j.url(url || this.href, { _: String.guid() })); return false;
            });
        }
    };
    //表单扩展
    song.form={
        get:function(id){
            return  id ? (typeof id=="string" ? j("#"+id) : j(id)) : j(document.forms[0]);
        },
        ajaxSubmit:function(form,callback){
            var form=this.get(form);
            if(!form.valid()){
                return false;
            }
            j.post(form.attr("action"),form.serialize(),callback || song.noop,"json")
            return true;
        },
        submit:function(){
            var form=this.get(form);
            if(!form.valid()){
                return false;
            }
            form.get(0).submit();
            return true;
        }
    }
    //验证扩展
    song.valid = {
        regex: {
            email: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
            en: /^[A-Za-z]+$/,
            cn: /^[\u0391-\uFFE5]+$/,
            url: /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
            ip: /^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$/,
            zip: /^[1-9]\d{5}$/, //邮政编码
            alpha: /^[0-9a-zA-Z\_]+$/, //数字字母下划线
            tel: /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/,
            mobile: /^1[3|4|5|8][0-9]\d{4,8}$/, //手机
            int: /^(-|\+)?\d+$/,
            float: /^(-?\d+)(\.\d+)?$/,
            idCard: /^\d{15}(\d{2}[A-Za-z0-9])?$/,
            carNo: /^[\u4E00-\u9FA5][\da-zA-Z]{6}$/, // 车牌号码（例：粤J12350）
            qq: /^[1-9]\d{4,10}$/,
            msn: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
        },
        check: function (type, value) {
            if (this.regex.hasOwnProperty(type)) { return this.regex[type].test(value); }
            return type.test(value);
        },
        checkEmpty: function (obj) {
            if (!obj) { return true; } var msg = "";
            for (var i in obj) { if (song.dom(i).value.trim() == "") { msg += "--" + obj[i] + "\n"; } }
            if (msg == "") { return true; } else { alert(msg); return false; }
        },
        dateRange: function (idStart, idEnd, msg) {
            var dsValue = song.dom(idStart).value;
            var de = song.dom(idEnd), deValue = de.value;
            if (Date.parse(dsValue.replace(/\-/g, "/")) > Date.parse(deValue.replace(/\-/g, "/"))) {
                alert(msg || "开始日期不能大于结束日期！");
                de.focus();
                return false;
            }
            return true;
        }
    };
    //扩展jquery
    j.fn.extend({
        disabled:function(value){
            return value ? (this.attr("disabled","disabled")) : this.removeAttr("disabled");
        },
        checked:function(value){
            return value ? this.attr("checked","checked") : this.removeAttr("checked");
        },
        isDisabled:function(){
            return this.attr("disabled")=="disabled";
        }
    });
})(window.song, window.jQuery);
