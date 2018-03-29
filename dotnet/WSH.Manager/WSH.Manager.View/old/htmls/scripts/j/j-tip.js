/*
title:                      tip-msg-loading
content:               提示框，等待框，信息框
author:                 wsh-j-王松华
version:                1.0
updateDate:        2011-7-4
*/
(function (j) {
    j.tip = j.getClass();
    j.tip.skin = {
        blur: { border: "#7fcdee", background: "#d9f1fb", color: "#1b475a" },
        green: { border: "#b6e184", background: "#f2fdf1", color: "#558221" },
        yellow: { border: "#e9d315", background: "#f9f2ba", color: "#5b5316" }
    }
    j.tip.prototype = {
        init: function (opts) {
            j.extend(this, opts, {
                id: "j-tip" + j.guid(), targetWidth: 8, skin: "green", dir: "right", align: "center", close: false, target: false, top: "center", left: "center"
            });
            this.createWrap();
        },
        createWrap: function () {
            if (this.mask) {
                this.maskPanel = new j.mask(this.maskEl);
            }
            var wrap = this.wrap = j("<div>").css({ position: "absolute", zIndex: j.zIndex() });
            wrap.attr("id", this.id + "wrap");
            if (this.width) {
                wrap.css({ width: this.width + "px" });
            }
            wrap.html(this.getHTML()).toBody();
            var tip = j(this.id)
            if (this.cls) {
                tip.addClass(this.cls);
            }
            if (this.icon) {
                tip.addClass("j-tip-icon-" + this.icon);
            }
            this.setPosition({ left: this.left, top: this.top });
            if (this.time) {
                this.timer(this.time);
            }
            if (this.close != false) {
                var close = j(this.id + "close");
                close.bind("click", j.bind(this, this.hide));
            }
        },
        timer: function (second) {
            if (second) this.timer = setTimeout(j.bind(this, function () {
                this.hide();
                clearTimeout(this.timer);
            }), 1000 * second);
        },
        getHTML: function () {
            var sk;
            var dir = this.dir;
            var b = new j.builder();
            b.addFmt('<div class="j-tip" id="{0}"', this.id);
            if (this.skin != false) {
                sk = j.tip.skin[this.skin];
                b.addFmt(' style="background-color:{0};border:1px solid {1};color:{2};"', sk.background, sk.border, sk.color);
            }
            b.add(">");
            if (this.target != false && this.skin != false) {
                b.addFmt('<span style="border-{0}:5px solid {1}" class="j-tip-target target-{2}">', dir, sk.border, dir);
                b.addFmt('<span class="j-tip-target" style="border-{0}:5px solid {1}">', dir, sk.background);
                b.add('</span></span>');
            }
            if (this.close != false) {
                b.addFmt('<a href="{0}" class="j-tip-close" id="{1}close"></a>', j.nullUrl, this.id);
            }
            b.addFmt('<div class="j-tip-text" id="{0}text">{1}</div>', this.id, this.text);
            b.add('</div>');

            return b.toString();
 
        },
        setPosition: function (obj) {
            if (this.el != null) {
                new j.direction(this.wrap, { follow: this.el, dir: this.dir, align: this.align, autoSet: true });
            } else {
                this.wrap.setRegion(obj.left || "center", obj.top || "center",this.maskEl);
            }
        },
        removeMask: function () {
            if (this.mask && this.maskPanel != null) { this.maskPanel.remove(); }
        },
        remove: function () {
            this.wrap.remove();
            this.wrap = null;
            this.removeMask();
        },
        show: function () {
            this.wrap.show(); return this;
        },
        hide: function () {
            this.wrap.hide(); this.removeMask(); return this;
        }
    }
    j.tip.loading = function (text, mask, maskEl, top, left) {
        return new j.tip({ left: left || "center", top: top || "center", cls: "j-tip-load", icon: "load", text: text || "正在加载,请稍后...", skin: "blur", mask: mask, maskEl: maskEl });
    }
    j.tip.msg = function (text, icon, time, close, top, left) {
        var i = "info", s = "blur";
        if (icon == "error") { i = icon; s = "yellow"; }
        if (icon == "ok") { i = icon; s = "green"; }
        return new j.tip({ icon: i, skin: s, left: left || "center", top: top || "center", time: time == null ? 2 : time, text: text, cls: "j-tip-msg", close: close == null ? false : true });
    }
    j.tip.hint = function (text, el, skin) {
        el = dom(el);
        var movetip = new j.tip({ skin: skin || "green", text: text, target: false });
        movetip.hide();
        var setxy = (function (m) {
            return function (e) {
                var evt = j.evt(e);
                m.setPosition({ top: evt.y() + 12, left: evt.x() + 15 });
            }
        })(movetip)
        el.onmouseover = function (e) {
            movetip.show();
            setxy(e);
        }
        el.onmouseout = function () {
            movetip.hide();
        }
        el.onmousemove = function (e) {
            setxy(e);
        }
        el = null;
    }
})(wsh)