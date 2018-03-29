/*
author:               	王松华
email:                 	shwang@ewaytec.cn
namespace:      		Apply|Modify
content:            	折扣销售产品开通和变更，资费相关的通用方法
beforeLoad:     		j,base,apply|modify
createDate:             2014-05-14
updatedDate:  			2014-05-14
*/
; (function (song,j) { 
    var com=window.apply || window.modify;
    /*************************************资费相关的通用方法******************************************/
    j.extend(com,{
        getCrmProductCodes:function(prdList){
            //获取选中的产品编码
            var prdList =$(".product:checked");
            var chooseCrmProductCodes = com.tariff.CrmProductCode + "^";
            $.each(prdList, function (i, box) {
                var _box = $(box);
                var sPrdCode = _box.val();
                chooseCrmProductCodes += sPrdCode + "^";
            });
            return chooseCrmProductCodes.delEnd("^");
        },
        hasProductCodes:function(products,codes){
            //判断选中的产品编码，是否存在于一个产品编码集合中
            for (var i = 0; i < products.length; i++) {
                for (var k = 0; k < codes.length; k++) {
                    if(products[i].toLowerCase().trim()==codes[k].toLowerCase().trim()){
                        return true;
                    }
                }
            }
            return false;
        },
        bindViewBusiness:function(){
            //点击资费详情，查看业务信息
            $(".servicequery").click(function () {
                var productCode = $(this).attr("productcode");
                com.viewBusiness(productCode);
            });
        },
        viewBusiness:function(code){
            //查询资费的详情，包括服务和参数信息
            var dialog = com.getDialog({
                id:"serviceDialog"
            });
            dialog.option({title:"资费详情",width:600,height:280});
            dialog.open(song.url("ProductOpen","ProductServiceQuery",{subproductcode:code}).getUrl());
        },
        bindIsCheck:function(){
            $.each($("[ischecked='1']"), function (i, p) {
                $(p).attr("checked", "checked");
            });
        },
        getPropertyValues:function(){
            //用户切换资费时，应该保持之前填写的属性值 
            //var values=[{name:"code",type:"text",checked:false,isHide:false,value:"n"}];//返回值例子
            var els=j("#productProperty").find("input,textarea,select"),
                values=[];
            els.each(function(i){
                var el=j(this),
                    tagName=this.tagName.toLowerCase(),
                    type=tagName=="input" ? this.type : tagName,
                    isHide=el.attr("class")=="hiddenproperty",
                    name=isHide ? el.attr("proname") : el.attr("name"),
                    checked=/radio|checkbox/.test(type) ? this.checked : false,
                    value=el.val();
                values.push({name:name,type:type,checked:checked,isHide:isHide,value:value});
            });
            return values;
        },
        setPropertyValues:function(values){
            var wrap=j("#productProperty");
            //首先要重置单选框，否则会因为默认值导致选不中
          // alert(wrap.find("input:radio").length);
            wrap.find("input:radio").removeAttr("checked");
            //alert(wrap.find("input:radio").length);
            for (var i = 0; i < values.length; i++) {
                var value=values[i];
                if(/radio/.test(value.type)){
                    value.checked && wrap.find("input[name='"+value.name+"'][value='"+value.value+"']").checked(value.checked);
                }else if(/checkbox/.test(value.type)){
                    wrap.find("input[name='"+value.name+"'][value='"+value.value+"']").checked(value.checked);
                }else if(/textarea|select/.test(value.type)){
                    wrap.find(value.type+"[name='"+value.name+"']").val(value.value);
                }else if(value.isHide){
                    wrap.find("input[proname='"+name+"']").val(value.value);
                }else{
                    wrap.find("input[name='"+value.name+"']").val(value.value);
                }
            }
        }
    });
})(window.song,window.jQuery);