/**
 * Created by song on 2017/8/29.
 */
(function (cmp, $) {
    cmp.builder = {
        write: function (html) {
            document.write(html);
        },
        getRowCount: function (count, col) {
            return Math.ceil(count / col);
        },
        setPrefix: function (attr, fix) {
            //补充属性前缀
            return fix ? (fix + "-" + attr) : attr;
        },
        getPrefix: function (attr, fix) {
            return fix ? attr.substr((fix + "-").length) : attr;
        },
        getColumnCount: function (items) {
            //解析item.colspan,计算总列
            var count = 0;
            $.each(items, function (i, item) {
                if (item.colspan && item.colspan > 1) {
                    count += item.colspan;
                } else {
                    count++;
                }
            });
            return count;
        },
        repairColspan: function (items, column) {
            //对列的colspan进行修复，如共4列，第3列配置colspan=3，则修复为colspan=2，保持样式不变形
            var line = 0;
            $.each(items, function (i, item) {
                line += item.colspan ? item.colspan : 1;
                if (line == column) {
                    //如果累加刚刚满了一行，则从零开始判断第二行
                    line = 0;
                }
                if (line > column) {
                    //如果累加大于一行的总列数，则修补当前列的colspan
                    item.colspan = (column - (line - item.colspan));
                    line = 0;
                }
            });
            return items;
        },
        tagOptions: function (options) {
            //组件html标签属性
            var opts = [];
            $.each(options, function (key, value) {
                opts.push(key + "=" + cmp.quote(value));
            });
            return " " + opts.join(' ');
        },
        tag: function (tagName, options, content) {
            //组件html标签
            var opts = cmp.builder.tagOptions(options);
            var html = ['<', tagName, opts, '>', content, '</', tagName, '>'].join('');
            return html;
        },
        hiddenTag: function (items) {
            var tpl = [];
            $.each(items, function (i, item) {
                var attr = {
                    id: item.field,
                    name: item.field,
                    type: "hidden",
                    "class": "cmp-hidden",
                    value: (item.value || "")
                };
                if (item.isReset === false) {
                    attr["data-reset"] = "none";
                }
                tpl.push(cmp.builder.tag("input", attr));
            });
            return tpl.join('');
        },
        getStyle: function (styles) {
            var css = [];
            $.each(styles, function (key, value) {
                css.push(key + ":" + value);
            });
            return css.length > 0 ? cmp.builder.tagOptions({style: css.join(";")}) : "";
        }
    }
})(window.cmp, window.jQuery);

