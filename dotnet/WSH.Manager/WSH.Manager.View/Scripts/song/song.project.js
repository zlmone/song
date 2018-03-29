/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Project
content:            项目应用相关
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song, j) {
    j.extend(song,{
        loadXml: function (url) {
            var xmlDoc;
            try { 
                xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
            } catch (e) { 
                xmlDoc = document.implementation.createDocument("", "", null); 
            }
            xmlDoc.async = false; xmlDoc.load(url); return xmlDoc;
        },
        open:function(opts){
            j.extend(this,{ width: 600, height: 300, left: 0, top: 0, target: "_blank" },opts); 
            this.top = ((screen.height - this.height) / 2) - 40; this.left = (screen.width - this.width) / 2; 
            var sb = new song.builder();
            sb.add("toolbar=no,location=no,directions=no,status=no,revisable=no,scrollbars=yes,menubar=no,");
            sb.addFmt("width={0}px,height={1}px,top={2}px,left={3}px", this.width, this.height, this.top, this.left);
            window.open(this.url, this.target, sb.toString());
        }
    });
    song.form=function(name){
        this.form=document.forms[name || 0];
    }
    song.form.prototype={
        submit:function(url){
           url && (this.form.action=url); 
           form.submit();
        },
        reset:function(){
            this.form.reset();
        },
        enabled:function(){
            var els=this.form.elements;
            for (var i = 0,len=els.length; i < len; i++) {
                els[i].disabled=true;
            }
        }
    }
    //---------------------------------select---------------------------------
    song.select = function (el) { 
        this.el = song.dom(el);this.items = this.el.options;
    }
    song.select.prototype={
        count: function () { return this.items.length;},
        index: function () {return this.el.selectedIndex;},
        currItem: function () {
            var index=this.index();
            if(index>-1){return this.items[index];}
            return null;
        },
        removeItem: function (index) { 
            if (index == null) { index = this.index(); if (index == -1) { return; } } this.items.remove(index);
             
        },
        addItem: function (text, value) {
            if (value == null) { value = text; } this.items.add(new Option(text, value));
        },
        existsItem: function (text, value) {
            if (typeof (text) != "string") {value = text.value; text = text.text; }
            for (var i = 0; i < this.items.length; i++) {
                var item = this.items[i]; if (text == item.text && value == item.value) {return true;}
            }; return false;
        },
        clearItem: function (start) {
            if (start == null) { start = 0; } for (var i = start; i < this.items.length; i++) { this.removeItem(i);i--;} 
        },
        dataBind: function (data, currIndex) {
            var index = currIndex == null ? 0 : currIndex;
            for (var i = 0; i < data.length; i++) {
                var txt = data[i], val = data[i];
                if (typeof (txt) == "object") { txt = txt.text; val = val.value; if (txt.selected == true) { index = i;}}
                this.addItem(txt, val);this.el.selectedIndex = index;
            }
        },
        remoteBind: function (options) {
            var opts = j.extend({ url: location.href,index: 0,clear: true,clearIndex: 0}, options || {});
            //alert(j.getUrl(opts.url, opts.params));
            var obj = this,url=new song.param(opts.url,opts.params).url;
            j.ajax({dataType: "json",type: "get",url:url,
                success: function (data) {
                    if (opts.clear == true) {obj.clearItem(opts.clearIndex);}obj.dataBind(data, opts.index);
                },
                error: function (xhr,error) { alert(error);}
            });
        },
        toOther: function (other, isAll, isRemove) {
            var next = new song.select(other);
            for (var i = 0; i < this.items.length; i++) {
                if (this.items[i].selected == true || isAll == true) {
                    var txt = this.items[i].text; var val = this.items[i].value;
                    if (!next.existsItem(txt, val)) {next.addItem(txt, val); if (isRemove == true) { this.items.remove(i); i--; }}
                }
            }
        },
        moveFirst:function(){
            var item=this.currItem(),firstChild=this.el.firstChild;
            if(item && item!=firstChild){
                this.el.insertBefore(item,firstChild);
            }
        },
        moveLast:function(){
            var item=this.currItem(),lastChild=this.el.lastChild;
            if(item && item!=lastChild){
                //j(this.items[lastIndex]).after(item);——jQuery方式实现
                this.el.appendChild(item);//——append方式实现
                //this.el.insertBefore(item,lastChild.nextSibling); 
            }
        },
        movePrev:function(){
            var item=this.currItem(),firstChild=this.el.firstChild;
            if(item && item!=firstChild){
                var prevChild=item.previousSibling;
                this.el.insertBefore(item,prevChild);
            }
        },
        moveNext:function(){
            var item=this.currItem(),lastChild=this.el.lastChild;
            if(item && item!=lastChild){
                var nextChild=item.nextSibling.nextSibling;
                this.el.insertBefore(item,nextChild);
            }
        }
    }
    //*******************************************cookie*******************************************
    song.cookie = {
        get: function(name){
		    var v = document.cookie.match('(?:^|;)\\s*' + name + '=([^;]*)');
		    return v ? decodeURIComponent(v[1]) : null;
        },
        set: function(name, value ,expires, path, domain){
            var str = name + "=" + encodeURIComponent(value);
		    if (expires != null || expires != '') {
			    if (expires == 0) {expires = 100*365*24*60;}
			    var exp = new Date();
			    exp.setTime(exp.getTime() + expires*60*1000);
			    str += "; expires=" + exp.toGMTString();
		    }
		    if (path) {str += "; path=" + path;}
		    if (domain) {str += "; domain=" + domain;}
		    document.cookie = str;
        },
        remove: function(name, path, domain){
            document.cookie = name + "=" +
			    ((path) ? "; path=" + path : "") +
			    ((domain) ? "; domain=" + domain : "") +
			    "; expires=Thu, 01-Jan-70 00:00:01 GMT";
        }
    };   
    
})(window.song, window.jQuery)