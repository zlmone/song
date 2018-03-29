/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Modify
content:            	折扣销售产品变更基类
beforeLoad:     		j,base
createDate:             2014-02-25
updatedDate:  			2014-05-12
*/
; (function (song,j) { 
    /*************************************产品变更公共方法******************************************/
    window.modify=window.modify || {
        url:function(controller,action,params){
            return song.url(controller,action,params).getUrl();
        },
        fromList:function(){
            //变更页面，返回上一步跳转到对应的列表页面
            modify.jump();
            var url=modify.attrs.fromList== "1" 
                ? modify.url("DiscountOrderApplyWorkItem","DiscountOrderApplyQuery") 
                : modify.url("ProductModify","ProductModifyQuery");
            location.href = url;
        },
        fromApplyList:function(){
            //返回申请单查询页面
            modify.jump();
            var url=modify.url("DiscountOrderApplyWorkItem","DiscountOrderApplyQuery");
            location.href = url;
        },
        getRealEc:function(){
            //获取真实集团资料信息
            return {RealECCode:j("#RealECCode").val(),RealECName:j("#RealECName").val()};
        }
    };
})(window.song,window.jQuery);