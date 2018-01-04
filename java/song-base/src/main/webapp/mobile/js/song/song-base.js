//===================================debug==================================================
window.song = {
    debug: true
}
//===================================base===================================================
$.extend(song, {
    basePath: song.debug ? "http://wx.10085.cn/xizang/lucky/" : "http://wx.10086.cn/xizang/lucky/",
    msg: "服务器繁忙，请稍后重试",
    //编码
    encode: function (param) {
        return encodeURIComponent(param);
    },
    //解码
    decode: function (param) {
        return decodeURIComponent(param);
    },
    setConfig: function (d) {
        song.config = d;
    },
    getConfig: function (key, isDecode) {
        var p = song.config[key];
        return isDecode === true ? song.decode(p) : p;
    }
})
//===================================ajax===================================================
$.extend(song, {
    ajax: function (url, data, success, options) {
        var opts = {};
        $.extend(opts, {
            type: "post",
            dataType: "json"
        }, options);
        $.extend(opts, {
            url: url,
            data: data,
            success: function (result) {
                success && success(result);
            },
            error: function (xhr, err) {
                options.error && options.error(false);
            }
        });
        $.ajax(opts);
    },
    postAjax: function (url, data, success, options) {
        options = options || {};
        options.type = "post";
        song.ajax(url, data, success, options);
    },
    getAjax: function (url, data, success, options) {
        options = options || {};
        options.type = "get";
        song.ajax(url, data, success, options);
    },
    isSuccess: function (data) {
        // 判断ajax是否成功
        if (data != null && data.isSuccess) {
            return true;
        }
        return false;
    }
});




