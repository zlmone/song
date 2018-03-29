/*
author:                 王松华
email:                  shwang@163.com
namespace:              Member
content:                成员开通通用
beforeLoad:             jQuery,song
dateUpdated:            2014-11-26
*/
; (function (song, j) {
    window.memberOpen=window.memberOpen || {
        ECPrdCode:"",
        ProductCode:"",
        PackageType:"",
        isValid:true,      
        setParentIframeHeight:function(){
            var height=$("#memberapplywrap").outerHeight();
 
            //设置iframe的高度
            window.parent.view.setIframeHeight(height);
            //设置菜单跟iframe一样高
            window.parent.view.setMemuHeight();
        },  
        loadSelectProduct:function(){
            //加载选择产品页面
            var url=song.url("MemberOpen","SelectProduct").getUrl();
            song.loading.show();
            j("#selectProductWrap").html("").load(url,function(){
                song.loading.hide();
            });
        },
        validSelectProduct:function(){
            var product = j("input[name='memberProduct']:checked");
            if (product.length <= 0) {
                song.topAlert("请选择套餐");
            } else {
                var ecprdcode = product.val(),
                    productcode = product.attr("data-productcode"),
                    packageType = product.attr("data-packageType"),
                    url = memberOpen.url("FillAttrMember", { packageCode: productcode, ECPrdCode: ecprdcode, packageType: packageType });
                if(memberOpen.ECPrdCode==ecprdcode){
                    memberOpen.loadPage("fillAttrMemberWrap", url);
                }else{
                    memberOpen.reloadPage("fillAttrMemberWrap", url);
                }
                memberOpen.ECPrdCode=ecprdcode;
                memberOpen.ProductCode = productcode;
                memberOpen.PackageType = packageType;
            }
        },
        hideAllWrap:function(){
            j("div[data-type='step']").hide();
        },
        showPage:function(id_panel){
            memberOpen.hideAllWrap();
            memberOpen.getJqueryObject(id_panel).show();
            memberOpen.setParentIframeHeight();
        },
        getJqueryObject:function(id_panel){
            return typeof(id_panel)=="string" ? j("#"+id_panel) : id_panel;
        },
        reloadPage:function(id_panel,url,callback){
            var panel=memberOpen.getJqueryObject(id_panel);
            panel.removeAttr("isLoaded");
            memberOpen.loadPage(panel,url,callback);
        },
        loadPage:function(id_panel,url,callback){
            //加载页面
            var panel=memberOpen.getJqueryObject(id_panel);
            var isLoad=panel.attr("isLoaded");
            if(!isLoad){
                song.loading.show();
                panel.html("");
                panel.load(url,function(){
                    panel.attr("isLoaded","true");
                    callback && callback();
                    memberOpen.showPage(panel);
                    song.loading.hide();
                    panel.find("select.dropdown").each(function(){
                        var instance = new song.dropdown();
                        instance.init(this,{width:190});
                        memberOpen.setParentIframeHeight();
                    });
                });
            }else{
                memberOpen.showPage(panel);
            }
        },
        getDialog:function(options){
            //获取dialog对象
            options=options || {};
            if(options.id==null){
                options.id="flowMemberOpenDialog";
            }
            return new window.top.song.dialog(options);
        },
        closeDialog:function(id,returnParams){
            //关闭父页面的dialog
            song.dialog.closeParent(id || "flowMemberOpenDialog",returnParams);
        },
        clearAttrError:function(){
            //清除错误信息
            memberOpen.isValid=true;
            j("#memberAttrWrap .attrmsg").html('');
        },
        setMsg:function(el,msg,yesno){
            //设置验证信息
            el.html('<b class="'+(yesno ? 'cGreen060' : 'cRedf00')+'">'+msg+'</b>');
            if(!yesno){
                el.hide().fadeIn();
            }
        },
        setError:function(el,msg){
            memberOpen.setMsg(el,msg,false);
        },
        setCorrect:function(el,msg){
            //设置正确信息
            memberOpen.setMsg(el,msg || "填写正确",true);
        },
        eachAttrs:function(callback){
            //遍历属性
            var attrs=j("#memberAttrWrap .attritem");
            attrs.each(function(i){
                var attr=attrs.eq(i),
                    value=memberOpen.getInputValue(attr),
                    attrcode=attr.attr("data-attrcode"),
                    attrname=attr.attr("data-attrname");
                //增加对checkbox，radio的支持
                callback && callback(attr,value,attrcode,attrname);
            });
        },
        getInputValue:function(attr){
            //获取属性值
            var type=attr.attr("data-controltype");
            if(type && /checkbox|radio/.test(type)){
                var inputs=attr.find("input:"+type+":checked"),
                    values=[];
                inputs.each(function(i){
                    values.push(this.value);
                });
                return values.join(",");
            }
            return attr.val();
        },
        validAttrs: function () {
            //验证属性是否填写正确
            memberOpen.clearAttrError();
            memberOpen.eachAttrs(function(attr,value,attrcode,attrname){
                memberOpen.validAttr(attr,value,attrcode,attrname);
            });
        },
        validAttr:function(attr,value,attrcode,attrname){
            //验证单个属性
            attr=j(attr);
            value=value==undefined ? memberOpen.getInputValue(attr).trim() : value.trim();
            attrcode=attrcode==undefined ? attr.attr("data-attrcode") : attrcode;
            attrname=attrname==undefined ? attr.attr("data-attrname") : attrname;
            if(attrcode.toLowerCase()=="effectiveway"){
                return;
            }
            var isrequired=attr.attr("data-require"),
                msg=j("#attrmsg_"+attrcode),
                itemIsValid=true;
            if(isrequired && !value){
                itemIsValid=false;
                memberOpen.isValid=false;
                memberOpen.setError(msg, (attrname ? (attrname + "必填") : "此项必填"));
            }
            if(value!=""){
                //校验流量值必须为正整数
                if(attrcode.toLowerCase()=="flowvalue"){
                    if(!/^[0-9]*[1-9][0-9]*$/.test(value)){
                        itemIsValid=false;
                        memberOpen.isValid=false;
                        memberOpen.setError(msg,"分配流量必须是正整数");
                    }
                }
                itemIsValid && memberOpen.setCorrect(msg);
            }
        },
        getAttrValue:function(idflag){
            var attr=j("#attr_"+idflag);
            if(attr.length>0){
                return attr.val();
            }
            return "";
        },
        parseAttrs: function() {
            var data={ECPrdCode:memberOpen.ECPrdCode,Attrs:[]};
            //生效方式和流量值
            data.EffectiveWay=memberOpen.getAttrValue("EffectiveWay");
            data.FlowValue=memberOpen.getAttrValue("FlowValue");
            data.ProductName = j("#memberOpenProductName").text(); 
            data.ProductCode=memberOpen.ProductCode;
            //数据例子：{ECPrdCode:"",Attrs:[{AttrCode:"",AttrName:"",AttrValue:""}],Members:[{Id:"",UserName:"",Mobile:"",Email:"",Department:""}]}
            memberOpen.eachAttrs(function(attr,value,attrcode,attrname){
                var isShow=attr.attr("data-isshow"),
                    isShowValue=isShow ? true : false;
                if(!/EffectiveWay|FlowValue/.test(attrcode)){
                    data.Attrs.push({AttrCode:attrcode,AttrName:attrname,AttrValue:value,IsShow:isShowValue});
                }
            }); 
            return data;
        }
    };
})(window.song, window.jQuery)