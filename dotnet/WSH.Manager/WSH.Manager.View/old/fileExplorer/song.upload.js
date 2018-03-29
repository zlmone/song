/*
author:               	wang song hua
email:                 	songhuaxiaobao@163.com
url:                    http://www.netstudio80.com
namespace:      		Song.Upload
content:            	web应用相关
beforeLoad:     		j,base
dateUpdated:  			2013-01-22
*/
; (function (song, j) {
    song.upload = function (options) {
        song.upload.base.constructor.call(this, song.upload.defaults, options);
    };
    song.upload.defaults = {
        
    };
    song.extend(song.control, song.upload, {
        render: function () {
            this.iframeID=this.id+"-upload-iframe";
            this.dom=this._getDom();
        },
        _getDom:function(){
            var dom={};
             
            return dom;
        },
        size:function(width,height){
            
        },
        createIframe:function(){
            var id=this.iframeID;
            return j('<iframe src="javascript:false;">').attr({id:id,name:id}).hide().appendTo('body')[0];
        },
        createForm:function(){
            var form=j("<form>").attr({method:"POST",enctype:"multipart/form-data"});
            form.attr({action:this.url,target:this.iframeID});
            return form.hide().appendTo('body')[0];
        },
        getIframeData:function(){
            var iframe=song.dom(this.iframeID),
                html=song.iframe.getContent(iframe);
            if(html){
                return html.toJson();
            }
            return null;
        },
        setProgress:function(progress,rate){
            progress.css("width",rate+"%");
            //progress.parent().parent().html(rate);
        },
        sendFile:function(obj){
            
            var me=this,
                file=obj.files,
                name=obj.name,
                xhr = window.XMLHttpRequest ? new window.XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");
            //FireFox Safari Chrome
            if(xhr.upload){
               
                xhr.upload.addEventListener("progress", function(e){
                    
                    if (e.lengthComputable) {
                        var rate = Math.round(e.loaded * 100 / e.total);
                        me.setProgress(obj.progress,rate);
                    }
                    else {
                        me.setProgress(obj.progress,100);
                    }
                }, false);
//                if(file.getAsBinary){
//                    var boundary = "AjaxUploadBoundary" + (new Date).getTime();
//                    xhr.setRequestHeader("Content-Type", "multipart/form-data; boundary=" + boundary);
//                    xhr[xhr.sendAsBinary ? "sendAsBinary" : "send"](me.multipart(boundary, name, file));
//                } else {
//                    
//                };
               // xhr.setRequestHeader("Content-Type", "multipart/form-data");
                //xhr.setRequestHeader("X-Name", name);
                //xhr.setRequestHeader("X-Filename", file.fileName);
                var fd = new FormData();
                fd.append("fileToUpload", file);
                xhr.open("POST",this.url);
                xhr.send(fd);
            }else{
                //IE Opera 
                var iframe=me.createIframe(),
                    form=me.createForm();
                iframe.onreadystatechange=function(){
                    if(/loaded|complete/i.test(iframe.readyState)){
                        me.iframeLoad(iframe);
                    }else{
                        me.onProgress && me.onProgress();
                    }
                }
            }
        },
        iframeLoad:function(iframe){
            iframe.onreadystatechange = iframe.onload = iframe.onerror = null;

        },
        multipart:function(boundary, name, file){
            var br="\r\n";
            return  "--".concat(
                boundary, br,
                'Content-Disposition: form-data; name="', name, '"; filename="', file.fileName, '"', br,
                "Content-Type: application/octet-stream", br,
                br,
                file.getAsBinary(), br,
                "--", boundary, "--", br
            );
        },
        destroy: function () {

        }
    });
    song.upload._template="";
})(window.song, window.jQuery)