/**
 * Created by song on 2017/9/1.
 */
(function (cmp, $) {
    //默认配置
    $.extend(cmp.builder, {
        controlType: {
            native: ["label", "checkbox", "radio", "text"],
            input: ["text", "radio", "checkbox", "button", "file"],
            query: ["textbox", "combobox", "datebox", "datetimebox","text"],
            form: ["validatebox", "textbox", "passwordbox", "combogrid", "combotree", "combotreegrid",
                "tagbox", "numberbox", "combobox", "datebox", "datetimebox", "filebox",
                "label", "text", "checkbox", "radio"]
        },
        defaults: {
            form: {
                column: 2,
                className: "form-panel",
                "ectype": "application/x-www-form-urlencoded",
                isLayout: false,
                labelWidth: "110px",
                controlWidth: "100%"
            },
            query: {
                column: 4,
                isLayout: true,
                layout: {region: "north", height: "auto", title: "搜索"},
                labelWidth: "110px",
                controlWidth: "85%"
            }
        }
    });
    //公用方法
    $.extend(cmp.builder, {
        parseDataOptions: function (options) {
            var opts = [];
            $.each(options || {}, function (key, value) {
                if (value != undefined) {
                    var type = $.type(value);
                    if (type === "string") {
                        value = cmp.quote(value, "'");
                    }
                    opts.push(key + ":" + value);
                }
            });
            return opts.join(',');
        },
        dataOptions: function (options) {
            return {"data-options": cmp.builder.parseDataOptions(options)};
        },
        getDataOptions: function (options) {
            return cmp.builder.tagOptions(cmp.builder.dataOptions(options));
        },
        easyuiTag: function (tagName, easyuiType, dataOptions, htmlOptions) {
            var attrs = htmlOptions || {};
            $.extend(attrs, {
                "class": ("easyui-" + easyuiType + " ") + (attrs["class"] || "")
            }, cmp.builder.dataOptions(dataOptions));
            return cmp.builder.tag(tagName, attrs);
        },
        control: function (controlType, dataOptions, htmlOptions) {
            //先判断是否是原生控件
            if ($.inArray(controlType, cmp.builder.controlType.native) > -1) {
                var tagName = controlType;
                if ($.inArray(controlType, cmp.builder.controlType.input) > -1) {
                    tagName = "input";
                    htmlOptions.type = controlType;
                }
                return cmp.builder.tag(tagName, htmlOptions, htmlOptions.content);
            }
            return cmp.builder.easyuiTag("input", controlType, dataOptions, htmlOptions);
        },
        filterControl: function (type, items) {
            var newItems = [],
                controlType = cmp.builder.controlType[type];
            $.each(items, function (i, n) {
                var ctype = n.control.toLowerCase();
                if ($.inArray(ctype, controlType) > -1) {
                    newItems.push(n);
                }
            });
            return newItems;
        },
        setHtmlOptions: function (panelId, item, htmlOptions) {
            var id = cmp.builder.setPrefix(item.field, panelId);
            var opts = {};
            $.extend(opts, {
                value: item.value,
                type: item.type || "text",
                id: id,
                name: id,
                content: item.content
            }, htmlOptions);
            return opts;
        },
        setControlDefault: function (type, item) {
            var opts = {},
                attrs = cmp.builder.setHtmlOptions((type == "query" ? type : null), item, item.htmlOptions);
            if (type == "query") {
                $.extend(opts, {
                    width: item.width,
                    editable: item.control == "textbox" ? true : false
                }, item.dataOptions || {});
            } else {
                $.extend(opts, {
                    width: item.width
                }, item.dataOptions || {});
            }
            return cmp.builder.control(item.control, opts, attrs);
        },
        controlTable: function (id, controlType, options) {
            var column = options.column,
                //先过滤无法识别的控件
                opts = cmp.builder.filterControl(controlType, options.items),
                //对每列横跨数进行修复，防止数组越界
                items = cmp.builder.repairColspan(opts, column),
                tpl = [];
            //循环生成项
            if (items && items.length > 0) {
                tpl.push('<table cellpadding="0" class="', controlType, '-table">');
                //算出总列数和总行数
                var total = cmp.builder.getColumnCount(items),
                    row = cmp.builder.getRowCount(total, column),
                    itemIndex = -1;
                for (var a = 0; a < row; a++) {
                    tpl.push("<tr>");
                    for (var b = 0; b < column;) {
                        var lw = cmp.builder.tagOptions({style: "width:" + options.labelWidth});
                        if (itemIndex < items.length - 1) {
                            itemIndex++;
                            var item = items[itemIndex],
                                colspan = "";
                            if (item.colspan) {
                                //如果跨行，则循环index累加
                                b += item.colspan;
                                //真实的colspan需要算上th+td，一个item=th+td
                                colspan = cmp.builder.tagOptions({colspan: item.colspan * 2 - 1});
                            } else {
                                b++;
                            }
                            tpl.push("<th", lw, ">", item.label, "：</th>");
                            //设置默认宽度
                            if (!item.width) {
                                item.width = options.controlWidth;
                            }
                            tpl.push("<td", colspan, ">", cmp.builder.setControlDefault(controlType, item), "</td>");
                        } else {
                            b++;
                            //补全td
                            tpl.push("<th", lw, ">&nbsp;</th><td>&nbsp;</td>");
                        }
                    }
                    tpl.push("</tr>");
                }
                tpl.push("</table>");
            }
            return tpl.join('');
        },
        getLayoutPanel: function (options, content) {
            return ['<div', cmp.builder.getDataOptions(options), '>', content, "</div>"].join('');
        },
        isLayoutPanel: function (isLayout, layout, content) {
            return isLayout ? cmp.builder.getLayoutPanel(layout, content) : content;
        },
        getFormPanel: function (id, options) {
            var opts = {};
            $.extend(true, opts, cmp.builder.defaults.form, options);
            var tpl = ['<div class="', opts.className, '"><form enctype="', opts.ectype, '" id="', id, '">'];
            //添加表单
            tpl.push(cmp.builder.controlTable(id, "form", opts));
            //添加隐藏域
            if (options.hidden) {
                tpl.push(cmp.builder.hiddenTag(options.hidden));
            }
            tpl.push('</form></div>');
            var content = tpl.join('');
            return cmp.builder.isLayoutPanel(opts.isLayout, opts.layout, content);
        },
        getGridPanel: function (id, options) {
            var opts = {};
            $.extend(true, opts, {
                isLayout: true,
                layout: {region: "center", border: 0}
            }, options);
            var content = ['<table id="', id, '"></table>'].join('');
            return cmp.builder.isLayoutPanel(opts.isLayout, opts.layout, content);
        },
        getTreePanel: function (id, options) {
            var opts = {};
            $.extend(true, opts, {
                isLayout: true,
                layout: {region: "west", border: 1}
            }, options);
            var content = ['<ul id="', id, '"></ul>'].join('');
            return cmp.builder.isLayoutPanel(opts.isLayout, opts.layout, content);
        },
        getQueryPanel: function (id, options) {
            var opts = {};
            $.extend(true, opts, cmp.builder.defaults.query, options);
            var tpl = [];
            tpl.push(
                '<div id="', id, '" class="query-panel">',
                '<table>',
                '<tr>',
                '<td>');
            tpl.push(cmp.builder.controlTable(id, "query", opts));
            tpl.push('</td>',
                '<td class="query-btn-panel">',
                '<a href="javascript:void(0)" style="margin-left:10px;" class="easyui-linkbutton btn-query" iconCls="icon-search">查询</a>',
                '<a href="javascript:void(0)" class="easyui-linkbutton btn-reset" iconCls="icon-redo">重置</a>',
                '</td>',
                '</tr>',
                '</table>',
                '</div>');
            var content = tpl.join('');
            return cmp.builder.isLayoutPanel(opts.isLayout, opts.layout, content);
        },
        getMenuItems: function (items) {
            var tpl = [];
            $.each(items, function (i, item) {
                var styles = {};
                if (item.width) {
                    styles["width"] = item.width + "px";
                }
                var map = cmp.getActionMappers(item, "iconCls,text");
                var opts = {
                    iconCls: map.iconCls,
                    id: (item.id || ""),
                    action: (item.action || "")
                }
                var dp = cmp.builder.getDataOptions(opts);
                tpl.push('<div', cmp.builder.getStyle(styles), dp, '>');
                if (item.items) {
                    tpl.push(cmp.builder.getMenuItems(item.items));
                } else {
                    tpl.push(map.text);
                }
                tpl.push('</div>');
            });
            return tpl.join('');
        },
        getMenuPanel: function (id, options) {
            var opts = {};
            $.extend(opts, {
                width: 100
            }, options);
            var styles = {
                width: opts.width + "px",
                display: "none"
            };
            return ['<div id="', id, '"', cmp.builder.getStyle(styles), '>', cmp.builder.getMenuItems(options.items || []), '</div>'].join('');
        }
    });
    //输出控件
    $.extend(cmp.builder, {
        panel: function (id,options,content) {
            var opts = {};
            $.extend(true, opts, {
                isLayout: true,
                layout: {region: "center", border: 0}
            }, options);
            cmp.builder.write(cmp.builder.isLayoutPanel(opts.isLayout, opts.layout, content));
            return this;
        },
        gridPanel: function (id, options) {
            cmp.builder.write(cmp.builder.getGridPanel(id, options));
            return this;
        },
        queryPanel: function (id, options) {
            cmp.builder.write(cmp.builder.getQueryPanel(id, options));
            return this;
        },
        formPanel: function (id, options) {
            cmp.builder.write(cmp.builder.getFormPanel(id, options));
            return this;
        },
        dialog: function (id) {
            var tpl = [];
            tpl.push('<div id="', id, '" class="cmp-dialog">');
            var content = song.slice(arguments, 1);
            if (content && content.length > 0) {
                tpl.push(content.join(''));
            }
            tpl.push('</div>');
            cmp.builder.write(tpl.join(''));
            return this;
        },
        dialogForm: function (dialogId, formId, options) {
            return cmp.builder.dialog(dialogId, cmp.builder.getFormPanel(formId, options));
        },
        treePanel: function (id, options) {
            cmp.builder.write(cmp.builder.getTreePanel(id, options));
            return this;
        },
        menuPanel: function (id, options) {
            cmp.builder.write(cmp.builder.getMenuPanel(id, options));
            return this;
        }
    });
})(window.cmp, window.jQuery);