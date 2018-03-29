/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		FeeModify.CheckFee
content:            	产品资费变更核对订单
beforeLoad:     		j,base,modify
createDate:             2014-05-16
updatedDate:  			2014-05-16
*/
; (function (song,j,modify) { 
    window.feeModify=window.feeModify || {
        controller:"ProductFeeModify",
        url:function(action,params){
            //返回资费变更对应的action的路径
            return song.url(feeModify.controller,action,params).getUrl();
        }
    };
    /*************************************产品资费核对订单模块******************************************/
    j.extend(feeModify,{
        checkBalance:function(){
            //校验余额是否充足
            modify.disabledButton(true);
            var url=feeModify.url("CheckBalance",{
                ecPrdCode:modify.tariff.ECPrdCode,
                totalFee:modify.tariff.TotalFee,
                productCode:modify.tariff.CrmProductCode
            });
            song.ajax(url,null,function(data){
                if(data.isSuccess){
                    var m=parseFloat(data.amount);
                    if(m>0){
                        feeModify.recharge(data.amount);
                    }else{
                        feeModify.saveOrderApply();
                    }
                }else{
                    modify.alert("系统繁忙，请稍后再试");
                }
            },function(){
                modify.disabledButton(false);
            },true);
        },
        recharge:function(content){
            //充值
            var isRecharge=modify.attrs.isRecharge,
                ecprdcode=modify.tariff.ECPrdCode;
            if(isRecharge.toLowerCase()=="true"){
                //如果充值按钮打开，则弹出充值页面
                song.confirm("您的账号余额不足，请先充值再进行变更操作！是否立即充值？",function(result){
                    if(result){
                        var rechargeUrl=modify.attrs.rechargeUrl+"?ecprdcode={0}&cost={1}".format(
                            ecprdcode,content
                        );
                        window.open(rechargeUrl);
//                        var saveUrl=feeModify.url("SaveECOnlineRecharge"),
//                            param={
//                                ecPrdCode:ecprdcode,
//                                price:content,
//                                productCode:modify.tariff.CrmProductCode
//                            };
//                        modify.disabledButton(true);
//                        //保存充值记录
//                        song.ajax(url,param,function(e){
//                            if(e.Success){
//                                window.open(rechargeUrl);
//                            }else{
//                                modify.alert("系统网络繁忙，请稍后重试!");
//                            }
//                        },function(){
//                            modify.disabledButton(false);
//                        });
                    }
                });
            }else{
                //充值按钮关闭，则提示用户充值
                modify.alert("您的账号余额不足，请先充值再进行变更操作！");
            }
        },
        saveOrderApply:function(){
            //提交订单
            modify.disabledButton(true);
            var param={applyCode:modify.tariff.ApplyCode},
                url=feeModify.url("SaveOrderApply",param);
            song.ajax(url,null,function(data){
                if (data.IsSuccess == true) {
                    //代表接口调用失败
                    if (data.Result == 0) {
                        modify.alert("系统网络繁忙，请稍后重试！");
                    } else {
                        modify.jump();
                        window.location.href =feeModify.url("FinishFee",{
                            applyCode:param.applyCode,
                            isAudit:modify.attrs.isAudit
                        });
                    }
                } else {
                    modify.alert(data.message);
                }
            },function(){
                modify.disabledButton(false);
            },true);
         },
         backTariff:function(){
            //返回上一步
            modify.jump();
            var url=feeModify.url("SelectFee",{
                ApplyCode:modify.tariff.ApplyCode,
                listfrom:modify.attrs.fromList,
                ecprdcode:""
            });
            window.location.replace(url);
         }
    });
})(window.song,window.jQuery,window.modify);