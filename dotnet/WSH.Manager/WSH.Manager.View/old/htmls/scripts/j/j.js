/*
title:                      js-framework
content:               简化jquery操作dom
                              通用项目方法集合
                              通用组件函数封装
                              项目通用组件
                              扩展各种原型
author:                 wsh-j-王松华
version:                2.0
updateDate:        2011-7-5
*/
function dom(el, attrs) {
    var elem = el;
    if (typeof (el) == "string") {
        if (el.indexOf("<") != -1) {
            var tag = el.replace("<", "").replace(">", "");
            elem = document.createElement(tag);if (attrs != null) { dom.setFormatAttrs(elem, attrs);}
        } else {elem = document.getElementById(el);}
    }; return elem;
}
dom.setFormatAttrs = function (el, attrs) {
    for (var i in attrs) {
        var attrName = i;
        if (attrName == "cls" || attrName == "class" || attrName == "className") {
            el.className = attrs[i];
        } else {
            el.setAttribute(attrName, attrs[i]);
            //el[attrName] = attrs[i];
        }
    }
}
window.j = window.wsh = function (el) { return new j.fn.init(el); }
//-------------------Event--------------------------
j.event = function (objEvent) {
    var scroll = j.position.scroll();
    this.e = window.event || objEvent;
    this.target = this.e.srcElement || this.e.target;
    this.kc = this.keyCode = this.e.which || this.e.keyCode;
    this.x = this.e.pageX || (this.e.clientX + scroll.left);
    this.y = this.pageY || (this.e.clientY + scroll.top);
}
j.event.add = function (el, type, fn, handler) {
    handler = j.setDefault(handler, fn);
    if (el.addEventListener) {
        el.addEventListener(type, handler, false);
    } else {
        el.attachEvent("on" + type, handler);
    }
    var evt = { el:el, type: type, fn: fn, handler: handler };
    j.eventList.push(evt);
}
j.event.remove = function (i) {
    var list = j.eventList;
    var el = list[i].el;
    var fn = list[i].handler;
    var type = list[i].type;
    if (el.removeEventListener) {
        el.removeEventListener(type, fn, false);
    } else {
        el.detachEvent("on" + type, fn);
    }
    Array.remove(list, i);  
}
j.event.prototype = {
    getXY: function () { return { x: this.x, y: this.y }; },
    prevent: function () { if (this.e.preventDefault) { this.e.preventDefault(); } else { this.e.returnValue = false; }; return this; },
    stop: function () { if (this.e.stopPropagation) { this.e.stopPropagation(); } else { this.e.cancelBubble = true; }; return this; }
}
//-------------------模拟jQuery简化dom操作（不支持css选择器）--------------------------
j.fn = j.prototype = {
    init: function (el) {
        if (typeof (el) == "function") { this.ready(el); }
        else if (el instanceof j) { return el; }
        else { this.el = dom(el); }; return this;
    },
    ready: function (fn) {
        j(window).bind("load", fn);
    },
    val: function (value) { if (value == null) { return this.el.value; }; this.el.value = value; return this; },
    html: function (value) { if (value == null) { return this.el.innerHTML; }; this.el.innerHTML = value; return this; },
    attr: function (name, value) {
        if (value != null) { var obj = {}; obj[name] = value; dom.setFormatAttrs(this.el, obj); } else {
            if (typeof (name) == "string") {
                return this.el.getAttribute(name);
            } else { dom.setFormatAttrs(this.el, name); }
        }; return this;
    },
    bind: function (type, fn, args) {
        var el = this.el;
        var handler = function (e) { var evt = new j.event(e); fn.call(el, evt, args); }
        j.event.add(el, type, fn, handler); return this;
    },
    unbind: function (type, fn) {
        var list = j.eventList;
        for (var i = 0; i < list.length; i++) {
            if (list[i].el == this.el && list[i].type == type) {
                if (fn == null) {
                    j.event.remove(i); i--;
                } else {
                    if (fn == list[i].fn) { j.event.remove(i); i--; }
                }
            }
        }; return this;
    },
    on: function (type, fn, args) { return this.bind(type, fn, args); },
    unon: function (type, fn) { return this.unbind(type, fn); },
    hover: function (fn1, fn2) { return this.bind("mouseover", fn1).bind("mouseout", fn2); },
    setFormatStyle: function (name, value) {
        if (name == "float") { name = j.browser.ie ? "styleFloat" : "cssFloat"; }
        if (name == "opacity") { this.opacity(value); } else {
            name = name.replace(/-([a-z])/ig, function (all, l) { return l.toUpperCase(); });
            this.el.style[name] = value;
        }
    },
    css: function (key, val) {
        if (typeof (key) == "object") { for (var i in key) { this.setFormatStyle(i, key[i]); } } else {
            if (val == null) {
                var styles = this.el.currentStyle || document.defaultView.getComputedStyle(this.el, null); return styles[key];
            } else { this.setFormatStyle(key, val); }
        }; return this;
    },
    getBorder: function () { return parseInt(this.css("borderWidth")) || 0; },
    getPadding: function (dir) { dir = j.setDefault(dir, "top").firstCase(); return parseInt(this.css("padding" + dir)) || 0; },
    innerWidth: function () {
        return this.width() - this.getPadding("left") - this.getPadding("right") - this.getBorder() * 2;
    },
    innerHeight: function () {
        return this.height() - this.getPadding("top") - this.getPadding("bottom") - this.getBorder() * 2;
    },
    opacity: function (value) {
        if (value == null) {
            var opa = this.css("opacity");
            if (opa == null) {
                var alpha = this.el.filters.alpha; return alpha == null ? 1 : alpha.opacity * 0.01;
            } else {
                return opa == null ? 1 : Math.round(opa * 100) / 100;
            }
        }
        if (this.el.style.opacity != null) { this.el.style.opacity = value; } else {
            this.el.style.filter = "alpha(opacity=" + (value / 0.01) + ")";
        }; return this;
    },
    cssText: function (txt) { if (txt == null) { return this.el.style.cssText; } this.el.style.cssText = txt; return this; },
    addClass: function () {
        var cl = new j.className(this.el); for (var i = 0; i < arguments.length; i++) { cl.add(arguments[i]); }; return this;
    },
    removeClass: function (cls) { new j.className(this.el).remove(cls); return this; },
    setClass: function (cls) { new j.className(this.el).set(cls); return this; },
    hasClass: function (cls) { return this.el.className.has(cls); },
    show: function () { this.el.style.display = "block"; return this; },
    hide: function () { this.el.style.display = "none"; return this; },
    toggle: function () { if (this.visible() == false) { return this.show(); } else { return this.hide(); } },
    visible: function () { if (this.el.style.display == "none") { return false; }; return true; },
    animate: function (opts, fn, speed) {
        return new j.animate(this, opts, fn);
    },
    fadeOut: function (fn, speed) {
        this.show().opacity(1).animate({ opacity: 0 }, function () {
            j(this).hide(); fn && fn.call(this);
        }, speed);
    },
    fadeIn: function (fn, speed) {
        this.opacity(0).show().animate({ opacity: 100 }, function () {
            fn && fn.call(this);
        }, speed);
    },
    append: function (c) { if (c.el != null) { c = c.el; }; this.el.appendChild(c); return this; },
    appendTo: function (p) { if (p.el != null) { p = p.el; }; p.appendChild(this.el); return this; },
    before: function (b) { if (b.el != null) { b = b.el; }; this.el.parentNode.insertBefore(b, this.el); return this; },
    after: function (a) { if (a.el != null) { a = a.el; }; this.el.parentNode.insertBefore(a, this.el.nextSibling); return this; },
    toBody: function () { return this.appendTo(document.body); },
    tag: function (tagName) { return this.el.getElementsByTagName(tagName); },
    name: function (name) { return this.el.getElementsByName(name); },
    remove: function () { this.parent().removeChild(this.el); delete this.el; return this; },
    parent: function () { return this.el.parentNode; },
    childs: function () { return this.el.childNodes; },
    prev: function () { return this.el.previousSibling; },
    next: function () { return this.el.nextSibling; },
    setRegion: function (left, top, p) { j.position.setRegion(this.el, left, top, p); },
    offset: function () { return j.position.offset(this.el); },
    width: function (val) { if (val == null) { return this.el.offsetWidth || 0; } else { this.el.style.width = val + (val.toString().has("%") ? "" : "px"); }; return this; },
    height: function (val) { if (val == null) { return this.el.offsetHeight || 0; } else { this.el.style.height = val + (val.toString().has("%") ? "" : "px"); }; return this; },
    get: function () { return this.el; }
}
j.fn.init.prototype = j.fn;
j.extend = function (p, c, d) {
    if (d) { j.extend(p, d); };
    if (p && c && typeof c == "object") { for (var i in c) { p[i] = c[i]; } }; return p; 
}
j.getClass = function () { return function () { this.init.apply(this, arguments); } }
//-------------------常用方法--------------------------
j.extend(j, {
    eventList: [],
    removeEventAll: function () {
        var list = j.eventList;
        for (var i = 0; i < list.length; i++) { j.event.remove(i); i--; }
    },
    getType: function (val) {
        if (val == null) { return "null"; }
        if (val.nodeType && val.nodeType == 1) { return "element"; }
        return Object.prototype.toString.apply(val).replace("[object ", "").replace("]", "").toLowerCase();
    },
    getBody: function () { return document.body; },
    nullFn: function () { },
    nullUrl: "javascript:void(0)",
    isStrict: document.compatMode == "CSS1Compat",
    isEl: function (el) { return this.getType(el) == "element"; },
    setDefault: function (old, def) { return old == null ? def : old; },
    getParam: function (url) {
        if (!url) { url = window.location.href; }
        if (url.lastIndexOf("?") >= 0) { url = url.substring(url.lastIndexOf("?") + 1); }
        var obj = {}; var pairs = url.split('&');
        for (var i = 0; i < pairs.length; i++) { var pair = pairs[i].split("="); obj[pair[0]] = pair[1]; }; return obj;
    },
    toParam: function (obj) {
        if (typeof (obj) == "string") { return obj }; var urlParam = "";
        for (var i in obj) { urlParam += i + "=" + obj[i] + "&"; }; urlParam = urlParam.delEnd("&"); return urlParam;
    },
    toDicJson: function (obj) {
        var jsonString = "{"; for (var i in obj) { jsonString += "\"{0}\":\"{1}\",".format(i, obj[i]); }
        jsonString = jsonString.delEnd(","); jsonString += "}"; return jsonString;
    },
    bind: function (obj, fun) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function (result) { if (result) { args.push(result); } return fun.apply(obj, args); }
    },
    bindWithEvent: function (obj, fun) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function (event) { return fun.apply(obj, [event || window.event].concat(args)); }
    },
    closeSelf: function () { window.opener = null; window.open('', '_self'); window.close(); },
    clearSelection: function () { window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty(); },
    addLink: function (url) {
        try {
            document.createStyleSheet(url).owningElement;
        } catch (e) {
            var e = document.createElement('link'); e.rel = 'stylesheet'; e.type = 'text/css'; e.href = url;
            document.getElementsByTagName('head')[0].appendChild(e);
        }
    },
    getUrl: function (url, params) {
        url = j.setDefault(url, location.href).replace("#", "");
        if (params) {
            var p = j.toParam(params);
            if (url.indexOf("?") == -1) { url += "?"; }
            if (url.lastIndexOf("?") != -1 && url.lastIndexOf("&") == -1 && p != "") { url += "&"; } url = url + p;
        }; return url;
    },
    load: function (el, fn) { el = dom(el); el.onload = el.onreadystatechange = function () { if (this.readyState && this.readyState !== 'complete') { return; } fn(); }; el = null; },
    loadXml: function (url) {
        var xmlDoc;
        try { xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); } catch (e) { xmlDoc = document.implementation.createDocument("", "", null); }
        xmlDoc.async = false; xmlDoc.load(url); return xmlDoc;
    },
    allCombox: function (visible) {
        var combo = j(document).tag("select");
        for (var i = 0; i < combo.length; i++) { combo[i].style.visibility = visible == "show" ? "visible" : "hidden"; }
    },
    formSubmit: function (name,url) {
        var form = document.forms[name || 0];
        if (url != null) { form.action = url; }
        form.submit();
    }
});
//-------------------原型的扩展--------------------------
j.extend(String.prototype, {
    trim: function () { return this.replace(/^\s+|\s+$/g, ''); },
    delTag: function () { return this.replace(/<[^>]+>/g, ""); },
    startWith: function (str) { return this.indexOf(str) == 0; },
    endWith: function (str) { var d = this.length - str.length; return d >= 0 && this.lastIndexOf(str) == d; },
    truncate: function (len, truncation) { if (!truncation) { truncation = "..." }; return this.length > len ? this.substring(0, len) + truncation : this; },
    removeNumber: function () { return this.replace(/[^d]/g, ""); },
    padLeft: function (len, pad) {
        pad = pad == null ? "0" : pad; var str = this;
        if (len > this.length) { for (var i = 0; i < len - this.length; i++) { str = pad + str; } }; return str;
    },
    format: function () { var str = this; for (var i = 0; i < arguments.length; i++) { str = str.replace("{" + (i) + "}", arguments[i]); }; return str; },
    firstCase: function (mode) {
        var f = this.substring(0, 1);
        if (mode == null || mode == "upper") { f = f.toUpperCase(); } else { f = f.toLowerCase(); }
        return f + this.substring(1);
    },
    delEnd: function (str) { return this.endWith(str) ? this.substring(0, this.length - str.length) : this; },
    delStart: function (str) { return this.startWith(str) ? this.substring(str.length) : this; },
    isEmpty: function () { if (this == null || this.trim() == "") { return true; } return false; },
    subRight: function (len) { return this.slice(this.length - len); },
    subLeft: function (len) { return this.slice(0, len); },
    toJson: function () { return eval("(" + this + ")"); },
    has: function (obj) { return this.indexOf(obj) > -1 },
    toggle: function (a, b) { return this == a ? a : b; },
    toDate: function () {
        var converted = Date.parse(this), myDate = new Date(converted);
        if (isNaN(myDate)) { var arys = this.split('-'); myDate = new Date(arys[0], arys[1], arys[2]);}
        return myDate;
    },
    replaceList: function (arr, rep) { var str = this; for (var i = 0; i < arr.length; i++) { str = str.replace(arr[i], rep); }; return str; },
    replaceAll: function (s1, s2) { return this.replace(new RegExp(s1, "gm"), s2); }
});
j.extend(Date.prototype, {
    format: function (format) {
        var o =
            {
                "M+": this.getMonth() + 1, "d+": this.getDate(), "H+": this.getHours(), "m+": this.getMinutes(),
                "s+": this.getSeconds(), "q+": Math.floor((this.getMonth() + 3) / 3), "S": this.getMilliseconds()
            }
        if (/(y+)/.test(format)) {
            format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        }
        for (var k in o) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
            }
        };return format;
    },
    isLeapYear: function () {return (0 == this.getYear() % 4 && ((this.getYear() % 100 != 0) || (this.getYear() % 400 == 0)));}
});
j.extend(Array, {
    remove: function (arr, index_value) {
        if (typeof (index_value) == "number") {arr.splice(index_value, 1);
        } else { var i = Array.indexOf(arr, index_value); if (i > -1) { arr.splice(i, 1); }};return arr;
    },
    clear: function (arr) {arr.splice(0, arr.length);},
    indexOf: function (arr, value) {for (var i = 0; i < arr.length; i++) { if (arr[i] == value) { return i; } }; return -1;},
    has: function (arr,value) {return Array.indexOf(arr,value)>-1;},
    each: function (arr, fn) {for (var i = 0; i < arr.length; i++) { if (fn(arr[i],i)==false) { break; }}}
});
j.extend(Object,{
    add:function(obj,list){if(obj==null){obj={};};for (var i in list ) {obj[i]=list[i];};return obj;},
    each:function(obj,fn){for (var i in obj) {if(fn(i,obj[i])==false){break;}}}
});
(function(j){
    var guid = 0;
    j.guid = function () {return guid++;}
    j.maskActive = 0;
    var zi = 1000;
    j.zIndex = function () {return zi++;}
    var userAgent = navigator.userAgent.toLowerCase();
    j.browser = {
        version: (userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [])[1],
        ie: /msie/.test(userAgent) && !/opera/.test(userAgent),
        ie6: /msie/.test(userAgent) && !window.XMLHttpRequest,
        webkit: /webkit/.test(userAgent),
        opera: /opera/.test(userAgent),
        firefox: /firefox/.test(userAgent)
    }
})(j);
j.now = {
    datetime: new Date().format("yyyy-MM-dd HH:mm:ss"),
    date: new Date().format("yyyy-MM-dd"),
    time: new Date().format("HH:mm:ss")
}
j.kc = {
    tab: 9, back: 8, enter: 13, shift: 16, ctrl: 17, esc: 27, del: 46, left: 37, up: 38, right: 39, down: 40,
    f1: 112, f2: 113, f3: 114, f4: 115, f5: 116, f7: 118, f8: 119, f9: 120, f10: 121, f11: 122, f12: 123,
    zero: 48, one: 49, nine: 57, minus: 189, dot: 190, empty: 32, a: 65, z: 90, x: 88, c: 67, v: 86, start: 36, end: 35
}
j.cookie = {
    add: function () { },
    del: function () { },
    get: function () { }
}
//-------------------验证--------------------------
j.validator = {
    regex: {
        email: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
        en: /^[A-Za-z]+$/,
        cn: /^[\u0391-\uFFE5]+$/,
        url: /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
        ip: /^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$/,
        zip: /^[1-9]\d{5}$/,
        qq: /^[1-9]\d{4,10}$/,
        alpha: /^[0-9a-zA-Z\_]+$/,
        tel: /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/,
        mobile: /^1[3|4|5|8][0-9]\d{4,8}$/,
        int: /^(-|\+)?\d+$/,
        float: /^(-?\d+)(\.\d+)?$/,
        idCard: /^(([0-9]{14}[x0-9]{1})|([0-9]{17}[x0-9]{1}))$/,
        idCard15: /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/,
        idCard18: /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$/
    },
    checkEmpty: function (obj) {
        if (!obj) { return true; } var msg = "";
        for (var i in obj) { if (dom(i).value.trim() == "") { msg += "--" + obj[i] + "\n"; } }
        if (msg == "") { return true; } else { alert(msg); return false; }
    },
    check: function (type, value) {
        if (this.regex.hasOwnProperty(type)) { return this.regex[type].test(value); }
        return type.test(value);
    }
}
j.form = {
    waterMark: function (el, text, color) {
        var color = j.setDefault(color, "#ccc");var text = j.setDefault(text, "请输入");var elem = j(el);
        var oldColor = elem.css("color");
        if (elem.val().isEmpty()) { elem.val(text).css("color", color); }
        elem.bind("focus", function (e) {
            if (this.value == text) { this.value = ""; this.style.color = oldColor; }
        }).bind("blur", function (e) {
            if (this.value.isEmpty()) { this.value = text; this.style.color = color; }
        });
    },
    showLength: function (el, infoCurr, infoMax) {
        var max = parseInt(j(infoMax).html());el = dom(el);
        infoCurr=dom(infoCurr);
        var api = {
            setLen: function () {
                var val = this.value.trim();
                if (val.length > max) {this.value = val.substring(0, max);} else {infoCurr.innerHTML = val.length;}
            }
        }
        el.onkeyup = api.setLen;
        el.onkeydown = api.setLen;
        el = null;
    }
}
//-------------------获取或设置各种Position--------------------------
j.position = {
    dd: function (win) { return (win ? win.document.documentElement : document.documentElement); },
    db: function (win) { return (win ? win.document.body : document.body); },
    maxClient: function (win) {
        var doc = j.position.dd(win);
        return { width: Math.max(doc.clientWidth, doc.scrollWidth), height: Math.max(doc.clientHeight, doc.scrollHeight), top: 0, left: 0 };
    },
    client: function (win) { var doc = j.position.dd(win); return { width: doc.clientWidth, height: doc.clientHeight, top: 0, left: 0 }; },
    scroll: function (win) {
        var dd = j.position.dd(win), db = j.position.db(win);
        return { left: Math.max(dd.scrollLeft, db.scrollLeft), top: Math.max(dd.scrollTop, db.scrollTop) }
    },
    screen: function () { return { width: screen.availWidth, height: screen.availHeight} },
    offset: function (el) {
        var t = 0, l = 0, el = dom(el);
        var w = el.offsetWidth, h = el.offsetHeight;
        do {
            t += el.offsetTop || 0; l += el.offsetLeft || 0;
            if (el.offsetParent) { el = el.offsetParent; } else { break; }
        } while (el);
        return { top: t, left: l, width: w, height: h }
    },
    setRegion: function (elem, left, top,parent) {
        var el = j(elem), elw = el.width(), elh = el.height(), t = 0, l = 0;
        var s =   j.position.scroll();
        var p =parent== null ? j.position.client() : j.position.offset(parent);
        if (top != null) {
            switch (top) {
                case "top": { t = s.top; } break;
                case "center": { t = (p.height - elh) / 2 + s.top; } break;
                case "bottom": { t = p.height - elh + s.top; } break;
                default: { t = parseInt(top); } break;
            }
        }
        if (left != null) {
            switch (left) {
                case "left": { l = s.left; } break;
                case "center": { l = (p.width - elw) / 2 + s.left; } break;
                case "right": { l = p.width - elw + s.left } break;
                default: { l = parseInt(left); } break;
            }
        }
        el.css({ left: l + "px", top: t + "px" });
    }
}
//-------------------ClassName--------------------------
j.className =function(el){this.el = dom(el);}
j.className.prototype = {
    set: function (cls) { this.el.className = cls; return this; },
    toArray: function () { return this.el.className.trim().split(/\s+/); },
    add: function (cls) { if (!this.has(cls)) { this.set(this.toArray().concat(cls).join(" ")); } return this; },
    has: function (cls) { return this.el.className.has(cls); },
    remove: function (cls) { return this.set(Array.remove(this.toArray(), cls).join(" ")); }
}
//-------------------Ajax--------------------------
j.ajax = j.getClass();
j.ajax.getXHR = function () {return window.ActiveXObject ? new ActiveXObject("Microsoft.XMLHTTP") : new XMLHttpRequest();}
j.ajax.prototype = {
    init: function (opts) {
        this.opts = j.extend({type: "post",data: "",dataType: "text",url: j.getUrl()}, opts || {});
        this.xhr = j.ajax.getXHR();this.type = this.opts.type.toUpperCase();this.data = j.toParam(this.opts.data);this.request();
    },
    request: function () {
        this.xhr.open(this.type, this.opts.url, true);
        this.xhr.onreadystatechange = j.bind(this, this.setChange);
        this.xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        this.xhr.send(this.type == "GET" ? null : this.data);
    },
    setChange: function () {
        if (this.xhr.readyState == 4) {
            if (this.opts.complete) { this.opts.complete(this.xhr); }
            if (this.xhr.status == 200) {
                if (this.opts.success) {
                    var data;
                    switch (this.opts.dataType) {
                        case "json": data = this.xhr.responseText.toJson(); break;
                        case "xml": data = this.xhr.responseXML; break;
                        default: data = this.xhr.responseText; break;
                    }
                    this.opts.success(data, this.xhr);
                }
            } else { if (this.opts.error) { this.error(this.xhr); }}
        }
    }
}
//-------------------StringBuilder-------------------------
j.builder =function(line){this.arr=[];this.line=j.setDefault(line,"\n");}
j.builder.prototype = {
    add: function (str) { this.arr.push(str); return this; },
    addFmt: function () {
        // var arg = Array.prototype.slice.call(arguments).slice(1);
        var arg = arguments;for (var i = 1; i < arg.length; i++) { arg[0] = arg[0].replace("{" + (i - 1) + "}", arg[i]); }this.arr.push(arg[0]); return this;
    },
    addLine: function (str) { this.arr.push(this.line); this.arr.push(str); return this; },
    toString: function () { return this.arr.join(""); }
}
//-------------------HashMap的模拟和扩展--------------------------
j.map = j.getClass();
j.map.prototype = {
    init: function (obj) {
        this.dic = new Array();if(typeof obj!="object"){return;}
        for (var i in obj) {this.add(i,obj[i]);}
    },
    get: function (key) {for (var i = 0; i < this.dic.length; i++) {if (key == this.dic[i].key) { return this.dic[i].value; }} return null; },
    add: function (key, value) {if (!this.existsKey(key)) { this.dic.push({ key: key, value: value }); return this; }},
    remove: function (key) {for (var i = 0; i < this.dic.length; i++) { if (key == this.dic[i].key) { this.dic.splice(i, 1); break; }}},
    clear: function () {this.dic.splice(0, this.count());},
    each: function (fn) {Array.each(this.dic, fn); },
    existsKey: function (key) { if (key == null) { return true; }for (var i in this.dic) { if (this.dic[i].key == key) { return true; break; }} return false;},
    existsValue: function (value) { for (var i in this.dic) { if (this.dic[i].value == value) { return true; break; }} return false; },
    count: function () { return this.dic.length;},
    toParam: function () {var obj = {};for (var i in this.dic) {obj[this.dic[i].key] = this.dic[i].value;} return j.toParam(obj);},
    toJson: function () { var obj = {}; for (var i in this.dic) {obj[this.dic[i].key] = this.dic[i].value;} return j.toDicJson(obj);}
}
//-------------------下拉框操作的封装和扩展--------------------------
j.combox = function (el) { this.el = dom(el);this.items = this.el.options;}
j.extend(j.extend(j.combox.prototype, j.prototype), {
    count: function () { return this.items.length;},
    index: function () {return this.el.selectedIndex;},
    currItem: function () { return this.items[this.index()];},
    removeItem: function (index) { if (index == null) { index = this.index(); if (index == -1) { return; } } this.items.remove(index); },
    addItem: function (text, value) {if (value == null) { value = text; } this.items.add(new Option(text, value));},
    existsItem: function (text, value) {
        if (typeof (text) != "string") {value = text.value; text = text.text; }
        for (var i = 0; i < this.items.length; i++) {
            var item = this.items[i]; if (text == item.text && value == item.value) {return true;}
        }; return false;
    },
    clearItem: function (start) {if (start == null) { start = 0; } for (var i = start; i < this.items.length; i++) { this.removeItem(i);i--;} },
    dataBind: function (data, currIndex) {
        var index = currIndex == null ? 0 : currIndex;
        for (var i = 0; i < data.length; i++) {
            var txt = data[i], val = data[i];
            if (typeof (txt) == "object") { txt = txt.text; val = val.value; if (txt.selected == true) { index = i;}}
            this.addItem(txt, val);this.el.selectedIndex = index;
        }
    },
    remoteBind: function (options) {
        var opts = j.extend({ url: location.href,index: 0, msg: "读取数据失败!", clear: true,clearIndex: 0}, options || {});
        //alert(j.getUrl(opts.url, opts.params));
        var obj = this;
        new j.ajax({dataType: "json",type: "get",url: j.getUrl(opts.url, opts.params),
            success: function (data) {
                if (opts.clear == true) {obj.clearItem(opts.clearIndex);}obj.dataBind(data, opts.index);
            },
            error: function () { if (opts.msg != false) { alert(opts.msg); }}
        });
    },
    toOther: function (other, isAll, isRemove) {
        var next = new j.combox(other);
        for (var i = 0; i < this.items.length; i++) {
            if (this.items[i].selected == true || isAll == true) {
                var txt = this.items[i].text; var val = this.items[i].value;
                if (!next.existsItem(txt, val)) {next.addItem(txt, val); if (isRemove == true) { this.items.remove(i); i--; }}
            }
        }
    }
});
//-------------------遮罩--------------------------
j.mask = function (el) {
    this.id = j.guid();
    if (el != null) {
        this.limit = j.position.offset(el);
    } else { this.limit = j.position.maxClient(); }
    this.show();
}
j.mask.prototype = {
    show: function () {
        this.box= j("j-mask-" + this.id);
        if (this.box.get() == null) {
            var p = { zIndex: j.zIndex() }
            for (var i in this.limit) { p[i] = (this.limit[i] + "px"); }
            this.box = j("<div>").setClass("j-mask").attr({ id: ("j-mask-" + this.id) }).css(p).toBody();
            if (j.browser.ie6) {
                j.allCombox("hide");
                //m.html("<iframe frameborder='0'  class='j-mask-frame'></iframe>");
            }
        }
    },
    remove: function () { this.box.remove(); delete this.box;if (j.browser.ie6) { j.allCombox("show"); } }
}
//-------------------设置元素显示位置（可自适应）--------------------------
j.direction = function (el, opts) {
    this.el = j(el);
    //如果自动适应位置，防止两边位置都不合适而造成的死循环
    this.auto = false;
    this.elW = this.el.width();
    this.elH = this.el.height();
    this.client = j.position.client();
    this.opts = j.extend({
        autoDir: true,
        align: "left",
        dir: "bottom",
        autoSet: false,
        autoShow:false
    }, opts || {});
    var f = this.opts.follow;
    if (f.x && f.y) {
        this.setXY(f);
    } else {
        this.offset = j(f).offset();
    }
    this.left = this.top = 0;
    if (this.opts.autoSet == true) { this.set(); }
}
j.direction.prototype = {
    setXY: function (xy) {
        this.offset = { width: 0, height: 0, left: xy.x, top: xy.y }
    },
    setAlign: function (align) {
        if (align != null) { this.opts.align = align; }
    },
    setDir: function (dir) {
        if (dir != null) { this.opts.dir = dir; }
    },
    set: function (dir, align) {
        this.setDir(dir);
        this.setAlign(align);
        this["get" + this.opts.dir]();
        if(this.autoShow){this.el.show();}
        this.el.css({ left: this.left + "px", top: this.top + "px" });
        this.auto = false;
    },
    getbottom: function () {
        var t = this.offset.top + this.offset.height;
        //防止底部溢出
        if (this.opts.autoDir == true && this.auto == false && (t + this.elH) > this.client.height) {
            this.auto = true; this.gettop();
        } else {
            this.top = t; this.getLeftForBT();
        }
    },
    gettop: function () {
        var t = this.offset.top - this.elH;
        //防止头部溢出
        if (this.opts.autoDir == true && this.auto == false && t < 0) {
            this.auto = true; this.getbottom();
        } else {
            this.top = t; this.getLeftForBT();
        }
    },
    getleft: function () {
        var l = this.offset.left - this.elW;
        //防止左边溢出
        if (this.opts.autoDir == true && this.auto == false && l < 0) {
            this.auto = true; this.getright();
        } else {
            this.left = l; this.getTopForLR();
        }
    },
    getright: function () {
        var l = this.offset.left + this.offset.width;
        //防止右边溢出
        if (this.opts.autoDir == true && this.auto == false && (l + this.elW) > this.client.width) {
            this.auto = true; this.getleft();
        } else {
            this.left = l; this.getTopForLR();
        }
    },
    getLeftForBT: function () {
        this.left = this.offset.left;
        if (this.opts.align == "center") {
            this.left = this.offset.left + (this.offset.width - this.elW) / 2;
        }
        if (this.opts.align == "right" || (this.left + this.elW) > this.client.width) {
            this.left = this.offset.left + this.offset.width - this.elW - 1;
        }
        if (this.left < 0) { this.left = 0; }
    },
    getTopForLR: function () {
        this.top = this.offset.top;
        if (this.opts.align == "center") {
            this.top = this.offset.top + (this.offset.height - this.elH) / 2;
        }
        if (this.opts.align == "right" || (this.top + this.elH) > this.client.height) {
            this.top = this.offset.top + this.offset.height - this.elH;
        }
        if (this.top < 0) { this.top = 0; }
    }
}
//-------------------弹出浏览器窗口--------------------------
j.open = j.getClass();
j.open.prototype = {
    init: function (opts) { j.extend(this, opts, { width: 600, height: 300, left: 0, top: 0, target: "_blank" }); },
    openWindow: function () {
        this.top = ((screen.height - this.height) / 2) - 40; this.left = (screen.width - this.width) / 2; var sb = new j.builder();
        sb.add("toolbar=no,location=no,directions=no,status=no,revisable=no,scrollbars=yes,menubar=no,");
        sb.addFmt("width={0}px,height={1}px,top={2}px,left={3}px", this.width, this.height, this.top, this.left);
        return window.open(this.url, this.target, sb.toString());
    }
}
//-------------------拖动--------------------------
j.drag = j.getClass();
j.drag.prototype = {
    init: function (drag, opts) {
        this.drag = j(drag); this.x = this.y = 0;
        this.box = j("<div>").setClass("j-drag").toBody();
        j.extend(this, opts, { handler: this.drag, limit: true });
        this.onMove = j.bindWithEvent(this, this.move); this.onStop = j.bind(this, this.stop);
        this.handler.css({ cursor: "move" }).on("mousedown", j.bindWithEvent(this, this.start));
    },
    start: function (e) {
        this.offset = this.drag.offset();
        if (this.limit == true) { this.max = j.position.client(); this.scroll = j.position.scroll(); }
        var l = this.offset.left, t = this.offset.top;
        this.box.show().css({ left: l + "px", top: t + "px", height: this.offset.height + "px", width: this.offset.width + "px" });
        this.x = e.x - l; this.y = e.y - t;
        j(document).on("mousemove", this.onMove).on("mouseup", this.onStop);
        if (this.handler.get().setCapture) { this.handler.get().setCapture(); } e.prevent();
    },
    move: function (e) {
        var l = e.x - this.x, t = e.y - this.y;
        if (this.limit == true) {
            l = Math.max(Math.min(l, this.max.width - this.offset.width + this.scroll.left), this.scroll.left);
            t = Math.max(Math.min(t, this.max.height - this.offset.height + this.scroll.top), this.scroll.top);
        }
        this.box.css({ left: l + "px", top: t + "px" }); e.prevent();
    },
    stop: function () {
        this.drag.css({ left: this.box.css("left"), top: this.box.css("top") }); this.box.hide();
        j(document).unon("mousemove", this.onMove).unon("mouseup", this.onStop);
        if (this.handler.get().releaseCapture) { this.handler.get().releaseCapture(); }
    }
}
j.data = {
    month: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"]
}
j.editMode = { add:"Add", edit:"Edit", view:"View" };
if (j.browser.ie6) {
    document.execCommand("BackgroundImageCache", false, true);
}
j(window).bind("unload", j.removeEventAll);
//-------------------json序列化--------------------------
if (typeof JSON == 'undefined') { JSON = {}; };
(function () {
    JSON.validate = function (string) {
        string = string.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, '@').
					replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']').
					replace(/(?:^|:|,)(?:\s*\[)+/g, '');
        return (/^[\],:{}\s]*$/).test(string);
    };
    JSON.encode = JSON.stringify ? function (obj) {
        return JSON.stringify(obj);
    } : function (obj) {
        if(obj==null){return "";}
        switch (j.getType(obj)) {
            case 'string' :return '"' + obj+ '"';
            case 'array' :
                var str=[];
                Array.each(obj,function(item,i){
                    var json = JSON.encode(obj[i]);if(json)str.push(json);
                });return '['+str.toString()+']';
            case 'object' : 
                var str = [];
                for (var i in obj) {
                    var json = JSON.encode(obj[i]); if (json) str.push(JSON.encode(i) + ':' + json);
                };return '{' + str.toString()+ '}';
            case 'number': case 'boolean': return '' + obj;
        }; return null;
    };
    JSON.decode = function (str) {
        if (str==null || typeof(str) != 'string') return null;
        if (JSON.parse) return JSON.parse(str);
        return eval('(' + str + ')');
    };
})();
//-------------------mvc表格插件（其他开发模式可作相应的修改）--------------------------
j.grid = function (el, opts) {
    j.extend(this, opts, { skin: "Ext", dataKey: "dataKey", checkName: "checkAll",
        ajaxDelete: true, nowarp: true, sortable: true, dirValue: "desc", sortValue: "id",
        imgPath: "../Images/grid"
    });
    this.gridCls = this.skin + "_Tab";
    this.oddCls = this.skin + "_RowOdd";
    this.evenCls = this.skin + "_RowEven";
    this.hoverCls = this.skin + "_RowHover";
    this.clickCls = this.skin + "_RowClick";
    this.el = j(el);
    this.selectedRow = null;
    this.getRows();
    if (this.rows.length > 0) {
        this.el.addClass(this.gridCls);
        if (this.nowarp) { this.el.addClass("nowarp_table"); }
    }
    this.setStyleEvent(true);
    if (this.ajaxDelete == false) {
        this.createDelIdsField();
    }
    if (this.sortable) {
        this.bindSort();
    }
}
j.grid.prototype = {
    bindSort: function () {
        this.sortName = j.setDefault(this.sortName, "sortname");
        this.dirName = j.setDefault(this.dirName, "sortdir");
        var sortfield = j("<input>").attr({ type: "hidden", id: this.sortName, name: this.sortName }).val(this.sortValue);
        var dirfield = j("<input>").attr({ type: "hidden", id: this.dirName, name: this.dirName }).val(this.dirValue);
        this.el.after(sortfield).after(dirfield);
        var headers = j(this.rows[0]).tag("th");
        for (var i = 0; i < headers.length; i++) {
            var h = j(headers[i]);
            var sortField = h.attr("sortField");
            if (sortField != null && sortField != "") {
                if (this.sortValue == sortField) {
                    h.append(j("<img>").attr("src", this.imgPath + "/s.gif").addClass("sort" + this.dirValue));
                }
                h.css("cursor", "pointer").attr("title", "点击列头进行排序").bind("click", this.sort, this);
            }
        }
    },
    createDelIdsField: function () {
        this.delName = this.delName == null ? "del_ids" : this.delName;
        var delfield = j("<input>").attr({ type: "hidden", id: delName, name: delName });
        this.el.after(delfield);
    },
    getRows: function () {
        this.rows = this.el.get() == null ? [] : this.el.tag("tr");
    },
    resetStyle: function () {
        this.selectedRow = null;
        this.getRows(); this.setStyleEvent(false);
    },
    setStyleEvent: function (isEvent) {
        if (this.rows.length <= 0) { return; }
        for (var i = 1; i < this.rows.length; i++) {
            var row = this.rows[i], obj = this;
            row.className = (i % 2 == 0) ? this.oddCls : this.evenCls;
            if (isEvent) {
                row.setAttribute("tabindex", "0"); row.setAttribute("hidefocus", "true");
                if (this.allowMouse != false) {
                    row.onmouseover = function () {
                        if (this.className != obj.clickCls) { this.className = obj.hoverCls; }
                        //j(this).addClass(obj.hoverCls);
                    }
                    row.onmouseout = function () {
                        if (this.className != obj.clickCls) { this.className = (this.rowIndex % 2 == 0) ? obj.oddCls : obj.evenCls; }
                        //j(this).removeClass(obj.hoverCls);
                    }
                    // if (j.browser.ie) {
                    row.onkeydown = function (e) {
                        var evt = new j.event(e);
                        switch (evt.kc) {
                            case j.kc.up: { obj.prevRow(); }; break;
                            case j.kc.down: { obj.nextRow(); }; break;
                            case j.kc.enter: { obj.selectedRowEnter && obj.selectedRowEnter(obj.getId(), obj.selectedRow); }; break;
                        }
                    }
                    // }
                }
                if (this.allowClick != false) {
                    row.onclick = function () {
                        obj.setSelectedRow(this);
                    };
                }
                if (obj.dblclick) { row.ondblclick = function () { obj.dblclick(obj.getId(), this); } }
            }
            row = null;
        }
    },
    setSelectedRow: function (row) {
        if (!row) { return; }
        if (this.selectedRow != row) {
            if (this.selectedRow != null) { this.selectedRow.className = (this.selectedRow.rowIndex % 2 == 0) ? this.oddCls : this.evenCls; }
            row.className = this.clickCls; this.selectedRow = row;
            this.click && this.click(this.getId(), row);
        }
    },
    prevRow: function () {
        if (this.selectedRow == null) { return; }
        var selectedIndex = this.selectedRow.rowIndex;
        if (selectedIndex > 1) {
            this.setSelectedRow(this.rows[selectedIndex - 1]);
        }
    },
    nextRow: function () {
        if (this.selectedRow == null) { return; }
        var selectedIndex = this.selectedRow.rowIndex;
        if (selectedIndex < this.rows.length) {
            this.setSelectedRow(this.rows[selectedIndex + 1]);
        }
    },
    checkAll: function (el) {
        el = dom(el || "checkAll"); var chs = this.el.tag("input"), n = this.checkName;
        el.onclick = function () {
            for (var i = 0; i < chs.length; i++) { if (chs[i].type == "checkbox" && chs[i].name == n) { chs[i].checked = this.checked; } }
        }; el = null;
    },
    getId: function (row) {
        var curr = j.setDefault(row, this.selectedRow);
        return curr == null ? "" : curr.getAttribute(this.dataKey);
    },
    getIds: function () {
        var ids = new Array();
        for (var i = 1; i < this.rows.length; i++) {
            var row = this.rows[i];
            var chs = row.getElementsByTagName("input");
            for (var j = 0; j < chs.length; j++) {
                if (chs[j].type == "checkbox" && chs[j].name == this.checkName && chs[j].checked == true) {
                    var id = this.getId(row); if (id != "") { ids.push(id); }
                }
            }
        }; return ids;
    },
    getRowById: function (id) {
        if (typeof id == "object") { return id; }
        if (this.rows.length <= 0) { return null; }
        for (var i = 1; i < this.rows.length; i++) {
            if (this.rows[i].getAttribute(this.dataKey) == id) {
                return this.rows[i];
            }
        }
    },
    deleteRow: function (id_row) {
        var row = this.getRowById(id_row);
        if (row != null) {
            row.onclick = null; row.ondblclick = null; row.onkeydown = null;
            row.parentNode.removeChild(row);
        }
    },
    showDialog: function (mode, id, action) {
        action = action || "Details";
        var param = new j.map(), obj = this;
        param.add("mode", mode).add("datakey", id);
        var page = "/" + this.editController + "/" + action + "?" + param.toParam();
        //var opts = j.extend({ id: (this.editController + "Edit"), page: page, width: 600,}, this.dialogOptions || {});
        var dg = new $.dialog(j.extend({ id: (this.editController + "Edit"), page: page, width: 600, onXclick: function () {
            dg.cancel();
            //            if (dg.dgWin && dg.dgWin.closeReload == true) {
            //                window.document.forms[0].submit();
            //            }

        }
        }, this.dialogOptions || {}));
        dg.ShowDialog();
    },
    submit: function (url) {
        j.formSubmit(this.formName, url);
    },
    edit: function (id, action, msg) {
        id = id ? id : this.getId();
        if (id == "") {
            j.tip.msg(msg || "请选择一条记录进行操作");
        } else {
            this.showDialog(j.editMode.edit, id, action);
        }
    },
    add: function (action) {
        this.showDialog(j.editMode.add, "", action);
    },
    view: function (id, action) {
        this.showDialog(j.editMode.view, id || this.getId(), action);
    },
    checkdel: function (msg) {
        var check = true;
        var ids = this.getIds().toString();
        ids = ids == "" ? this.getId() : ids;
        if (ids == "") {
            j.tip.msg(msg || "请至少选择一条记录进行操作！");
            check = false;
        } else {
            check = confirm("确定要删除选中的记录吗？");
        }
        return { ids: ids, check: check }
    },
    del: function (action, msg) {
        if (this.ajaxDelete == true) {
            this.ajaxDel(action, msg);
        } else {
            this.submitDel(action, msg);
        }
    },
    submitDel: function (action, msg) {
        var d = this.checkdel(msg);
        if (d.check) {
            var delids = j(this.delName).val(d.ids);
            this.submit("/" + this.editController + "/" + (action || "Del"));
        }
    },
    ajaxDel: function (action, msg) {
        var d = this.checkdel(msg);
        if (d.check) {
            //var load = j.tip.loading("正在提交您的请求，请稍后", true);
            var url = "/" + this.editController + "/" + (action || "AjaxDelete") + "?ids=" + d.ids, obj = this;
            //setTimeout(function () { 
            $.ajax({
                type: "get", dataType: "json", url: url, success: function (data) {
                    // load.remove();
                    if (data.result == "true") {
                        j.tip.msg("删除成功!" + data.msg);
                        var ids = d.ids.split(",");
                        for (var i = 0; i < ids.length; i++) {
                            obj.deleteRow(ids[i]);
                        }
                        obj.resetStyle();
                    } else {
                        j.tip.msg("删除失败！" + data.msg, "error", 3, true);
                    }
                }, error: function (xhr) {
                    //load.remove();
                    j.tip.msg("删除失败！", "error", 3, true);
                }
            });
            // }, 200);
        }
    },
    query: function (action) {
        dom("pageindex").value = 1;
        this.submit();
    },
    sort: function (e, obj) {
        dom(obj.sortName).value = this.getAttribute("sortField");
        var dir = dom(obj.dirName);
        dir.value = dir.value == "desc" ? "asc" : "desc";
        obj.submit();
    }
}
//-------------------数字输入框--------------------------
j.numberbox = function (el, opts) {
    this.el = j(el);
    j.extend(this, opts, {
        //是否允许输入负数
        allowNegative: true,
        //是否允许输入小数
        allowDecimal: true,
        //是否允许输入0
        allowZero: true,
        //允许的功能键
        allowFunction: [j.kc.ctrl, j.kc.back, j.kc.del, j.kc.left, j.kc.right, j.kc.enter, j.kc.start, j.kc.end, j.kc.tab, j.kc.shift],
        ctrlWithKey:[j.kc.z,j.kc.x,j.kc.c,j.kc.v],
        maxValue: Number.MAX_VALUE,
        minValue: Number.MIN_VALUE
    });
    if (j.browser.ie) { this.el.css("ime-mode", "Disabled"); };
    this.el.bind("keydown", this.checkKeyCode, this).bind("blur", this.checkChange, this);
}
j.numberbox.prototype = {
    parseValue: function (value) {
        if (!this.allowNegative) { value = value.replaceAll('-', ''); }
        if (!this.allowZero) { value = value.replaceAll('0', ''); }
        value = this.allowDecimal ? parseFloat(value) : parseInt(value);
        return isNaN(value) ? "" : value;
    },
    checkChange: function (e, obj) {
        this.value = obj.parseValue(this.value);
    },
    checkKeyCode: function (e, obj) {
        //j.tip.msg(e.kc);
        var v = this.value.trim();
        var c = false, ctrl = e.e.ctrlKey;
        //可以输入负数(只能输入一个-只能出现在第一位)
        var pos = j.getFocusPosition(obj.el.el);
        if (obj.allowNegative && (e.kc == 109 || e.kc == 189) && !v.has("-") && (pos < 1)) { return true; }
        //可以输入小数(只能输入一个.不能出现在第一位,如果有负数不能出现在第二位)
        if (obj.allowDecimal && (e.kc == 190 || e.kc == 110) && !v.has(".") && (pos > v.has("-") ? 1 : 0) && pos != null) { return true; }
        //可以输入0
        if (obj.allowZero && (e.kc == 96 || e.kc == 48)) { return true; }
        //可以输入数字
        if ((e.kc >= 49 && e.kc <= 57) || (e.kc >= 97 && e.kc <= 105)) { return true; }
        //可以输入ctrl,home,end,delete,backspace,enter,tab,->,<-,复制,粘贴,剪切,回退等功能键
        if (Array.has(obj.allowFunction, e.kc)) { return true; }
        if (ctrl && Array.has(obj.ctrlWithKey, e.kc)) { return true; }
        e.prevent();
    }
}
j.getFocusPosition = function (obj) {
    var result = 0;
    if (!j.browser.ie) {  
        result =obj.selectionStart || 0;
    } else { 
        var rng;
        if (obj.tagName == "TEXTAREA") {  
            rng = event.srcElement.createTextRange();
            rng.moveToPoint(event.x, event.y);
        } else { 
            rng = document.selection.createRange();
        }
        rng.moveStart("character", -event.srcElement.value.length);
        result = rng.text.length;
    }
    return result;
}
//-------------------菜单--------------------------
j.menu = function (opts) {
    j.extend(this, opts, {
        id: "j-menu" + j.guid(), items: []
    });
    this.menuPanel = this.create(this.items).toBody();
    j(document).bind("click", j.bind(this, this.hide));
    if (this.follow) {
        this.setXY(this.follow);
    }
}
j.menu.over = function (e) {
    var li = j(this);
    var ch = li.childs();
    if (ch.length > 1) {
        j(ch[1]).css({left:this.offsetWidth-4+"px",top:"0px"}).show();
    }
    li.addClass("menu-item-hover");
}
j.menu.out = function (e) {
    var li = j(this);
    var ch = li.childs();
    if (ch.length > 1) {
        j(ch[1]).hide();
    }
    li.removeClass("menu-item-hover");
}
j.menu.prototype = {
    setXY: function (xy) {
        this.show();
        new j.direction(this.menuPanel, { follow: xy, autoSet: true, autoDir: true });
        this.hide();
    },
    showXY: function (xy) {
        this.setXY(xy);
        this.show();
    },
    show: function () {
        this.menuPanel.show();
    },
    hide: function () {
        this.menuPanel.hide();
    },
    create: function (items) {
        var div = j("<div>").addClass("menu-panel");
        var ul = j("<ul>");
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            var li = j("<li>");
            if (item == "-") {
                li.setClass("menu-separator");
            } else {
                li.setClass("menu-item");
                var a = j("<a>").setClass("menu-item-link").attr("href", j.nullUrl);
                var span = j("<span>").setClass("menu-icontext").html(item.text);
                if (item.icon) {
                    span.addClass("icon-" + item.icon);
                }
                span.appendTo(a);
                a.appendTo(li);
                if (item.items) {
                    a.addClass("menu-item-arrow");
                    var p = this.create(item.items).appendTo(li);
                }
                li.bind("mouseover", j.menu.over);
                li.bind("mouseout", j.menu.out);
            }
            li.appendTo(ul);
        }
        ul.appendTo(div);
        return div;
    }
}
//-------------------右键菜单--------------------------
j.contextmenu = function (el, opts) {
    var m = new j.menu(opts);
    j(el).bind("contextmenu", function (e) {
        m.showXY(e.getXY());
        e.prevent();
    });
}
//------------------可输入的下拉框------------------------
j.editSelect = j.getClass();
j.editSelect.prototype = {
    init: function (el, opts) {
        j.extend(this, opts, {
            id: "j-editSelect" + j.guid()
        });
        el = new j.combox(el);
        var pos = el.offset(), w = pos.width - 19 + "px", h = pos.height - 2 + "px";
        if (j.browser.ie6) {
            j("<iframe>").attr({ frameborder: "0" }).setClass("j-editSelect-iframe").css({ width: w, height: h, top: pos.top + "px", left: pos.left + "px" }).toBody();
        }
        var edit = j("<input>").attr({ type: "text", id: this.id }).setClass("j-editSelect-text").css({ lineHeight: h, width: w, height: h, top: pos.top + "px", left: pos.left + "px" }).toBody();
        edit.val(el.currItem().text);
        edit.bind("change", function () {
            el.get().selectedIndex = -1;
            el.val(this.value);
        });
        el.bind("change", function () {
            edit.val(this.value);
        });
    }
}
//---------------------单轨迹动画（不支持元素队列）------------------------------
j.animate = function (el, opts, callback) {
    j.extend(this, { el: j(el), opts: opts, callback: callback });
    var that = this;
    this.timer && clearInterval(this.timer)
    this.timer = setInterval(function () {
        that.doMove();
    },20);
}
j.animate.prototype = {
    doMove: function () {
        var complete = true;
        for (var i in this.opts) {
            var isOpacity = i == "opacity";
            var curr = isOpacity ? this.el.opacity() * 100 : parseFloat(this.el.css(i));
            if (isNaN(curr)) { curr = this.el.offset()[i]; }
            var speed = (this.opts[i] - curr) / 6;
            speed = speed > 0 ? Math.ceil(speed) : Math.floor(speed);
            var v = (curr + speed);
            this.opts[i] == curr || (complete = false, isOpacity ? this.el.opacity(v / 100) : this.el.css(i, v + "px"));
        }
        complete && (clearInterval(this.timer), this.callback && this.callback.call(this.el));
    } 
}
//-----------------------------Fit布局--------------------------
j.stackPanel = function (el, opts) {
    this.el = j(el);
    j.extend(this, opts, {
        fit: true,
        dir: "vbox",
        width: this.el.innerWidth(),
        height: this.el.innerHeight()
    });
    //    if (this.wrap != null) {
    //        this.wrap = j(this.wrap);
    //        this.width = this.wrap.innerWidth();
    //        this.height = this.wrap.innerHeight();
    //    } else {
    //        var client = j.position.client();
    //        this.width = client.width;
    //        this.height = client.height;
    //    }

    var childs = this.el.childs();
    var surplus = {};
    alert(childs.length);
    for (var i = 0; i < childs.length; i++) {
        var child = j(childs[i]);
        if (this.dir == "hbox") {
            child.css("float", "left");
            if (this.fit) {
                child.height(this.height - child.getBoder() * 2);

            }
        } else {

            if (this.fit) {
               
                //child.width(this.width-child.getBorder()*2);
                //child.css({ display: "block", width: "100%" });
                // child.height((this.height - 6) / 3);


            }
        }

    }

}