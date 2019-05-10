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
        { title: '用户名', key: 'userName', sortable: true },
        { title: '真实姓名', key: 'realName',sortable:true },
        { title: '是否管理员', key: 'isAdmin' },
        { title: '是否启用', key: 'enable' },
        { title: 'IP', key: 'ipAddress' },
        { title: 'MAC', key: 'macAddress' },
        { title: '邮箱', key: 'email' },
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
      api.get("user/list").then(data=>{
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
