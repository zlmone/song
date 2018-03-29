/*
author:                 王松华
email:                  shwang@163.com
namespace:              Member.Open.File
content:                成员开通-文件导入
beforeLoad:             jQuery,song
dateUpdated:            2014-11-26
*/
; (function (song, j) {
    j.extend(memberOpen, {
        url: function(action, params) {
            var controller = "MemberBatchOpen";
            return song.url(controller, action, params).getUrl();
        },  
        //导出错误信息
        ErrorExport: function() {
            var url = memberOpen.url("ErrorExport");
            window.location.href = url;
        },
        //导出成功文件
        SuccessExport: function() {
            var url = memberOpen.url("SuccessExport");
            window.location.href = url;
        },
        //加载核对页面
        LoadCheckApply: function() {
            memberOpen.validAttrs();
            if (memberOpen.isValid) {
                var Opendata = memberOpen.parseAttrs();
                Opendata.OpenTag = $("input[name='opentag']:checked").val();
                if (!Opendata.OpenTag) {
                    song.topAlert("请选择开通方式！");
                    return;
                }
                Opendata.PackageCode = memberOpen.ProductCode;
                Opendata.PackageType = memberOpen.PackageType;
                var MemberCount = parseInt($("#hiddenMemberCount").val());
                var MemberErrorCount = parseInt($("#hiddenMemberErrorCount").val());
                var datajson = j.toJSON(Opendata);
                if (isNaN(MemberCount) | MemberCount <= 0) {
                    song.topAlert("请导入有效成员");
                    return;
                } else {
                    if (MemberErrorCount > 0) {
                        window.top.song.confirm("是否忽略错误的成员!", function() {
                            song.ajax(memberOpen.url("CheckApply"), datajson, function(data) {
                                $("#checkApply").html(data);
                                memberOpen.showPage("checkApply");
                            }, function() {
                            }, true, "text");
                        });
                    } else {
                        song.ajax(memberOpen.url("CheckApply"), datajson, function(data) {
                            $("#checkApply").html(data);
                            memberOpen.showPage("checkApply");
                        }, function() {
                        }, true, "text");
                    }
                }
            } 
        },
        //提交订单
        Submit: function() {
             memberOpen.validAttrs();
            if (memberOpen.isValid) { 
                var Opendata = memberOpen.parseAttrs();
                Opendata.OpenTag = $("input[name='opentag']:checked").val(); 
                Opendata.PackageCode = memberOpen.ProductCode;
                Opendata.PackageType = memberOpen.PackageType;
                var MemberCount = parseInt($("#hiddenMemberCount").val());
                if (isNaN(MemberCount) | MemberCount <= 0) {
                    song.topAlert("请导入成员");
                } else {
                    song.ajax(memberOpen.url("SaveOrderApply"), j.toJSON(Opendata), function(data) {
                        if (data) {
                            if (data.result) {
                                memberOpen.loadPage('finish', memberOpen.url("Finish"));
                            } else {
                                song.topAlert(data.message);
                            }
                        }
                    }, function(){},true,'json');
                }
            }
        }
    });
})(window.song, window.jQuery)