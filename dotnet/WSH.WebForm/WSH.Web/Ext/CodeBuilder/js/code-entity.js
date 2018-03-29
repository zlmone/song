code.entity = {
    getCommonEntity: function () {
        var b = new code.builder();
        var fileName = code.getUpperTableName() + "Entity";
        b.add(0, "using System;" + code.br).add(0, "namespace Entity{");
        b.addFmt(1, "public class {0}{", fileName);
        code.eachStore(function (r, i, last) {
            var lname = code.first(r.field, "lower");
            var uname = code.first(r.field, "upper");
            b.addFmt(2, "private  {0} {1};", r.dataType, lname);
            b.add(2, "/// <summary").add(2, "///" + r.display).add(2, "/// </summary>");
            b.addFmt(2, "public {0} {1}{", r.dataType, uname);
            b.addFmt(3, "get { return {0}; }", lname).addFmt(3, "set { {0} = value; }",lname).add(2,"}") ;
        });
        b.add(1, "}").add(0, "}");
        return { fileName: fileName, content: b.toString() }
    }
}
