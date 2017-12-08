/**
 * Created by song on 2017/9/11.
 */
//---------------------------------follow---------------------------------
song.follow = function (el, opts) {
    this.el = $(el).css("position", "absolute");
    this.auto = false;
    this.elW = this.el.outerWidth();
    this.elH = this.el.outerHeight();
    this.client = song.position.client();
    $.extend(this, {autoDir: true, align: "left", dir: "bottom", autoSet: true, top: 0, left: 0, fix: 0}, opts);
    this.offset = song.position.getOffsetSize($(this.follow));
    if (this.autoSet == true) {
        this.set();
    }
}
song.follow.prototype = {
    set: function () {
        this["get" + this.dir]();
        this.el.css({left: this.left, top: this.top});
    },
    getbottom: function () {
        var t = this.offset.top + this.offset.height;
        //防止底部溢出
        if (this.autoDir == true && this.auto == false && (t + this.elH + this.fix) > this.client.height) {
            this.auto = true;
            this.gettop();
        } else {
            this.top = t + this.fix;
            this.getLeftForBT();
        }
    },
    gettop: function () {
        var t = this.offset.top - this.elH;
        //防止头部溢出
        if (this.autoDir == true && this.auto == false && t - this.fix < 0) {
            this.auto = true;
            this.getbottom();
        } else {
            this.top = t - this.fix;
            this.getLeftForBT();
        }
    },
    getleft: function () {
        var l = this.offset.left - this.elW;
        //防止左边溢出
        if (this.autoDir == true && this.auto == false && l - this.fix < 0) {
            this.auto = true;
            this.getright();
        } else {
            this.left = l - this.fix;
            this.getTopForLR();
        }
    },
    getright: function () {
        var l = this.offset.left + this.offset.width;
        //防止右边溢出
        if (this.autoDir == true && this.auto == false && (l + this.elW + this.fix) > this.client.width) {
            this.auto = true;
            this.getleft();
        } else {
            this.left = l + this.fix;
            this.getTopForLR();
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
        if (this.left < 0) {
            this.left = 0;
        }
    },
    getTopForLR: function () {
        this.top = this.offset.top;
        if (this.align == "center") {
            this.top = this.offset.top + (this.offset.height - this.elH) / 2;
        }
        if (this.align == "right" || (this.top + this.elH) > this.client.height) {
            this.top = this.offset.top + this.offset.height - this.elH;
        }
        if (this.top < 0) {
            this.top = 0;
        }
    }
}
