<template>
  <div class="app-container">
    <pager @pageChange="loadData" :total="total" ></pager>
    <el-table :data="rows" v-loading.body="listLoading" element-loading-text="正在努力加载数据..." border fit highlight-current-row>
      <el-table-column prop="id" label="ID" width="50"></el-table-column>
      <el-table-column prop="name" label="姓名" width="100"></el-table-column>
      <el-table-column align="center" label="合并显示">
        <template slot-scope="scope">
          <span>{{scope.row.id}}{{scope.row.name}}</span>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import  Pager  from '@/components/Pager'
import { getList } from '@/api/table'
 
export default {
  components:{
    Pager
  },
  data() {
    return {
      rows: null,
      total:0,
      listLoading: true
    }
  },
  created() {
    this.loadData()
  },
  methods: {
    loadData(pageNum,pageSize) {
      this.listLoading = true
      getList(this.listQuery).then(response => {
        this.rows = response.data.rows;
        this.total=this.data.total;
        this.listLoading = false;
      })
    }
  }
}
</script>
