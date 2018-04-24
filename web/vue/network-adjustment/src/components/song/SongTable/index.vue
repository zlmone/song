<template>
  <div>
    <el-table :data="rows" v-loading.body="loading" 
      element-loading-text="正在努力加载数据..." 
      border fit highlight-current-row stripe >
      <el-table-column v-for="(item,key) in columns" 
        v-if="item.isDataColumn!==false"
        :key="key"
        :prop="item.prop"
        :label="item.label"
        :width="item.width"
        :align="item.align"
        :fixed="item.fixed"
        :sortable="item.sortable"
        :resizable="item.resizable"
        ></el-table-column>
      <el-table-column v-else
        :key="key"
        :prop="item.prop"
        :label="item.label"
        :width="item.width"
        :align="item.align"
        :fixed="item.fixed"
        :sortable="item.sortable"
        :resizable="item.resizable">
          <template scope="scope">
              <slot :name="item.prop" :$index="scope.$index" :row="scope.row"></slot>
          </template>
      </el-table-column>
    </el-table>
    <song-pager @pageChange="loadPage" :total="total" ></song-pager>
  </div>
</template>

<script>
import SongPager from '@/components/song/SongPager'
import Vue from 'vue'
import request from '@/utils/request'

export default {
  name:"song-table",
  components:{
    SongPager
  },
  props:{
    columns:{type:Array,default:function(){
      return []
    }},
    url:{type:String},
    method:{type:String,default:"GET"},
    params:{type:Object,default:function(){
      return {}
    }}
  },
  data() {
    return {
      rows: null,
      total:0,
      loading: true
    }
  },
  created() {
    this.load()
  },
  methods: {
    load:function(){
        this.loadPage()
    },
    reload:function(){

    },
    loadPage(pageParams) {
      this.loading = true
      if(pageParams){
          Vue.util.extend(this.params,pageParams)
      }
      request({
        url: this.url,
        method: this.method,
        params:this.params
      }).then(response => {
        this.rows = response.data.rows
        this.total=response.data.total
        this.loading = false
      })
    }
  }
}
</script>
