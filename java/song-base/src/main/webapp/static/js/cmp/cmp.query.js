/**
 * Created by 王松华 on 2017/8/29.
 */
(function (cmp, $) {
//======================================query==============================================
    cmp.query = cmp.create({
        init: function () {
            //绑定查询事件
            $.parser.parse(this.el);
            var query = this.el.find("a.btn-query"),
                reset = this.el.find("a.btn-reset"),
                that = this;
            query.click(function () {
                that.doQuery();
            });
            reset.click(function () {
                that.reset();
                that.doQuery();
            });
            //绑定回车键查询
            this.el.on("keyup", function (e) {
                if (e.which === 13) {
                    that.doQuery();
                }
            });
        },
        reset: function () {
            this.eachControl(function (control, ctype, field) {
                control[ctype]("reset");
            });
        },
        doQuery: function () {
            var values = this.getValues();
            this.options.onQuery && this.options.onQuery.call(this, values);
        },
        eachControl: function (callback) {
            var ctypes = cmp.builder.controlType.query;
            for (var i = 0; i < ctypes.length; i++) {
                var ctype = ctypes[i],
                    controls = this.el.find("input.easyui-" + ctype);
                controls.each(function (i) {
                    var control = controls.eq(i);
                    var field = cmp.builder.getPrefix(control.attr("id"), "query");
                    callback(control, ctype, field);
                });
            }
        },
        get:function (field) {
            return $("#query-"+field);
        },
        getValues: function (isEncode) {
            var values = {};
            this.eachControl(function (control, ctype, field) {
                var value = control[ctype]("getValue");
                values[field] = cmp.encodeValue($.trim(value), isEncode);
            });
            return values;
        }
    });
})(window.cmp, window.jQuery);

