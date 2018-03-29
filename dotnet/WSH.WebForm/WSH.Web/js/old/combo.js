j.combox = j.getClass();
j.combox.prototype = {
    init: function(el, opts) {
        this.opts = j.extend({
            path: "../images/grid-ext/",
            readonly: false,
            width: 160,
            query: true,
            data: []
        }, opts || {});
        this.el = $(dom(el));
        this.create();
        this.query();
    },
    create: function() {
        var imgwidth = 17;
        var elwidth = this.opts.width - imgwidth;
        this.el.attr("class", "text combo-text").attr("autocomplete", "off").width(elwidth);
        if (this.opts.readonly == true) {
            this.el.attr("readonly", "readonly").attr("onfocus", "this.blur()");
            this.el.attr("onselectstart", "return false;").addClass("noselect");
        }
        var img = $("<img>").attr("src", this.opts.path + "s.gif");
        img.addClass("combo-img");
        this.el.after(img);
        //创建隐藏域
        var val = this.val = $("<input>").attr("type", "hidden");
        if (this.opts.valueId != null) {
            val.attr("id",this.opts.valueId);
        }
        img.after(val);
        //创建下拉框
        var items = this.items = $("<div>").addClass("combo-items").width(this.opts.width).appendTo(document.body);
       
        img.bind("click", j.bindWithEvent(this, this.show));
        $(document).bind("click", (function(items) {
            return function() {
                items.hide();
            }
        })(items));
        this.el.bind("click", function(e) {
            e.stopPropagation();
        });
        for (var i in this.opts.data) {
            var item = this.opts.data[i];
            this.add(item.text, item.value);
        }
    },
    show: function(e) {
        j.evt(e).stop();
        if (this.items.css("display") == "none") {
            this.items.show();
            this.setSelected();
            j.showEl(this.el, this.items);
        } else {
            this.items.hide();
        }
    },
    add: function(text, value) {
        var item = $("<a>").attr("href", "javascript:").attr("val", value).html(text).appendTo(this.items);
        item.bind("click", (function(obj) {
            return function() {
                var curr = $(this);
                obj.el.val(curr.html());
                obj.val.val(curr.attr("val"));
            }
        })(this));
    },
    setSelected: function() {
        var items = this.items.children("a");
        items.filter(".combo-selecteditem").removeClass("combo-selecteditem");
        var val = this.getValue();
        items.each(function(i) {
            $(this).show();
            if ($(this).attr("val") == val) {
                $(this).addClass("combo-selecteditem");
            }
        });
    },
    getValue: function() {
        return this.val.val();
    },
    setValue: function(value, text) {
        this.val.val(value);
    },
    query: function() {
        if (this.opts.query == true) {
            var items = this.items.children("a");
            var obj = this;
            this.el.bind("keyup", function(e) {
                var value = e.target.value;
                var count = 0;
                obj.items.show();
                items.each(function(i) {
                    if (!$(this).html().startWith(value)) {
                        $(this).hide();
                    } else {
                        $(this).show();
                        count++;
                    }
                });
                if (count <= 0) {
                    obj.items.hide();
                }
            });
        }
    }
}