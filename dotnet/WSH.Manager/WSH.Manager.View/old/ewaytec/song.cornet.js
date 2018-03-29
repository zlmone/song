/*
author:               	wang song hua
email:                 	shwang@ewaytec.cn
namespace:      		Song.Cornet
content:            	短号
beforeLoad:     		j,base
dateUpdated:  			2013-01-22
*/
; (function (song, j) {
    window.cornet={
        controller:"MemberOpen",
        url:function(action,params){
            return song.url(cornet.controller,action,params).getUrl();
        },
        getMobileBox:function(){
            return j("#txtMobiles");
        },
        getSumbit:function(){
            return j("#btnSubmit");
        },
        getMobiles:function(val){
            if(cornet.defaultValue==val){
                return [];
            }
            //获取换行和逗号分割的手机号码
            var mobiles=j.trim(val).split(/\n+/),
                ms=[];
            if(mobiles!=null && mobiles.length>0){
                for (var i = 0; i < mobiles.length; i++) {
                    var arr=mobiles[i].split(/,|，+/);
                    for (var n = 0; n < arr.length; n++) {
                        ms.push(arr[n].toString().trim());
                    }
                }
            }
            return ms;
        },
        wait:function(txt){
            txt=txt || "提交中...";
            var sub=cornet.getSumbit();
           // sub.attr("oldValue",sub.html()).html(txt).disabled(true);
            sub.hide().next("a").html(txt).show();
            j("#linkBack").hide().next("span").show();
        },
        unwait:function(){
            var sub=cornet.getSumbit();
            //sub.html(sub.attr("oldValue")).disabled(false);
            sub.show().next("a").hide();
            j("#linkBack").show().next("span").hide();
        },
        setError:function(err,el){
            var error=el || j("#error");
            (error.length>0) && error.hide().html(err).fadeIn();
            cornet.unwait();
        },
        clearError:function(el){
            el=el || j("#error");
            el.html('').hide();
            cornet.unwait();
        },
        validMobile:function(ms){
            //校验手机数量和格式输入是否正确
            cornet.wait("校验中...");
            
            var txt=cornet.getMobileBox();
            if(ms==null || ms.length<=0){
                ms=cornet.getMobiles(txt.val())
            }
            var len=ms.length;
            if(len<=0){
                cornet.setError("请至少输入一个手机号码");return false;
            }
            if(len>10){
                cornet.setError("最多输入10个手机号码，当前已经输入了{0}个".format(len));
                return false;
            }
            //做手机号码格式验证
            var errorMobile=[],
                adcmobile=[];
//            for (var i = 0; i < len; i++) {
//                if(!/^0{0,1}(13[0-9]|15[7-9]|153|156|18[7-9])[0-9]{8}$/.test(ms[i])){
//                    errorMobile.push(ms[i]);
//                }
////                if(!/^0{0,1}(13[4-9]|15[7-9]|15[0-2]|18[7-8])[0-9]{8}$/.test(ms[i])){
////                    adcmobile.push(ms[i]);
////                }
//            }
//            if(errorMobile.length>0){
//                cornet.setError("您输入的手机号码：{0}格式不正确".format(errorMobile.join(",")));
//                return false;
//            }
//            if(adcmobile.length>0){
//                cornet.setError("您输入的手机号码：{0}不是移动号码".format(adcmobile.join(",")));
//                return false;
//            }
            //重复手机号码验证
            if(Array.hasRepeat(ms)){
                cornet.setError("您输入的手机号码中有重复的号码");
                return false;
            }
            //验证是否是广州移动号码
            var url=cornet.url("CheckMobile"),
                mobiles=ms.join(',');
            song.jsonRequest(url,{mobiles:mobiles},function(data){
                if(data.result){
                    //location.href=cornet.url("SelectTariff",{mobiles:mobiles,eccode:cornet.eccode()});
                    cornet.mobiles(mobiles);
                    cornet.submit();
                }else{
                    cornet.setError(data.msg);
                }
            },function(){
                
            });
            return true;
        },
        checkAll:function(obj){
            var boxs=document.getElementsByName("mobilecheckbox");
            for (var i = 0; i < boxs.length; i++) {
                boxs[i].checked=obj.checked;
            }
        },
        checkCornet:function(){
            //逐个进行手机号是否可办理短号校验
            var mobiles=j("#tariffList").find("tbody tr"),
                url=cornet.url("CheckCornet"),
                eccode=cornet.eccode();
                
            mobiles.each(function(i){
                var mobile=mobiles.eq(i),
                    m=mobile.attr("mobile");
                song.jsonRequest(
                    url,
                    {mobile:m,eccode:eccode},
                    function(data){
                        cornet.createCornetRow(mobile,data);
                    },function(){
                        //如果还处在加载中，提交按钮不可用
                        if(i==mobiles.length-1){
                            cornet.unwait();
                        } 
                    }
                );
        });
        },
        createCornetRow:function(row,data){
            var usable=data.Status=="可办理";
            //动态生成行
            var temp=[
                '<td>',usable ? '<input type="checkbox" name="mobilecheckbox"/>' : '','</td>',
                '<td>',data.Mobile,'</td>',
                '<td><span>',data.Status,'</span></td>',
                '<td>',cornet.getMealHtml(data),'</td>',
                '<td>',cornet.getShortNumBox(data),'</td>',
                '<td class="borderNone"><span class="cRed">',data.Error || '&nbsp;','</span></td>'
            ];
            row.find("td").remove();
            var cells=temp.join('');
            row.html(cells);
            //更新可办理的数量
            usable && cornet.updateUsableCount();
        },
        updateUsableCount:function(){
            var dom=song.dom("usableCount"),
                val=parseInt(dom.innerHTML);
            dom.innerHTML=++val;
        },
        getShortNumBox:function(data){
            //判断短号是否可以办理
            if(data.Status=="可办理"){
                return '<input type="text" value="{0}" style="width:60px;" class="shortnumbox"/>'.format(data.ShortNum);
            }else{
                return data.ShortNum;
            }
        },
        getMealHtml:function(data){
            if(data.Status=="可办理"){
                var select=['<select>'];
                //如果是内网套餐
                if(!data.IsOuter){
                    select.push('<option>prod.ShortNum.0	省内0元短号网套餐</option>');
                    select.push('<option>prod.ShortNum.5	本地5元短号网套餐</option>');
                    select.push('<option>prod.ShortNum.10	省内10元短号网套餐</option>');
                    select.push('<option>prod.ShortNum.15	省内15元短号网套餐</option>');
                }else{
                    //如果是外网套餐
                    select.push('<option>prod.10000000000253	综合集群网网外成员5元套餐</option>');
                    select.push('<option>prod.10000000000254	综合集群网网外成员10元套餐</option>');
                    select.push('<option>prod.10000000000255	综合集群网网外成员15元套餐</option>');
                    select.push('<option>prod.10000000000256	综合集群网网外成员20元套餐</option>');
                }
                select.push("</select>");
                return select.join('');
            }else{
                return "<div style='width:320px'>"+data.Tariff+"</div>";
            }
        },
        getChecked:function(){
            //获取已选择的可办理的短号
            var checks=j("input[name='mobilecheckbox']:checked"),
                data=[];
            if(checks.length<=0){
                alert("请至少选择一个号码进行办理");
            }else{
                var eccode=cornet.eccode(),
                    errCount=0;
                for (var i = 0; i < checks.length; i++) {
                    var cell=checks.eq(i).parent(),
                        row=cell.parent(),
                        err=row.find("span.cRed"),
                        num=row.find("input.shortnumbox").val(),
                        tariff=row.find("select").find("option:selected").text().replace(' ','\t'),
                        mobile=cell.next("td").html();
                    //校验短号格式是否输入正确
                    if(!/^6[1-9]{1}\d{4}$/.test(num)){
                        cornet.setError("短号号码必须是61-69开头的6位整数",err);
                        errCount++;
                    }else{     
                        cornet.clearError(err);  
                        data.push({eccode:eccode,shortnum:num,mobile:mobile,error:err,tariff:tariff});
                    }
                }
            }
            if(errCount>0){
                return [];
            }
            return data;
        },
        validShortNum:function(){
            cornet.wait("校验中...");
            var data=cornet.getChecked();
            if(data.length<=0){
                cornet.unwait();
                return false;
            }
            var mobiles=[],nums=[],
                eccode=data[0].eccode,
                url=cornet.url("ValidShortNum"),
                els={};
            for (var i = 0; i < data.length; i++) {
                var n=data[i].shortnum,
                    m=data[i].mobile;
                mobiles.push(m);
                els[m]=data[i].error;
                //验证当前集合是否存在相同短号
                if(Array.has(nums,n)){
                    cornet.setError("短号号码已存在，请修改",els[m]);
                    return false;
                }
                nums.push(n);
            }
            //校验该集团是否存在相同的短号                 
            song.jsonRequest(url,{eccode:eccode,mobiles:mobiles.join(','),shortnums:nums.join(',')},function(d){
                if(!d.result){
                    //location.href=cornet.url("SubmitMember",{eccode:cornet.eccode()});
                    var list=[];
                    for (var n = 0; n < data.length; n++) {
                        var da=data[n];
                        list.push({Mobile:da.mobile,ShortNum:da.shortnum,Tariff:da.tariff});
                    }
                    var ls=j.toJSON(list).replace("\t",' ');
                    cornet.listString(ls);
                    cornet.submit();
                }else{
                    //如果校验失败，返回{手机号：错误信息}格式
                    for (var i in d.result) {
                        var key=d.result[i].Mobile;
                        cornet.setError(d.result[i].Error,els[key]);
                    }
                }
            },function(){
                 cornet.unwait();
            });
        },
        checkSubmit:function(){
            //提交033校验接口
            var rows=j("#submitTable").find("tbody tr");
            if(rows.length>0){
                var success=0,error=0,
                    url=cornet.url("CheckSubmit");
                for (var i = 0; i < rows.length; i++) {
                    var row=rows.eq(i),
                        mobile=row.find("td:first").html(),
                        id=row.attr("applyItemID");
                    (function(curr,count,row){
                        song.jsonRequest(url,{mobile:mobile,applyItemID:id},function(d){
                            var el=row.find("td:last");
                            if(d.Status.toString().toLowerCase()=="true"){
                                success++;
                                el.html("<span>受理中</span>");
                            }else{
                                error++;
                                cornet.setError(d.Error,el);
                                el.append("<span style='display:none'>"+d.Tariff+"</span>");
                            }
                            if(curr==count){
                                cornet.showSuccessPanel(success,error); 
                            }
                        });
                    })(i,rows.length-1,row)
                }                 
            }
        },
        showSuccessPanel:function(success,error){
            var panel=j("#successPanel").fadeIn();
            j("#successCount").html(success || 0);
            j("#errorCount").html(error || 0);
        },
        listString:function(listString){
            return listString ? j("#hideList").val(listString) : j("#hideList").val();
        },
        mobiles:function(mobiles){
            return mobiles ? j("#Mobiles").val(mobiles) : j("#Mobiles").val();
        },
        eccode:function(eccode){
            return eccode ? j("#EcCode").val(eccode) : j("#EcCode").val();
        },
        ecprdcode:function(ecprdcode){
            return ecprdcode ? j("#EcPrdCode").val(ecprdcode) : j("#EcPrdCode").val();
        },
        submit:function(){
            cornet.wait("提交中...");
            document.forms[0].submit();
        },
        back:function(step){
            //返回输入手机号码页面
            if(step==2){
                location.href=cornet.url("InputMobile",{ecprdcode:cornet.ecprdcode(),mobiles:cornet.mobiles()});
            }else{
                var param={type:"1",ecprdCode:cornet.ecprdcode()};
                location.href=song.url("MemberManager","MemberOrderManger",param).getUrl();
            }
        }
    }
    //加载事件
    j(function(){
        //设置水印的默认值
        var box=cornet.getMobileBox(),
            submit=cornet.getSumbit();
        if(box.length>0){
           // song.dom("hideInput").focus();
            cornet.defaultValue='可同时添加最多10个号码，号码之间请以逗号“，”或换行隔开;\n例子1：13422114637，13822114678\n例子2：\n13422114637\n13822114678';
            submit.click(function(e){
                cornet.validMobile()
            });
            //返回输入页面时保存状态
            var mbs=cornet.mobiles(null);
            mbs && box.val(mbs);
        }
        var usable=j("#usableCount");
        if(usable.length>0){
            cornet.wait("加载中...");
            cornet.checkCornet();
            submit.click(function(){
                cornet.validShortNum();
            });
        }
        var success=j("#successPanel");
        if(success.length>0){
            cornet.checkSubmit();
        }
        //通用的水印效果渲染

            j("#txtMobiles").watermark(cornet.defaultValue);
        j("#linkBack").click(function(e){
            cornet.back(j(this).attr("step"));
        });
    });
})(window.song, window.jQuery)