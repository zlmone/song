code.aspnet = {
    getGridView: function () {
        var b = new code.builder();
        b.add(0, '<asp:GridView ID="grid" runat="server" CellPadding="0" CellSpacing="0" AutoGenerateColumns="false">');
        b.add(1, '<Columns>');
        b.add(2, '<asp:TemplateField HeaderStyle-Width="35">');
        b.add(3, '<HeaderTemplate>');
        b.add(4, '<input type="checkbox" id="checkAll"/>');
        b.add(3, '</HeaderTemplate>');
        b.add(3, '<ItemTemplate>');
        b.add(4, '<input type="checkbox" name="checkAll" MultiCheck="true" runat="server" id="MultiCheck"/>');
        b.add(3, '</ItemTemplate>');
        b.add(2, '</asp:TemplateField>');
        code.eachStore(function (record, i) {
            if (record.hide == "false") {
                var type = record.editType == "checkbox" ? 'CheckBox' : 'Bound';
                var sort = record.sort == "true" ? ' SortExpression="' + record.field + '"' : '';
                var fmt = record.format == "" ? '' : ' DataFormatString="' + record.format + '"';
                b.add(2, '<asp:' + type + 'Field DataField="' + record.field + '" HeaderText="' + record.display + '"' + sort + '' + fmt + ' />');
            }
        });
        b.add(1, '</Columns>');
        b.add(0, '</asp:GridView>' + code.br + code.br);
        b.addNon(this.getGridViewJs());
        return b.toString();
    },
    getGridViewJs: function () {
        var b = new code.builder();
        b.add(0, '<!--设置GridView的样式和客户端事件-->');
        b.add(0, '<script type="text/javascript">');
        b.add(1, 'var grid=new  j.grid("<%=grid.ClientID%>",{');
        b.add(2, 'click:function(id,obj){},');
        b.add(2, 'dblclick:function(id,obj){}');
        b.add(1, '});').add(0, code.scriptEnd);
        return b.toString();
    },
    getMvcGrid: function () {
        var b = new code.builder(), bb = new code.builder(), dataKey;
        var ln = code.getLowerTableName(), un = code.getUpperTableName();
        b.addFmt(0, code.pageTitle.mvc + code.br, "List", "PageList<" + code.getProjectName() + ".Models." + un + ">");
        b.addFmt(0, code.titleContent, un);
        b.add(0, code.scriptContentBegin).add(0, code.contentEnd);
        b.add(0, code.mainContentBegin);
        b.addFmt(1, '<form action="/{0}/Index" method="post">', un);
        b.add(2, '<%: Html.Toolbar(new List<ToolbarItem> { ');
        //查询条件
        code.eachStore(function (r, i, last) {
            if (r.query == "true") {
                var control = (code.control[r.editType]["html"](r.field, "true")).replaceAll('"', "'").replace("class='text'", "class='textbox'");
                b.addFmt(3, 'new ToolbarItem{Content="{0}：{1}"},', r.display, control);
            }
        });
        var mgr = "grid" || ln;
        b.addFmt(3, 'new ToolbarItem{Icon= Icons.Query,Text="查询",Click="{0}.query();"},', mgr);
        b.addFmt(3, 'new ToolbarItem{Icon= Icons.AddRow,Text="添加",Click="{0}.add();"},', mgr);
        b.addFmt(3, 'new ToolbarItem{Icon= Icons.Edit,Text="编辑",Click="{0}.edit();"},', mgr);
        b.addFmt(3, 'new ToolbarItem{Icon= Icons.DeleteRow,Text="删除",Click="{0}.del();"} ', mgr);
        b.add(2, '})%>');
        b.add(2, '<table id="grid">').add(3, "<tr>");
        b.add(4, '<th style="width:35px;"><input type="checkbox" id="checkAll" /></th>');
        bb.add(4, '<td><input type="checkbox" name="checkAll" /></td>');
        code.eachStore(function (r, i, last) {
            var property = r.field;
            if (r.dataKey == "true") { dataKey = property; }
            if (r.hide != "true") {
                var sort = r.sort == "true" ? ' sortField="' + property + '"' : '';
                b.addFmt(4, "<th{0}>{1}</th>", sort, r.display);
                bb.addFmt(4, "<td><%: item.{0} %></td>", property);
            }
        });
        b.add(3, "</tr>");
        b.add(2, "<% foreach (var item in Model) { %>");
        var id = dataKey == null ? "" : "<%: item." + dataKey + " %>";
        b.addFmt(3, '<tr dataKey="{0}">', id).addNon(bb.toString());
        b.add(3, "</tr>").add(2, "<% } %>").add(2, "</table>");
        //分页
        b.addFmt(2, '<%: Html.Paging(Model.PageIndex, Model.PageSize,Model.TotalRecord,"/{0}/Index")%>', un);
        b.add(1, '</form>');
        b.add(1, code.scriptBegin);
        b.add(2, 'var grid = new j.grid("grid", {');
        b.add(3, 'imgPath:"../img/grid",');
        b.add(3, 'sortValue:"<%=Model.SortName %>",');
        b.add(3, 'dirValue:"<%=Model.SortDir %>",');
        b.addFmt(3, 'editController: "{0}",', un);
        b.addFmt(3, 'dialogOptions:{width:500,title:"{0}"},', un);
        b.add(3, 'dblclick: function (id, obj) {');
        b.add(4, 'grid.showDialog(id);');
        b.add(3, '}').add(2, '});');
        b.add(2, 'grid.checkAll();');
        /*
        b.addFmt(1, "var {0}={", ln);
        b.add(2, "showDialog:function(id,mode){");
        b.addFmt(3, 'var page = "/{0}/";', un).add(3, 'if (mode == "add") {').add(4, 'page += "Add";').add(3, '} else {');
        b.add(4, 'page += "Details?id=" + id;').add(3, '}');
        b.addFmt(3, 'var dg = new $.dialog({ id: "{0}Edit", page: page, width: 600 });', ln).add(3, 'dg.ShowDialog();');
        b.add(2, "},");
        b.add(2, 'edit:function(){').add(3, 'var id = grid.getId();').add(3, ' if (id == "") {');
        b.add(4, 'j.tip.msg("请选择一条记录进行操作");').add(3, '} else {').add(4, 'this.showDialog(id);').add(3, '}');
        b.add(2, '},');
        b.add(2, 'add:function(){').add(3, 'this.showDialog(null, "add");');
        b.add(2, '},');
        b.add(2, 'del:function(){').add(3, 'var ids = grid.getIds().toString();').add(3, 'if (ids == "") {');
        b.add(4, 'j.tip.msg("请至少勾选一条记录进行操作！");').add(3, '} else { ').add(4, 'if(confirm("确定要删除选中的记录吗？")){}');
        b.add(3, '}').add(2, '},');
        b.add(2, 'query:function(){}');
        b.add(1, "}");
        */
        b.add(1, code.scriptEnd).add(0, code.contentEnd);
        return b.toString();
    },
    getForm: function () {
        var b = new code.builder();
        var formLine = Ext.getCmp("formLine").getValue();
        var pageMode = Ext.getCmp("pageMode").getValue();
        var controlType = Ext.getCmp("controlType").getValue();
        var ln = code.getLowerTableName();
        var un = code.getUpperTableName();
        var pk = "ID";
        //js,css区域
        var addScriptStyle = function () {
            b.add(1, code.scriptBegin);
            //数据验证......
            b.add(2, '$(function () {');
            if (pageMode == "mvc") {
                b.add(3,"returnAction.execute('<%=ViewData[\"returnaction\"] %>');");
                b.add(3, '$(document.forms[0]).viewForm("editmode");');
            }
            b.add(3, '$("#save").validator({').add(4, 'custom: function () {').add(5, ' return true;').add(4, '}').add(3, '});');
            b.add(2, '});');
            b.add(1, code.scriptEnd);
            //样式调整
            b.add(1, code.styleBegin);
            b.add(2, ".form-table td.odd{width:15%;}").addFmt(2, ".form-table td.even{width:{0}%;}", (formLine == 1 ? "85" : "35"));
            b.add(1, code.styleEnd);
        }
        //页面声明
        switch (pageMode) {
            case "mvc":
                {
                    b.addFmt(0, code.pageTitle.mvc + code.br, "Edit", (code.getProjectName() + ".Models." + un));
                    //mvc模式下输出页面title
                    b.add(0, String.format(code.titleContent, un));
                }; break;
            case "webform": { b.addFmt(0, code.pageTitle.webform + code.br, un, "Edit", un + "Edit", un + "Edit"); }; break;
            case "static":
                {
                    b.add(0, code.pageTitle.static)
                    //静态页面模式下输出head和title标记
                    b.add(0, code.htmlBegin).add(0, '<head>').addFmt(1, '<title>{0}</title>', un);
                    addScriptStyle();
                    b.add(0, '</head>').add(0, '<body>');
                    b.add(1, '<div class="form-wrap">');
                }; break;
        }
        if (pageMode != "static") {
            b.add(0, code.scriptContentBegin);
            addScriptStyle();
            b.add(0, code.contentEnd);
            //页面主体
            b.add(0, code.mainContentBegin);
        }
        if (pageMode == "mvc") {
            b.addFmt(1, '<form action="/{0}/Save" method="post">', un);
            b.add(1, '<%: Html.Toolbar(new List<ToolbarItem> { ');
            //b.add(2, 'new ToolbarItem{Icon=Icons.SaveAdd,Text="保存&添加",Click=""},');
            b.add(2, 'new ToolbarItem{Id="save",Icon=Icons.Save,Text="保存",Click="j.formSubmit();"}');
            b.add(1, '},false)%>');
        }
        b.add(1, '<table class="form-table">');
        var itemSum = 0;
        var j; //保存实际显示的字段数量
        var store = code.getStore();
        for (var i = 0; i < store.length; i++) {
            var row = store[i];
            var id = row.get("Field");
            if (row.get("DataKey") == "true") {
                pk = id;
            }
            if (row.get("Hide") == "true") {
                continue;
            }
            j++;
            itemSum++;
            var display = row.get("Display");
            var editType = row.get("EditType");
            var allowBlank = row.get("AllowBlank");
            var fmt=row.get("Format");
            //判断是否添加tr的开始标记
            if (formLine == 1 || itemSum == 1) { b.add(2, "<tr>"); }
            //获取控件类型
            var ctl = code.control[editType][controlType](id, allowBlank, fmt);
            //如果每行两列，最后一行只剩一列，合并单元格,并输出行的结束标记
            var colSpan = "";
            if (formLine == 2 && i == store.length - 1 && j % 2 != 0) {
                colSpan = ' colspan="3"'; itemSum = 2;
            }
            //输出必填的标记
            var required = allowBlank == "false" ? '<span class="required">*</span>' : "";
            b.addFmt(3, '<td class="odd">' + required + '{0}</td>', display);
            b.addFmt(3, '<td class="even"' + colSpan + '>{0}</td>', ctl);
            //当每行两列，输出两列后才输出tr的结束标记
            if (formLine == 1 || (itemSum == 2)) {
                b.add(2, "</tr>");
                //输如果每行两列，输出tr结束标记后，将列标志重置，表示该行已经输出完毕
                if (formLine == 2) { itemSum = 0; }
            }
        }
        b.add(1, ' </table>');
        if (pageMode == "mvc") {
            b.add(1, '<!--主键-->');
            b.addFmt(1, '<%:Html.HiddenFor(o=>o.{0}) %>', pk);
            b.add(1, '<!--编辑模式-->');
            b.addFmt(1, '<%:Html.Hidden("editmode",ViewData["mode"].ToString()) %>');
            b.add(1, "</form>");
        }
        if (pageMode != "static") {
            b.add(0, code.contentEnd);
        } else {
            b.add(1, "</div>").add(0, code.htmlEnd);
        }
        return b.toString();
    }
}
