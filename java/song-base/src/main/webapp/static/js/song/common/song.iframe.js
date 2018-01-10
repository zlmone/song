/**
 * Created by song on 2017/9/11.
 */
//*******************************************iframe*******************************************
(function (song, $) {
    var frameName = 'SONG_COMMON_IFRAME';
    song.iframe = {
        window: function (iframe) {
            return iframe.contentWindow || iframe.window;
        },
        document: function (iframe) {
            return iframe.contentDocument || song.iframe.window(iframe).document;
        },
        //自适应高度和宽度
        auto: function (id, isWidth) {
            var frame = song.dom(id);
            frame.height = "10px";
            song.loaded(id, function () {
                var pos = song.position.maxClient(song.iframe.document(frame));
                this.height = pos.height + "px";
                isWidth && (this.width = pos.width + "px")
            });
        },
        data: function (name, value) {
            var top = window.top, cache = top[dataName] || {};
            top[frameName] = cache;
            if (value != undefined) {
                cache[name] = value;
            } else {
                return cache[name];
            }
            return cache;
        },
        removeData: function (name) {
            var cache = window.top[frameName];
            if (cache && cache[name]) delete cache[name];
        },
        clearData: function () {
            if (window.top[frameName]) {
                delete window.top[frameName];
            }
        },
        getContent: function (iframe) {
            var doc = song.iframe.document(iframe),
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
                    var win = song.iframe.window(frame),
                        doc = win.document;
                    try {
                        doc.write('');
                        doc.clear();
                        win.close();
                        doc = null;
                        win = null;
                    } catch (e) {
                    }
                }
                frames.remove();
                if (window.CollectGarbage) {
                    window.CollectGarbage();
                }
            }

        },
        download: function (url, params) {
            var iframeName = frameName + "_DOWNLOAD",
                formName = iframeName + "_FORM",
                iframe = $("#" + iframeName),
                form = $("#" + formName);
            if (iframe.length <= 0) {
                iframe = $("<iframe>").attr("id", iframeName).attr("name", iframeName);
                iframe.css({display: 'none'}).appendTo('body');
            }
            if (form.length <= 0) {
                form = $("<form>").attr("action", url).attr("target", iframeName).attr("id", formName);
                form.appendTo('body');
            }
            //清空参数
            form.empty();
            if (params) {
                //动态添加参数
                for (var k in params) {
                    form.append($("<input>").attr("name", k).val(params[k]).attr("type", "hidden"));
                }
            }
            form[0].submit();
        }
    }
    $(window).bind("unload", song.clearData);
})(window.song, window.jQuery)
