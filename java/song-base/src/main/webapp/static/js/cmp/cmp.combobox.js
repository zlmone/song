/**
 * Created by 王松华 on 2017/8/25.
 */
(function (cmp, $) {
    cmp.combobox = cmp.create({
        init: function () {
            this.el.combobox(this.options);
        },
        loadData: function (data) {
            this.el.combobox("loadData", data);
        },
        reload: function (url) {
            this.el.combobox("reload", url);
        },
        setValue: function (values) {
            if (values) {
                var type = $.type(values);
                if (type == "array") {
                    this.el.combobox("setValues", values);
                } else {
                    this.el.combobox("setValue", values);
                }
            }
        },
        getValue: function () {
            return this.el.combobox("getValue");
        },
        getValues: function () {
            return this.el.combobox("getValues");
        }
    });
})(window.cmp, window.jQuery);

