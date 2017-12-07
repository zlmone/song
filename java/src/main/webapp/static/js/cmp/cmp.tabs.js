/**
 * Created by 王松华 on 2017/8/25.
 */
(function (cmp, $) {
    cmp.tabs = cmp.create({
        init:function () {
             this.el.tabs(this.options);
        },
        select:function (param) {
            this.el.tabs("select",param);
        },
        openTabs: function (options) {
            var title = options.title;
            if (this.el.tabs("exists", title)) {
                this.select(title);
            } else {
                //ie下iframe加载较慢，显示loading
                cmp.loading.show();
                this.el.tabs('add', {
                    title: title,
                    content: cmp.template.iframe(options.url),
                    closable:options.closable || true,
                    icon: options.icon
                });
            }
        }
    });
})(window.cmp,window.jQuery);

