<template>
  <div>
      <tables ref="tables" editable searchable search-place="top"  v-model="tableData" :columns="columns" 
      @on-delete="handleDelete" @on-edit="handleEdit"/>
  </div>
</template>

<script>
import Tables from '_c/tables'
import api from '@/libs/api.request'
export default {
  components: {
    Tables
  },
  data () {
    return {
      columns: [
        { title: '连接名', key: 'connectionName', sortable: true,width:120},
        { title: '数据类型', key: 'dbType', width:100},
        { title: '连接字符串', key: 'url' },
        {
          title: '操作',key: 'handle',width:120,fiexd:"right",
          options: ['delete','edit']
        }
      ],
      tableData: []
    }
  },
  methods: {
    handleDelete (params) {
      api.delete("conn/remove",{id:params.row.id}).then(data=>{
         
      });
    },
    handleEdit(params){
      console.log(params);
    },
    getTableData () {
      api.get("conn/list").then(data=>{
        if(data){
            this.tableData=data;
        } 
      });
    }
  },
  mounted () {
    this.getTableData();
  }
}
</script>

<style>

</style>
