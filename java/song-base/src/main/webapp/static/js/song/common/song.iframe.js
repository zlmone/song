/**
 * Created by song on 2017/9/11.
 */
//*******************************************iframe*******************************************
(function (song,$) {
    var dataName = '@SONG.DATANAME';
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
        },
        data: function (name, value) {
            var top = window.top, cache = top[dataName] || {};
            top[dataName] = cache;
            if (value != undefined) {
                cache[name] = value;
            } else {
                return cache[name];
            }
            return cache;
        },
        removeData: function (name) {
            var cache = window.top[dataName];
            if (cache && cache[name]) delete cache[name];
        },
        clearData: function () {
            if (window.top[dataName]) {
                delete window.top[dataName];
            }
        },
        getContent: function (iframe) {
            var doc = iframe.contentDocument || iframe.contentWindow.document,
                html = doc.body.innerHTML;
            //纯文本响应可能会被包裹在<pre>标签
            if (html && html.match(/^<pre/i)) {
                html = doc.body.firstChild.firstChild.nodeValue;
            }
            return html;
        },
        destroy: function (frames) {
            if (frames.length > 0) {
                for (var i = 0; i < frames.length; i++) {
                    var frame = frames[i];
                    frame.src = "about:blank";
                    try {
                        frame.contentWindow.document.write('');
                        frame.contentWindow.document.clear();
                        frame.contentWindow.close();
                    } catch (e) {
                    }
                }
                frames.remove();
                if (window.CollectGarbage) {
                    window.CollectGarbage();
                }
            }

        }
    }
    $(window).bind("unload", song.clearData);
})(window.song,window.jQuery)
