<template>
	<div>
		<el-pagination
		  background
	      @size-change="pageSizeChange"
	      @current-change="pageNumChange"
	      :current-page="pageNum"
	      :page-sizes="[10,15, 20, 30, 40,50]"
	      :page-size="pageSize"
	      layout="total, sizes, prev, pager, next, jumper"
	      :total="total">
	    </el-pagination>
	</div>
</template>

<script>
	export default {
	  name: 'song-pager',
	  props: { 
  		pageNum:{
  			type:Number,
  			default:1
  		},
	  	pageSize:{
	  		type:Number,
	  		default:15
	  	},
	    total: {
	      	type: Number,
	      	default: 0
	    }
	  },
	  methods:{
	  	load:function(){
			this.$emit("pageChange",{pageNum:this.num,pageSize:this.size});
	  	},
	  	pageSizeChange:function(val){
	  		this.size=val;
  			this.load();
	  	},
	  	pageNumChange:function(val){
	  		this.num=val;
	  		this.load();
	  	}
	  },
	  data(){
	  	return {
	  		size:this.pageSize,
	  		num:this.pageNum
	  	}
	  }
	}
</script>