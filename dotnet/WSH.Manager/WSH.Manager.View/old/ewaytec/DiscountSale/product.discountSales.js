/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Apply|Modify
content:            	折扣销售通用的方法
beforeLoad:     		j,base,apply|modify
createDate:             2014-04-15
updatedDate:  			2014-05-12
*/
; (function (song,j) { 
    var com=window.apply || window.modify;
    /*************************************通用的方法和属性******************************************/
    j.extend(com,{
        attrs:{},
        regex:{},
        tariff:{},
        disabledButton:function(isEnabled){
            isEnabled 
                ? song.setDisabled("input.btn,input.btn_3f","input.btn_4f") 
                : song.removeDisabled("input.btn,input.btn_3f","input.btn_4f");
        },
        removeBlank:function(str){
            return str.replace(/^\s+|\s+$/g, "");
        },
        jump:function(msg){
            msg && song.loading.setMsg(msg);
            song.loading.show();
            j("input.btn,input.btn_3f,input.btn_4f").disabled(true);
        },
        alert:function(msg){
            window.top.song.alert(msg || "系统网络繁忙，请稍后重试！");
        },
        getDialog:function(options){
            //获取dialog对象
            options=options || {};
            if(options.id==null){
                options.id="discountSalesDialog";
            }
            return new window.top.song.dialog(options);
        },
        closeDialog:function(id,params){
            //关闭父页面的dialog
            song.dialog.closeParent(id || "discountSalesDialog",params);
        }
    });
})(window.song,window.jQuery);