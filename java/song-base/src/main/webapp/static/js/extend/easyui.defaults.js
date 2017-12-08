/**
 * Created by song on 2017/9/4.
 */
//默认关闭easyui的自动解析，在ie下太耗性能
$.parser.auto=false;
//======================================dialog==============================================
$.extend($.fn.dialog.defaults, {
    modal: true,
    closed: true
});
//======================================form==============================================
$.extend($.fn.form.defaults,{
    iframe:false,
    ajax:true
});
//======================================grid==============================================
$.extend($.fn.datagrid.defaults, {
    fit: true,
    fitColumns: true,
    pagination: true,
    striped: true,
    border: 0,
    pageList: [10, 15, 20, 25, 30, 40, 50],
    pageSize: 15,
    rownumbers: true
});
//======================================tabs==============================================
$.extend($.fn.tabs.defaults, {
    fit: true
});
$.extend($.fn.tree.defaults,{
    lines:true
})
//======================================panel==============================================
//iframe回收内存
$.fn.panel.defaults.onBeforeDestroy = function() {
    var frames = $(this).find("iframe");
    song.iframe.destroy(frames);
};