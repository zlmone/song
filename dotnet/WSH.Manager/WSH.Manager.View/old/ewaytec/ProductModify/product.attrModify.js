/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		AttrModify
content:            	产品属性变更
beforeLoad:     		j,base,modify
createDate:             2014-05-19
updatedDate:  			2014-05-19
*/
; (function (song,j,modify) { 
    /*************************************产品资费变更******************************************/
    window.attrModify=window.attrModify || {
        controller:"ProductAttrModify",
        attrInfo:{},
        url:function(action,params){
            //返回资费变更对应的action的路径
            return song.url(attrModify.controller,action,params).getUrl();
        },
        loadAttrPage:function(){
            //属性页面加载
            $("#submitOrder").live("click", function () {
                attrModify.submitAttr();
            });
            $("input,select,textarea").blur(function () {
                attrModify.validAttrInfo();
            });
            $("#selDomainProvider").unbind("blur"); 
        },
        submitAttr:function(){
            //提交属性变更申请单
            attrModify.validAttrInfo();
            attrModify.getAttrInfo();
            if(modify.productCode=='820'){
                modify.validDomainName(function(){
                    attrModify.submitAttrInfo();
                });
            }else{
                attrModify.submitAttrInfo();
            }
        },
        submitAttrInfo:function(){
            //禁用按钮
            if(modify.isValid){
                modify.disabledButton(true);
                var url=attrModify.url("InputAttr"),
                    param=$.toJSON(attrModify.attrInfo);
                song.ajax(url,param,function(data){
                    if (data.resultnum == 0) {
                        modify.alert("系统网络繁忙，请稍后重试!");
                    }else if(data.resultnum == 2)
                    {
                        modify.alert("产品属性信息没有变化");
                    }  else {
                        if (data.resultnum == 3) {
                            modify.jump();
                            //提交属性成功，跳转到属性页面
                            window.location.href =attrModify.url("CheckAttr",{
                                ApplyCode:data.applycode,
                                listFrom:modify.attrs.fromList
                            });
                        }
                        if(data.resultnum == 4) {
                            //提交失败，提示错误信息
                            modify.alert(data.msg);
                        }
                    }
                },function(){
                    modify.disabledButton(false);
                },true);
             }
        },
        getAttrInfo:function(){
            //组装属性变更实体
            attrModify.attrInfo.ProductAttrModifyInfoVMs=[];
            "ProductCode,ApplyCode,ProductName,ECCode,ECName,AreaCode".replace(song.split,function(name){
                attrModify.attrInfo[name]=modify.tariff[name];
            });
            if(modify.isValid){
                //循环属性，添加属性值
                $(".hiddenproperty").each(function (i, p) {
                    var pname = $(p).attr("proname");
                    attrModify.pushProperty(pname);
                });      
            }
        },
        pushProperty:function(pname){
            //添加属性值
            var ids = pname.split('^'),AttrCode = ids[3],AttrName=ids[4],IsEnum=ids[5],
                ProductServiceAttributeId=ids[1],AttrID=ids[6],Sprodid=ids[7],productCode=ids[2],
                OptType=ids[8],curp = $("[name='" + pname + "']"),p = $("[proname='" + pname + "']"),
                el=$(p),productServiceRelationId =el.attr("ProductServiceRelationId"),
                serviceCode =el.attr("serviceCode"),sepSign = el.attr("sepsign"),
                itagName = el.attr("tagname"),AttrOldValue=el.attr("AttrOldValue"),
                AttrOldName=el.attr("AttrOldName"),AttrNewName="",AttrNewValue = "";
            if (itagName == "3") {
                $("[name='" + pname + "']:checked").each(function (i, v) {
                    AttrNewValue += $(v).val() + sepSign;
                    AttrNewName+=$(v).attr("enumname")+sepSign;
                });
                AttrNewValue = AttrNewValue.substring(0, AttrNewValue.length - 1);
            } else if (itagName == "4") {
                $("[name='" + pname + "']:checked").each(function (i, v) {
                    AttrNewValue = $(v).val();
                    AttrNewName=$(v).attr("enumname")+sepSign;
                });
            } else if (itagName == "5") {
                AttrNewValue = curp.val();
                AttrNewName=curp.find("option:selected").text();
            }
            else {
                AttrNewValue = curp.val();
                AttrNewName=curp.val();
            }
            var property = {};
            property.ProductServiceRelationId = productServiceRelationId;
            property.ProductServiceAttributeId=ProductServiceAttributeId;
            property.ProductCode = productCode;
            property.ServiceCode = serviceCode;
            property.IsEnum=IsEnum;
            property.OptType=OptType;
            property.SepSign=sepSign;
            property.AttrName = AttrName;
            property.AttrNewName=AttrNewName;
            property.AttrOldName=AttrOldName;
            property.AttrID=AttrID;
            property.Sprodid=Sprodid;
            property.AttrCode = AttrCode;
            property.AttrNewValue = AttrNewValue;
            property.AttrOldValue=AttrOldValue;
            attrModify.attrInfo.ProductAttrModifyInfoVMs.push(property);
        },
        validAttrInfo:function(){
            //校验属性信息
            modify.isValid=true;
            $(".hiddenproperty").each(function (i, p) {
                var content=modify.getPropertyValue(p);
                //验证属性格式是否正确
                modify.validProperty(content.el,content.name,content.value,function(isCorrect){
                    //手机邮箱个性化属性校验
                    if(isCorrect){
                        modify.validMobileMail(content.name,content.value) || (isCorrect=false);
                    }
                    //企业邮箱个性化验证
                    if(isCorrect){
                        modify.validCorpDomain(content.name,content.value) || (isCorrect=false);
                    }
                    //818产品个性化验证
//                    if(isCorrect){
//                        modify.validContactMobile(content.name,content.value) || (isCorrect=false);
//                    }
                    modify.validMailServerID(content.name,content.value) || (isCorrect=false);
                    if(isCorrect){
                        if(content.name.indexOf("MailServerID") != -1 && parseInt(modify.attrs.UseProductMemberCount)>0)
                        {
                            $("[lname='" + pname + "']").html('产品已经分配成员，需要先把所有成员注销才能修改此值');
                            return false;
                        }
                    }
                    return isCorrect;
                });
            });
        }
    };
})(window.song,window.jQuery,window.modify);