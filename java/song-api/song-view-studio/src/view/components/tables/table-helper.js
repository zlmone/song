export default {
  getEditColumns: function (columns) {
    let newItem={};
    columns.forEach(item => {
        let isEditor=item.slot;
        if(isEditor){
          newItem[item.key]="";
        }
    });
    return newItem;
  },
  updateRowData:function(target,source){
    for (const key in source) {
      target[key]=source[key];
    }
    //console.log(target);
  },
  clearRowData:function(rowData){
    for (const key in rowData) {
      rowData[key]="";
    }
  }
}
