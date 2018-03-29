code.controller = {
    getMvcWithLinq: function () {
        var b = new code.builder(), savefield = new code.builder();
        var pn = code.getProjectName();
        var un = code.getUpperTableName();
        var ln = code.getLowerTableName();
        var pk = "ID";
        code.eachStore(function (r, i, last) {
            if (r.dataKey == "true") { pk = r.field; }
            //            var f = 'form["' + r.field + '"];';
            //            switch (r.dataType) {
            //                case "int": f = 'Convert.ToInt32(form["' + r.field + '"]);'; break;
            //                case "bool": f = 'form["' + r.field + '"].ToLower()=="false" ? false : true;'; break;
            //                case "decimal": f = 'Convert.ToDecimal(form["' + r.field + '"]);'; break;
            //                case "DateTime": f = 'Convert.ToDateTime(form["' + r.field + '"]);'; break;
            //            }
            if (r.hide == "false") {
                savefield.addFmt(4, '{0}.{1} =form.{2};', ln, r.field, r.field);
            }
        });
        b.add(0, 'using System;').add(0, 'using System.Collections.Generic;').add(0, 'using System.Linq;');
        b.add(0, 'using System.Web.Mvc;').addFmt(0, 'using {0}.Models;', pn);
        b.add(0, 'using WshMvcControls;' + code.br);
        b.addFmt(0, 'namespace {0}.Controllers', pn).add(0, '{');
        b.addFmt(1, 'public class {0}Controller : Controller', un).add(1, '{');
        b.addFmt(2, 'private {0}DataContext mgr = new {1}DataContext();', un, un);
        //查询分页
        b.add(2, 'public ActionResult Index(FormCollection form)').add(2, '{');
        b.add(3, 'int pageIndex = MvcCommon.AsInt(form["pageindex"],1);');
        b.add(3, 'int pageSize = MvcCommon.AsInt(form["pagesize"],20);');
        b.addFmt(3, 'int totalRecord = mgr.{0}.Count();', un);
        b.addFmt(3, 'List<{0}> list=mgr.{1}.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();', un, un);
        b.addFmt(3, 'return View("{0}List",new PageList<{1}>(list,pageIndex,pageSize,totalRecord));', un, un);
        b.add(2, '}');
        //明细
        b.add(2, 'public ActionResult Details(EditMode mode,int? datakey) {');
        b.add(3, 'ViewData["mode"] = mode;');
        b.add(3, 'if(mode== EditMode.Add){');
        b.addFmt(4, 'return View("{0}Edit");', un).add(3, '}');
        b.addFmt(3, '{0} {1} = mgr.{2}.Where(o => o.{3} == dataKey).First();', un, ln, un, pk);
        b.addFmt(3, 'return View("{0}Edit",{1});', un, ln);
        b.add(2, '}');
        //        //添加
        //        b.add(2, 'public ActionResult Add() {');
        //        b.addFmt(3, 'return View("{0}Edit");', un);
        //        b.add(2, '}');
        //删除
        b.add(2, 'public ActionResult Del(FormCollection form) {');
        b.add(3, 'string[] ids=form["del_ids"].Split(",".ToCharArray());');
        b.addFmt(3, 'List<{0}> list = mgr.{1}.Where(o => ids.Contains(o.{2}.ToString())).ToList();', un, un, pk);
        b.addFmt(3, 'mgr.{0}.DeleteAllOnSubmit(list);', un);
        b.add(3, 'mgr.SubmitChanges();');
        b.add(3, 'return Index(form);');
        b.add(2, '}');
        //ajax删除
        b.add(2, 'public ContentResult AjaxDelete(string ids){');
        b.add(3, 'string msg = "", result = "true";');
        b.add(3, 'try{').addFmt(4, 'string delSql = string.Format("delete {0} where {1} in({0});",ids);', code.tableName, pk);
        b.add(4, 'mgr.ExecuteCommand(delSql);');
        b.add(3, '}catch (Exception ex){');
        b.add(4, 'msg = MvcCommon.ReplaceBR(ex.Message);').add(4, 'result = "false";').add(3, '}');
        b.add(3, 'string data = new JsonList().Add("msg", msg).Add("result", result).ToJsonString();');
        b.add(3, 'return Content(data);');
        b.add(2, '}');
        //保存
        b.add(2, 'public ActionResult Save(string editmode,Test form) {');
        //b.add(3, 'string mode = form["editmode"];');
        b.add(3, 'ViewData["mode"] = editmode;');
        // b.addFmt(3, '{0} {1} = new {2}();', un, ln, un);
        b.add(3, 'if (editmode == EditMode.Add.ToString()){');
        b.addFmt(4, 'mgr.{0}.InsertOnSubmit(form);', un);
        b.add(4, 'ViewData["returnaction"] = ReturnAction.CloseDialog;');
        b.add(3, '}else{');
        b.addFmt(4, '{0} {1} = mgr.{2}.Where(o => o.{3} == form.{4}).FirstOrDefault();', un, ln, un, pk, pk);
        b.addNon(savefield.toString());
        b.add(4,'ViewData["returnaction"] = ReturnAction.CloseDialog;');
        b.add(3, '}');
        b.add(3, 'mgr.SubmitChanges();');
        b.addFmt(3, 'return View("{0}Edit");', un);
        b.add(2, '}');
        b.add(1, "}").add(0, "}");
        return { content: b.toString(), fileName: un + "Controller" }
    }
}