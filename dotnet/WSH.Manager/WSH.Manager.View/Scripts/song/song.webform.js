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
        action:{ add:"Add", edit:"Edit", view:"View" },
        page:{
            param: function (url,params) { 
                return new song.param(url || location.href, params).stamp(); 
            },
            url: function (params,url) {
                return this.param(url, params).getUrl();
            },
            asyncUrl:function(key){
                return this.param().add("isAsyncRequest",key).getUrl();
            },
            open:function(url,options){
                var opts=j.extend(song.option.dialog,options);
                opts.close=function(){
                    var count=song.iframe.data("saveSuccessCount");
                    song.iframe.removeData("saveSuccessCount");
                    //当关闭窗口时，判断保存数据成功的次数，如果大于0则刷新父窗体的grid
                    if(count && count>0){
                        if(options.gridID){
                            var grid=song.getCmp(options.gridID);
                            grid && grid.load();
                        }else if(options.treeID){
                            //更新树节点
                            var nodes=song.iframe.data("treeNodes");
                            song.iframe.removeData("treeNodes");
                            var tree=song.ztree.get(options.treeID);
                            if(options.action==song.action.edit){
                                tree.updateNode(nodes);
                            }else{
                                var parentNode=song.ztree.getSelectedNode(options.treeID);
                                tree.addNodes(parentNode,nodes);
                            }
                        }
                    }
                }
                song.dialog.open(url,opts);
            },
            cancel:function(){
                song.dialog.close();
                return false;
            },
            setSaveSuccessCount:function(){
                var count=song.page.getSaveSuccessCount();
                if(count && count>0){
                    song.iframe.data("saveSuccessCount",count);
                }
            },
            getSaveSuccessCount:function(){
                var dom=song.dom("hideSaveSuccessCount");
                return dom==null ? 0 : dom.value;
            },
            saveAfter:function(result){
                //设置操作成功条数
                song.page.setSaveSuccessCount();
                if(result.isSuccess){
                    if(result.treeNode){
                        var nodes=song.iframe.data("treeNodes") || [],
                            arr=[];
                        for (var i = 0; i < nodes.length; i++) {
                            arr.push(nodes[i]);
                        }
                        arr.push(result.treeNode);
                        song.iframe.data("treeNodes",arr);
                    }
                    if(result.isClosePage){
                        //当操作类型为保存的时候，则保存完之后关闭窗口
                        song.page.cancel();
                    }else{
                        song.tip.msg(result.msg,"ok",{left:0,top:"100%"});
                    }
                }else{
                    song.dialog.alert(result.msg);
                }
            },
            validate:function(){
                var v=new song.validate(),result=v.valid();
                if(result){
                     new song.loading({msg:"正在提交您的请求..."}).show();
                }
                return result;
            },
            ajax:function(url,data,success,loading){
                var loading=song.page.loading();
                $.ajax({
                    type:"post",
                    dataType:"json",
                    url:url,
                    data:data,
                    success:function(result){
                        loading.hide();
                        if(result.isSuccess){
                            result.msg && song.tip.msg(result.msg,"ok",{top:0});
                            success && success(result);
                        }else{
                            result.msg && song.dialog.alert(result.msg);
                        }
                    },
                    error:function(xhr,err){
                        loading.hide();
                        song.dialog.alert("服务器繁忙，请稍后再试！<br>"+err);
                    }
                });
            },
            loading:function(id){
                var loading=new song.loading({id:"song-loading-request",msg:"正在努力提交您的请求..."});
                loading.show();
                return loading;
            },
            grid:{
                url:function(params,url){
                    return song.page.asyncUrl("getGridSource");
                },
                add:function(page){
                    var url=song.page.url({action:song.action.add},page.editUrl);
                    song.page.open(url,{title:page.title+"-新增",gridID:page.gridID});
                },
                edit:function(id,page){
                    var url=song.page.url({action:song.action.edit,id:id},page.editUrl);
                    song.page.open(url,{title:page.title+"-编辑",gridID:page.gridID});
                },
                view:function(id,page){
                    var url=song.page.url({action:song.action.view,id:id},page.editUrl);
                    song.page.open(url,{title:page.title+"-查看"});
                },
                load:function(id,isFirst){
                    var grid=song.getCmp(id);
                    if(!grid || grid.theRequest){return;}
                    isFirst && grid.moveFirst();
                    grid.load();
                },
                enterQuery:function(grid){
                    if(!grid.queryID){return;}
                    var query=j("#"+grid.queryID);
                    query.keydown(function(e){
                        if(e.keyCode==song.kc.enter){
                            song.page.grid.load(grid.gridID,true);
                        }
                    });
                }
            },
            tree:{
                addChild:function(tree,isPrompt){
                    var node=song.ztree.getSelectedNode(tree.treeID);
                    if(isPrompt){
                        var url=song.page.asyncUrl("addTreeChildNode");
                        song.dialog.prompt("新增子节点",function(val){
                            if(val.trim()==""){
                                this.DOM.content.find('input').addClass("textbox input-error");
                                return false;
                            }
                            var data={treeNodeText:val,parentNodeValue:node.value};
                            song.page.ajax(url,data,function(result){
                                //更新树节点
                                var newNode=result.newNode;
                                song.ztree.get(tree.treeID).addNodes(node,newNode);
                            });
                        });
                    }else{
                        var url=song.page.url({action:song.action.add,editPageMode:"tree"},tree.editUrl);
                        song.page.open(url,{title:tree.title+"-新增",treeID:tree.treeID,action:song.action.add});
                    }    
                },
                edit:function(tree,isPrompt){
                    var node=song.ztree.getSelectedNode(tree.treeID),
                        value=node.value;
                    if(isPrompt){
                        var url=song.page.asyncUrl("editTreeNode");
                        song.dialog.prompt("编辑节点",function(val){
                            if(val.trim()==""){
                                this.DOM.content.find('input').addClass("textbox input-error");
                                return false;
                            }
                            var data={treeNodeText:val,treeNodeValue:value};
                            song.page.ajax(url,data,function(result){
                                //更新树节点
                                node.name=val;
                                song.ztree.get(tree.treeID).updateNode(node);
                            });
                        },node.name);
                    }else{
                        var url=song.page.url({action:song.action.edit,id:value,editPageMode:"tree"},tree.editUrl);
                        song.page.open(url,{title:tree.title+"-编辑",treeID:tree.treeID,action:song.action.edit});
                    }
                },
                remove:function(tree){
                    song.dialog.confirm("确定删除该节点吗？",function(){
                        var url=song.page.asyncUrl("removeTreeNode"),
                            node=song.ztree.getSelectedNode(tree.treeID),
                            value=node.value,
                            data={treeNodeValue:value};
                        song.page.ajax(url,data,function(result){
                            //移除树节点
                            song.ztree.get(tree.treeID).removeNode(node);
                        });
                    });
                } 
            }
        }    
    });
    song.option={
        //弹出窗口的默认配置
        dialog:{
            width:600
        },
        render:{
            yesno:function(val){
                return val=="true" ? "是" : "否";
            },
            format:function(fmt){
                return function(val){
                    
                }
            }
        },
        column:{
            edit:function(grid,auth){
                var w=auth.edit ? 80 : 40;
                return {header:"",align:"center",width:w,render:function(val,row){
                    var id=row.data[this.dataKey],html="";
                    if(auth.edit){
                        html+="<a href='"+song.href+"' onclick='song.page.grid.edit("+id+",{editUrl:\""+grid.editUrl+"\",title:\""+grid.title+"\",gridID:\""+grid.gridID+"\"});' class='song-grid-cmd'>编辑</a> | ";
                    }
                    html+="<a href='"+song.href+"' onclick='song.page.grid.view("+id+",{editUrl:\""+grid.editUrl+"\",title:\""+grid.title+"\"});' class='song-grid-cmd'>查看</a>";
                    return html;
                }}
            }
        },
        button:{
            query:function(grid){
                return {text:"查询",iconClass:"icon-query",onClick:function(){
                    song.page.grid.load(grid.gridID,true);
                }};
            },
            add:function(grid,auth){
                return auth.add ? {text:"新增",iconClass:"icon-addrow",onClick:function(){
                    song.page.grid.add(grid);
                }} : null;
            },
            edit:function(grid,auth){
                return auth.edit ? {text:"修改",iconClass:"icon-edit",onClick:function(){
                    var grid=song.getCmp(grid.gridID),
                    row=grid.getSelectedRow();
                    if(row==null){
                        song.tip.msg("请选择一条记录进行操作！");
                    }
                }} : null;
            },
            deleteBatch:function(grid,auth,before){
                return auth.remove ? {text:"删除",iconClass:"icon-deleterow",onClick:function(){
                    var g=song.getCmp(grid.gridID),
                        rows=g.getSelectedRows();
                     if(before){
                        if(!before(g,rows)){return;}
                     }
                     if(rows.length<=0){
                        song.tip.msg("请至少选择一条记录进行操作！","info");
                        return;
                     }
                     song.dialog.confirm("确定要删除选中的记录吗？",function(){
                         var ids=[];
                         for (var i = 0; i < rows.length; i++) {
                            ids.push(rows[i].data[g.dataKey]);
                         }
                         var url=song.page.asyncUrl("deleteBatch"),
                             data={deleteIDs:ids.join(',')};
                         song.page.ajax(url,data,function(result){
                             g.load();
                         });
                     });
                }} : null;
            }
        }
    }
})(window.song, window.jQuery)