<template>
  <div>
    <el-form :inline="true" :model="query">
      <el-form-item label="ID">
        <el-input v-model="query.id"></el-input>
      </el-form-item>
      <el-form-item label="姓名">
        <el-input v-model="query.name"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onQuery">查询</el-button>
      </el-form-item>
    </el-form>
    <song-table ref="table" :url="url" :columns="columns" ></song-table>
 
  </div>
</template>

<script>
import  SongTable  from '@/components/song/SongTable'
 
export default {
  components:{
    SongTable
  },
  data() {
    return {
      query:{id:"",name:""},
      url:"/demo/list",
      columns:[
        {prop:"id",label:"ID"},
        {prop:"name",label:"姓名"}
      ]
    }
  },
  methods:{
    onQuery:function(){
        this.$refs.table.reload(this.query);
    }
  }
}
</script>
