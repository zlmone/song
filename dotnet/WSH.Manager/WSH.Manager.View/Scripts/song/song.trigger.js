/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Trigger
content:            下拉相关
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
(function (song, j) {
    song.trigger = function (options) {
        song.trigger.base.constructor.call(this, song.trigger.defaults, options);
    };
    song.trigger.defaults = {
        width: 250,
        valueName: song.id(),
        readOnly: false
    };
    song.trigger._template = [
        '<input type="text" class="song-trigger-text" autocomplete="off"/>',
        '<span  class="song-trigger-arrow"></span>',
        '<input type="hidden" class="song-trigger-value"/>',
    ].join('');
    song.extend(song.control, song.trigger, {
        _hoverCls: "song-trigger-arrow-hover",
        _activeCls: "song-trigger-arrow-active",
        _getDom: function () {
            var wrap = j('<span>').appendTo(this.renderTo || 'body');
            wrap.addClass("inline-block song-trigger-wrap").html(song.trigger._template);
            var els = wrap.children(), len = els.length, dom = {}, name, t = this.id, v = this.valueName;
            for (var i = 0; i < len; i++) {
                name = els[i].className.split('song-trigger-')[1];
                dom[name] = els.eq(i);
            }
            dom.arrow.addClass("inline-block");
            dom.text.addClass("textbox").attr("readOnly", this.readOnly).attr({ id: t, name: t });
            dom.value.attr({ id: v, name: v });
            dom.wrap = wrap;
            return dom;
        },
        _addHover: function () {
            this.dom.text.addClass("input-focus");
            this.dom.arrow.addClass(this._hoverCls);
        },
        _removeHover: function () {
            this.dom.text.removeClass("input-focus");
            this.dom.arrow.removeClass(this._hoverCls);
        },
        getType: function () {
            return song.trigger.base.getType() + ".trigger";
        },
        init: function () {
            var me = this;
            var dom = this.dom = this._getDom();
            dom.wrap.hover(function () {
                if (me.enabled) { return; }
                me._addHover();
            }, function () {
                if (me.enabled) { return; }
                me._removeHover();
            });
            this.setWidth();
            this.enabled && this.setEnabled(true);
        },
        setEnabled: function (enabled) {
            this.enabled = enabled;
            var dom = this.dom;
            if (enabled) {
                dom.wrap.addClass("enabled"); dom.text.attr("disabled", true);
            } else {
                dom.wrap.removeClass("enabled"); dom.text.removeAttr("disabled");
            }
            return this;
        },
        setWidth: function (w) {
            this.width = w || this.width;
            // this.dom.wrap.width(this.width);
            this.dom.text.width(this.width - 20 - 2);
            return this;
        },
        setText: function (text) {
            this.dom.text.val(text); return this;
        },
        setValue: function (value) {
            this.dom.value.val(value); return this;
        },
        set: function (text, value) {
            this.setText(text); this.setValue(value); return this;
        },
        getText: function () {
            return this.dom.text.val();
        },
        getValue: function () {
            return this.dom.value.val();
        },
        destroy: function () {
            this.dom = null;
        }
    });
    /***************************combo********************************/
    song.combo = function (options) {
        song.combo.base.constructor.call(this, options);
    }
    song.extend(song.trigger, song.combo, {
        border: true,
        isLoaded: false,
        isShow: false,
        getType: function () {
            return song.search.base.getType() + ".combo";
        },
        render: function () {
            var dom = this.dom, me = this;
            var d = j("<div class='song-trigger-dropdown'>").appendTo(dom.wrap);
            d.width(this.itemWidth ? this.itemWidth : this.width - (this.border ? 2 : 0));
            this.itemHeight && d.height(this.itemHeight);
            if (!this.border) {
                d.css({ borderWidth: 0 });
            }
            dom.dropDown = d;
            dom.wrap.bind("mouseout", function () {
                if (me.isShow) { me._addHover(); }
            }).bind("click", function (e) {
                e.stopPropagation();
            });
            dom.arrow.bind("click", function (e) {
                if (me.enabled) { return; }
                me.expand();
                if (!me.isLoaded) {
                    me.firstLoad && me.firstLoad.call(me);
                }
                e.stopPropagation();
            });
            j(document).bind("click", function () {
                if (me.enabled) { return; }
                me.collapse();
            });
            this._setPosition();
        },
        expand: function () {
            this.isShow = true;
            this.dom.dropDown.show();
            this._addHover();
        },
        collapse: function () {
            this.isShow = false;
            this.dom.dropDown.hide();
            this._removeHover();
        },
        _setPosition: function () {
            //            var d = this.dom.dropDown,
            //            offset = this.dom.wrap.offset(),
            //            client = song.position.client(),
            //            h = d.outerHeight(),
            //            t = 22;
            //            if (offset.top + h > client.height) {
            //                t = -h;
            //            }
            //            d.css({ top: t });
            new song.follow(this.dom.dropDown, { follow: this.dom.text, align: "left", dir: "bottom" });
        },
        destroy: function () {
            song.combo.base.destroy.call(this);
        }
    });
    /***************************comboGrid********************************/
    song.comboGrid = function (options, gridOptions) {
        j.extend(options, {
            border: 1,
            itemWidth: 600,
            itemHeight: 300,
            multiple: false
        });
        this.gridOptions = gridOptions;
        song.comboGrid.base.constructor.call(this, options);
    }
    song.extend(song.combo, song.comboGrid, {
        getType: function () {
            return song.comboGrid.base.getType() + ".comboGrid";
        },
        loaded: function () {
            var me = this;
            this.dom.dropDown.show();
            var opts = j.extend(this.gridOptions, {
                width: "100%",
                height: "100%",
                autoLoad: false,
                singleSelect: !this.multiple,
                renderTo: this.dom.dropDown,
                afterLoad: function (success) {
                    if (!success) me.isLoaded = false;
                },
                onRowClick: function (row) {
                    var tf = me.textField, vf = me.valueField || tf, t = "", v = "";
                    if (!me.multiple) {
                        t = row.data[tf];
                        v = row.data[vf];
                        me.collapse();
                    } else {
                        var rows = this.getSelectedRows();
                        if (rows) {
                            var len = rows.length, texts = [], values = [], d;
                            for (var i = 0; i < len; i++) {
                                d = rows[i].data;
                                texts.push(d[tf]);
                                values.push(d[vf]);
                            }
                            t = texts.join(","); v = values.join(",");
                        }
                    }
                    me.setText(t);
                    me.setValue(v);
                }
            });
            this.grid = new song.grid(opts);
            this.dom.dropDown.hide();
        },
        firstLoad: function () {
            var grid = this.grid;
            if (!grid) { return; }
            this.isLoaded = true;
            grid.load();
        },
        destroy: function () {
            song.comboGrid.base.destroy.call(this);
            this.gridOptions = null;
            this.grid = null;
        }
    });
    /***************************comboTree********************************/
    song.comboTree = function (options, treeOptions, treeNode) {
        j.extend(options, {
            padding: 5,
            isSelectParent: false
        });
        song.comboTree.base.constructor.call(this, options);
        this.dom.dropDown.html("<ul class='ztree' id='combotree-{0}' style='padding:{1}px'></ul>".format(this.id, this.padding));
        j.fn.zTree.init(j("#combotree-" + this.id), treeOptions, treeNode);
    }
    song.extend(song.combo, song.comboTree, {
        getType: function () {
            return song.comboTree.base.getType() + ".comboTree";
        },
        getTree: function () {
            return song.ztree.get("combotree-"+this.id);
        },
        destroy: function () {
            song.comboTree.base.destroy.call(this);
            // this.treeOptions = null;
        }
    });
    /***************************查询框********************************/
    song.search = function (options) {
        options = j.extend(options, { readOnly: true });
        song.search.base.constructor.call(this, options);
    };
    song.extend(song.trigger, song.search, {
        getType: function () {
            return song.search.base.getType() + ".search";
        },
        render: function () {
            var me = this, dom = this.dom;
            dom.text.css("cursor", "pointer");
            dom.arrow.addClass("song-search");
            if (!this.enabled && this.onSearch) {
                dom.wrap.bind("click", function () {
                    me.onSearch.call(me);
                });
            }
        }
    });
})(window.song, window.jQuery)
