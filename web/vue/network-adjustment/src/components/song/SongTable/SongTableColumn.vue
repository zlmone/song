<template scope="scope">
	<el-table-column v-for="(item,key) in columns" v-bind="item">
  		<slot v-if="item.slot" :name="item.prop" :$index="scope.$index" :row="scope.row"></slot>
  		<span v-else>{{scope.row[item.prop]}}</span>
 	 </el-table-column>
</template>
      