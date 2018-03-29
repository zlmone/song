Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "H+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,(this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
 
Date.jsonFormat=function(jsonDate,format){
    return new Date(eval(jsonDate.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).format(format);
}

Date.range = function (idStart, idEnd, msg) {
    var dsValue = document.getElementById(idStart).value;
    var de = document.getElementById(idEnd);
    var deValue = de.value;
    if (Date.parse(dsValue.replace(/\-/g, "/")) > Date.parse(deValue.replace(/\-/g, "/"))) {
        alert(msg || "开始日期不能大于结束日期！");
        de.focus();
    }
}
String.prototype.toDate=function(){
    return new Date(Date.parse(this.replace(/-/g, "/")));
}
 