/**
 * Created by song on 2017/9/11.
 */
song.test = function () {
    this.start();
};
song.test.prototype = {
    second: function (get_as_float) {
        var now = new Date().getTime() / 1000;
        var s = parseInt(now, 10);
        return (get_as_float) ? now : (Math.round((now - s) * 1000) / 1000) + ' ' + s;
    },
    start: function () {
        this.startTime = new Date().getTime();
        return this;
    },
    end: function (isAlert) {
        this.endTime = new Date().getTime();
        isAlert && this.alert();
        return this;
    },
    alert: function () {
        if (!this.endTime) {
            alert("测试器尚未结束！");
            return;
        }
        var span = this.endTime - this.startTime;
        alert("耗时：" + span + "毫秒");
        return this;
    }
}