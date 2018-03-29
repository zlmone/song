/*
author:               wang song hua
email:                 songhuaxiaobao@163.com
url:                      http://www.netstudio80.com
namespace:      Song.Validate
content:            数据验证
beforeLoad:     j,base
dateUpdated:  2012-03-14
*/
; (function (song, j) {
    song.validate = function (options) { 
        j.extend(this,{
            formName:0,
            isValid:true
        },options);
        this.form=j(document.forms[this.formName]);
    }
    song.validate.prototype={
        valid:function(){
            var items=this.form.find("input,select,textarea"),me=this;
            items.each(function(i){
                var item=items.eq(i);
                me.validItem(item);
            });
            return this.isValid;
        },
        validItem:function(item){
            var required=item.attr("data-required"),me=this,val=item.val().trim();
            if(required=="true"){
                if(val==""){
                    me.showError(item,"required");
                }else{
                    me.removeError(item);
                }
            }
            var dataType=item.attr("data-dataType");
            if(dataType){
                if(!song.validate.check(dataType,val)){
                    me.showError(item,dataType);
                }else{
                    me.removeError(item);
                }
            }
        },
        removeError:function(item){
            item.removeClass("input-error");
        },
        showError:function(item,type){
            item.addClass("input-error");
            this.isValid=false;
            var me = this, tip = song.tip.valid(item, type,function(){
                me.validItem(item);
            });
        }
    };
    j.extend(song.validate,{
        regex: {
            email: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
            en: /^[A-Za-z]+$/,
            cn: /^[\u0391-\uFFE5]+$/,
            url: /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
            ip: /^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$/,
            zip: /^[1-9]\d{5}$/, //邮政编码
            alpha: /^[0-9a-zA-Z\_]+$/, //数字字母下划线
            tel: /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/,
            mobile: /^1[3|4|5|8][0-9]\d{4,8}$/, //手机
            int: /^(-|\+)?\d+$/,
            float: /^(-?\d+)(\.\d+)?$/,
            idCard: /^\d{15}(\d{2}[A-Za-z0-9])?$/,
            carNo: /^[\u4E00-\u9FA5][\da-zA-Z]{6}$/, // 车牌号码（例：粤J12350）
            qq: /^[1-9]\d{4,10}$/,
            msn: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
        },
        msg:{
            required:"此项必填",
            email:"邮箱格式不正确",
            en:"请输入英文",
            cn:"请输入中文",
            url:"Url地址格式不正确",
            ip:"IP地址不正确",
            zip:"邮政编码格式不正确",
            alpha:"请输入数字字母或下划线",
            tel:"电话格式不正确",
            mobile:"手机格式不正确",
            int:"请输入整数",
            float:"请输入数字",
            idCard:"身份证格式不正确",
            carNo:"车牌号格式不正确",
            qq:"QQ号码格式不正确",
            msn:"MSN账号格式不正确"
        },
        checkEmpty: function (obj) {
            if (!obj) { return true; } var msg = "";
            for (var i in obj) { 
                if (dom(i).value.trim() == "") { 
                    msg += "--" + obj[i] + "\n"; 
                } 
            }
            if (msg == "") { 
                return true; 
            } else { 
                alert(msg); return false; 
            }
        },
        check: function (type, value) {
            if (this.regex.hasOwnProperty(type)) { 
                return this.regex[type].test(value); 
            }
            return type.test(value);
        },
        dateRange: function (idStart, idEnd, msg) {
            var dsValue = song.dom(idStart).value;
            var de = song.dom(idEnd), deValue = de.value;
            if (Date.parse(dsValue.replace(/\-/g, "/")) > Date.parse(deValue.replace(/\-/g, "/"))) {
                alert(msg || "开始日期不能大于结束日期！");
                de.focus();
            }
        }
    });
})(window.song, window.jQuery);