<template>
  <div>
 
      <Table ref="tables" :data="tableData" :columns="columns">
        <template slot-scope="{ row, index }" slot="enabled">
          <Checkbox type="text" :value="row.enabled"  v-if="editIndex === index"/>
          <span v-else>{{ row.enabled }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="orderId">
          <Input type="text" :value="row.orderId"  v-if="editIndex === index" />
          <span v-else>{{ row.orderId }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="field">
          <Input type="text" :value="row.field"  v-if="editIndex === index" />
          <span v-else>{{ row.field }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="display">
          <Input type="text" :value="row.display"  v-if="editIndex === index" />
          <span v-else>{{row.display }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="isPrimaryKey">
          <Checkbox type="text" :value="row.isPrimaryKey"  v-if="editIndex === index" />
          <span v-else>{{row.isPrimaryKey }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="dataType">
          <Select  :value="row.dataType"  v-if="editIndex === index">
            <Option v-for="item in options.dataTypes" :value="item.value" :key="item.value">{{item.label}}</Option>
          </Select>
          <span v-else>{{row.dataType }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="editorType">
          <Select  :value="row.editorType"  v-if="editIndex === index">
            <Option v-for="item in options.editorTypes" :value="item.value" :key="item.value">{{item.label}}</Option>
          </Select>
          <span v-else>{{row.editorType }}</span>
        </template>
      </Table>
    
  </div>
</template>

<script>
import Tables from '_c/tables'
import dataOptions from './data.js'
export default {
  name: 'columnList',
  components: {
    Tables
  },
  data () {
    let two=40;
    let twoOrder=80;
    let three=72;
    let four=85;
    let name=120;
    return { 
      options:dataOptions,
      editIndex:0,
      columns: [
        { title: '可用', key: 'enabled',slot:'enabled',fixed:'left',width:two},
        { title: '排序', key: 'orderId',slot:'orderId',fixed:'left',width:twoOrder,sortable: true },
        { title: '字段', key: 'field',slot:'field',fixed:'left',width:name },
        { title: '显示', key: 'display',slot:'display',fixed:'left',width:name},
        { title: '主键', key: 'isPrimaryKey',slot:'isPrimaryKey' ,fixed:'left',width:two},
        { title: '类型', key: 'dataType',slot:'dataType',width:two},
        { title: '编辑器', key: 'editorType',slot:'editorType',width:three},
        { title: '排序', key: 'sortable',width:two },
        { title: '查询', key: 'queryable' ,width:two},
        { title: '导出', key: 'isExport' ,width:two},
        { title: '导入', key: 'isImport' ,width:two},
        { title: '固定', key: 'isFrozen',width:two },
        { title: '隐藏', key: 'isHidden',width:two },
        { title: '必填', key: 'required' ,width:two},
        { title: '宽度', key: 'width' ,width:two},
        { title: '长度', key: 'length' ,width:two},
        { title: '精度', key: 'precision' ,width:two},
        { title: '默认值', key: 'defaultValue',width:three },
        { title: '格式化', key: 'formatString' ,width:three},
        { title: '对齐方式', key: 'align' ,width:four},
        { title: '跨行', key: 'rowspan' ,width:two},
        { title: '跨列', key: 'colspan' ,width:two},
        { title: '数据类型', key: 'dbDataType',width:85},
        {
          title: '操作',
          key: 'handle',
          width:two,
          fixed:'right',
          options: ['delete','edit'] 
        }
      ],
      tableData: [{
        enabled:true,orderId:100,field:"name",display:"名称",isPrimaryKey:true,dataType:"String",editorType:"textbox"
      }]
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
    
  }
}
</script>

<style>
.ivu-table-cell{padding-right:3px;padding-left:3px; }
</style>
