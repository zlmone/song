/*
author:                 wang song hua
email:                  songhuaxiaobao@163.com
namespace:              Song.Upload
content:                上传控件
beforeLoad:             jQuery,song.base
dateUpdated:            2012-11-07
*/
; (function (song,j) { 
    song.upload=function(options){
        song.upload.base.constructor.call(this,song.upload.defaults,options);
    };
    j.extend(song.upload,{
        defaults:{
            editable:true,
            uploadedFiles:"",
            uploadPath:"Upload",
            queueId:"fileQueue",
            listId:"fileList",
            multi:true,
            auto:false,
            fileExt:".jpg;.gif;.bmp;.png;.doc;.docx;.xls;.xlsx;.ppt;.pptx;.zip;.rar;.txt;.pdf",
            fileDesc:"Web Files (.jpg,.gif,.bmp,.png,.doc,.docx,.xls,.xlsx,.ppt,.pptx,.zip,.rar,.txt,.pdf)",
            maxSize:5
        },
        buttonHover:function(el){
            j(el).hover(function(){
                j(this).addClass("uploadify-hover");
            },function(){
                j(this).removeClass("uploadify-hover");
            });
        }
    });
    song.extend(song.control,song.upload,{
        init:function(){
            this.createDom();
            //绑定已经上传过的文件
            this.bindFiles(this.uploadedFiles);
        },
        render:function(){
            if(this.editable){
                var that=this;
                $('#'+this.id).uploadify({
                    formData:{uploadPath:decodeURIComponent(this.uploadPath)},
				    swf: song.root+'Scripts/uploadify/uploadify.swf',
				    uploader:song.root+'FileUploader/Uploader',
                    queueID:this.queueId,
                    multi:this.multi,
                    fileTypeExts:this.getExts(),
                    fileTypeDesc:this.fileDesc,
                    fileSizeLimit:this.getFileByte(),
                    buttonText:"选择文件",
                    successTimeout:0,
                    removeTimeout:0,
                    width:80,
                    height:24,
                    auto:this.auto,
                    onUploadComplete:function(file){
                        //var file={size:21212,name:"2.png",type:".png",index:0}
                    },
                    onUploadSuccess:function(file,result,isSuccess){ 
                        var json=result.toJson();
                        if(json.status==1){
                            that.bindFiles([json.url,file.name].join(','));
                        }
                    }
			    });
            }
        },
        uploadFiles:function(){
            var count=j("#"+this.queueId).find("div.uploadify-queue-item").length;
            if(count>0){
                //参数：fileId,*代表所有
                 $('#'+this.id).uploadify("upload","*");
            }else{
                window.top.song.alert("请选择文件");
            }
        },
        getExts:function(){
            var arr=this.fileExt.split(';'),
                newArray=[],
                descArray=[];
            for (var i = 0; i < arr.length; i++) {
                var ext=arr[i].delStart('.');
                newArray.push("*."+ext.toLowerCase());
                newArray.push("*."+ext.toUpperCase());
                descArray.push("."+ext.toUpperCase());
            }
            this.fileDesc="Web Files ({0})".format(descArray.join(','));
            return newArray.join(';');
        },
        getFileByte:function(){
            return this.maxSize * 1024 * 1024;
        },
        bindFiles:function(files){
            var val=files;
            if(val!=""){
                var fileArray=val.split('|');
                for (var i = 0; i < fileArray.length; i++) {
                    var info=fileArray[i].split(','),
                        del="song.getCmp('{0}').deleteFile('{1}')".format(this.id,fileArray[i]),
                        filename=info[1],
                        truncatename=this.truncate ? filename.truncate(this.truncate) : filename;
                        filepath=info[0],
                        delHtml=this.editable ? '<a class="uploadify-deletefile" href="{0}" onclick="{1}">删除</a>'.format(song.href,del) : '',
                        fileCls="file-"+song.path.getExtension(filename).delStart("."),
                        templ=[
                        '<div filename="',info[0],'" class="uploadify-fileitem">',
                            '<button class="uploadify-filetype filetype ',fileCls,'"></button>',
                            '<a href="',filepath,'" target="_blank" class="uploadify-filename" title="',info[1],'">',truncatename,'</a>',
                            delHtml,
                        '</div>'];
                    j("#"+this.listId).append(templ.join(''));  
                    this.updateHideFile(fileArray[i],"Upload");
                }
            }
        },
        deleteFile:function(fileinfo){
            var that=this;
            window.top.song.confirm("确定删除该附件吗？",function(){
                var info=fileinfo.split(',');
                var item=j("#"+that.listId).find("div[filename='{0}']".format(info[0]));
                if(item.length>0){
                    var result=true;
                    if(that.onDeleteFile && that.onDeleteFile(info[0],info[1])===false){
                        result=false;
                    }
                    if(!result){
                        item.fadeOut(function(){
                            j(this).remove();
                        });
                        that.updateHideFile(fileinfo,"Upload");
                    }
                }
            });
        },
        clearFile:function(){
            //删除已经上传的文件
            var fileArray=this.getUploadedFileArray();
            for (var i = 0; i < fileArray.length; i++) {
                this.deleteFile(fileArray[i]);
            }
        },
        createDom:function(){
           // this.hideFileId=this.id+"-hiddenfile";
            this.hideUploadId=this.id+"-hiddenupload";
           // j("<input type='hidden'>").attr({id:this.hideFileId}).appendTo('body');
            j("<input type='hidden'>").attr({id:this.hideUploadId}).appendTo('body');
        },
        updateHideFile:function(file,type){
            //更新选择的文件集合
            var hide=j("#"+this["hide"+type+"Id"]),
                files=hide.val();
            var fs=files=="" ? [] : files.split('|');
            if(Array.has(fs,file)){
                Array.remove(fs,file);
            }else{
                fs.push(file);
            }
            hide.val(fs.join('|'));
        },
        clearQueueFile:function(){
            j("#"+this.hideFileId).val('');
           // j("#"+this.hideUpload).val('');
        },
        getUploadedFileArray:function(){
            var files=this.getUploadedFile();
            return files ? files.split('|') : [];
        },
        getUploadedFile:function(){
            return j("#"+this.hideUploadId).val();
        },
        destroy:function(){
            
        }
    });
})(window.song,window.jQuery);