/*
author:                 wang song hua
email:                  songhuaxiaobao@163.com
namespace:              Song.Upload.Plugs
content:                上传控件扩展插件
beforeLoad:             jQuery,song.base,song.upload
dateUpdated:            2012-11-13
*/
; (function (song,j) { 
    j.extend(song.upload,{
        parse:function(el){
            //将上传控件转换成上传按钮
            el=j(el).addClass("song-upload-file");
            var templ=['<a href="javascript:void(0)" class="song-upload-button" >',
                            '<div class="song-upload-filewrap">',
                            '</div>',
                        '</a>'];
            el.wrap(templ.join(''));
            var parent=el.parent(),
                wrap=parent.parent(),
                hoverCls="song-upload-hover";
            parent.before('<span class="song-upload-text">上传文件</span>');

            el.hover(function(){
                wrap.addClass(hoverCls);
            },function(){
                wrap.removeClass(hoverCls);
            });
        },
        kissyUploader:function(options){
            //var options={el:"#id",queueTarget:"#id",hideTarget:"#id",url:"http://"}
            var k = KISSY;
            k.use('gallery/uploader/1.4/index,gallery/uploader/1.4/themes/default/index,gallery/uploader/1.4/themes/default/style.css', function (k, Uploader, DefaultTheme) {
                var plugins = 'gallery/uploader/1.4/plugins/auth/auth,' +
                            'gallery/uploader/1.4/plugins/urlsInput/urlsInput,' +
                            'gallery/uploader/1.4/plugins/proBars/proBars';
                    k.use(plugins, function (S, Auth, UrlsInput, ProBars, Filedrop, Preview) {
                    //上传插件
                    var uploader = new Uploader(options.el, {
                        action:options.url,
                        type:["ajax","flash","iframe"],
                        multiple: true
                    });
                    //使用主题
                    uploader.theme(new DefaultTheme({
                        queueTarget: options.queueTarget
                    })).plug(new Auth({
                        max: 1,
                        maxSize: 2000
                    })).plug(new UrlsInput({ 
                        target: options.hideTarget 
                    })).plug(new ProBars());
                });
            });
        }
    });
})(window.song,window.jQuery);