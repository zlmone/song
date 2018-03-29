j.upload = j.getClass();
j.upload.prototype = {
    init: function (opts) {
        j.extend(this, opts, {
            id: "j-upload" + j.guid(),
            size: 2,
            count: 4,
            height: 200,
            type: ["jpg", "jpeg", "bmp", "ico", "gif", "png", "doc", "docx", "txt", "exe"],
            renderTo: j.getBody()
        });
        this.createPanel();
    },
    createPanel: function () {
        var obj = this;
        var listid = this.id + "list";
        var wrap = j("<div>").setClass("panel-ext").attr({ id: this.id });
        this.width && wrap.width(this.width);
        var list = this.list = j("<div>").attr({ id: listid }).setClass("j-upload-list").height(this.height - 27).appendTo(wrap);
        wrap.appendTo(j(this.renderTo));
        var tb = this.tb = new j.toolbar({ renderTo: wrap.get() });
        //创建选择按钮
        var filewrap = j("<div>").setClass("j-upload");
        var fake = j("<a>").setClass("j-upload-link btn-ext").attr({ "href": j.nullUrl });
        fake.html('<span class="btn-ext-right"><span class="btn-ext-center">浏览...</span></span>');
        var file = j("<input>").setClass("j-upload-file").attr({ type: "file" }).bind("change", function () {
            var fname = this.value;
            var l = j(listid);
            //检测文件重名
            var items = l.tag("lable");
            for (var i = 0; i < items.length; i++) {
                if (items[i].innerHTML.has(fname)) { return; }
            }
            //检测文件个数
            var count = obj.count;
            if (items.length >= count) {
                alert("最多只能同时上传{0}个文件!".format(count)); return;
            }
            //检测文件类型
            var type = obj.type;
            if (type != "*") {
                var ftype = fname.substring(fname.lastIndexOf(".") + 1);
                if (Array.indexOf(type, ftype) == -1) {
                    alert("只能上传{0}格式的文件！".format(type.toString())); return;
                }
            }
            //检测文件大小
            var size;
            if (this.files == null) {
                try {
                    var fso = new ActiveXObject('Scripting.FileSystemObject');
                    size = fso.GetFile(fname);
                } catch (e) {
                    var img = new Image();
                    img.dynsrc = fname;
                    size = img.fileSize;
                }
            } else {
                size = this.files[0].fileSize;
            }
            var mb = Math.round(size / (1024 * 1024));
            if (mb > obj.size) {
                alert("最大只能上传{0}MB大小的文件！".format(obj.size)); return;
            }
            var row = j("<a>").setClass("j-upload-item").attr("href", j.nullUrl);
            var name = j("<lable>").html(fname);
            var del = j("<span>").attr("title", "删除").setClass('j-upload-remove icon-delete').bind("click", function () {
                var p = this.parentNode;
                j(this).unbind("click").remove();
                j(p).remove();
            });
            row.append(name).append(del).appendTo(l);
        });
        filewrap.append(fake).append(file);
        tb.add("-");
        tb.add(filewrap.get());
        var t = obj.type;
        if (t != "*") {
            tb.add("-");
            tb.add("&nbsp;格式：");
            tb.add("<span class='j-upload-limit' title='{0}'>{1}...&nbsp;</span>".format(t.toString(), t[0].toString()));
        }
        tb.add("-");
        tb.add("&nbsp;大小：");
        tb.add("<span class='j-upload-limit'>{0}MB</span>&nbsp;".format(this.size));
        tb.add("-");
        tb.add("&nbsp;最多：");
        tb.add("<span class='j-upload-limit'>{0}</span>&nbsp;".format(this.count));
        tb.add("-");
        tb.add({ text: "清空", icon: "reload", handler: function () {
            if (confirm("确定清空文件列表？")) {
                var items = dom(listid).childNodes;
                for (var i = 0; i < items.length; i++) {
                    var nodes = items[i].childNodes;
                    for (var k = 0; k < nodes.length; k++) {
                        var node = j(nodes[k]);
                        if (node.hasClass("j-upload-remove")) { node.unbind("click"); } node.remove(); k--;
                    }; j(items[i]).remove(); i--;
                }
            }
        }
        });
        tb.add({ text: "上传 ", icon: "save", handler: function () {
 
        }
        });
    }
}