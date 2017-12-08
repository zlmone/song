/**
 * Created by 王松华 on 2017/8/25.
 */
(function (cmp, $) {
    cmp.dialog = cmp.create({
        init: function () {
            var url=this.options.url;
            if(url){
                var id=this.options.id || cmp.id("dialog");
                this.el=$("<div id='"+id+"'>").appendTo('body');
                var realUrl=typeof(url)=="string" ? url : "";
                var frame=cmp.template.iframe(realUrl);
                this.options.content=frame;
                this.options.closed=true;
            }
            this.openCount=0;
            this.el.dialog(this.options);
        },
        open: function (title,url) {
            if (title) {
                this.el.dialog("setTitle", title);
            }
            //是否重新获取内容
            if(url){
            	this.options.url=url;
                    var iframe=this.el.find("iframe");
                    iframe[0].src=url;
            }
            this.el.dialog("open");
            //为了防止ajax重新设置内容，open后需要重新设置居中+
            this.el.dialog("vcenter");
            this.openCount++;
        },
        close: function () {
            this.el.dialog("close");
        }

    });
    $.extend(cmp.dialog,{
        select:function (el,options) {
            var opts={};
            $.extend(opts,{
                title:"选择",
                width:800,
                height:450,
                closable:true
            },options);
            var confirm = cmp.getActionMappers({action:"selectConfirm"}, "iconCls,text"),
                cancel=cmp.getActionMappers({action:"cancel"}, "iconCls,text");
            var dialog=new cmp.dialog(el,$.extend(opts,{
                buttons:[
                    {text:confirm.text,iconCls:confirm.iconCls,handler:function () {
                        var result=true;
                        if(opts.onSelectConfirm){
                            result=opts.onSelectConfirm();
                        }
                        if(result!==false){
                            dialog.close();
                        }
                    }},
                    {text:cancel.text,iconCls:cancel.iconCls,handler:function () {
                        opts.onSelectCancel && opts.onSelectCancel();
                        dialog.close();
                    }}
                ]
            }));
            return dialog;
        }
    });
})(window.cmp, window.jQuery);

