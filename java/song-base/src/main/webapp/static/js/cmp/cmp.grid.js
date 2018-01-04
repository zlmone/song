/**
 * Created by 王松华 on 2017/8/25.
 */
(function (cmp, $) {
    /*自定义属性如下
     checkColumn:true
     operateColumn:{
         menu:[
            {action:"edit",onClick:function(){}}
         ]
     }
     */
    cmp.grid = cmp.create({
        init: function () {
            //复制原来的参数
            var options = this.cloneOptions(),
                that = this;
            //重写事件和参数配置
            $.extend(this.options, {
                onLoadSuccess: function (data) {
                    that.el.datagrid('getPanel').find("a.cmp-menubutton").menubutton();
                    options.onLoadSuccess && options.onLoadSuccess(data);
                }
            });
            this.parseToolbar();
            this.parseFrozenColumns();
            this.el.datagrid(this.options);
        },
        parseFrozenColumns: function () {
            var frozens = this.options.frozenColumns;
            if (!frozens || frozens.length <= 0) {
                this.options.frozenColumns = [[]];
            }
            var operate = this.options.operateColumn,
                datakey = this.options.datakey;
            if (operate) {
                operate.field = datakey;
                this.options.frozenColumns[0].unshift(cmp.grid.column.operate(operate));
            }
            if (this.options.checkColumn !== false) {
                this.options.frozenColumns[0].unshift(cmp.grid.column.check());
            }
        },
        parseToolbar: function () {
            var tbs = this.options.toolbar,
                tbConfig = [];
            if (tbs && tbs.length > 0) {
                for (var i = 0; i < tbs.length; i++) {
                    var tb = tbs[i];
                    if (tb === "-") {
                        tbConfig.push(tb);
                    } else {
                        var map = cmp.getActionMappers(tb, "iconCls,text");
                        tbConfig.push({text: map.text, iconCls: map.iconCls, handler: tb.onClick});
                    }
                }
                this.options.toolbar = tbConfig;
            }
        },
        getChecked: function (field) {
            var checked = this.el.datagrid("getChecked") || [];
            if (field) {
                var values = [];
                for (var i = 0; i < checked.length; i++) {
                    values.push(checked[i][field]);
                }
                return values;
            }
            return checked;
        },
        getSelected: function () {
            return this.el.datagrid("getSelected");
        },
        load: function (params) {
            this.el.datagrid("load", params);
        },
        reload: function (params) {
            this.el.datagrid("reload", params);
        },
        removeRow: function (url, param_id, success) {
            //删除行
            var that = this;
            cmp.confirm(cmp.text.confirmRemoveRecord, function () {
                cmp.postAjax(url, cmp.param.id(param_id), function (result) {
                    success && success(result);
                    if (cmp.isSuccess(result)) {
                        cmp.msg.success();
                        //删除成功之后，置为第一页，重新加载数据
                        that.load();
                    } else {
                        cmp.msg.error();
                    }
                });
            });
        },
        validRecord: function (record) {
            //验证是否选择了记录
            if (record && record.length > 0) {
                return true;
            }
            cmp.msg(cmp.text.nullRecord);
            return false;
        },
        removeChecked: function (url, field, success) {
            //删除复选框选中的记录
            var ids = this.getChecked(field || this.options.datakey);
            if (this.validRecord(ids)) {
                this.removeRow(url, ids.join(','), success);
            }
        }
    });
    $.extend(cmp.grid, {
        column: {
            operate: function (options) {
                return {
                    field: (options.field || "_operate_"), align: "center",
                    title: (options.title || cmp.text.operate), width: (options.width || "80px"),
                    formatter: cmp.grid.render.operate({
                        text: options.text || cmp.text.operate,
                        icon: options.iconCls || "icon-man",
                        menuWidth: options.menuWidth || "100px",
                        menu: options.menu
                    })
                }
            },
            check: function (options) {
                return $.extend({field: "_check_", checkbox: true}, options || {});
            }
        },
        render: {
            operate: function (opt) {
                return function (val, row) {
                    //生成操作菜单
                    var pid = cmp.id("gridmenu"),
                        menuitemname = "_menuid_";
                    var tpl = ['<a href="#" class="cmp-menubutton" data-options="duration:100,height:20,width:72,menu:\'#' + pid + '\',iconCls:\'' + opt.icon + '\'">' + opt.text + '</a>'];
                    if (opt.menu) {
                        var menu = ["<div id='" + pid + "' style='display:none;width:" + opt.menuWidth + "'>"];
                        for (var i = 0; i < opt.menu.length; i++) {
                            //记录唯一标识，用来绑定事件
                            var m = opt.menu[i],
                                menuid = cmp.id("gridmenuitem");
                            m[menuitemname] = menuid;
                            var map = cmp.getActionMappers(m, "iconCls,text");
                            menu.push('<div id="' + menuid + '" data-options="iconCls:\'' + map.iconCls + '\'">' + map.text + '</div>');
                        }
                        menu.push("</div>");
                        $('body').append(menu.join(''));
                        //绑定操作菜单事件
                        for (var i = 0; i < opt.menu.length; i++) {
                            var m = opt.menu[i];
                            //采用闭包传参，避免循环总是赋值最后一个
                            (function (memuitem, fieldValue, rowData, itemname) {
                                $("#" + m[itemname]).click(function () {
                                    memuitem.onClick && memuitem.onClick(fieldValue, rowData);
                                })
                            })(m, val, row, menuitemname)
                        }
                    }
                    return tpl;
                }
            },
            date: function (fmt) {
                return function (val, row) {
                    fmt = fmt || "yyyy-MM-dd HH:mm";
                    return new Date(val).format(fmt);
                }
            },
            yesno: function () {
                return function (val, row) {
                    return val ? "是" : "否";
                }
            },
            truncate: function (len) {
                return function (val, row) {

                    return "<span title='{0}'>{1}</span>".format(val, val.truncate(len));
                }
            },
            img: function (w, h) {
                return function (val, row) {
                    var width = w ? 'width="' + w + 'px"' : '',
                        height = h ? 'height="' + h + 'px"' : '';
                    return '<img src="{0}" {1} {2}/>'.format(val, width, height);
                }
            },
            link: function (target) {
                return function (val) {
                    target = target || "_blank";
                    return '<a href="{0}" class="grid-cmd" target="{1}">{2}</a>'.format(val, target, val);
                }
            },
            status: function (value, row) {
                if (value = "000") {
                    return "有效";
                } else {
                    return "无效";
                }
            }
        },
        action: {}
    });
})(window.cmp, window.jQuery);

