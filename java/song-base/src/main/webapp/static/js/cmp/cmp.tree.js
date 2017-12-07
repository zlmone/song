/**
 * Created by 王松华 on 2017/9/8.
 */
(function (cmp, $) {
    cmp.tree = cmp.create({
        init: function () {
            this.renderMenu();
            this.el.tree(this.options);
        },
        renderMenu: function () {
            var menus = this.options.menu;
            if (!menus || menus.length <= 0) {
                return;
            }
            var menuid = cmp.id("treemenu"),
                that = this,
                opts = {
                    items: menus
                };
            $('body').append(cmp.builder.getMenuPanel(menuid, opts));
            $("#" + menuid).menu({
                onClick: function (item) {
                    $.each(menus, function (i, menuitem) {
                        if (menuitem.action == item.action || menuitem.id == item.id) {
                            if (menuitem.onClick) {
                                var node = that.getSelected();
                                menuitem.onClick.call(that, node, item);
                            }
                        }
                    });
                }
            });
            $.extend(this.options, {
                onContextMenu: function (e, node) {
                    e.preventDefault();
                    that.select(node);
                    $('#' + menuid).menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });
        },
        validNode: function (node) {
            return node && node.target;
        },
        getSelected: function () {
            return this.el.tree("getSelected");
        },
        getChecked: function () {
            return this.el.tree("getChecked");
        },
        removeNode: function (node) {
            this.el.tree("remove", node.target);
        },
        remove: function (node, url, success) {
            if (!this.validNode(node)) {
                return;
            }
            //支持本地删除模式和后台删除模式
            if (url) {
                var that = this;
                cmp.confirm(cmp.text.confirmRemoveNode, function () {
                    //后台删除，节点有id会自动带id，没有id则自定义参数
                    var params = cmp.param.attrs(node, "id,code");
                    cmp.postAjax(url, params, function (result) {
                        success && success(result);
                        if (cmp.isSuccess(result)) {
                            cmp.msg.success();
                            that.removeNode(node);
                        } else {
                            cmp.msg.error();
                        }
                    });
                });
            } else {
                this.removeNode(node);
            }
        },
        update: function (node, data) {
            if (this.validNode(node) && data) {
                data.target = node.target;
                this.el.tree("update", data);
            }
        },
        append: function (node, data) {
            if (this.validNode(node) && data && data.length > 0) {
                this.el.tree("append", {
                    parent: node.target,
                    data: data
                });
            }
        },
        insert: function (node, data, before_after) {
            if (this.validNode(node) && data) {
                var opts = {data: data};
                opts[before_after || "after"] = node.target;
                this.el.tree("insert", opts);
            }
        },
        getRoot: function () {
            return this.el.tree("getRoot");
        },
        loadData: function (data) {
            if (data && data.length > 0) {
                this.el.tree("loadData", data);
            }
        },
        reload: function (node) {
            if (!node) {
                node = this.getRoot();
            }
            if (this.validNode(node)) {
                this.el.tree("reload");
            }
        },
        select: function (node) {
            if (this.validNode(node)) {
                this.el.tree("select", node.target);
            }
        },
        collapse: function (node) {
            if (this.validNode(node)) {
                this.el.tree("collapse", node.target);
            }
        },
        expand: function (node) {
            if (this.validNode(node)) {
                this.el.tree("expand", node.target);
            }
        }
    });
})(window.cmp, window.jQuery);

