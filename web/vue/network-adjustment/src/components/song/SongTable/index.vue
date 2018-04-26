<template>
  <div>
    <el-table :data="rows" v-loading.body="loading" 
      element-loading-text="正在努力加载数据..." 
      border fit highlight-current-row stripe >
      <el-table-column v-for="(item,key) in columns" v-bind="item">
          <template scope="scope">
              <slot v-if="item.slot" :name="item.prop" :$index="scope.$index" :row="scope.row"></slot>
              <span v-else>{{scope.row[item.prop]}}</span>
          </template>
      </el-table-column>
    </el-table>
    <song-pager @pageChange="loadPage" :total="total" ></song-pager>
  </div>
</template>

<script>
import SongPager from '@/components/song/SongPager'
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
    params:{type:Object,default:function(){return {}}}
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
    load:function(loadParams){
        this.loadPage(loadParams)
    },
    reload:function(loadParams){
        this.params["pageNum"]=1;
        this.loadPage(loadParams)
    },
    loadPage(pageParams) {
      this.loading = true
      if(pageParams){
        for (var key in pageParams) {
          this.params[key] = pageParams[key];
        }
      }
      request({
        url: this.url,
        method:this.method,
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
