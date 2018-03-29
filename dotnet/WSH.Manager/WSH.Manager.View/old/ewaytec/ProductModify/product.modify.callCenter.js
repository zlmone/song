/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Modify
content:            	折扣销售-400语音虚拟呼叫中心-产品个性化变更
beforeLoad:     		j,base
createDate:             2014-02-25
updatedDate:  			2014-02-25
*/
; (function (song,j) { 
    window.modify=window.modify || {};
    /*************************************400语音虚拟呼叫中心-产品个性化变更******************************************/
    j.extend(modify,{
        url:function(action,params){
            return song.url("CallCenterModify",action,params).getUrl();
        },
        checkProduct:function(e,areacode){
            $("input.product").removeAttr("checked");
            $(e).attr("checked","checked");
            modify.tariffLoaded(areacode);
        },
        tariffLoaded:function(areacode){
            var prdList = $("input.product:checked"),
                chooseCrmProductCodes = "";
            $.each(prdList, function (i, box) {
                var _box = $(box);
                var sPrdCode = _box.val();
                chooseCrmProductCodes += sPrdCode + ",";
            });
            chooseCrmProductCodes=chooseCrmProductCodes.delEnd(",");
            modify.loadProductProperty(chooseCrmProductCodes,areacode);
        },
        loadProductProperty:function(crmProductCodes,areacode){
            //如果没有选中，则不获取属性
            if($("input.product:checked").length==0)return;
            //先保存已经填写的属性值
            var values=apply.getPropertyValues();
            song.setDisabled("#btnPrev","#btnNext");
            //动态加载产品属性
            var property=$("#productProperty");
            property.html("正在加载属性...");
            var url=modify.url("ProductProperty",{
                crmProductCodes:crmProductCodes.replace(/^\s+|\s+$/g, ""),
                areacode:areacode
            });
            property.load(url,function(){
                song.removeDisabled("#btnPrev","#btnNext");
                //渲染已经填写的属性值
                apply.setPropertyValues(values);
            });
        },
        openCallCenter:function(orderid,areacode){
            var dialog = apply.getDialog({
                id:"callCenterModifyDialog",
                onClose:function(returnvalue){
                    view.movePage();
                }
            });
            dialog.option({title:"国内400业务-添加产品",width:800,height:500});
            dialog.open(modify.url("CallCenterModify",{orderid:orderid,areacode:areacode}));
        },
        gotoFinish:function(){
            //跳转到成功页面
            location.href=modify.url("Finish");
        },
        setError:function(lname,msg,yesno){
            $("[lname='" + lname + "']").html('<b class="'+(yesno ? 'cGreen060' : 'cRedf00')+'">'+msg+'</b>');
        },
        submitCallModify:function(){
            //提交变更申请单
            if(modify.validSubmit()){
                var val=modify.getValues();
                //序列化资费信息，校验订单
                song.setDisabled("input.btn");
                var url=modify.url("SubmitCallCenterModify"),
                    params=j.toJSON(val).replace(/undefined/g, '\"\"');
                song.loading.setMsg("正在提交资费信息...");
                song.ajax(url,params,function(data){
                    if(data.isSuccess){
                        song.loading.show();
                        modify.gotoFinish();
                    }else{
                        window.top.song.alert(data.msg);
                       // apply.gotoCheckOrder();
                    }
                },function(){
                    song.removeDisabled("input.btn");
                },true);
            }
        },
        validSubmit:function(){
            var chs=$("input.product:checked");
            if(chs.length<=0){
                window.top.song.alert("请选择资费");
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
                        modify.setError(pname,"该项必须填写",false);
                        propChecked = false;
                        isCorrect = false;
                    }
                }
                if (imaxLength != undefined && imaxLength > 0) {
                    if (sval.length > imaxLength) {
                        modify.setError(pname,'最多允许输入' + imaxLength + '个字符',false);
                        propChecked = false;
                        isCorrect = false;
                        //  return false;
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
                                    //return false;
                                }
                            }
                        }
                    }
                }
            });
            if (!propChecked) {
                return false;
            }
            return true;
        },
        getValues:function(){
            //属性列表
            var values={SubProducts:[],Attrs:[],OrderId:$("#OrderId").val()};
            //获取选中的资费
            $("input.product:checked").each(function (i, v) {
                values.SubProducts.push({SubProductCode:$(v).val()});
            });
            //获取属性
            $("input.hiddenproperty").each(function (i, p) {
                var pname = $(p).attr("proname"),
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
                }
                values.Attrs.push({AttrCode:attrCode,AttrValue:sval,ProductCode:productCode});
            });
            return values;
        },
        cancelCallModify: function () {
            //取消开通
            apply.closeDialog("callCenterModifyDialog");
        }
    });
})(window.song,window.jQuery);