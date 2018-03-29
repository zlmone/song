; (function (j) { 
    
    j.extend(song,{
        getDefaultUrl:function(params){
            var url=location.href;
            if(url.indexOf("?")>-1){
                url=url.substring(0,url.lastIndexOf("?"));
            }
            url=url+"?isAjaxRequest=true";
            if(params){
                for (var i in params) {
                    url+="&"+i+"="+params[i];
                }
            }
            return url;
        },
        ztree:{
            init:function(id_jquery,setting,data){
                var el=typeof id_jquery=="string" ? j("#"+id_jquery) : id_jquery;
                return j.fn.zTree.init(el,setting,data);
            },
            get:function(treeid){
                return j.fn.zTree.getZTreeObj(treeid);
            },
            node:function(treeid_obj){
                var tree=typeof(treeid_obj)=="string" ? cmp.zTree.get(treeid_obj) : treeid_obj;
                var nodes=tree.getSelectedNodes();
                if(nodes.length>0){
                    return nodes[0];
                }
                return null;
            }
        }
    });
    if(window.art){
        song.dialog=art.dialog;
    }
})(window.jQuery)