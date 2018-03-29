/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		FeeModify.Valid
content:            	产品资费变更验证模块
beforeLoad:     		j,base,modify,feeModify
createDate:             2014-05-12
updatedDate:  			2014-05-19
*/
; (function (song,j,modify) { 
    /*************************************产品资费变更验证模块******************************************/
    j.extend(feeModify,{
        validTariff:function(){
            //验证资费信息
            modify.isValid=true;
            $(".error").remove();
            $(".correct").remove();
            var ischeckedmnual = false,ischeckRequisite = false,msgmnual = "",msgRequisite = "";
            //判断功能费是否有被选中的
            var isFunctionCosts = false,requiredCheck = {};
            $(".product").each(function (i, box) {
                var ckre = $(box).attr("requiredexclusion");
                var ckval = $(box).val();
                if (ckre != null && ckre != "" && ckre != undefined) {
                    if (!requiredCheck[ckre]) {
                        requiredCheck[ckre] = { valid: false, msg: "" };
                    }
                    if (ckre.indexOf(ckval) >= 0) {
                        var dd = $(box).chekced;
                        if ($(box).attr("checked") == "checked") {
                            ischeckedmnual = true;
                            requiredCheck[ckre].valid = true;
                        } else {
                            msgmnual += $(box).attr("pname") + ",";
                        }
                        if (requiredCheck[ckre].valid) {
                            requiredCheck[ckre].msg = "";
                        } else {
                            requiredCheck[ckre].msg += $(box).attr("pname") + ",";
                        }
                    }
                }
                if ($(box).attr("checked") == "checked") {
                    ischeckRequisite = true;
                } else {
                    msgRequisite += $(box).attr("pname") + ",";
                }
                if ($(box).attr("checked") == "checked" && $(box).attr("name") == "FunctionCosts") {
                    isFunctionCosts = true;
                }
            });
            if (isFunctionCosts == false) {
                modify.alert('功能费套餐必须选择一项!');
                modify.isValid = false;
                return false;
            }
            for (var k in requiredCheck) {
                if (!requiredCheck[k].valid) {
                    var msg = requiredCheck[k].msg;
                    modify.alert(msg.substr(0, msg.length - 1) + "必须选择一个");
                    modify.isValid = false;
                    return false;
                }
            }
            if (ischeckRequisite == false) {
                if (msgRequisite != "") {
                    modify.alert(msgRequisite.substr(0, msgmnual.length - 1) + "必须选择一项");
                    modify.isValid = false;
                    return false;
                }
            }
            //校验资费是否正确选择
            var prdList = $(".product:checked");
            clsSubProductChooseCommon.sSubProductCodes = "";
            $.each(prdList, function (i, box) {
                var _box = $(box);
                var sPrdCode = _box.val();
                clsSubProductChooseCommon.sSubProductCodes += sPrdCode + ",";
            });
            var message = false;
            var lastcondition = "";
            $.each(prdList, function (i, ap) {
                var sConditionsSelectedPart = $(ap).attr("conditionsSelectedPart");
                if (sConditionsSelectedPart && sConditionsSelectedPart != "" != null && sConditionsSelectedPart != undefined) {
                    if (lastcondition.indexOf(sConditionsSelectedPart) < 0) {
                        message = clsSubProductChooseCommon.fnValidateConditionsSelectedPart(sConditionsSelectedPart, prdList, true, true, "");
                        lastcondition += sConditionsSelectedPart + ",";
                    }
                }
            });
            if (message != false) {
                modify.isValid = false;
                return false;
            }
            //校验属性是否正确填写,保存原有的附加产品
            $(".hiddenproperty").each(function (i, p) {
                var ShowAttr = true,pel=$(p);
                if (pel.attr("IsHideReturn").toLowerCase() == "true") {
                    ShowAttr = false;
                }
                else {
                    if (pel.attr("IsShow") == 0) {
                        ShowAttr = false;
                    }
                }
                if (pel.attr("optType") != 1 && ShowAttr == true) {
                    var content=modify.getPropertyValue(p);
                    feeModify.validProperty(content.el,content.name,content.value);
                }
            });
            if (!modify.isValid) {
                return false;
            }
        },
        blurValidProperty:function (obj) {
            //属性失去焦点进行验证
            modify.isValid = true;
            $(".error").remove();
            $(".correct").remove();
            var p = $("[proname='" + $(obj).attr("name") + "']"),
                pname = $(obj).attr("name"),
                sval = obj.value;
            feeModify.validProperty(p,pname,sval);
            if (!modify.isValid) {
                return false;
            }
        },
        validProperty:function(p,pname,sval){
            //校验属性
            modify.validProperty(p,pname,sval,function(isCorrect){
                if(isCorrect){
                    isCorrect=modify.validNfactor(pname,sval);
                    isCorrect=feeModify.validGN400DLH(pname,sval);
                }
                return isCorrect;
            });
        },
        validGN400DLH:function(pname,sval){
            //验证中心坐席数是否填写正确
            if(window.modify.productCode!="4001" || !pname.toLowerCase().has("gn400dlh_usernum") || sval==""){
                return true;
            }
            var result=true,msg="填写正确";
            var r = /^[0-9]*[1-9][0-9]*$/ ;　　//正整数
            if(!r.test(sval.trim())){
                result=false;
                msg="必须是正整数";
            }
            if(!result){
                window.modify.setError(pname,msg,result);
                modify.isValid=false;
            }
            return result;
        }
    });
})(window.song,window.jQuery,window.modify);