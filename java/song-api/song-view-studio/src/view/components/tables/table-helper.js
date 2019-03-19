export default {
  getEditColumns: function (columns) {
    let newItem = {};
    columns.forEach(item => {
      let isEditor = item.slot;
      if (isEditor) {
        newItem[item.key] = "";
      }
    });
    return newItem;
  },
  updateRowData: function (target, source) {
    for (const key in source) {
      target[key] = source[key];
    }
    //console.log(target);
  },
  clearRowData: function (rowData) {
    for (const key in rowData) {
      rowData[key] = "";
    }
  },
  getRemoveIds: function (rows, key="id") {
    var ids = [];
    rows.forEach(sel => {
      if(sel[key]){
        ids.push(sel[key]);
      }
    });
    return ids;
  },
  removeRowsData: function (tableData, ids, key="id") {
      ids.forEach(id => {
        for (let i = 0; i < tableData.length; i++) {
          if (tableData[i][key] == id) {
            tableData.splice(i, 1);
            break;
          }
        }
      });
  },
  removeProp:function(obj,...props){
      for (const prop of props) {
        if(obj.hasOwnProperty(prop)){
          delete obj[prop];
        }
      }
  },
  setDefaultProp:function(obj,defs){
    for (const prop of defs) {
      if(!obj[prop]){
         obj[prop]=defs[prop];
      }
    }
  }
}
