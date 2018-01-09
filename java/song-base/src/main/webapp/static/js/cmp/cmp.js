/**
 * Created by 王松华 on 2017/8/25.
 */
(function (win, $) {
    win.cmp = {
        version: "1.0.0",
        text: {
            operate: "操作",
            success: "操作成功！",
            error: "操作失败，请稍后再试或联系管理员！",
            title: '温馨提示',
            loading: "正在加载，请稍后...",
            nullRecord: "请选择记录进行操作",
            confirmRemoveRecord: "确定删除记录吗？",
            confirmRemoveNode: "确定删除节点以及子节点吗？"
        },
        param: {
            //封装的动态参数
            id: function (p) {
                return this.attr(p, "id");
            },
            attr: function (p, attr) {
                if (p && typeof(p) != "object") {
                    var params = {};
                    params[attr] = p;
                    return params;
                }
                return p;
            },
            attrs: function (item, attrs) {
                var params = {};
                attrs.replace(song.split, function (name) {
                    if (item[name]) {
                        params[name] = item[name];
                    }
                });
                return params;
            }
        },
        create: function (options) {
            var fn = function () {
                var arg = arguments;
                $.extend(this, {
                    el: $(arg[0]),
                    options: arg[1] || {}
                });
                this.cloneOptions = function () {
                    var opts = {};
                    $.extend(opts, this.options);
                    return opts;
                }
                this.set = function (key, value) {
                    this.options[key] = value;
                };
                //执行事件
                this.fire = function (eventName) {
                    if (this.options[eventName]) {
                        var args = song.slice(arguments, 1);
                        this.options[eventName].apply(this, args)
                    }
                }
                this.init && this.init();
            }
            options && (fn.prototype = options);
            return fn;
        },
        id: function (flg) {
            return song.id(flg);
        },
        quote: function (value, qtype) {
            qtype = qtype || '"';
            return qtype + value + qtype;
        },
        layout: function (target, options) {
            if (!target) {
                target = 'body';
            }
            var el = $(target),
                defaults = {
                    fit: true
                };
            options && $.extend(defaults, options);
            el.layout(defaults);
        },
        template: {
            iframe: function (src) {
                var tpl = "<iframe style='width:100%;height:100%;border:0px;' frameborder='0' scrolling='auto' src='" + src + "'></iframe>";
                return tpl;
            },
            link: function (text, href) {
                href = href || 'javascript:void(0)';
                var tpl = "<a href='" + href + "'>" + text + "</a>";
                return tpl;
            }
        }
    }

    $.extend(cmp, {
        msg: function (msg, title) {
            $.messager.show({
                title: title || cmp.text.title,
                msg: msg
            });
        },
        confirm: function (msg, success, title) {
            $.messager.confirm(title || cmp.text.title, msg, function (r) {
                if (r) {
                    success();
                }
            });
        },
        loading: {
            show: function (msg, title) {
                $.messager.progress({
                    title: title || cmp.text.title,
                    msg: msg || cmp.text.loading
                });
                window.showLoading=true;
            },
            hide: function () {
                if (window.showLoading){
                    $.messager.progress("close");
                    window.showLoading=false;
                }
            }
        },
        getActionMapper: function (attrName, actionValue, attrValue) {
            //获取配置映射值，优先判断该属性是否有值，如果没有值则获取映射信息
            if (attrValue) {
                return attrValue;
            }
            var map = cmp.mapper.action[actionValue];
            if (map) {
                return map[attrName];
            }
        },
        getActionMappers: function (item, attrNames) {
            //根据配置批量获取映射值
            var values = {};
            if (item && attrNames) {
                var keys = attrNames.split(',');
                for (var i = 0; i < keys.length; i++) {
                    var key = keys[i];
                    values[key] = cmp.getActionMapper(key, item.action, item[key])
                }
            }
            return values;
        },
        isSuccess: function (result, attr) {
            //判断ajax业务处理是否成功，默认isSuccess属性
            if (result && result[attr || "isSuccess"]) {
                return true;
            }
            return false;
        },
        ajax: function (url, data, success, options) {
            var opts = {};
            //覆盖项
            $.extend(opts, {
                type: "get",
                dataType: "json"
            }, options);
            cmp.loading.show(opts.loadingMsg);
            //固定项
            $.extend(opts, {
                url: url,
                data: data,
                success: function (result) {
                    cmp.loading.hide();
                    success && success(result);
                },
                error: function (xhr, err) {
                    cmp.loading.hide();
                    options.error && options.error(false);
                    cmp.msg.error();
                }
            });
            $.ajax(opts);
        },
        postAjax: function (url, data, success, options) {
            options = options || {};
            options.type = "post";
            this.ajax(url, data, success, options);
        },
        getAjax: function (url, data, success, options) {
            options = options || {};
            options.type = "get";
            this.ajax(url, data, success, options);
        },
        encodeValue: function (value, isEncode) {
            if (isEncode !== false) {
                return encodeURIComponent(value);
            }
            return value;
        }
    });
    $.extend(cmp.msg, {
        error: function (msg, title) {
            cmp.msg(msg || cmp.text.error, title);
        },
        success: function (msg, title) {
            cmp.msg(msg || cmp.text.success, title);
        }
    });

    cmp.mapper = {
        mode: {
            add: 1,
            edit: 2,
            view: 3
        },
        action: {
            selectConfirm: {
                text: "确认选择",
                iconCls: "icon-ok"
            },
            add: {
                text: "新增",
                iconCls: "icon-add"
            },
            edit: {
                text: "编辑",
                iconCls: "icon-edit"
            },
            editFlow: {
                text: "编辑流程",
                iconCls: "icon-edit"
            },
            remove: {
                text: "删除",
                iconCls: "icon-remove"
            },
            save: {
                text: "保存",
                iconCls: "icon-save"
            },
            cancel: {
                text: "取消",
                iconCls: "icon-cancel"
            },
            appendNode: {
                text: "添加子节点",
                iconCls: "icon-add"
            },
            editNode: {
                text: "编辑节点",
                iconCls: "icon-edit"
            },
            removeNode: {
                text: "删除节点",
                iconCls: "icon-remove"
            },
            insertNode: {
                text: "添加同级节点",
                iconCls: "icon-add"
            }
        }
    }
})(window, jQuery);

