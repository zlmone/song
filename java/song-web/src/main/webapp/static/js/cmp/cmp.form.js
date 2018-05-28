/**
 * Created by 王松华 on 2017/8/25.
 */
(function (cmp, $) {
    cmp.form = cmp.create({
        init: function () {
            $.parser.parse(this.el);
            this.renderButton();
            var that = this;
            $.extend(this.options, {
                queryParams: {},
                onSubmit: function (param) {
                    var result = that.valid();
                    if (result && that.options.onBeforeSubmit) {
                        result = that.options.onBeforeSubmit.call(that, param);
                    }
                    /*if (result !== false) {
                        cmp.loading.show();
                    }*/
                    return result;
                },
                success: function (result) {
                    var json = result;
                    if (typeof(result) == "string") {
                        json = result.toJson();
                    }
                    var isSuccess = cmp.isSuccess(json);
                    if (isSuccess) {
                        cmp.msg.success(json.msg);
                    } else {
                        cmp.msg.error(json.msg);
                    }
                    that.options.onAfterSubmit && that.options.onAfterSubmit.call(that, isSuccess, json);
                },
                onLoadSuccess: function (result) {
                    cmp.loading.hide();
                    that.options.onAfterLoad && that.options.onAfterLoad.call(that, true, result);
                },
                onLoadError: function () {
                    //加载出错，清空表单
                    cmp.loading.hide();
                    that.options.onAfterLoad && that.options.onAfterLoad.call(that, false);
                    cmp.msg.error();
                }
            });
            this.el.form(this.options);
        },
        renderButton: function () {
            var btns = this.options.button || [];
            var btnPanel = $("<div class='btn-panel'>").appendTo(this.el);
            for (var i = 0; i < btns.length; i++) {
                var b = btns[i],
                    map = cmp.getActionMappers(b, "iconCls,text");
                var btnEl = $(cmp.template.link(map.text)).appendTo(btnPanel);
                btnEl.linkbutton({
                    iconCls: map.iconCls,
                    onClick: b.onClick
                });
            }
        },
        reset: function () {
            this.el.form("reset");
            //调用form.reset是不会清空hidden标记，需要手动清除
            var hiddens = this.el.find("input.cmp-hidden");
            hiddens.each(function (i) {
                var h = hiddens.eq(i),
                    isreset = h.attr("data-reset");
                if (!isreset || isreset != "none") {
                    h.val('');
                }
            });
            this.options.onReset && this.options.onReset();
        },
        valid: function () {
            return this.el.form("validate");
        },
        getData: function () {
            var data = this.el.serializeArray(),
                params = this.options.queryParams;
            if (data && data.length > 0) {
                $.each(data, function (i, item) {
                    params[item.name] = item.value;
                });
            }
            return params;
        },
        submit: function () {
            var result = true,
                that = this;
            if (this.options.onSubmit) {
                result = this.options.onSubmit(this.options.queryParams);
            }
            if (result !== false) {
                var params = this.getData();
                cmp.postAjax(this.options.url, params, function (res) {
                    that.options.success(res);
                });
            }
        },
        load: function (url_data) {
            cmp.loading.show();
            this.el.form("load", url_data);
        },
        get:function (field) {
            return $("#"+field);
        }
    });

})(window.cmp, window.jQuery);

