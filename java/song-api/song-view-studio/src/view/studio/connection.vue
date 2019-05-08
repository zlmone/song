<template>
  <div>
      <tables ref="tables" editable searchable search-place="top"  v-model="tableData" :columns="columns" @on-delete="handleDelete"/>
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
        { title: '连接名', key: 'connectionName', sortable: true },
        { title: '数据类型', key: 'dbType',sortable:true },
        { title: '连接字符串', key: 'url' },
        {
          title: '操作',
          key: 'handle',
          options: ['delete'],
          button: [
             
          ]
        }
      ],
      tableData: []
    }
  },
  methods: {
    handleDelete (params) {
      console.log(params)
    },
    getTableData () {
      api.get("connection/list").then(data=>{
           console.log(data);
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
