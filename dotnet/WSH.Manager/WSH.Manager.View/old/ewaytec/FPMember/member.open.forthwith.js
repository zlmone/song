/*
author:                 王松华
email:                  shwang@163.com
namespace:              Member.Open.Forthwith
content:                成员开通-实时开通
beforeLoad:             jQuery,song
dateUpdated:            2014-11-26
*/
; (function (song, j) {
    j.extend(memberOpen, {
        openMax: 20,
        url: function (action, params) {
            var controller = "MemberOpen";
            return song.url(controller, action, params).getUrl();
        },
        addSelectedMemberList: function (memberlist) {
            //将成员添加到待开通成员列表中
            //memberlist:[{id:"",mobile:"",username:"",email:"",department:""}]
            if (memberlist) {
                for (var i = 0; i < memberlist.length; i++) {
                    var m = memberlist[i];
                    var template = ["<tr data-memberid='",m.id,"' id='selectedMember-", m.id, "'>",
                        "<td><input type='checkbox' checked='true'/></td>",
                        "<td>", m.mobile, "</td>",
                        "<td>", m.username, "</td>",
                        "<td>", m.email, "</td>",
                        "<td>", m.department, "</td>",
                        "<td><a href='javascript:memberOpen.removeSelectedMember(" + m.id + ")'>删除</a></td>",
                    "</tr>"];
                    j("#openMemberList > tbody").append(template.join(''));
                }
            }
        },
        removeSelectedMember: function (id) {
            //删除待开通的成员
            var memberRow = j("#selectedMember-" + id);
            if (memberRow.length > 0) {
                memberRow.remove();
            }
        },
        selectMember: function (ecInfoID) {
            //选择成员
            memberOpen.endSelectMember();
            $("#memberDiv").hide();
            var url = song.url("FPMemberInfo", "FPMemberInfoSelectQuery", { ecInfoID: ecInfoID }).getUrl();
            $("#selectMembersDiv").load(url);
            //var dialog = memberOpen.getDialog({ id: "dialogSelectMember", url: url, onClose: function (returnValue) {
            //    //将选择的成员添加到待开通列表里面
            //    memberOpen.addSelectedMemberList(returnValue);
            //} 
            //});
            //dialog.option({ title: "选择成员", width: 850, height: 595 });
            //dialog.open(url);
            $(".btnPre").attr("disabled", "disabled");
            $(".btnSave").attr("disabled", "disabled");
            $("#selectMembersDiv").show();
          
        },
        addMember: function (ecID) {
            //新增成员
            memberOpen.endSelectMember();
            $("#memberDiv").hide();
            song.loading.show();
            var url = song.url("FPMemberInfo", "FPMemberInfoEdit", { ECInfoID: ecID, OperateType: 1 }).getUrl();
            $("#addMembersDiv").load(url,function(){
                song.loading.hide();
                $(this).find("div.content_01").width(800).css("padding-left","0px").css("padding-right","0px").css("padding-bottom","0px");
            });
            //var dialog = memberOpen.getDialog({ id: "dialogAddMember", onClose: function (returnValue) {
            //    //将选择的成员添加到待开通列表里面
            //    memberOpen.addSelectedMemberList(returnValue);
            //dialog.option({ title: "新增成员", width: 420, height: 300 });
            // dialog.open(url); 
            //} 
            //});
            $(".btnPre").attr("disabled", "disabled");
            $(".btnSave").attr("disabled", "disabled");
            $("#addMembersDiv").show();
        },
        getSelectedMembers:function(){
            var members=[],
                rows=j("#openMemberList tbody tr");
            rows.each(function(i){
                var row=rows.eq(i),
                    cols=row.find("td");
                if(cols.eq(0).find("input:checkbox").is(":checked")){
                    var id=row.attr("data-memberid"),
                        mobile=cols.eq(1).text(),
                        username=cols.eq(2).text(),
                        email=cols.eq(3).text(),
                        department=cols.eq(4).text();
                    members.push({Id:id,Mobile:mobile,UserName:username,Email:email,Department:department});
                }
            });
            return members;
        },
        startSelectMember: function () {
            $(".btnPre").removeAttr("disabled");
            $(".btnSave").removeAttr("disabled");
        },
         endSelectMember:function ()
        {
            $(".btnPre").removeAttr("disabled");
            $(".btnSave").removeAttr("disabled");
            $("#selectMembersDiv").html("").hide();
            $("#addMembersDiv").html("").hide();
            $("#memberDiv").show();
            memberOpen.setParentIframeHeight();
        },
        parseAttrMember:function(){
            //解析属性值，和成员列表
            var data = memberOpen.parseAttrs();
            data.Members=memberOpen.getSelectedMembers();
            memberOpen.OpenData=data;
            return data;
        },
        prevSelectProduct: function () {
            //上一步，进入选择产品页面
            memberOpen.showPage("selectProductWrap");
        },
        nextCheckApply: function () {
            //下一步，进入到核对订单页面
            memberOpen.validAttrs();
            if (memberOpen.isValid) {
                var data=memberOpen.parseAttrMember();
                if(memberOpen.OpenData.Members.length<=0){
                    song.topAlert("请选择成员");
                }else if(memberOpen.OpenData.Members.length>memberOpen.openMax){
                    song.topAlert("每次最多选择{max}个成员".format({max:memberOpen.openMax}));
                }else{
                    memberOpen.bindDataLoad("CheckApply","checkApplyWrap");
                }
            }
        },
        bindDataLoad:function(action,wrapid){
            var dataJson=j.toJSON(memberOpen.OpenData),
                url=memberOpen.url(action);
            song.ajax(url,dataJson,function(result){
                if(result.trim()==""){
                    song.topAlert();
                }else{
                    var panel=j("#"+wrapid).html(result);
                    memberOpen.showPage(panel);
                }
            },function(){},true,"text");
        },
        prevMemberAttr: function () {
            //上一步进入到成员属性页面
            memberOpen.showPage("fillAttrMemberWrap");
        },
        nextFinsh: function () {
            //进入到完成页面
            memberOpen.bindDataLoad("Finish","finishWrap");
        }
    });
})(window.song, window.jQuery)
