/*
 author:                 王松华
 email:                  songhuaxiaobao@163.com
 namespace:              Song.Suggest
 content:                搜索建议，自动补全
 beforeLoad:             jQuery,Song.Base
 createDate:             2012-03

 updatelist:
 2017-08-21  新增：支持本地数据加载模式
 */
;(function (song, j) {
    song.suggest = function (el, options) {
        this.el = j(el);
        song.suggest.base.constructor.call(this, song.suggest.defaults, options);
    };
    song.suggest.defaults = {
        modelType: "remote",
        localData: [],
        selectedIndex: -1,
        max: 10,
        delay: 500,
        url: "",
        name: "songsuggest",
        width: "equal",  //auto|equal|固定宽度
        height: "auto", //auto|固定高度
        textField: "text"
    };
    song.extend(song.control, song.suggest, {
        //showLoading:true,
        getType: function () {
            return song.suggest.base.getType() + ".suggest";
        },
        render: function () {
            var offset = song.position.getOffsetSize(this.el);
            var css = {zIndex: song.zIndex(), top: offset.height + offset.top, left: offset.left};
            css["width"] = this.width == "equal" ? offset.width - 2 : this.width;
            css["height"] = this.height;
            this.dropDown = j("<div class='song-suggest-dropdown'>").css(css).appendTo('body').hide();
            this.setEvent();
        },
        showLoading: function () {
            j("<div class='song-suggest-loading'>加载中...</div>").appendTo(this.dropDown);
        },
        setEvent: function () {
            var me = this;
            //this.el.bind("keydown",function(e){

            // });
            this.el.bind("keyup", function (e) {
                switch (e.which) {
                    case song.kc.up :
                    case song.kc.down : {
                        me._keyUpdown(e.which, val);
                        e.preventDefault();
                        return false;
                    }
                    case song.kc.enter: {
                        if (me.selectedIndex > -1) {
                            me.setSelectedValue();
                        }
                        e.preventDefault();
                        return false;
                    }
                    default: {
                        var val = this.value.trim();
                        me._keySearch(val);
                    }
                }

            });
        },
        _keyUpdown: function (kc, val) {
            //按上下键
            if (kc == song.kc.down) {
                this.selectedIndex++;
                this.selectItem();
            } else {
                this.selectedIndex--;
                this.selectItem();
            }
        },
        _keySearch: function (val) {
            //如果ajax正在请求，则避免重复请求
            var me = this;
            if (me.theRequest) {
                return;
            }
            ;
            if (val == "") {
                me.clearTimer();
                me.clearItem();
                return;
            } else {
                me.setTimer(val);
            }
        },
        localRequest: function (val) {
            if (this.localData) {
                var data = this.localData;
                this.createItem(data, val);
            }
        },
        request: function (val) {
            this.theRequest = true;
            var name = this.name, me = this;
            this.show();
            this.showLoading();
            // setTimeout(function(){
            j.ajax({
                type: "get", data: {name: val}, url: me.url, dataType: "json",
                success: function (data) {
                    me.theRequest = false;
                    me.createItem(data, val);
                },
                error: function (xhr, err) {
                    me.theRequest = false;
                    me.clearItem();
                    alert(err);
                }
            });
            //},1000);
        },
        createItem: function (data, val) {
            this.clearItem();
            var me = this;
            if (me.onDataFilter) {
                data = me.onDataFilter.call(this, val, data);
            }
            if (typeof data == "object" && data.length > 0) {
                //执行数据过滤事件
                for (var i = 0; i < data.length; i++) {
                    var d = data[i];
                    var a = j("<a>").attr({
                        href: song.href,
                        itemindex: i
                    }).html(d[this.textField].replace(val, "<strong>" + val + "</strong>"));
                    a.click(function (e) {
                        me.selectedIndex = this.getAttribute("itemindex");
                        me.setSelectedValue();
                        me.hide();
                    });
                    this.dropDown.append(a);
                    a = null;
                }
            }
            this.show();
        },
        selectItem: function () {
            var index = this.selectedIndex,
                aclass = "song-suggest-active";
            var items = this.dropDown.children("a[itemindex]");
            //判断，如果超过下标索引，则循环
            if (index >= items.length) {
                index = this.selectedIndex = 0;
            }
            if (index < 0) {
                index = this.selectedIndex = items.length - 1;
            }
            var item = items.filter("[itemindex='" + index + "']");
            items.removeClass(aclass);
            item.addClass(aclass);
            return item;
        },
        setSelectedValue: function () {
            var item = this.selectItem();
            var value = item.text();
            this.el.val(value);
            this.onSelectedValue && this.onSelectedValue.call(this, value);
        },
        setTimer: function (val) {
            var me = this;
            this.clearTimer();
            this.timer = setTimeout(function () {
                if (me.modelType == "local") {
                    me.localRequest(val);
                } else {
                    me.request(val);
                }
                me.clearTimer();
            }, this.delay);
        },
        clearTimer: function () {
            this.timer && clearTimeout(this.timer);
        },
        clearItem: function () {
            var items = this.dropDown.children();
            for (var i = 0; i < items.length; i++) {
                items.eq(i).unbind().html("").remove();
            }
            this.selectedIndex = -1;
            this.hide();
        },
        show: function () {
            this.dropDown.show();
        },
        hide: function () {
            this.dropDown.hide();
        },
        destroy: function () {
            this.clearTimer();
            this.el = null;
            this.dropDown = null;
        }
    });
})(window.song, window.jQuery);