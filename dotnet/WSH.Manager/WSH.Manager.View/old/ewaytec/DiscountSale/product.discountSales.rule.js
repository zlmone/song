
/************************************************/
//功能说明:折扣销售产品开通和变更,通用的规则验证
//创建人:候红丽
//创建时间:2011-6-29
//修改人:王松华
//修改时间:2014-05-12
/************************************************/
$.extend(Array, {
    remove: function (arr, index_value) {
        if (typeof (index_value) == "number") {
            arr.splice(index_value, 1);
        } else { var i = Array.indexOf(arr, index_value); if (i > -1) { arr.splice(i, 1); } }; return arr;
    },
    clear: function (arr) { arr.splice(0, arr.length); },
    indexOf: function (arr, value) {
        for (var i = 0; i < arr.length; i++) { if (arr[i] == value) { return i; } }; return -1;
    },
    has: function (arr, value) { return Array.indexOf(arr, value) > -1; },
    max: function (arr) {
        return Math.max.apply(Math, arr);
    },
    min: function (arr) {
        return Math.max.apply(Math, arr);
    },
    //是否是取消其中一个勾
    mutexGroup: function (isChecked, currCodes, otherCodes) {
        //互斥规则判断,isChecked:当前复选框的checked，currCodes：组员集合，otherCodes:他组成员
        if (isChecked) {
            //如果当前复选框选中的话，则勾选同组，禁用其他组
            var radioNum = 0;
            $.each(currCodes, function (i, p) {
                $("[id='prd_" + p + "']").attr({ "checked": "checked" });
                if ($("[id='prd_" + p + "']").attr("name") == "communicationCost") {
                    radioNum++;
                }
            });
            $.each(otherCodes, function (i, p) {
                if ($("[id='prd_" + p + "']").attr("name") == "communicationCost") {
                    radioNum++;
                }

            });
            var TotalNum = currCodes.length + otherCodes.length;
            //只有当此规则都没有全部落在单选按钮里面 
            if (radioNum < TotalNum) {
                $.each(otherCodes, function (i, p) {
                    var ck = $("[id='prd_" + p + "']");
                    ck.removeAttr("checked");
                    ck.attr("ischecked", "0");
                    ck.attr({ "disabled": "disabled" });

                });
            }
        } else {
            //如果当前复选框未选中，则去除同组的选中，并解禁他组
            $.each(currCodes, function (i, p) {
                $("[id='prd_" + p + "']").removeAttr("checked");
            });
            $.each(otherCodes, function (i, p) {
                $("[id='prd_" + p + "']").removeAttr("disabled");
            });
        }
    }
});
var clsSubProductChooseCommon = function () {
    var isValidate = true;
    return {
        sSubProductCodes: "",
        isAlert: true,
        fnChoosePart: new Array(),
        aOpenSubPrdArr: new Array(),   // 待开通附加产品列表
        aCancelSubPrdArr: new Array(), // 待取消附加产品列表
        //如果选中了通信费的时候需要解禁其他资费
        funIscommunicationCost: function (box, prdlist) {
            var RadioArraySelectedPart = new Array();
            //查询单选按钮没有被选中的
            var nocheckeds = $('input:radio[name="communicationCost"]').not("input:checked");

            var nocheckedArray = new Array();
            $.each(nocheckeds, function (s, item) {
                // nocheckedArray.push(item.id);
                var crmcode = item.id;
                //条件必选部分解禁
                var conditionsselectedpart = $("[id='" + crmcode + "']").attr("conditionsselectedpart");
                //必选互斥
                var requiredExclusion = $("[id='" + crmcode + "']").attr("requiredExclusion");
                //互斥 
                var mutualExclusion = $("[id='" + crmcode + "']").attr("mutualExclusion");
                //条件必选
                var mutual = $("[id='" + crmcode + "']").attr("mutual");


                //如果是条件必选部分 则查看原先是否有过选择 有的话要把原先的选择给清空
                if (conditionsselectedpart != "" && conditionsselectedpart != null && conditionsselectedpart != undefined) {
                    clsSubProductChooseCommon.fnValidateConditionsSelectedPart(conditionsselectedpart, prdlist, false, false, box);

                } //必选互斥
                else if (requiredExclusion != "" && requiredExclusion != null && requiredExclusion != undefined) {
                    clsSubProductChooseCommon.fnValidateRequiredExclusion(requiredExclusion, prdlist, box, false);

                } //互斥 
                else if (mutualExclusion != "" && mutualExclusion != null && mutualExclusion != undefined) {

                    clsSubProductChooseCommon.fnCheckMutualExclusion(mutualExclusion, prdlist, box, false);

                } //条件必选
                else if (mutual != "" && mutual != null && mutual != undefined) {
                    clsSubProductChooseCommon.fnCheckMutual(mutual, prdlist, box, false);
                }

            });

        },
        fnCheckMutual: function (sMutual, sPrdCode, prdList, isFirst) { //验证条件必选规则
            var aMutualArr = new Array();
            aMutualArr = sMutual.split("|");
            var message = "";
            if (aMutualArr.length > 0) {
                $.each(aMutualArr, function (i, mutual) {
                    clsSubProductChooseCommon.sSubProductCodes = "";
                    $.each(prdList, function (i, box) {
                        var _box = $(box);
                        var sPrdCode = _box.val();
                        clsSubProductChooseCommon.sSubProductCodes += sPrdCode + ",";
                    });
                    //例：条件必选规则：A:C,D
                    //left = A,right = C,D
                    // aLefts = {A},aRights = {C,D}
                    // 如果附加产品中已经选择A,同时选择C，D
                    var left = mutual.split(':')[0];
                    var right = mutual.split(':')[1];
                    var aLefts = new Array();
                    var aRights = new Array();
                    var leftNames = "";
                    var rightNames = "";
                    aLefts = left.split(',');
                    aRights = right.split(',');
                    var iChooseNum = 0;
                    var iRChooseNum = 0;
                    if (aLefts.length >= 1) {
                        $.each(aLefts, function (j, lval) {
                            var _prd = $("[id='prd_" + lval + "']");
                            var oSubProduct = clsSubProductChooseCommon.fnGetSubProduct(_prd);
                            leftNames += oSubProduct.ProductName + ",";
                            if (clsSubProductChooseCommon.sSubProductCodes.indexOf(lval) != -1) {
                                iChooseNum += 1;
                            }
                        });
                    }
                    if (!isFirst) {
                        $.each(right, function (i, item) {
                            if (item.indexOf(',') >= 0) {
                                $.each(right.split(','), function (j, box) {
                                    var disabled = $("[id='prd_" + box + "']").attr("disabled");
                                    if (disabled != undefined) {
                                        $("[id='prd_" + box + "']").removeAttr("disabled");
                                    }
                                });

                            } else {

                                var disabled = $("[id='prd_" + item + "']").attr("disabled");
                                if (disabled != undefined) {
                                    $("[id='prd_" + item + "']").removeAttr("disabled");
                                }
                            }

                        });
                    }

                    if (iChooseNum == aLefts.length) {
                        //给出规则提示消息，默认选中条件必选规则选项
                        //alert("sMutual" + sMutual);
                        $.each(aRights, function (i, r) {
                            var _prd = $("[id='prd_" + r + "']");
                            var oSubProduct = clsSubProductChooseCommon.fnGetSubProduct(_prd);
                            rightNames += oSubProduct.ProductName + ",";
                            if (clsSubProductChooseCommon.sSubProductCodes.indexOf(r) != -1) {
                                iRChooseNum++;
                            }
                        });
                        if (iRChooseNum != aRights.length) {
                            isValidate = false;
                        }
                        $.each(aRights, function (i, r) {
                            var rprd = $("[id='prd_" + r + "']");
                            rprd.attr("checked", "checked");
                            rprd.attr({ "disabled": "disabled" });
                        });
                    }
                    else {
                        $.each(aRights, function (i, r) {
                            var rprd = $("[id='prd_" + r + "']");
                            rprd.removeAttr("disabled");
                        });
                        isValidate = true;
                    }
                    message += "【" + leftNames.substr(0, leftNames.length - 1) + "】与【" + rightNames.substr(0, rightNames.length - 1) + "】条件必选;";

                });
            }
        }, //isFirst表示勾选了其他通信费
        fnCheckMutualExclusion: function (sMutualExclusion, prdList, checkObj, isFirst) {//验证互斥规则
            var aMutualExclusionArr = new Array();
            aMutualExclusionArr = sMutualExclusion.split("|");
            if (aMutualExclusionArr.length > 0) {
                $.each(aMutualExclusionArr, function (i, mutualExclusion) {
                    clsSubProductChooseCommon.sSubProductCodes = "";
                    $.each(prdList, function (i, box) {
                        var _box = $(box);
                        var sPrdCode = _box.val();
                        clsSubProductChooseCommon.sSubProductCodes += sPrdCode + ",";
                    });
                    var mes = mutualExclusion.split(':');
                    var acis = 0; //总共选中组数
                    var isAllChoose = false;
                    var curme = "";
                    var acodes = new Array(); //规则包含的所有产品
                    var macodes = new Array(); //产品选择数量=产品总数-1的产品组
                    $.each(mes, function (j, me) {
                        var ci = 0; //组内产品选中数量
                        var ms = me.split(',');
                        $.each(ms, function (g, m) {
                            if (clsSubProductChooseCommon.sSubProductCodes.indexOf(m) != -1) { //如果已经选中，则组内产品选中数量加1
                                ci++;
                            }
                            acodes.push(m);
                        });
                        if (ci == ms.length) { //如果组内产品选中数据和组内产品数量和相等
                            isAllChoose = true;
                            curme = me;
                        }
                        if (ci > 0) { //如果组内有选中产品，总共选中组数+1
                            acis++;
                        }
                        if ((ms.length == 1 && ci == 1) || ci == ms.length - 1) { //
                            macodes.push(me);
                        }
                    });
                    /*************************WSH.Begin****************************/
                    // var res = mutualExclusion.split(':');
                    //currCodes：当前组成员，otherCodes：他组成员,currCode:当前编码
                    var currCodes = [],
                    otherCodes = [],
                    isChecked = checkObj.attr("checked"),
                    currCode = checkObj.val();
                    //已选中产品规则
                    $.each(mes, function (i, re) {
                        var rs = re.split(',');
                        //判断当前编码是否在当前组
                        var isCurrent = re.indexOf(currCode) > -1;
                        //如果当前编码组包含当前编码，则添加到当前组成员集合中
                        isCurrent ? (currCodes = rs) : (otherCodes = otherCodes.concat(rs));
                    });
                    //假如选中了其他项的单选按钮
                    if (!isFirst) {
                        $.each(otherCodes, function (i, code) {
                            var disabled = $("[id='prd_" + code + "']").attr("disabled");
                            if (disabled != undefined) {
                                $("[id='prd_" + code + "']").removeAttr("disabled");
                            }
                        });
                        return;

                    }

                    //判断互斥规则（wsh）
                    Array.mutexGroup(isChecked, currCodes, otherCodes);

                    //   return;
                    /*************************WSH.End****************************/


                });
            }
        },
        //条件必选部分 检测通讯费套餐的时候 是否是第一次加载 isFirst=true 是一次选中
        fnValidateConditionsSelectedPart: function (conditionsSelectedPart, prdList, isFirst, isSubmmit, checkObj) { //验证条件必选部分
            var message = false;
            var conditionsSelectedParts = conditionsSelectedPart.split("|");
            $.each(conditionsSelectedParts, function (pi, cspart) {
                clsSubProductChooseCommon.sSubProductCodes = "";
                $.each(prdList, function (i, box) {
                    var _box = $(box);
                    var sPrdCode = _box.val();
                    clsSubProductChooseCommon.sSubProductCodes += sPrdCode + ",";
                });

                var mes = cspart.split(':')[1],
                    cons = new Array(),
                    li = 0,
                    CheckedCon = false,
                    allChecked = false;
                if (cspart.split(':')[0].indexOf(',') >= 0) {
                    cons = cspart.split(':')[0].split(',');
                } else {
                    cons.push(cspart.split(':')[0]);
                }
                //条件组中已经选中产品规则
                var mleft = new Array();
                $.each(cons, function (i, l) {

                    if (clsSubProductChooseCommon.sSubProductCodes.indexOf(l) != -1) {
                        li++;
                        mleft.push(l);
                    }
                    if (!isSubmmit) {
                        //判断点击的是否是条件组里面的
                        if (checkObj.val().indexOf(l) >= 0) {
                            CheckedCon = true;
                        }
                    }

                });

                //如果是点击了其他单选按钮，那么原先有选中的条件必选部分的单选按钮，其余的都要取消禁用
                if (!isFirst) {
                    var otherCodes = [];
                    var currCodes = [];
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
                    return;

                }
                //假如条件组中没有全部选择完 且是选中当前框
                if (cons.length == li) {
                    allChecked = true;
                }
                //是否是提交 一定要选判断是否是提交 以防下面checkObj.val() js报错
                if (isSubmmit) {

                    message = clsSubProductChooseCommon.ConditionRequireNotice(mleft, mes, allChecked, clsSubProductChooseCommon.sSubProductCodes);
                    return message;
                }
                var currCodes = [],
                    otherCodes = [],
					conditionCodes = [],
                    isChecked = checkObj.attr("checked"),
                    currCode = checkObj.val(),
                    conditionLength = 1;

                //必选组中已选中产品规则
                if (mes.indexOf(';') > 0) {
                    $.each(mes.split(';'), function (i, re) {
                        var rs = re;

                        if (re.indexOf(',') >= 0) {

                            rs = re.split(',');
                        }
                        //判断当前编码是否在当前组
                        var isCurrent = re.indexOf(currCode) > -1;
                        //如果当前编码组包含当前编码，则添加到当前组成员集合中
                        isCurrent ? (currCodes = rs) : (otherCodes = otherCodes.concat(rs));
                    });
                } else {
                    var rs = mes.split(',');
                    //判断当前编码是否在当前组
                    var isCurrent = mes.indexOf(currCode) > -1;
                    //如果当前编码组包含当前编码，则添加到当前组成员集合中
                    isCurrent ? (currCodes = rs) : (otherCodes = otherCodes.concat(rs));
                }

                message = clsSubProductChooseCommon.ConditionRequireGroup(isChecked, currCodes, otherCodes, allChecked, mleft, CheckedCon, clsSubProductChooseCommon.sSubProductCodes);
            });

            return message;
        },
        ConditionRequireNotice: function (mleft, mright, allChecked, CheckedCodes) {
            var message = false,
                IsSingle = false;
            var otherCodes = [];
            var currCodes = [];

            if (mright.indexOf(';') >= 0) {
                $.each(mright.split(';'), function (i, re) {
                    var rs = re;
                    if (re.indexOf(',') >= 0) {
                        rs = re.split(',');
                    }
                    otherCodes = otherCodes.concat(rs);

                });

            } else {
                IsSingle = true;
                var rs = mright.split(',');
                otherCodes = otherCodes.concat(rs);
            }
            $.each(otherCodes, function (i, code) {

                if (CheckedCodes.indexOf(code) >= 0) {
                    currCodes.push(code);
                }
            });
            //如果是提交需要加判断 并且提示
            if (allChecked && currCodes.length == 0) {
                message = true;
                var leftmsg = "";
                var rightmsg = "";
                $.each(mleft, function (i, code) {
                    var prd = $("[id='prd_" + code + "']");
                    var pname = prd.attr("pname");
                    leftmsg += pname + ",";

                });
                leftmsg = leftmsg.substr(0, leftmsg.length - 1);
                $.each(otherCodes, function (i, code) {
                    var prd = $("[id='prd_" + code + "']");
                    var pname = prd.attr("pname");
                    rightmsg += pname + ",";

                });

                rightmsg = rightmsg.substr(0, rightmsg.length - 1);
                if (IsSingle) {
                    window.top.song.alert("您选中了" + leftmsg + ",那么必须在" + rightmsg + "中选择一个");
                } else {
                    window.top.song.alert("您选中了" + leftmsg + ",那么必须在" + rightmsg + "中选择一组");
                }
            }
            return message;
        },
        //isChecked 是否被选中 currCodes条件必选部分选中部分部分的当前组 otherCodes 没选中的组 allChecked条件组是否全部被选中 mleft条件组 CheckedCon选中的是否是条件组的 CheckedCodes 所有被选中的
        ConditionRequireGroup: function (isChecked, currCodes, otherCodes, allChecked, mleft, CheckedCon, CheckedCodes) {

            //表示全部选中才执行此规则
            if (allChecked == true && currCodes.length > 0) {
                //互斥规则判断,isChecked:当前复选框的checked，currCodes：组员集合，otherCodes:他组成员
                if (isChecked) {

                    //如果当前复选框选中的话，则勾选同组，禁用其他组
                    $.each(currCodes, function (i, p) {
                        $("[id='prd_" + p + "']").attr({ "checked": "checked" });
                    });
                    $.each(otherCodes, function (i, p) {
                        var ck = $("[id='prd_" + p + "']");
                        if (ck.attr("type").toLowerCase() == "checkbox") {
                            ck.removeAttr("checked");
                            ck.attr("ischecked", "0");
                            ck.attr({ "disabled": "disabled" });
                        }
                    });
                } else {
                    //如果当前复选框未选中，则去除同组的选中，并解禁他组
                    $.each(currCodes, function (i, p) {
                        $("[id='prd_" + p + "']").removeAttr("checked");
                    });
                    $.each(otherCodes, function (i, p) {
                        $("[id='prd_" + p + "']").removeAttr("disabled");
                    });
                }
            } else {
                //假如条件必选部分的条件组勾选去掉 那么要将必选部分的所有解禁
                if (!isChecked && CheckedCon) {
                    $.each(currCodes, function (i, p) {
                        $("[id='prd_" + p + "']").removeAttr("checked");
                        $("[id='prd_" + p + "']").removeAttr("disabled");
                    });
                    $.each(otherCodes, function (i, p) {
                        $("[id='prd_" + p + "']").removeAttr("disabled");
                        $("[id='prd_" + p + "']").removeAttr("checked");
                    });
                }
                var m = 0;
                $.each(otherCodes, function (i, p) {
                    if (CheckedCodes.indexOf(p) >= 0) {
                        m++;
                    }
                });
                //假如条件组中条件勾选，且必选部分有被选中的 那么要将必选部分勾选上的全部解禁
                if (m > 0 && isChecked) {
                    $.each(otherCodes, function (i, p) {
                        $("[id='prd_" + p + "']").removeAttr("checked");
                    });
                }

            }

        },
        //IsFirst 当是单选按钮的时候是否是第一次选中
        //checkObj 复选框的jQuery对象(wsh)
        fnValidateRequiredExclusion: function (requiredExclusion, prdList, checkObj, isFirst) //验证必选互斥
        {
            var message = "";
            var requiredExclusions = requiredExclusion.split("|");
            $.each(requiredExclusions, function (rei, rexclusion) {
                clsSubProductChooseCommon.sSubProductCodes = "";
                $.each(prdList, function (i, box) {
                    var _box = $(box);
                    var sPrdCode = _box.val();
                    clsSubProductChooseCommon.sSubProductCodes += sPrdCode + ",";

                });
                var res = rexclusion.split(':');
                var codes = new Array();  //规则包含的所有产品编码
                var curcodes = new Array(); //已选中产品编码集合
                var curex = ""; //已选中产品的规则
                var ichoose = 0; //已选择产品数
                //currCodes：当前组成员，otherCodes：他组成员,currCode:当前编码(wsh)
                var currCodes = [],
                    otherCodes = [],
                    isChecked = checkObj.attr("checked"),
                    currCode = checkObj.val();
                //已选中产品规则
                $.each(res, function (i, re) {
                    var rs = re.split(',');
                    //判断是否是当前组(wsh)
                    var isCurrent = re.indexOf(currCode) > -1;
                    $.each(rs, function (j, r) {
                        //如果当前编码组包含当前编码，则添加到当前组成员集合中(wsh)
                        isCurrent ? currCodes.push(r) : otherCodes.push(r);
                        if (clsSubProductChooseCommon.sSubProductCodes.indexOf(r) != -1) {
                            curex = re;
                            return;

                        }
                    });
                });
                //计算规则包含的所有产品编码、已选中产品编码集合、已选择产品数
                $.each(res, function (i, re) {
                    var rs = re.split(',');
                    $.each(rs, function (j, r) {
                        if (clsSubProductChooseCommon.sSubProductCodes.indexOf(r) != -1) {
                            ichoose++;

                        }
                        if (curex != "" && curex.indexOf(r) != -1) {
                            curcodes.push(r);

                        }
                        else {
                            codes.push(r);
                        }
                    });
                });
                //判断互斥规则（wsh）
                //假如选中了其他项的单选按钮
                if (!isFirst) {
                    $.each(otherCodes, function (i, code) {
                        var disabled = $("[id='prd_" + code + "']").attr("disabled"); ;
                        if (disabled != undefined) {
                            $("[id='prd_" + code + "']").removeAttr("disabled");
                        }

                    });
                    return;
                }
                Array.mutexGroup(isChecked, currCodes, otherCodes);

                isValidate = true;
            });


        },

        fnInformationValidateChoose: function (obj, IsupdateLoad) {
            var _this = $(obj);
            isValidate = true;

            var prdList = $(".product:checked");
            var sProductCode = _this.val();
            var sMutual = _this.attr("mutual");
            var sMutualExclusion = _this.attr("mutualExclusion");
            var sRequiredExclusion = _this.attr("requiredExclusion");
            var sConditionsSelectedPart = _this.attr("conditionsSelectedPart");
            var IscommunicationCost = _this.attr("name");
            if (IscommunicationCost != null && IscommunicationCost != "" && IscommunicationCost != undefined) {
                //检测必选互斥与条件必选部分通讯费按钮 将_this传入来确定该产品是选中 还是取消选中
                if (!IsupdateLoad) {
                    clsSubProductChooseCommon.funIscommunicationCost(_this, prdList);
                }
            }

            if (sMutualExclusion != null && sMutualExclusion != "" && sMutualExclusion != undefined) { //校验互斥规则
                clsSubProductChooseCommon.fnCheckMutualExclusion(sMutualExclusion, prdList, _this, true);
            }
            if (isValidate) {
                //检验条件必选部分
                if (sConditionsSelectedPart != null && sConditionsSelectedPart != "" && sConditionsSelectedPart != undefined) {

                    clsSubProductChooseCommon.fnValidateConditionsSelectedPart(sConditionsSelectedPart, prdList, true, false, _this);


                }
            }
            if (isValidate) {
                if (sMutual != null && sMutual != "" && sMutual != undefined) { //校验条件必选
                    clsSubProductChooseCommon.fnCheckMutual(sMutual, sProductCode, prdList, true);
                }
            }
            if (isValidate) {
                if (sRequiredExclusion != null && sRequiredExclusion != "" && sRequiredExclusion != undefined) { //校验必选互斥
                    clsSubProductChooseCommon.fnValidateRequiredExclusion(sRequiredExclusion, prdList, _this, true);
                }
            }


        },
        fnValidateChoose: function (_box) { //验证选择
            var _this = $(_box);
            isValidate = true;
            var oSubProduct = clsSubProductChooseCommon.fnGetSubProduct(_box);
            var prdList = $("#subProductChooseGrid input[type=checkbox][usedCheckBox!=true]:checked");

            if (oSubProduct.MutualExclusion != null && oSubProduct.MutualExclusion != undefined && oSubProduct.MutualExclusion != "") {
                clsSubProductChooseCommon.fnCheckMutualExclusion(oSubProduct.MutualExclusion, prdList, _this, true);
            }

            if (oSubProduct.Mutual != null && oSubProduct.Mutual != undefined && oSubProduct.Mutual != "") {
                clsSubProductChooseCommon.fnCheckMutual(oSubProduct.Mutual, oSubProduct.ProductCode, prdList);
            }

        },

        fnAddSubProduct: function (arr, _box) { //添加产品
            var sPrdCode = _box.attr("val");
            var oSubProduct = clsSubProductChooseCommon.fnGetSubProduct(_box);
            arr.push(oSubProduct);

        },
        fnGetSubProduct: function (box) { //获取附加产品对象
            var _box = $(box);
            var sPrdCode = _box.attr("val");
            var sPrdName = _box.parents("td").next("[columnname=ProductName]").children().text();
            var sMutual = _box.attr("mutual");
            var sMutualExclusion = _box.attr("mutualExclusion");
            var sRequiredExclusion = _box.attr("requiredExclusion");
            var sConditionsSelectedPart = _box.attr("conditionsSelectedPart");
            var iprice = _box.attr("price");
            var isHide = _box.attr("ishide");
            var oSubProduct = {};
            oSubProduct.ProductCode = sPrdCode;
            oSubProduct.ProductName = sPrdName;
            oSubProduct.Mutual = sMutual;
            oSubProduct.MutualExclusion = sMutualExclusion;
            oSubProduct.RequiredExclusion = sRequiredExclusion == undefined ? "" : sRequiredExclusion;
            oSubProduct.ConditionsSelectedPart = sConditionsSelectedPart == undefined ? "" : sConditionsSelectedPart;
            oSubProduct.Price = iprice;
            oSubProduct.IsHide = isHide;
            return oSubProduct;
        }
    }
} ();

