/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Song.Apply
content:            	折扣销售产品开通申请
beforeLoad:     		j,base
createDate:             2013-08-22
updatedDate:  			2013-11-08
*/
; (function (song,j) { 
    /*************************************产品开通******************************************/
    window.apply=window.apply || {
        controller:"ProductOpen",
        setEditMode:function(mode){
            if(mode && mode=="1"){
                j("#btnPrev").hide();
            }
        },
        getRealEc:function(){
            var echide=j("#RealECCode");
            return echide.length>0 ? {code:echide.val(),name:j("#RealECName").val()} : null;
        },
        getApplyInfo:function(){
            "CrmProductCode,ApplyCode,ECOrderApplyItemId,EcName,EcCode,ProductId,ProductName".replace(song.split,function(name){
                apply.tariff[name]=j("#"+name).val();
            });
            apply.productCode=apply.tariff.CrmProductCode;
        },
        url:function(action,params){
            return song.url(apply.controller,action,params).getUrl();
        },
        getEcParams:function(){
            var ec=apply.getRealEc();
            return {RealECCode:ec.code,RealECName:ec.name};
        },
        defaultUrl:function(action,params){
            params=params || {};
            j.extend(params,{
                oid:apply.tariff.ApplyCode,
                p:apply.tariff.ECOrderApplyItemId
            });
            j.extend(params,apply.getEcParams());
            return apply.url(action,params);
        },
        movePage:function(pageIndex,pageSize,url){
            //分页公用方法
            apply.pageParams = { pageIndex: pageIndex || 1, pageSize: pageSize };
            $("#pagingList").ajaxPager(new song.param(url,apply.pageParams).getUrl());
        }
    };
    /*************************************产品开通-填写资费******************************************/
    j.extend(apply,{
        showTip4001:function(products){
            products=products || apply.getCrmProductCodes();
            $("#tip4001").hide();
            var dx=j("#SubProduct4001").val(),
                psArray=products.split("^");
            if(dx){
                var dxArray=dx.split(",");
                if(apply.hasProductCodes(psArray,dxArray)){
                    $("#tip4001").show();
                }
            }
        },
        loadProductProperty:function(crmProductCodes,applyCode,ecOrderApplyItemId){
            //先保存已经填写的属性值
            var values=apply.getPropertyValues();
            song.setDisabled("#btnPrev","#btnNext");
            //动态加载产品属性
            var property=$("#productProperty");
            property.html("正在加载属性...");
            var url=apply.url("ProductProperty",{
                crmProductCodes:crmProductCodes.replace(/^\s+|\s+$/g, ""),
                ecOrderApplyItemId:ecOrderApplyItemId,
                applyCode:applyCode
            });
            property.load(url,function(){
                song.removeDisabled("#btnPrev","#btnNext");
                //渲染已经填写的属性值
                apply.setPropertyValues(values);
            });
        },
        backSelectGroup:function(){
            apply.jump();
            //返回选择集团页面
            var ec=apply.getRealEc();
            var url=apply.url("RealEcSelect",{
                realeccode:ec.code,
                productid: apply.tariff.ProductId,
                oid: apply.tariff.ApplyCode
            });
            location.href=url;
        },
        gotoCheckOrder:function(){
            apply.jump();
            //下一步，订单核对页面
            var url=apply.defaultUrl("CheckOrderApply");
            location.href=url;
        },
        getTariffInfo:function(){
            //获取资费信息
            apply.tariff.ChooseProducts=[];
            apply.tariff.ProductParams =[];
            apply.tariff.ECOrderApplyItemExpands=[];
            apply.tariff.Files=[];
            //添加隐藏域的值
            //添加管理员信息
            $("input.manager").each(function (i, p) {
                var pname = $(p).attr("name");
                apply.addTariffProperty(pname);
            });
            //预计使用时长,400产品展示不存在
            //资费套餐
            $("input.product:checked").each(function (i, v) {
                var product = {};
                product.ProductCode = $(v).val();
                product.IsChoose = true;
                if ($(v).attr("isShow").toLowerCase() == "false") {
                    product.IsHide = true;
                } else {
                    product.IsHide = false;
                }
                apply.tariff.ChooseProducts.push(product);
            });
            //属性列表
            $("input.hiddenproperty").each(function (i, p) {
                var pname = $(p).attr("proname");
                apply.addTariffProperty(pname);
            });
            //添加备注信息
            if(apply.tariff.CrmProductCode=="4001"){
                apply.addTariffExpand(j("#Remark"));
                //添加附件信息
                apply.tariff.Files.push({
                    Key:"scanning",
                    FileInfo:song.getCmp("upload400Purpose").getUploadedFiles()//协议附件
                });  
                apply.tariff.Files.push({
                    Key:"treaty",
                    FileInfo:song.getCmp("upload400Agreement").getUploadedFiles()//用途附件
                }); 
            }
        },
        addTariffExpand:function(r){
            //添加扩展信息
            var expand = {},
                keyName = $(r).attr("name");
            expand.ECOrderApplyItemId = apply.tariff.ECOrderApplyItemId;
            expand.KeyName = keyName;
            expand.KeyValue = $(r).val();
            apply.tariff.ECOrderApplyItemExpands.push(expand);
        },
        addTariffProperty:function(pname){
            //添加资费属性信息
            var crmproductcode=apply.tariff.CrmProductCode,
                ids = pname.split('^'),
                productCode = ids[0],
                productServiceRelationId = ids[1],
                serviceCode = ids[2],
                attrId = ids[3],
                attrCode = ids[4],
                attrName = ids[5],
                curp = $("[name='" + pname + "']"),
                p = $("[proname='" + pname + "']"),
                sepSign = $(p).attr("sepsign"),
                itagName = $(p).attr("tagname"),
                sval = "";
            if (itagName == "3") {
                $("input[name='" + pname + "']:checked").each(function (i, v) {
                    sval += $(v).val() + sepSign;
                });
                sval = sval.substring(0, sval.length - 1);
            } else if (itagName == "4") {
                sval = $("input:radio[name='" + pname + "']:checked").val();

            } else {
                sval = curp.val();
                if(crmproductcode=="4001")
                {
                    if(attrCode=="GN4001num"||attrCode=="GN4002num"||attrCode=="GN4004num"||attrCode=="GN4003num"||attrCode=="GN400SmsNum")
                    {
                        sval=4001+$("#txtGN4001num").val();
                    }
                }
            }
            var property = {};
            property.ProductServiceRelationId = productServiceRelationId;
            property.ProductCode = productCode;
            property.ServiceCode = serviceCode;
            property.AttrName = attrName;
            property.AttrId = attrId;
            property.AttrCode = attrCode;
            property.DefaultValue = sval;
            apply.tariff.ProductParams.push(property);
        },
        submitTariffInfo:function(){
            //alert(apply.isValid);
            if(apply.isValid){
                //序列化资费信息，校验订单
                song.setDisabled("input.btn_3f","input.btn_4f");
                apply.getTariffInfo();
                var url=apply.url("SubmitTariff"),
                    params=j.toJSON(apply.tariff).replace(/undefined/g, '\"\"');
                song.loading.setMsg("正在提交资费信息...");
                song.ajax(url,params,function(data){
                    
                    if(data.isSuccess){
                        apply.gotoCheckOrder();
                    }else{
                        window.top.song.alert(data.msg);
                       // apply.gotoCheckOrder();
                    }
                },function(){
                    song.removeDisabled("input.btn_3f","input.btn_4f");
                },true);
            }
        },
        submitTariff:function(){
            //提交资费信息，校验资费信息
            apply.validTariff();
            //alert(apply.isValid);
            if(!apply.isValid){
                var top = $("#jsSetProductParams").offset().top,
                headTop = 140 + top;
                $(window.top).scrollTop(headTop);
            }
            if(apply.productCode=='820'){
                apply.validDomainName(function(){
                    apply.submitTariffInfo();
                });
            }else{
                apply.submitTariffInfo();
            }
        }
    });
    /*************************************产品开通-填写资费-选择产品管理员******************************************/
    j.extend(apply,{
        openManager:function(){
            //弹出选择管理员页面
            var dialog = apply.getDialog({
                id:"managerDialog",
                onClose:function(returnvalue){
                    if(returnvalue){
                        var obj={
                            prdadminname:"realName",
                            prdadminuser:"userName",
                            prdadminmobile:"mobile",
                            prdadminmail:"email"
                        };
                        for (var key in obj) {
                            j("#"+key).val(returnvalue[obj[key]]).attr("readonly","readonly");
                        }
                    }
                }
            });
            dialog.option({title:"产品管理员选择",width:680,height:540});
            dialog.open(apply.url("ProductManager",{eccode:apply.tariff.EcCode}));
        },
        queryManager:function(pageIndex,pageSize){
            //产品管理员分页查询
            var param=song.url(apply.controller,"GetProductManager");
            param.addVals("queryUserName","queryRealName","queryMobile");
            param.add({eccode:j("#eccode").val()});
            apply.movePage(pageIndex,pageSize || 10,param.getUrl());
        },
        selectManager:function(){
            //选择产品管理员
            var radio=j("input:checked[name='managerradio']");
            if(radio.length<=0){
                window.top.song.alert("请选择管理员");return;
            }
            var returnValue={};
            "memberId,userName,realName,mobile,email".replace(song.split,function(name){
                returnValue[name]=radio.attr(name);
            });
            apply.closeDialog("managerDialog",returnValue);
        }
    });
    /*************************************产品开通-填写资费-400选号******************************************/
    j.extend(apply,{
        open400Num:function(){
            //弹出选择400号码页面
            var dialog =apply.getDialog({
                id:"numDialog",
                onClose:function(num){
                    if(num){
                        $("#txtGN4001num").val(num.substr(4));
                        //对号码预占
                        //apply.occupyNum();
                    }
                }
            });
            dialog.option({ title: "高级选号", width: 640, height: 400 });
            dialog.open(apply.url("Select400Num"));
        },
        query400Num:function(pageIndex,pageSize,num){
            //400随机选号分页,查询和随机选号共用，随机选号apply.num="#"
            if(!num && apply.num==null){
                num=song.dom("txtNum").value.trim();
                if(!view.validNum(num)){
                    return;
                }
                apply.num=num;
            }
            apply.movePage(pageIndex,pageSize || 8,apply.url("Get400Num",{num:apply.num,productCode:"4001"}));
        },
        select400Num:function(){
            //选择400号码
            var numArray=song.getCheckedValue("numRadio");
            if(numArray.length<=0 || !numArray[0]){
                window.top.song.alert("请选择号码");return false;
            }
            apply.closeDialog("numDialog",numArray[0]);
        }
    });
    /*************************************产品开通-订单提交******************************************/
    j.extend(apply,{
        backTariff:function(){
            apply.jump();
            //返回到资费填写页面
             location.href=apply.defaultUrl("FillTariff");
        },
        slideProperty:function(obj,id){
            //展开和收起资费信息
            var el=j("#"+id),
                span=j(obj),
                isHide=el.is(":hidden");
            if(isHide){
                span.attr("class","btn_up");
                el.show();
            }else{
                span.attr("class","btn_down");
                el.hide();
            }
        },
        getOrderInfo:function(){
            //获取订单提交的信息
            var sumfee = j("#TotalFee").val();
            var info={
                ApplyCode:apply.tariff.ApplyCode,
                TotalFee:sumfee,
                MinAmount: j("#CountervailFee").val(),
                FunctionFee: j("#DLHConsumption").val(),
                saveOrderApplyItemVMs:[
                    {
                        ECOrderApplyItemID:apply.tariff.ECOrderApplyItemId,
                        CrmProductCode:apply.tariff.CrmProductCode,
                        CmsProductName:apply.tariff.ProductName,
                        Code:j("#ApplyItemCode").val(),
                        SumFee:sumfee,
                        CrmFeelItemDetail:j("#CrmFeelItemDetail").val()
                    }
                ]
            };
            return info;
        },
        submitOrder:function(){
            //提交申请单
            song.setDisabled("input.btn_3f,input.btn_4f");
            song.loading.setMsg("正在提交订单...");
            var params=j.toJSON(apply.getOrderInfo());
           // alert(params);
            song.ajax(apply.url("SubmitOrderApply"), params, function (data) {
                if (data.isSuccess) {
                    var p=apply.getEcParams();
                    j.extend(p,{
                        isAudit: data.isAudit,
                        applyCode : data.applyCode
                    });
                    location.href = apply.url("Finish", p);
                } else {
                    window.top.song.alert(data.msg);
                }
            },
            function () {
                song.removeDisabled("input.btn_3f,input.btn_4f");
            },true);
        }
    });
    /*************************************产品开通-完成******************************************/
    j.extend(apply,{
        continueOpen:function(){
            //继续开通产品
            location.href=apply.url("ProductSelect");
        }
    });
})(window.song,window.jQuery);