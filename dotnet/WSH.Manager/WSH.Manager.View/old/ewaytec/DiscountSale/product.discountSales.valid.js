/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Apply|Modify
content:            	折扣销售产品开通和变更，通用的属性验证和产品个性化验证
beforeLoad:     		j,base,apply|modify
createDate:             2014-04-15
updatedDate:  			2014-05-12
*/
; (function (song,j) { 
    var com=window.apply || window.modify;
    /*************************************通用的产品验证******************************************/
    j.extend(com,{
        isValid:true,
        setError:function(lname,msg,yesno){
            //设置属性的验证信息
            $("[lname='" + lname + "']").html('<b class="'+(yesno ? 'cGreen060' : 'cRedf00')+'">'+msg+'</b>');
        },
        setCorrect:function(pname,msg){
            com.setError(pname,msg || "填写正确",true);
        },
        getPropertyValue:function(p){
            //获取属性的值
            var pel=$(p),pname=pel.attr("proname"),curp = $("[name='" + pname + "']"),
                itagName =pel.attr("tagname"),sval = "";
            if (itagName == "3" || itagName == "4") {
                if ($("[name='" + pname + "']:checked").length > 0) {
                    sval = "1";
                };
            }
            else {
                sval = curp.val();
            }
            return {name:pname,value:sval,el:pel}
        },
        validProperty:function(p,pname,sval,callback){
            //验证基本的信息
            var isCorrect = true;
            //校验是否是必填的
            com.validRequired(p,pname, sval) || (isCorrect = false);
            //校验长度输入是否正确
            if (isCorrect) {
                com.validMaxlength(p,pname, sval) || (isCorrect = false);
            }
            //正则校验属性是否正确填写
            if (isCorrect) {
                com.validRegex(p,pname, sval) || (isCorrect = false);
            }
            //自定义验证
            if(callback){
                if(callback(isCorrect)==false){
                    isCorrect=false;
                }
            }
            isCorrect && com.setCorrect(pname);
            return isCorrect;
        },
        validRequired:function(p,pname,sval){
            //校验必填的信息
            if (p.attr("isneed") == 1) {
                if (sval == "" || sval == null || sval == undefined) {
                    com.setError(pname,"该项必须填写!",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        validMaxlength:function(p,pname,sval){
            var imaxLength = p.attr("imaxLength");                    
            //校验长度输入是否正确
            if (imaxLength != undefined && imaxLength > 0) {
                if (sval.length > imaxLength) {
                    com.setError(pname,"该项最多输入"+imaxLength+"个字符!",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        validRegex:function(p,pname,val){
            var IRegular = p.attr("IRegular"),
                IRegularMsg = p.attr("IRegularMsg"),
                isShow = p.attr("IsShow");
            //正则校验属性是否正确填写
            if (isShow == "1") {
                if (IRegular != undefined && IRegular != "") {
                    var RegularList = IRegular.split(";"); //正则表达式
                    var MessageList = IRegularMsg.split(";"); //提示信息
                    for (var i = 0; i < RegularList.length; i++) {
                        var regex1 = RegularList[i];
                        if (regex1 != "") {
                            var tempResult =val.match(regex1);
                            if (tempResult == null) {
                                com.setError(pname, MessageList[i],false);
                                com.isValid=false;
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    });
    /*************************************企业邮箱产品个性化验证******************************************/
    j.extend(com,{
        validCorpDomain:function(pname,sval){
            //验证域名长度，域名格式
            var result=true;
            if(com.productCode=="820"){
                if (pname.indexOf("CorpDomain") != -1) {
                        if (sval.length > 26) {
                            com.setError(pname,"域名长度不能大于26个字!",false);
                            result = false;
                        }
                        if (!com.regex.DomainRegx.test(sval)) {
                            com.setError(pname,"域名只能输入字母、数字、中划线(-)、小数点(.)，不能输入下划线(_)，长度不能大于26个字！例如：www.baidu.com,www.yahoo.cn",false);
                            result = false;
                        }
                        if (result) {
                            com.setError(pname,"填写正确",true);
                            com.attrs.CorpDomain={key:pname,value:sval.trim()};
                        }else{
                            com.isValid = false;
                            com.attrs.CorpDomain=null;
                        }
                    }
            }
            return result;
        },
        validNfactor:function(pname,sval){
            //验证N值是否填写正确
            if(com.productCode!="820" || !pname.toLowerCase().has("nfactor")){
                return true;
            }
            var result=true,msg="填写正确";
            var nfactor=parseInt(sval.trim()),
                selectTariff=j("input[name='FunctionCosts']:checked").val();     
            if(isNaN(nfactor) || nfactor==0){
                result=false;
                msg="必须是正整数";
            }
            //获取选择的功能费，判断是按人数开通还是按容量开通
            if(com.attrs.NfactorPeopleProductCodes.has(selectTariff)){
                //按人数开通，N值不能小于10，并且是5的倍数
                if(nfactor<10 || (nfactor%5!=0)){
                    result=false;
                    msg="贵企业需要开通企业邮箱的人数,该人数必须大于或等于10，并且是5的倍数";
                }
                
            }else if(com.attrs.NfactorCapacityProductCodes.has(selectTariff)){
                //按容量开通，N值不能小于500，并且是250的倍数
                if(nfactor<500 || (nfactor%250!=0)){
                    result=false;
                    msg="贵企业需要开通企业邮箱的容量,该容量必须大于或等于500，并且是250的倍数";
                }
            }
            if(!result){
                com.setError(pname,msg,result);
                com.isValid=false
            }
            return result;
        },
        showSelectDomainButton:function(r){
            //判断是否显示选择域名的按钮
            var selDomainType = $(r),
                isUserDomain=com.attrs.IsUserDomainExchange=='TRUE',
                selectText=selDomainType.find("option:selected").text();
            if (selectText == "申请139cm.com二级域名") {
                if (isUserDomain) {
                    $("#txtCorpDomain").attr("readonly", true);
                    $("#selDomain").show();
                }
            }
            if (selectText == "移动协助申请.cn一级域名") {
                if (isUserDomain) {
                    $("#txtCorpDomain").attr("readonly", true);
                    $("#selDomain").show();
                }
            }
            if (selectText== "使用企业自有域名") {
                $("#txtCorpDomain").attr("readonly", false);
                $("#selDomain").hide();
            }
        },
        selectDomainName:function(){
            //选择域名
            var isUserDomain=com.attrs.IsUserDomainExchange == 'TRUE',
                selectText=$("#selDomainType").find("option:selected").text()
            if (selectText == "申请139cm.com二级域名") {
                if (isUserDomain) {
                    var h=com.attrs.ValidateDomainHeight;
                    var w=com.attrs.ValidateDomainWidth;
                    window.showModalDialog(com.attrs.ValidateDomainUrl, window, 
                    "center=yes;dialogHeight="+h+";dialogWidth="+w);
                }
            }
            if (selectText == "移动协助申请.cn一级域名") {
                if (isUserDomain) {
                    var h=com.attrs.RegisterDomainHeight;
                    var w=com.attrs.RegisterDomainWidth;
                    window.showModalDialog(com.attrs.RegisterDomainUrl, window, 
                    "center=yes;dialogHeight="+h+";dialogWidth="+w);
                }
            }
        },
        validDomainName:function(callback){
            //验证域名，必须符合域名格式，且不能存在申请单和订购中
            if(com.attrs.CorpDomain.value && com.isValid){
                song.setDisabled("input.btn_3f","input.btn_4f");
                var param={
                    paramValue:escape( com.attrs.CorpDomain.value),
                    applyCode:com.tariff.ApplyCode
                };
                if(com.tariff.ECPrdCode){
                    param.ecprdcode=com.tariff.ECPrdCode;
                }
                song.ajax(song.url("ProductOpen","ExistsCorpDomain").getUrl(),
                param,function(data){
                    if(!data.isSuccess){
                        com.setError(com.attrs.CorpDomain.key,data.msg,false);
                    }else{
                        callback();
                    }
                },function(){
                    song.removeDisabled("input.btn_3f","input.btn_4f");
                });
            }else{
                callback();
            }
        }
    });
    /*************************************1020手机邮箱产品个性化验证******************************************/
    j.extend(com,{
        validMobileMail:function(pname,sval){
            //校验1020手机邮箱属性
            var isValid=true;
            com.validPopAddress(pname,sval) || (isValid=false);
            com.validPopPort(pname,sval) || (isValid=false);
            com.validPopPort(pname,sval) || (isValid=false);
            com.validSmtpAddress(pname,sval) || (isValid=false);
            return isValid;
        },
        validPopAddress:function(pname,sval){
            if (pname.indexOf("pop_addr") != -1) {
                var isDomain = /[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+\.?/.test(sval);
                var isIP = /^(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)$/.test(sval);
                if (isDomain || isIP || sval == "") {
                } else {
                    com.setError(pname,"请填写正确的POP3地址",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        validPopPort:function(pname,sval){
            if (pname.indexOf("pop_port") != -1) {
                if (sval == "" || (/^\d+$/.test(sval) && sval >= 0 && sval <= 65535)) {
                } else {
                    com.setError(pname,"请填写正确的POP3端号口",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        validSmtpAddress:function(pname,sval){
            if (pname.indexOf("smtp_addr") != -1) {
                var isDomain = /[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+\.?/.test(sval);
                var isIP = /^(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)$/.test(sval);
                if (isDomain || isIP || sval == "") {
                } else {
                    com.setError(pname,"请填写正确的SMTP地址",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        validSmtpPort:function(pname,sval){
            if (pname.indexOf("smtp_port") != -1) {
                if (sval == "" || (/^\d+$/.test(sval) && sval >= 0 && sval <= 65535)) {
                } else {
                    com.setError(pname,"请填写正确的SMTP端号口",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        selectDomainProvider:function(r){
            //1020产品选择自建域名
            var selDomainProvider = $(r);
            if (selDomainProvider.val() == "自建域名" || selDomainProvider.val() == "其它") {
                $("#txtMailServerID").val("").removeAttr("readonly");
                $("#txtpop_addr").val("").removeAttr("readonly");
                $("#txtpop_port").val("").removeAttr("readonly");
                $("#txtsmtp_addr").val("").removeAttr("readonly");
                $("#txtsmtp_port").val("").removeAttr("readonly");
                $("input[type=radio]").each(function () {
                $(this).removeAttr("readonly");
                    if ($(this).attr("name").indexOf("if_smtp_fullauth") > -1) {
                        $(this).attr("checked", false);
                    } else if ($(this).attr("name").indexOf("if_smtp_auth") > -1) {
                        $(this).attr("checked", false);
                    } else if ($(this).attr("name").indexOf("character_encoding") > -1) {
                        $(this).attr("checked", false);
                    }
                });
            } else {
                song.ajax(
                    song.url("ProductOpen","GetDomainProviderDetails").getUrl(),
                    {domainName:escape(selDomainProvider.val())},
                    function(data){
                        $("#txtMailServerID").val(data.Result.Domain).attr("readonly","readonly");
                        $("#txtpop_addr").val(data.Result.Pop3Server).attr("readonly","readonly");
                        $("#txtpop_port").val(data.Result.Pop3Port).attr("readonly","readonly");
                        $("#txtsmtp_addr").val(data.Result.SmtpServer).attr("readonly","readonly");
                        $("#txtsmtp_port").val(data.Result.SmtpPort).attr("readonly","readonly");
                        $("input[type=radio]").each(function () {
                            if ($(this).attr("name").indexOf("if_smtp_fullauth") > -1) {
                                if ($(this).val() == data.Result.IsSmtpFullNameValidate) {
                                    $(this).attr("checked", true);
                                }
                                $(this).attr("readonly", "readonly");
                            } else if ($(this).attr("name").indexOf("if_smtp_auth") > -1) {
                                if ($(this).val() == data.Result.IsSmtpValidate) {
                                    $(this).attr("checked", true);
                                }
                                $(this).attr("readonly", "readonly");
                            } else if ($(this).attr("name").indexOf("character_encoding") > -1) {
                                if ($(this).val() == data.Result.CharaterSet) {
                                    $(this).attr("checked", true);
                                }
                                $(this).attr("readonly", "readonly");
                            }

                        });
                    }
                );
            }
        }
    });
    /*************************************818产品个性化验证******************************************/
    j.extend(com,{
        validContactMobile:function(pname,sval){
            if (pname.indexOf("联系手机") != -1 && pname.indexOf("ContactMobile") != -1) {
                if (!modify.regex.MobileRex.test(sval)) {
                    com.setError(pname,"不是移动手机号码",false);
                    com.isValid=false;
                    return false;
                }
            }
            return true;
        },
        validMailServerID:function(pname,sval){
            //验证邮箱服务器
            if (pname.indexOf("MailServerID") != -1){
                var useProductMemberCount=com.attrs.UseProductMemberCount;
                if(parseInt(useProductMemberCount)>0)
                {
                    com.setError(pname,"产品已经分配成员，需要先把所有成员注销才能修改此值",false);
                }else{
                    var siResult = com.validSIParameter();
                    if (!siResult) {
                        com.isValid=false;
                        return false;
                    }
                }
            }
            return true;
        },
        validSIParameter:function(){
            if(com.attrs.UseProductMemberCount>0)
            {
                return true;
            }else{
                var num = $("#txtMailServerID").val();
                var pname = $("#txtMailServerID").attr("name");
                var flag = false;
                if (num != "") {
                    $("[lname='" + pname + "']").html('<b class="cGreen060">正在对企业域名进行校验，请稍后...</b>');
                        $.ajax({
                            type: "GET",
                            async: false,
                            url: song.url("ProductOpen","SIParameterValidate").getUrl(),
                            dataType: 'json',
                            data: "ECPrdCode="+com.tariff.ECPrdCode+"ParamName=MailServerID&ParamValue=" + num + "&productCode="+com.productCode,
                            success: function (data) {
                            if (data.Result=="ok") {
                                    $("[lname='" + pname + "']").html('<b class="cGreen060">填写正确</b>');
                                    flag = true;
                                } else if (data.Result == "no") {
                                    $("[lname='" + pname + "']").html('<b class="cRedf00">请填写正确的域名，例如：chinamobile.com</b>');
                                    flag = false;
                                } else if (data.Result == "error") {
                                    $("[lname='" + pname + "']").html('<b class="cRedf00">系统网络繁忙，请稍后重试！</b>');
                                    flag = false;
                                }
                            },
                            error: function () {
                                $("[lname='" + pname + "']").html('<b class="cRedf00">系统网络繁忙，请稍后重试！</b>');
                                flag = false;
                            }
                        });
                }else {
                    $("[lname='" + pname + "']").html('<b class="cRedf00">该项必须填写!</b>');
                }
                return flag;
            }
        }
    });
})(window.song,window.jQuery);