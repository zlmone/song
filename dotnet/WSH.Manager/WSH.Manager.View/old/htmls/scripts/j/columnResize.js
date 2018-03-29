/*
title:                      columnResize
content:               改变表格列宽
author:                 wsh-j-王松华
version:                1.0
updateDate:        2011-6-28
*/
j.columnResize = j.getClass();
j.columnResize.prototype = {
    init: function(resize, opts) {
        this.x = this.width = 0;
        this.resize = dom(resize);
        this.onMove = j.bindWithEvent(this, this._move);
        this.onStop = j.bind(this, this._stop);
        this.opts = j.extend({
            handle: this.resize,
            min: 40
        }, opts || {});
        j(this.opts.handle).css("cursor","col-resize").on("mousedown", j.bindWithEvent(this, this._start));
    },
    _start: function(e) {
        this.x = e.x;
        this.width = this.resize.offsetWidth;
        j(document).on("mousemove", this.onMove).on("mouseup", this.onStop);
        if (this.opts.start) {
            this.opts.start();
        }
        e.prevent().stop();
    },
    _move: function(e) {
        var w = Math.max(this.width + e.x - this.x, this.opts.min);
        j(this.resize).css({ width: w + "px" });
        if (this.opts.move) {
            this.opts.move({ resize: this.resize, handle: this.opts.handle, width: w + "px" });
        }
        e.prevent().stop();
    },
    _stop: function() {
        j(document).unon("mousemove", this.onMove).unon("mouseup", this.onStop);
        if(this.opts.stop){
            this.opts.stop();
        }
    }
}