/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
namespace:      Song.Menu
content:            菜单
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
;(function (song, j) {
    song.menu = function (options) {
        song.menu.base.constructor.call(this, song.menu.defaults, options);
    };
    song.menu.defaults = {
        width: 100
    };
    song.extend(song.control, song.menu, {
        menus: {},
        getType: function () {
            return song.menu.base.getType() + ".menu";
        },
        render: function () {
            var me = this;
            this.menu = this.createMenu(null, this.width);
            this.addRange(this.items);
            j(document).bind("click", function () {
                me.hide();
            });
        },
        getEnabled: function (itemid) {
            return j(("#" + itemid)).hasClass("song-menu-enabled");
        },
        setEnabled: function (itemid, enabled) {
            var item = j("#" + itemid);
            enabled ? item.addClass("song-menu-enabled") : item.removeClass("song-menu-enabled");
        },
        addRange: function (items, menu) {
            if (this.items) {
                for (var i in items) {
                    this.addItem(items[i], menu);
                }
            }
        },
        removeItem: function (itemid) {
            j("#" + itemid).unbind().remove();
        },
        addItem: function (item, menu) {
            var me = this;
            item.id = (item.id || song.id());
            if (!menu) {
                menu = me.menu;
            }
            if (item == "-" || item.line) {
                menu.items.append("<li class='song-menu-separator'>");
                return;
            }
            ;
            var temp = [
                '<li class="song-menu-item radius">',
                '<a href="javascript:void(0)" class="song-menu-link">',
                '<span class="song-menu-icontext">', item.text, '</span>',
                '</a>',
                '</li>'
            ];
            var menuItem = $(temp.join("")).appendTo(menu.items);
            menuItem.attr("id", item.id);
            if (item.iconClass || item.icon) {
                var icon = $("span.song-menu-icontext:first", menuItem);
                item.iconClass && icon.addClass(item.iconClass);
                item.icon && icon.css("background-image", "url(" + item.icon + ")");
            }
            ;
            item.enabled && menuItem.addClass("song-menu-enabled");
            if (item.items) {
                menuItem.css("position", "relative").attr("isItems", true);
                j(">a.song-menu-link:first", menuItem).addClass("song-menu-arrow");
                var menuChild = this.createMenu(item.id, item.width);
                menuItem.append(menuChild);
                this.addRange(item.items, menuChild);
            }
            ;
            //显示子菜单
            menuItem.hover(function () {
                var that = j(this);
                if (!that.hasClass("song-menu-enabled")) {
                    that.addClass("song-menu-hover");
                    var children = $("div.song-menu-panel:first", that);
                    me.showAt(that.offset(), children, that.width(), that.outerHeight());
                }
            }, function () {
                var that = j(this);
                if (!that.hasClass("song-menu-enabled")) {
                    var children = $("div.song-menu-panel:first", that);
                    children && children.hide();
                    j(this).removeClass("song-menu-hover");
                }
            });
            //执行事件
            menuItem.click(function (e) {
                var that = $(this);
                var enabled = that.hasClass("song-menu-enabled");
                if (!enabled && !that.attr("isItems")) {
                    me.hide();
                    item.onClick && item.onClick.call(this, item);
                }
            });
        },
        getChildMenu: function (itemid) {
            if (this.menus[itemid]) {
                return this.menus[itemid];
            }
        },
        createMenu: function (pid, width) {
            var menu = j("<div class='song-menu-panel box-shadow'></div>");
            var items = menu.items = j("<ul>");
            items.appendTo(menu);
            menu.bind("click", function (e) {
                e.stopPropagation();
            }).bind("contextmenu", function (e) {
                e.stopPropagation();
                e.preventDefault();
            });
            width = width || this.width;
            menu.width(width);
            if (pid) {
                menu.attr("parentID", pid);
            } else {
                menu.css("z-index", song.zIndex()).attr("id", this.id).appendTo("body");
            }
            ;
            this.menus[pid || this.id] = menu;
            return menu;
        },
        showEl: function (options) {
            new song.follow(this.menu, options);
        },
        showEvent: function (e) {
            this.showAt({left: e.pageX, top: e.pageY});
            e.preventDefault();
        },
        showAt: function (pos, menu, pwidth, pheight) {
            var noChild = !menu;
            menu = menu || this.menu;
            pwidth = pwidth || 0;
            pheight = pheight || 0;
            var win = j(window);
            var wwidth = win.width();
            var wheight = win.height();
            var mwidth = menu.outerWidth();
            var mheight = menu.outerHeight();
            //自适应位置
            pos.left = (pos.left + mwidth + pwidth > wwidth) ? (noChild ? pos.left - mwidth : -mwidth) : (pwidth || pos.left);
            pos.top = (pos.top + mheight + pheight > wheight) ? (noChild ? pos.top - mheight : -(mheight - pheight)) : (noChild ? pos.top : 0);
            menu.css(pos);
            if (noChild) {
                this.show();
            } else {
                menu.show();
            }
        },
        show: function () {
            if (!this.isShow) {
                this.menu.show();
                this.isShow = true;
                this.onShow && this.onShow.call(this);
            }
        },
        hide: function () {
            if (this.isShow) {
                this.menu.hide();
                this.isShow = false;
                this.onHide && this.onHide.call(this);
            }
        },
        destroy: function () {
            this.menu.items = null;
            this.menu = null;
            this.menus = null;
        }
    });
    //右键菜单，继承Menu
    song.contextmenu = function (options) {
        song.contextmenu.base.constructor.call(this, options);
    };
    song.extend(song.menu, song.contextmenu, {
        getType: function () {
            return song.menu.base.getType() + ".contextmenu";
        },
        loaded: function () {
            var me = this;
            $(me.el || 'body').bind("contextmenu", function (e) {
                e.preventDefault();
                me.showAt({left: e.pageX, top: e.pageY});
            });
        }
    });
})(window.song, window.jQuery)