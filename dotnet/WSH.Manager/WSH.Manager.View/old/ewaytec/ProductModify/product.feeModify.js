/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		FeeModify
content:            	产品资费变更
beforeLoad:     		j,base,modify
createDate:             2014-05-12
updatedDate:  			2014-05-19
*/
; (function (song,j,modify) { 
    /*************************************产品资费变更******************************************/
    window.feeModify=window.feeModify || {
        controller:"ProductFeeModify",
        feeInfo:{},//变更信息
        pageFeeInfo:{},//存放变更页面临时信息
        url:function(action,params){
            //返回资费变更对应的action的路径
            return song.url(feeModify.controller,action,params).getUrl();
        },
        tariffLoad:function(){
            //资费页面加载逻辑
            $("#submitOrder").live("click", function () {
                feeModify.submitTariff();
            });
            //单击附加产品，加载资费属性
            $(".product").live("click", function () {
                clsSubProductChooseCommon.fnInformationValidateChoose(this, false);
                var chooseCrmProductCodes = modify.getCrmProductCodes();
                feeModify.loadProductProperty(chooseCrmProductCodes);
            });
            modify.bindIsCheck();
            feeModify.setOldProductCodes();
            modify.bindViewBusiness();
        },
        setOldProductCodes:function(){
            feeModify.pageFeeInfo.OldCrmCode = modify.tariff.CrmProductCode+ "^";
            //变更前的资费信息
            feeModify.pageFeeInfo.OldProductInfo={};
             $(".hiddenOldproduct").each(function (i, v) {
                var oldproduct = {},
                    el=$(v),
                    obj = $(v).val();
                oldproduct.crmProductCode = el.val();
                oldproduct.productName =el.attr("pname");
                var pstr = el.attr("prvalue");
                oldproduct.Description = pstr.split('^')[0];
                oldproduct.IsMemberoldproduct = pstr.split('^')[1];
                oldproduct.FeeType = pstr.split('^')[2];
                oldproduct.Sprodid = pstr.split('^')[3];
                oldproduct.IsShow = pstr.split('^')[4];
                oldproduct.OptType = 1;
                var optType = pstr.split('^')[5];
                if (modify.tariff.ApplyCode != '') {
                    if (optType==1) {
                        feeModify.pageFeeInfo.OldCrmCode += obj + "^";
                        feeModify.pageFeeInfo.OldProductInfo[el.val()] = oldproduct;
                    }
                } else {
                    feeModify.pageFeeInfo.OldCrmCode += obj + "^";
                    feeModify.pageFeeInfo.OldProductInfo[el.val()] = oldproduct;
                }
            });
            feeModify.pageFeeInfo.OldCrmCode = feeModify.pageFeeInfo.OldCrmCode.delEnd("^");
            //旧的属性列表
            feeModify.pageFeeInfo.OldAttr = {};
            $(".hiddenproperty").each(function (i, p) {
                feeModify.pushProperty(p, false);
            });
        },
        loadProductProperty:function(crmProductCodes){
            //根据资费编码，加载属性面板
            $("#productProperty").html("正在加载属性...");
            var openSource = 0,
                value = "",
                applyCode=modify.tariff.ApplyCode,
                ecPOId=modify.tariff.ECPOId,
                oldCrmProductCodes=feeModify.pageFeeInfo.OldCrmCode;
            if (applyCode!=null && applyCode!= '') {
                openSource = 2;
                value = applyCode;
            }
            if (ecPOId!=null && ecPOId!= '') {
                openSource = 1;
                value = ecPOId;
            }
            var url=feeModify.url("GetFeeAttr",{
                crmProducts:modify.removeBlank(crmProductCodes),
                crmOldProcuts:modify.removeBlank(oldCrmProductCodes),
                openSource:openSource,
                ecPrdCode:modify.tariff.ECPrdCode,
                value:value
            });
            $("#submitOrder").disabled(true);
            $("#productProperty").load(url, function () {
                //把GN4001num属性设为不可编辑
                if (modify.tariff.CrmProductCode == "4001") {
                    $.each($(".txtInput.n-ipt"), function (j, item) {
                        if (item.name.has("GN4001num")) {
                            $(this).attr('disabled', true);
                        }
                    });
                }

                $("#submitOrder").disabled(false);
            });
        },
        setApplyCode:function(applycode){
            if(applycode){
                modify.tariff.ApplyCode=applycode;
                feeModify.feeInfo.ApplyCode=applycode;

            }
        },
        submitTariff:function(){
            //提交资费信息
            modify.isValid=true;
            feeModify.validTariff();
            if(modify.isValid){
                //如果验证通过，则提交资费信息
                feeModify.getTariffInfo();
                if(modify.isValid){
                    song.setDisabled("input.btn_3f","input.btn_4f");                    
                    var url=feeModify.url("SubmitTariff"),
                        param=$.toJSON(feeModify.feeInfo);
                    song.ajax(url,param,function(data){
                        feeModify.setApplyCode(data.applyCode);
                        if (data.IsSuccess) {
                            if (data.resultnum == 0) {
                                modify.alert("系统网络繁忙，请稍后重试！");
                            } else {
                                if (data.resultnum == 3) {
                                    //跳转到审核页面
                                    modify.jump();
                                    window.location.href =feeModify.url("CheckFee",{
                                        ApplyCode:data.applyCode,
                                        listfrom:modify.attrs.fromList,
                                        isAudit:(data.isAudit==undefined ? true : data.isAudit)
                                    });
                                }else{
                                    modify.alert(data.msg);
                                }
                            }
                        } else {
                            modify.alert(data.message);
                        }
                    },function(){
                        song.removeDisabled("input.btn_3f","input.btn_4f");
                    },true);
                }
            }
        },
        getTariffInfo:function(){
            //获取变更前和变更后的资费信息
            feeModify.feeInfo.ECOrderApplyItemExpands=[];
            feeModify.feeInfo.Products=[];//附加产品列表
            feeModify.feeInfo.Attrs=[];//属性列表
            feeModify.pageFeeInfo.NewProductInfo={};//变更后的资费
            feeModify.pageFeeInfo.NewAttr={};//变更后的属性
            //添加变更的基本信息
            "ApplyCode,CrmProductCode,ProductName,ECPOId,ECPrdCode,ECCode".replace(song.split,function(name){
                feeModify.feeInfo[name]=modify.tariff[name];
            });
            //真实集团信息
            j.extend(feeModify.feeInfo,modify.getRealEc());
            var chooseProduct = "";
            $(".product:checked").each(function (i, v) {
                var product = {},
                    pstr = $(v).attr("prvalue"),
                    el=$(v);
                product.crmProductCode = el.val();
                product.productName = el.attr("pname");
                product.Description = pstr.split('^')[0];
                product.IsMemberProduct = pstr.split('^')[1];
                product.FeeType = pstr.split('^')[2];
                product.Sprodid = pstr.split('^')[3]; 
                //isHide是否隐藏与isShow正好相反
                product.IsShow = pstr.split('^')[4].toLowerCase() == "false" ? true : false;
                //默认为变更原有
                product.OptType = 1;
                chooseProduct += product.crmProductCode + ",";
                feeModify.pageFeeInfo.NewProductInfo[el.val()] = product;
            });
            feeModify.feeInfo.ChooseProduct = chooseProduct;
            //保存变更后的属性
            $(".hiddenproperty").each(function (i, p) {
                feeModify.pushProperty(p, true);
            });
            feeModify.feeInfoConvert();
        },
        pushProperty:function(p,isSave){
            //组装属性信息
            var el=$(p),
                pname = $(p).attr("proname"),pnametwo = $(p).attr("pnometwo"),
                ids = pname.split(','),productServiceRelationId = ids[0],
                ProductServiceAttributeId = ids[1],productCode = ids[2],attrType = ids[3],
                referFee = ids[4],serviceCode = ids[5],AttrCode = ids[6],
                optType = $(p).attr("optType");
            //第二部分的
            var ida = pnametwo.split(','),Description = ida[1],SortNo = ida[2],OpenType = ida[3],
                IsAllowModify = ida[4],IsNeed = ida[5],IsShow = ida[6],
                ObjectName = ida[7],ProductName = ida[8],
                AttrName = el.attr("disname"),curp = $("[name='" + pname + "']"),
                sepSign =el.attr("sepsign"),EditType = el.attr("tagname"),
                type = el.attr("tagtype"),MaxLength = el.attr("imaxLength"),
                MinLength = el.attr("iminLength"),defValue = el.attr("defValue"),
                ShelfHide = el.attr("ShelfHide"),sval = "";
            if (EditType == "3") {
                $("[name='" + pname + "']:checked").each(function (i, v) {
                    sval += $(v).val() + sepSign;
                    if (isSave == true) {
                        el.attr("optType", "4")
                    }
                });
                sval = sval.substring(0, sval.length - 1);
            } else if (EditType == "4") { //更改枚举值得时候 
                sval = $("input:radio[name='" + pname + "']:checked").val();
                if (isSave == true) {
                    el.attr("optType", "4")
                }
            } else {
                sval = curp.val();
            }
            var attr = {
                ProductServiceRelationId : productServiceRelationId,
                ProductServiceAttributeId : ProductServiceAttributeId,
                Crmproductcode : productCode,
                ServiceCode : serviceCode,
                ObjectName : ObjectName,
                AttrType : attrType,
                ReferFee : referFee,
                OptType : 1,
                AttrValue : sval,
                AttrCode : AttrCode,
                AttrName : AttrName,
                DefaultValue : defValue,
                Description : Description,
                SepSign : sepSign,
                SortNo : SortNo,
                EditType : EditType,
                OpenType : OpenType,
                IsAllowModify : IsAllowModify,
                IsNeed : IsNeed,
                IsShow : IsShow,
                MinLength : MinLength,
                MaxLength : MaxLength,
                Type : type,
                ProductName : ProductName
            };
            var key = ProductServiceAttributeId + ',' + productServiceRelationId + ',' + AttrCode;
            if (isSave == false) {//如果是false就表示是加载页面时候保存的旧数据
                //从核对页面返回上一步的时候
                if (modify.tariff.ApplyCode != '') {
                    //201是进行变更了的值,要保存到旧值里面 200是什么都没变的 但是还是需要保存一份到旧值里面
                    if (optType == 1 || optType == 201 || optType == 200) {
                        feeModify.pageFeeInfo.OldAttr[key] = attr;
                    }
                } else {
                    if (optType == 100) {
                        feeModify.pageFeeInfo.OldAttr[key] = attr;
                    }
                }
            } else {
                //如果是true就表示是保存后的新数据 如果是-1表示是从上架配置过来的
                if (optType == -1) {
                    attr.OptType = 2;
                }
                if (modify.tariff.ApplyCode != '') {
                    if (el.attr("optType") != 201 ) {
                        if (ShelfHide.toLocaleLowerCase() == "false") {
                            feeModify.pageFeeInfo.NewAttr[key] = attr;
                        }
                    }
                } else {
                    //从Ecpoid进来只要保存非变更原有的值
                    if (el.attr("optType") != 1) {
                        feeModify.pageFeeInfo.NewAttr[key] = attr;
                    }
                }
            }
        },
        feeInfoConvert:function(){
            //判读附加产品的变更状态
            var products = feeModify.feeInfo.Products,
                attrs =feeModify.feeInfo.Attrs;
            //判断附加产品是否改变过
            var isChooseProduct = false,isChooseAttr = false;
            //判断新的产品里面是否在旧的附加产品里面有，如果没有就将OptType设置为2即变更增加
            for (var i in feeModify.pageFeeInfo.NewProductInfo) {
                if (feeModify.pageFeeInfo.OldProductInfo[i] == undefined) {
                    isChooseProduct = true;
                    feeModify.pageFeeInfo.NewProductInfo[i].OptType = 2;
                    //变更增加
                    products.push(feeModify.pageFeeInfo.NewProductInfo[i]);
                } else {
                      
                    //假如附加产品没有变化 但是下面的属性有变化了
                    var opttype = feeModify.checkAttr(i);
                    if (opttype == 0) {

                    } else {
                        isChooseProduct = true;
                        feeModify.pageFeeInfo.NewProductInfo[i].OptType = opttype;
                        products.push(feeModify.pageFeeInfo.NewProductInfo[i]);
                        //附加产品下面的属性变了 那么附加产品也得重新保存一次叫做变更原有
                    }
                }
            }
            //判断旧的产品在新的附加产品里面是否含有，如果没有就将OptType设置为3即变更移除
            for (var i in feeModify.pageFeeInfo.OldProductInfo) {
                //先把旧的保存一次
                var oldproduct = feeModify.pageFeeInfo.OldProductInfo[i];
                products.push(oldproduct);
                if (Object.count(feeModify.pageFeeInfo.NewProductInfo)<=0) {
                    return;
                }
                if (feeModify.pageFeeInfo.NewProductInfo[i] == undefined) {
                    isChooseProduct = true;
                    var obj = {};
                    for (var k in feeModify.pageFeeInfo.OldProductInfo[i]) {
                        obj[k] = feeModify.pageFeeInfo.OldProductInfo[i][k];
                    }
                    obj.OptType = 3;
                    products.push(obj);
                }
            }
            //判断变更后的属性是否在旧的属性里面 
            for (var i in feeModify.pageFeeInfo.NewAttr) {
                if (feeModify.pageFeeInfo.OldAttr[i] == undefined) {
                    isChooseAttr = true;
                    feeModify.pageFeeInfo.NewAttr[i].OptType = 2;
                    attrs.push(feeModify.pageFeeInfo.NewAttr[i]);
                } else {
                    if (feeModify.pageFeeInfo.NewAttr[i].AttrValue != feeModify.pageFeeInfo.OldAttr[i].AttrValue) {
                        isChooseAttr = true;
                        feeModify.pageFeeInfo.NewAttr[i].OptType = 4;
                        attrs.push(feeModify.pageFeeInfo.NewAttr[i]);
                    }
                }
            }
            //判断变更前的属性是否在新的属性里面 
            for (var i in feeModify.pageFeeInfo.OldAttr) {
                //先把旧的保存一次
                attrs.push(feeModify.pageFeeInfo.OldAttr[i]);
                if (Object.count(feeModify.pageFeeInfo.NewAttr)<=0) {
                    //当附加产品已经被移除 且选中的产品下面没有任何属性值 那么需要把附加产品下面的值改成opt=3
                    for (var j in products) {
                        if (products[j].OptType == 3 && products[j].crmProductCode == feeModify.pageFeeInfo.OldAttr[i].Crmproductcode) {
                            isChooseAttr = true;
                            var obj = {};
                            for (var k in feeModify.pageFeeInfo.OldAttr[i]) {
                                obj[k] = feeModify.pageFeeInfo.OldAttr[i][k];
                            }
                            obj.OptType = 3;
                            attrs.push(obj);
                        }
                    }
                    return;
                }
                if (feeModify.pageFeeInfo.NewAttr[i] == undefined) {
                    isChooseAttr = true;
                    var obj = {};
                    for (var k in feeModify.pageFeeInfo.OldAttr[i]) {
                        obj[k] = feeModify.pageFeeInfo.OldAttr[i][k];
                    }
                    obj.OptType = 3;
                    attrs.push(obj);
                }
            }
            if (attrs.length != 0) {
                if (isChooseAttr == false && isChooseProduct == false) {
                    modify.isValid = false;
                    modify.alert("该产品资费或套餐没有进行任何变更，请修改相关信息后再提交");
                    return;
                }
            } else {
                if (isChooseProduct == false) {
                    modify.isValid = false;
                    modify.alert("该产品资费或套餐没有进行任何变更，请修改相关信息后再提交");
                    return;
                }
            }
        },
        checkAttr:function(crmproduct){
            //判断变更后的属性是否在旧的属性里面 
            for (var i in feeModify.pageFeeInfo.NewAttr) {
                //假如属性是从订购关系过来的
                if (feeModify.pageFeeInfo.OldAttr[i] != undefined) {
                    if (feeModify.pageFeeInfo.NewAttr[i].AttrValue != feeModify.pageFeeInfo.OldAttr[i].AttrValue) {
                        var aCrmproductcode = feeModify.pageFeeInfo.NewAttr[i].Crmproductcode;
                        if (aCrmproductcode == crmproduct) {
                            return 4;
                        }
                    }
                } else {//假如属性是从上架配置过来的

                    if (Object.count(feeModify.pageFeeInfo.NewAttr) >0) {
                        var aCrmproductcode = feeModify.pageFeeInfo.NewAttr[i].Crmproductcode;
                        if (aCrmproductcode == crmproduct) {
                            return 4;
                        }
                    }
                }
            }
            //判断变更前的属性是否在新的属性里面 
            for (var i in feeModify.pageFeeInfo.OldAttr) {
                if (feeModify.pageFeeInfo.NewAttr[i] != undefined) {
                    if (feeModify.pageFeeInfo.NewAttr[i].AttrValue != feeModify.pageFeeInfo.OldAttr[i].AttrValue) {
                        var aCrmproductcode = feeModify.pageFeeInfo.OldAttr[i].Crmproductcode;
                        if (aCrmproductcode == crmproduct) {
                            return 4;
                        }
                    }
                } else {
                    if (Object.count(feeModify.pageFeeInfo.OldAttr) >0) {
                        var aCrmproductcode = feeModify.pageFeeInfo.OldAttr[i].Crmproductcode;
                        if (aCrmproductcode == crmproduct) {
                            return 3;
                        }
                    }
                }
            }
            return 0;
        }
    };
})(window.song,window.jQuery,window.modify);