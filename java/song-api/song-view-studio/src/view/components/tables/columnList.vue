<template>
  <div>
    <Card>
      <tables ref="tables" editable searchable search-place="top" v-model="tableData" :columns="columns" @on-delete="handleDelete"/>
      
    </Card>
  </div>
</template>

<script>
import Tables from '_c/tables'
import { getTableData } from '@/api/data'
export default {
  name: 'columnList',
  components: {
    Tables
  },
  data () {
    return { 
      columns: [
        { title: 'Name', key: 'name', sortable: true },
        { title: 'Email', key: 'email', editable: false },
        { title: 'Create-Time', key: 'createTime' },
        {
          title: 'Handle',
          key: 'handle',
          options: ['delete'],
          button: [
            (h, params, vm) => {
              return h('Button', '自定义删除')
            }
          ]
        }
      ],
      tableData: []
    }
  },
  methods: {
    handleDelete (params) {
      console.log(params)
      return false;
    },
    exportExcel () {
      this.$refs.tables.exportCsv({
        filename: `table-${(new Date()).valueOf()}.csv`
      })
    }
  },
  mounted () {
    getTableData().then(res => {
      this.tableData = res.data
    })
  }
}
</script>

<style>

</style>
