code.winform={
    getDataGridViewColumns:function(){
        var arr=new Array(),colObj=new Array();
        arr.push("#region DataGridView-grid列集合"+code.br);
        code.eachStore(function(record,i){
            var type=record.editType;
            if(type=="text" || type=="int" || type=="float" || type=="date"){type="TextBox";}
            if(type=="checkbox"){type="CheckBox";}
            if(type=="combox"){type="ComboBox";}
            var col="col"+code.first(record.field);
            arr.push(String.format("DataGridView{0}Column {1}=new DataGridView{2}Column();"+code.br,type,col,type));
            colObj.push(col);
            arr.push(String.format("{0}.Name=\"{1}\";"+code.br,col,record.field));
            arr.push(String.format("{0}.DataPropertyName=\"{1}\";"+code.br,col,record.field));
            arr.push(String.format("{0}.HeaderText=\"{1}\";"+code.br,col,record.display));
            if(record.sort=="false" && type!="CheckBox"){
                arr.push(String.format("{0}.SortMode=DataGridViewColumnSortMode.NotSortable;"+code.br,col));
            }
            if(parseInt(record.width)>0){
                arr.push(String.format("{0}.Width={1};"+code.br,col,record.width));
            }
            if(record.hide=="true"){
                arr.push(String.format("{0}.Visible=false;"+code.br,col));
            }
            arr.push(code.br);
        });
        arr.push('this.grid.Columns.AddRange(new DataGridViewColumn[]{'+colObj.toString()+'});');
        arr.push(code.br+"#endregion");
        return arr.join("");
    }
}
