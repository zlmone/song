/*
author:         wang song hua
createDate:     2013-4-17
content:        应用选项卡组件
*/
define(function (require, exports, model) {
    var $ = require('jquery');
    var Backbone = require('backbone');
    require("jquery.sortable")($);

    var AppTabView = Backbone.View.extend({
        fix: "appTab-",             //元素id的前缀
        max: 20,                    //最多打开的应用数
        count: 0,                   //已经打开的应用数
        tabs: {},                   //打开的应用集合
        startIndex: 0,              //显示区域开始的应用index
        displayCount: 6,            //显示区域最多能显示多少个应用
        activeCls: "sel",          //选中的标签页样式
        initialize: function () {
            //初始化应用选项卡相关的元素
            this.dom = {
                prev: $("#jsAppTabPrev"),
                next: $("#jsAppTabNext"),
                menuBtn: $("#jsAppTabMenuBtn"),
                menu: $("#jsAppTabMenu"),
                titleWrap: $("#jsAppTabTitleWrap")
            };
            var that = this;
            this.dom.prev.click(function () {
                that.prev();
            });
            this.dom.next.click(function () {
                that.next();
            });
            this.showMenu();
            //拖动标签页排序
            this.dom.titleWrap.disableSelection().sortable();
        },
        getId: function (code, type) {
            return this.fix + code + "-" + type;
        },
        getFrameId: function (code) {
            return "AppFrame_" + code;
        },
        getFrameEl: function (code) {
            return $("#" + this.getFrameId(code));
        },
        getClass: function (type) {
            return "jsAppTab-" + type;
        },
        getEl: function (code, type) {
            //根据应用编码和类型得到元素
            return $("#" + this.getId(code, type));
        },
        getEls: function (tag, type) {
            //根据class得到元素集合
            var t = tag + "." + this.getClass(type);
            return $("#jsApp").find(t);
        },
        getActiveTitle: function () {
            //得到选中的标签页
            return this.getEl(this.activeCode, "title");
        },
        hasActive: function (code) {
            return this.getCode() == code;
        },
        getCode: function (li) {
            //得到应用编码
            return li ? li.attr("appcode") : this.activeCode;
        },
        open: function (options) {
            //打开一个应用
            $(".jsMain").hide();
            $("#jsApp").show();
            var code = options.code;
            this.has(code) ? this.active(code) : this.create(options);
        },
        has: function (code) {
            //判断是否已经打开应用
            return !!this.tabs[code];
        },
        create: function (options) {

            //创建一个选项卡
            if (this.count > this.max) {
                alert("最多同时打开" + this.max + "个应用"); return;
            }
            var code = options.code;
            $("#jsAppTabContentWrap").append(this.createContent(options));
            this.dom.titleWrap.prepend(this.createTitle(options));
            this.dom.menu.append(this.createMenu(options));
            this.tabs[code] = options.text;
            this.count++;
            this.active(code);
        },
        createContent: function (options) {
            //创建内容元素
            var id = this.getFrameId(options.code),
                divid = this.getId(options.code, "content"),
                that = this,
                divcls = this.getClass("content"),
                frame = $("<iframe style='min-height: 450px'>").attr({
                    width: "100%", height: "450px",
                    frameborder: "0",
                    src: options.url, id: id
                }),
                wrap = $("<div>").attr("id", divid).addClass(divcls).addClass("pageloading").append(frame);
            this.loaded(frame, function () {
                $(this).parent().removeClass("pageloading");
                that.autoHeight(this);
                var iframe = this,
                    me = that;
                //定时监控iframe高度是否发生变化
                setInterval(function () {
                    me.autoHeight(iframe);
                }, 1000);
            });
            return wrap;
        },
        createTitle: function (options) {
            //创建标签页元素
            var title = $("<li>"),
                that = this,
                code = options.code,
                cls = this.getClass("title"),
                titleid = this.getId(code, "title"),
                closeid = this.getId(code, "close"),
                close = $("<span>"),
                text = $("<a>");
            close.attr({ appcode: code, appname: options.appname, id: closeid }).html(" X ");
            close.click(function (e) {
                var a = $(this);
                that.remove(a.attr("appcode"), a.attr("appname"));
                return false;
            });
            text.html(options.text).attr("href", "javascript:void(0)");
            title.addClass(cls).attr({ id: titleid, appcode: code }).append(text).append(close);
            title.click(function () {
                var code = $(this).attr("appcode");
                that.hasActive(code) || that.active(code);
            });
            return title;
        },
        createMenu: function (options) {
            //创建菜单元素
            var that = this,
                id = this.getId(options.code, "menu"),
                menu = $("<dd>").attr({ id: id, appcode: options.code });
            menu.html('<a href="javascript:void(0);"><img src="' + options.img + '" width="24" height="24">&nbsp;' + options.text + '</a>');
            menu.click(function () {
                that.active($(this).attr("appcode"));
            });
            return menu;
        },
        loaded: function (el, callback) {
            var dom = el.get(0);
            document.addEventListener ? el.bind("load", function () {
                $(this).unbind("load");
                callback.call(this);
                dom = null;
            }) : dom.onreadystatechange = function () {
                if (/loaded|complete/.test(this.readyState)) {
                    dom.onreadystatechange = null;
                    callback.call(this);
                    dom = null;
                }
            };
        },
        autoHeight: function (frame) {
            try {
                //本域iframe高度自适应
                var win = frame.contentWindow,
                    doc = win.document,
                    docEl = doc.documentElement,
                    body = doc.body,
                    height = Math.max(docEl.clientHeight, docEl.scrollHeight),
                    that = this;
                frame.height = height + "px";
            } catch (e) { }
        },
        remove: function (code, text) {
            //移除一个选项卡
            //if(!confirm("确定要关闭"+text+"？")){return;}
            var close = this.getEl(code, "close"),
                title = this.getEl(code, "title"),
                frame = this.getFrameEl(code),
                content = this.getEl(code, "content"),
                menu = this.getEl(code, "menu"),
                isActive = this.hasActive(code);
            close.unbind("click").remove();
            title.unbind().remove();
            // 重要！需要重置iframe地址，否则下次出现的对话框在IE6、7无法聚焦input
            // IE删除iframe后，iframe仍然会留在内存中出现上述问题，置换src是最容易解决的方法
            frame.attr("src", "about:blank").remove();
            content.remove();
            menu.unbind("click").remove();
            this.count--;
            delete this.tabs[code];
            //移除了则显示第一个
            if (isActive) {
                var titles = this.getEls("li", "title");
                if (titles.length > 0) {
                    this.active(this.getCode(titles.eq(0)));
                }
            } else {
                //如果移除的不是选中的标签页，则往前移动一个位置
                if (this.startIndex > 0) {
                    this.startIndex--;
                }
                this.resetActive();
            }

            //当this.count为0时，跳转到应用首页
            if (!this.count) {
                Backbone.Router.prototype.navigate('App')
            }
        },
        resetActive: function () {
            this.activeStart();
            this.checkMore();
        },
        checkMore: function () {
            var start = this.startIndex,
                count = this.displayCount,
                total = this.getEls("li", "title").length;
            //如果有超出显示区域的应用则开启分页模式
            if (total > count) {
                this.dom.prev.show();
                this.dom.next.show();
                this.dom.menuBtn.show();
                //判断上下页是否可用
                this.dom.prev.attr("class", "app_leftScroll");
                this.dom.next.attr("class", "app_rightScroll");
                if (start == 0) {
                    this.dom.prev.attr("class", "app_leftNoScroll");
                }
                if (start + count >= total) {
                    this.dom.next.attr("class", "app_rightNoScroll");
                }
            } else {
                this.dom.prev.hide();
                this.dom.next.hide();
                this.dom.menu.parent().hide();
                this.dom.menuBtn.hide();
            }
        },
        active: function (code, noSelected) {
            //根据应用编码选中指定的应用
            var li = this.getEl(code, "title"),
                index = li.prevAll("li").length,
                start = this.startIndex,
                count = this.displayCount;
            //判断应用是否在左边隐藏区域
            if (index < start) {
                this.startIndex = index;
            }
            //判断应用是否在右边隐藏区域
            if (index >= count + start) {
                this.startIndex = index + 1 - count;
            }
            this.activeStart();
            if (noSelected != true) {
                this.getEls("li", "title").removeClass(this.activeCls);
                li.addClass(this.activeCls);
                this.activeCode = this.getCode(li);
                this.getEls("div", "content").hide();
                this.getEl(code, "content").show();
            }
            this.checkMore();
        },
        activeStart: function () {
            //从开始位置选中应用
            var start = this.startIndex,
                count = this.displayCount;
            this.getEls("li", "title").each(function (i) {
                if (i < start || (i >= start + count)) {
                    $(this).hide();
                } else {
                    $(this).show();
                }
            });
        },
        getStartTitle: function () {
            return this.getEls("li", "title").eq(this.startIndex);
        },
        getEndTitle: function () {
            return this.getEls("li", "title").eq(this.startIndex + this.displayCount - 1);
        },
        prev: function () {
            //移动到上一个隐藏应用
            var active = this.getStartTitle(),
                prev = active.prev("li");
            if (prev.length > 0) {
                if (this.startIndex > 0) {
                    this.startIndex--;
                }
                this.resetActive();
            }
        },
        next: function () {
            //移动到下一个隐藏应用
            var active = this.getEndTitle(),
                next = active.next("li");
            if (next.length > 0) {
                this.startIndex++;
                this.resetActive();
            }
        },
        showMenu: function () {
            //显示更多应用菜单
            var that = this;
            this.dom.menuBtn.click(function () {
                var menu = that.dom.menu,
                    isHide = menu.is(":hidden");
                if (isHide) {
                    menu.parent().slideDown("fast");
                    that.setTimer();
                }
            });
            this.dom.menu.hover(function () {
                that.clearTimer();
            }, function () {
                that.setTimer();
            });
        },
        setTimer: function () {
            //设置菜单定时器
            this.clearTimer();
            var that = this;
            this.timer = setTimeout(function () {
                that.dom.menu.parent().fadeOut();
            }, 1500);
        },
        clearTimer: function () {
            //清除菜单定时器
            this.timer && clearTimeout(this.timer);
        }
    });
    return AppTabView;
});