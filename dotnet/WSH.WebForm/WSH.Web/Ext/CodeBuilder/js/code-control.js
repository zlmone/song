code.control = {
    textbox: {
        helper: function (id, required, attr) {
            return String.format('<%:Html.TextBoxFor(o => o.{0}, new { @class = "text"{1}{2}})%>',id,(required=="false" ? ',required="true"' : ""),attr || "");
        },
        server: function (id, required, attr) {
            return String.format('<asp:TextBox ruant="server" CssClass="text" {0}{1}{2}></asp:TextBox>', code.id(id), attr || "", code.required(required));
        },
        html: function (id, required, attr) {
            return String.format('<input type="text" class="text" {0}{1}{2}/>', code.idName(id), attr || "", code.required(required));
        }
    },
    combox: {
        helper: function (id) {
            return "";
        },
        server: function (id) {
            return String.format('<asp:DropDownList ruant="server" CssClass="combox" {0}></asp:DropDownList>', code.id(id));
        },
        html: function (id) {
            return String.format('<select class="combox" {0}></select>', code.idName(id));
        }
    },
    checkbox: {
        helper: function (id) {
            return String.format('<span class="checkbox"><%:Html.CheckBoxFor(o =>o.{0})%></span>', id);
        },
        server: function (id) {
            return String.format('<asp:CheckBox runat="server" CssClass="checkbox" {0}></asp:CheckBox>', code.id(id));
        },
        html: function (id) {
            return String.format('<span class="checkbox"><input type="checkbox" {0}/></span>', code.idName(id));
        }
    },
    date: {
        helper: function (id, required,fmt) {
            return String.format('<div class="text"><%:Html.TextBoxFor(o => o.{0}, new { @class = "date"{1},datatype="date"{2}})%></div>', id, required == "false" ? ',required="true"' : "",fmt ? ',dateformat="'+fmt+'"' : '');
        },
        server: function (id, required, fmt) {
            return String.format('<div class="text"><asp:TextBox ruant="server" CssClass="date" {0} datetype="date"{1}{2}></asp:TextBox></div>', code.idName(id), code.required(required),fmt ? ' dateformat="'+fmt+'"' : '');
        },
        html: function (id, required, fmt) {
            return String.format('<div class="text"><input type="text" class="date" {0} datatype="date"{1}{2}/></div>', code.idName(id), code.required(required), fmt ? ' dateformat="' + fmt + '"' : '');
        }
    },
    textarea: {
        helper: function (id, required) {
            return String.format('<%:Html.TextAreaFor(o => o.{0}, new { @class = "textarea"{1}})%>', id, required == "false" ? ',required="true"' : "");
        },
        server: function (id, required) {
            return String.format('<asp:TextBox ruant="server" CssClass="textarea" TextMode="MultiLine" {0}{1}></asp:TextBox>', code.id(id), code.required(required));
        },
        html: function (id, required) {
            return String.format('<textarea class="textarea" {0}{1}></textarea>', code.idName(id), code.required(required));
        }
    },
    int: {
        helper: function (id,required) {
            return code.control.textbox.helper(id, required,',datatype="int"');
        },
        server: function (id, required) {
            return code.control.textbox.server(id, required, ' datatype="int"');
        },
        html: function (id, required) {
            return code.control.textbox.html(id, required, ' datatype="int"');
        }
    },
    float: {
        helper: function (id, required) {
            return code.control.textbox.helper(id, required, ',datatype="float"');
        },
        server: function (id, required) {
            return code.control.textbox.server(id, required, ' datatype="float"');
        },
        html: function (id, required) {
            return code.control.textbox.html(id, required, ' datatype="float"');
        }
    }
}