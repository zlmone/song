/*
author:                 wang song hua
email:                  songhuaxiaobao@163.com
url:                    http://www.netstudio80.com
namespace:              Song.Using
content:                动态引入js和css文件
beforeLoad:             j,base
dateUpdated:            2012-08-28
*/
; (function (song,j) { 
    var moduleList=[],currflag="$";
    var scripts=document.getElementsByTagName("script"),
                src=scripts[scripts.length-1].src,
                path=song.path.getPath(src);
    song.using=function(files,callback,isCurrent){
        files.replace(song.split,function(key){
            if(isCurrent){
               var url=curr.path+key;
                song.using.add(url);
            }else{
                var value=song.using.config[key] || key;            
                if(typeof(value)==="string"){
                    if(value.has(currflag)){
                        value=value.replace(currflag,path);
                    }
                    song.using.add(value);
                }else if(song.getType(value)==="array"){
                    for (var i = 0; i < value.length; i++) {
                        song.using.add(value[i]);
                    }
                }
            }
        });
        song.using.require(callback);
    }
    j.extend(song.using,{
        config:{
            jqueryExtend:"/js/jquery/jquery.extend.js",
            artDialog:["/admin/js/artDialog/default.css","/admin/js/artDialog/jquery.artDialog.js"],
            artDialogIframe:"/admin/js/artDialog/iframeTools.js",
            ztree:["/admin/js/ztree/style/zTreeStyle.css","/admin/js/ztree/js/jquery.ztree.core-3.2.min.js"],
            ztreeCheck:"/admin/js/ztree/js/jquery.ztree.excheck-3.2.min.js",
            ztreeEdit:"/admin/js/ztree/js/jquery.ztree.exedit-3.2.min.js",
            easyui:["/admin/js/easyui/themes/default/easyui.css","/admin/js/easyui/jquery.easyui.min.js","/admin/js/easyui/easyui-lang-zh_CN.js"]
        },
        cmp:function(files,callback){
            var fs=files.split(","),len=fs.length,arr=[];
            for (var i = 0; i < len; i++) {
                arr.push(currflag+"song."+fs[i]+".js");
            }
            song.using(arr.join(","),callback);
        },
        add:function(file){
           if(!Array.has(moduleList,file)){
                moduleList.push(file);
           }  
        },
        loadFile:function(options){
            //{jsPath:"",cssPath:"",url:"",cache:true,charset:"",async:false}
            var head = document.head || document.getElementsByTagName("head")[0],
	        el,isjs=song.path.getExtension(options.url)==".js",
            path=(isjs ? options.jsPath : options.cssPath) || "",
            url=path+options.url,
            tag=isjs ? "<script>" : "<link>",
            type=isjs ? "text/javascript" : "text/css";
            if(options.cache === false){
		        url = url+( /\?/.test( url ) ? "&" : "?" )+ "_=" +(new Date()).getTime();
	        }
	        el = song.dom(tag,{async:options.async || false,type:type});
	        if (options.charset) {
		        el.charset = options.charset;
	        }
            if(!isjs){
                el.rel="stylesheet";
                el.href=url;
                head.insertBefore(el, head.firstChild);   
            }else{
                el.src=url;
                head.appendChild(el);
            }
		    options.success && song.loaded(el,options.success);
        },
        addLink:function(url){
            if(document.createStyleSheet){
                document.createStyleSheet(url).owningElement;
            } else{
                var e = document.createElement('link'); e.rel = 'stylesheet'; e.type = 'text/css'; e.href = url;
                document.getElementsByTagName('head')[0].appendChild(e);
            }
        },
        require:function(callback){
            //动态加载js和css文件
            var index=0,len=moduleList.length;
            for (var i = 0; i < len; i++) {
                var file=moduleList[i];
                this.loadFile({
                    url:file,
                    success:function(){
                        index++;index>=len && callback && callback();
                    }   
                });
            }
        }
    });
})(window.song,window.jQuery);