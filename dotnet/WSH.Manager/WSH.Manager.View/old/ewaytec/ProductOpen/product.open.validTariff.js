/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Song.Apply.ValidTariff
content:            	折扣销售产品开通申请-资费验证
beforeLoad:     		j,base,apply
createDate:             2013-08-26
updatedDate:  			2013-08-26
*/
; (function (song,j) { 
    j.extend(apply,{
        setError:function(lname,msg,yesno){
            $("[lname='" + lname + "']").html('<b class="'+(yesno ? 'cGreen060' : 'cRedf00')+'">'+msg+'</b>');
        },
        tariffLoaded:function(){
            $(".product").live("click", function () {
			     var prdList = $(".product:checked");
			    //对于条件必选部分的规则，当选择条件组的所有产品时，必选部分所有组都需要重新选择；
			    apply.checkedRuleValid(prdList,$(this).attr("conditionsSelectedPart"));
                clsSubProductChooseCommon.fnInformationValidateChoose(this, false);
                var chooseCrmProductCodes = apply.getCrmProductCodes(prdList);
                //显示4001的温馨提示
                apply.showTip4001(chooseCrmProductCodes);
                apply.loadProductProperty(chooseCrmProductCodes, apply.tariff.ApplyCode, apply.tariff.ECOrderApplyItemId);
            });
            apply.bindViewBusiness();
            apply.bindIsCheck();
            apply.signValid();
        },
        signValid:function(){
            /*********签名互斥规则控制**************/
            var exists4Sign = function () {
                var isTextSign = $("div[id='IsTextSign']").length;
                var defaultSinglang = $("div[id='DefaultSignlang']").length;
                var textSignEN = $("div[id='TextSignEN']").length;
                var textSignZH = $("div:[id='TextSignZH']").length;
                if (isTextSign != undefined && isTextSign != ''
                            && defaultSinglang != undefined && defaultSinglang != ''
                                && textSignEN != undefined && textSignEN != ''
                                    && textSignZH != undefined && textSignZH != '') {
                    return true;
                } else {
                    return false;
                }
            };
            var setShowOrHideSign = function () {
                var isTextSign = $("input:radio:checked[attrCode='IsTextSign']").val();
                if (isTextSign == "1") {
                    $("div[id='DefaultSignlang']").show();
                    setDefaultSinglang();
                } else {
                    $("div[id='DefaultSignlang']").hide();
                    $("div[id='TextSignZH']").hide();
                    $("div[id='TextSignEN']").hide();
                }
            };
            var setDefaultSinglang = function () {
                var defaultSinglang = $("select[attrCode='DefaultSignlang']  option:selected").val();
                if (defaultSinglang == "1") {
                    $("div[id='TextSignZH']").show();
                    $("div[id='TextSignEN']").hide();
                } else {
                    $("div[id='TextSignEN']").show();
                    $("div[id='TextSignZH']").hide();
                }
            };
            $("input:radio[attrCode='IsTextSign']").each(function () {
                if (exists4Sign()) {
                    $(this).change(function () {
                        setShowOrHideSign();
                    });
                }
            });
            $("select[attrCode='DefaultSignlang']").each(function () {
                if (exists4Sign()) {
                    $(this).click(function () {
                        setDefaultSinglang();
                    });
                }
            });
            if (exists4Sign()) {
                setShowOrHideSign();
            }
        },
        checkedRuleValid:function(prdList,tempsConditionsSelectedPart){
            //校验规则
            if (tempsConditionsSelectedPart && tempsConditionsSelectedPart != "" != null && tempsConditionsSelectedPart != undefined)
			{
				var tempSelectProducts='';
				var conditionsSelectedPartsList = tempsConditionsSelectedPart.split("|");
	 			$.each(conditionsSelectedPartsList, function (pi, cspart)
				{
					$.each(prdList, function (i, box) {
						var _box = $(box);
						var sPrdCode = _box.val();
						tempSelectProducts += sPrdCode + ",";
					});
					var mes = cspart.split(':')[1],
						cons = new Array(), li = 0;
					if (cspart.split(':')[0].indexOf(',') >= 0)
					{
						cons = cspart.split(':')[0].split(',');
					} else {
						cons.push(cspart.split(':')[0]);
					}
					//条件组中已经选中产品
					var tempmleft = new Array();
					$.each(cons, function (i, l) {
						if (tempSelectProducts.indexOf(l) != -1) {
							li++;
							tempmleft.push(l);
						}
					});
					if(tempmleft.length == li)
					{
						//条件组中的产品全部选中；
							var otherCodes = [];
							if (mes.indexOf(';') >= 0) {
								$.each(mes.split(';'), function (i, re) {
									var rs = re;
									if (re.indexOf(',') >= 0) {
										rs = re.split(',');
									}
									otherCodes = otherCodes.concat(rs);
								});
							} else {
								var rs = mes.split(',');
								otherCodes = otherCodes.concat(rs);
							}
							$.each(otherCodes, function (i, code) {
								$("[id='prd_" + code + "']").removeAttr("disabled");
							});
					}      
				});
			}	
        },
        validTariff:function(){
            //验证资费填写信息
            apply.isValid=true;
                $(".error").remove();
                $(".correct").remove();
                var ischeckedmnual = false;
                var ischeckRequisite = false;
                var msgmnual = "";
                var msgRequisite = "";
                var pRequistite = "";
                $(".product").each(function (i, box) {
                    var ckre = $(box).attr("requiredexclusion");
                    var ckval = $(box).val();
                    if (ckre != null && ckre != "" && ckre != undefined) {
                        if (pRequistite.indexOf(ckre) < 0) {
                            var ckres = new Array();
                            if (ckre.indexOf(",") >= 0) {
                                $.each(ckre.split(':'), function (i, item) {
                                    $.each(item.split(','), function (j, box) {
                                        ckres.push(box);
                                    })
                                })
                            } else {
                                ckres = ckre.split(':');
                            }
                            $.each(ckres, function (a, code) {
                                var dd = $(box).chekced;
                                if ($("[id='prd_" + code + "']").attr("checked") == "checked") {
                                    ischeckedmnual = true;
                                } else {
                                    msgmnual += $("[id='prd_" + code + "']").attr("pname") + ",";
                                }
                            });
                            pRequistite += ckre;
                        }
                        if ($(box).attr("checked") == "checked") {
                            ischeckRequisite = true;
                        } else {
                            msgRequisite += $(box).attr("pname") + ",";
                        }
                    }
                });
                if (ischeckedmnual == false) {
                    if (msgmnual != "") {
                        window.top.song.alert(msgmnual.substr(0, msgmnual.length - 1) + "必须选择一个");
                        apply.isValid = false;
                        return false;
                    }

                } else if (ischeckRequisite == false) {
                    if (msgRequisite != "") {
                        window.top.song.alert(msgRequisite.substr(0, msgmnual.length - 1) + "必须选择");
                        apply.isValid = false;
                        return false;
                    }
                }
                //修改成必须选择一个资费
                var functionCostCounts = $("input[name='communicationCost']:checked,input[name='FunctionCosts']:checked").length;
                if (functionCostCounts <= 0) {
                        window.top.song.alert("请选择功能费或者通讯费");
                        apply.isValid = false;
                        return false;
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
                    apply.isValid = false;
                    return false;
                }
                //校验属性是否正确填写
                var propChecked = true;
                $(".hiddenproperty").each(function (i, p) {
                    var pname = $(p).attr("proname");
                    var curp = $("[name='" + pname + "']");
                    var itagName = $(p).attr("tagname");
                    var isreq = $(p).attr("isneed");
                    var isShow = $(p).attr("IsShow");
                    var imaxLength = $(p).attr("imaxLength");
                    var IRegular = $(p).attr("IRegular");
                    var IRegularMsg = $(p).attr("IRegularMsg");
                    var curpanme = $(p).attr("disname");
                    var sval = "";
                    if (itagName == "3" || itagName == "4") {
                        if ($("[name='" + pname + "']:checked").length > 0) {
                            sval = "1";
                        }
                        ;
                    } else {
                        sval = curp.val();
                    }
                    var isCorrect = true;
                    if (isreq == "1") {
                        if (sval == "" || sval == null || sval == undefined) {
                            apply.setError(pname,"该项必须填写",false);
                            propChecked = false;
                            isCorrect = false;
                        }
                    }
                    if (imaxLength != undefined && imaxLength > 0) {
                        if (sval.length > imaxLength) {
                            apply.setError(pname,'最多允许输入' + imaxLength + '个字符',false);
                            propChecked = false;
                            isCorrect = false;
                        }
                    }
                    //正则校验属性是否正确填写
                    if (isShow == "1") {
                        if (IRegular != undefined && IRegular != "") {
                            var RegularList = IRegular.split(";"); //正则表达式
                            var MessageList = IRegularMsg.split(";"); //提示信息
                            for (var i = 0; i < RegularList.length; i++) {
                                var regex1 = RegularList[i];
                                if (regex1 != "") {
                                    var tempResult = sval.match(regex1);
                                    if (tempResult == null) {
                                        var msg = '<b class="cRedf00">' + MessageList[i] + '</b>';
                                        $("[lname='" + pname + "']").html(msg);
                                        propChecked = false;
                                        isCorrect = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (pname.indexOf("MailServerID") != -1) {
                        var SIParameterValidateResult = clsImmediatelyOpenInfo.fnSIParameterValidate();
                        if (!SIParameterValidateResult) {
                            propChecked = false;
                            isCorrect = false;
                        }
                    }
                    //企业邮箱个性化验证
                    apply.validCorpDomain(pname,sval);
                    apply.validNfactor(pname,sval);
                });
                if (!propChecked) {
                    apply.isValid = false;
                    return false;
                }
                //校验是否正确填写管理员信息
                var isCheckedManager = true;
                $(".manager").each(function (i, v) {
                    var curp = $(v);
                    var curname = curp.attr("name");
                    var sname = curp.attr("sname");
                    var curval = curp.val();
                    var curpanme = $(v).attr("disname");
                    var iscorrect = true;
                    if (curval == "" || curval == null || curval == undefined) {
                        apply.setError(sname,'该项必须填写!',false);
                        isCheckedManager = false;
                        iscorrect = false;
                    }
                    if (iscorrect) {
                        if (curname.indexOf("手机号码") != -1) {
                            var rex = apply.regex.CMMobileRex;
                            if (!rex.test(curval)) {
                                apply.setError(sname,'手机号码格式不正确!',false);
                                isCheckedManager = false;
                                iscorrect = false;
                            }
                        }
                        if (curname.indexOf("电子邮件") != -1) {
                            var rex = /^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$/;
                            if (!rex.test(curval)) {
                                apply.setError(sname,'电子邮件格式不正确!',false);
                                isCheckedManager = false;
                                iscorrect = false;
                            }
                        }
                        if (curname.indexOf("产品管理员账号") != -1) {
                            if ($("#prdadminuser").val().length > 16) {
                                apply.setError(sname,'产品管理员账号长度不能大于16位!',false);
                                isCheckedManager = false;
                                iscorrect = false;
                            }
                        }
                    }
                    if (iscorrect) {
                        apply.setError(sname,'填写正确',true);
                    }
                });
                if (!isCheckedManager) {
                    apply.isValid = false;
                    return false;
                }
                //400个性化校验
                if(apply.tariff.CrmProductCode=="4001")
                {
                    //验证备注信息
                    var Remark=j("#Remark").val().trim();
                    if(Remark.length>200){
                        apply.setError("Remark",'最多输入200个字!',false);
                        apply.isValid = false;
                        return false;
                    }
//                    var yuzhan=$("#txtGN4001yzdannum").val();
//                    if(yuzhan=="")
//                    {
                    //再次校验400号码是否可以使用
                    var num=$("#txtGN4001num");
                    if(num.length>0){
                        var flag=apply.occupyValid(true);
                        if(flag==false)
                        {  
                            apply.isValid = false;
                            return false;
                        }
                    }
                //}
            }
//            if(apply.isValid){
//                apply.submitTariffInfo();
//            }
        },occupyValid:function(isNum){
            //校验400号码是否可以使用
            var n=$("#txtGN4001num").val().trim(),
                num ="4001"+n,
                pname = $("#txtGN4001num").attr("name"),
                flag = false,
                regex = /^([0-9]{6})$/,
                defaultValue="4001"+$("#txtGN4001numDefault").val().trim();
            if(num!="" && defaultValue!="" && num==defaultValue){
                return true;
            }
            if(!regex.test(n))
            {
                apply.setError(pname,"必须填写六位数字",false);
                return false; 
            }
            if(num!="") {
//                apply.setError(pname,"正在对号码进行校验，请稍后...",true);
//                var params={ParamValue:num,ProductCode:apply.tariff.CrmProductCode};
//                song.ajax(apply.url("OccupyValidate"),params,function(data){
//                    if (data.isSuccess) {
//                        if(data.numberStatus!="ok")
//                        {
//                            apply.setError(pname,data.numberStatus,false);
//                            apply.isValid=false;
//                        }else
//                        {
//                            apply.setError(pname,"号码可以使用",true);
//                            apply.isValid=true;
//                            isNum && apply.occupyNum();
//                        }
//                                
//                    } else{
//                        apply.setError(pname,data.msg,false);
//                        apply.isValid=false;
//                    }
//                },function(r){
//                    r || (apply.isValid=false);
//                });
                return true;
            }else {
                apply.setError(pname,"该项必须填写!",false);
                apply.isValid=false;
            }
            return flag;
        },
        occupyNum:function(){
            //对400号码预占
             var num ="4001"+$("#txtGN4001num").val(),
                pname = $("#txtGN4001num").attr("name"),
                flag = false,
                params={EcName:encodeURIComponent(apply.tariff.EcName),ParamValue:num,ProductCode:apply.tariff.CrmProductCode};
            song.ajax(apply.url("OccupyNum"),params,function(data){
                if (data.msg.indexOf("ok")>=0) {
                    apply.setError(pname,"号码可以使用",true);
                    //$("#txtGN4001yzdannum").val(data.msg.split(':')[1]);
                    apply.isValid=true;
                    //预占号码之后，提交订单
                    apply.submitTariffInfo();
                } else if (data.msg == "no") {
                    apply.setError(pname,"号码已预占，不能使用",false);
                    apply.isValid=false;
                } else if (data.msg == "error") {
                    apply.setError(pname,"系统网络繁忙，请稍后重试！",false);
                    apply.isValid=false;
                }
            },function(r){
                r || (apply.isValid=false);
            });
            return flag;
        }
    });
})(window.song,window.jQuery);