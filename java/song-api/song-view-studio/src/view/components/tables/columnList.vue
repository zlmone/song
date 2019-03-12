<template>
  <div>
      <Table ref="tables" :data="tableData" :columns="columns">

        <template slot-scope="{ row, index }" slot="field">
          <Input type="text" v-model="editRowData.field"  v-if="editIndex === index" />
          <span v-else>{{ row.field }}</span> 
        </template>
        <template slot-scope="{ row, index }" slot="display">
          <Input type="text" v-model="editRowData.display"  v-if="editIndex === index" />
          <span v-else>{{row.display }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="defaultValue">
          <Input type="text" v-model="editRowData.defaultValue"  v-if="editIndex === index" />
          <span v-else>{{row.defaultValue }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="formatString">
          <AutoComplete  v-model="editRowData.formatString" :data="options.formatStrings"  v-if="editIndex === index">
          </AutoComplete>
          <span v-else>{{row.formatString }}</span>
        </template>
       

        <template slot-scope="{ row, index }" slot="dataType">
          <Select  v-model="editRowData.dataType"  v-if="editIndex === index">
            <Option v-for="item in options.dataTypes" :value="item.value" :key="item.value">{{item.label}}</Option>
          </Select>
          <span v-else>{{row.dataType }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="editorType">
          <Select  v-model="editRowData.editorType"  v-if="editIndex === index">
            <Option v-for="item in options.editorTypes" :value="item.value" :key="item.value">{{item.label}}</Option>
          </Select>
          <span v-else>{{row.editorType }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="align">
          <Select  v-model="editRowData.align"  v-if="editIndex === index">
            <Option v-for="item in options.aligns" :value="item.value" :key="item.value">{{item.label}}</Option>
          </Select>
          <span v-else>{{row.align }}</span>
        </template>


        <template slot-scope="{ row, index }" slot="isPrimaryKey">
          <i-switch size="small" type="text" v-model="editRowData.isPrimaryKey"  v-if="editIndex === index" />
          <span v-else>{{row.isPrimaryKey }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="enabled">
          <i-switch size="small" v-model="editRowData.enabled"  v-if="editIndex === index" />
          <span v-else>{{ row.enabled }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="editable">
          <i-switch size="small" v-model="editRowData.editable"  v-if="editIndex === index"/>
          <span v-else>{{ row.editable }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="sortable">
          <i-switch size="small" v-model="editRowData.sortable"  v-if="editIndex === index"/>
          <span v-else>{{ row.sortable }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="queryable">
          <i-switch size="small" v-model="editRowData.queryable"  v-if="editIndex === index"/>
          <span v-else>{{ row.queryable }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="isExport">
          <i-switch size="small" v-model="editRowData.isExport"  v-if="editIndex === index"/>
          <span v-else>{{ row.isExport }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="isImport">
          <i-switch size="small" v-model="editRowData.isImport"  v-if="editIndex === index"/>
          <span v-else>{{ row.isImport }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="isFrozen">
          <i-switch size="small" v-model="editRowData.isFrozen"  v-if="editIndex === index"/>
          <span v-else>{{ row.isFrozen }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="isHidden">
          <i-switch size="small" v-model="editRowData.isHidden"  v-if="editIndex === index"/>
          <span v-else>{{ row.isHidden }}</span>
        </template>
        <template slot-scope="{ row, index }" slot="required">
          <i-switch size="small" v-model="editRowData.required"  v-if="editIndex === index"/>
          <span v-else>{{ row.required }}</span>
        </template>

        <template slot-scope="{ row, index }" slot="orderId">
          <Input type="text" v-model="editRowData.orderId"  v-if="editIndex === index" />
          <span v-else>{{ row.orderId }}</span> 
        </template>
        <template slot-scope="{ row, index }" slot="width">
          <Input v-model="editRowData.width"  v-if="editIndex === index" />
          <span v-else>{{ row.width }}</span> 
        </template>
        <template slot-scope="{ row, index }" slot="length">
          <Input v-model="editRowData.length"  v-if="editIndex === index" />
          <span v-else>{{ row.length }}</span> 
        </template>
        <template slot-scope="{ row, index }" slot="precision">
          <Input v-model="editRowData.precision"  v-if="editIndex === index" />
          <span v-else>{{ row.precision }}</span> 
        </template>
        <template slot-scope="{ row, index }" slot="colspan">
          <Input v-model="editRowData.colspan"  v-if="editIndex === index" />
          <span v-else>{{ row.colspan }}</span> 
        </template>
        <template slot-scope="{ row, index }" slot="rowspan">
          <Input v-model="editRowData.rowspan"  v-if="editIndex === index" />
          <span v-else>{{ row.rowspan }}</span> 
        </template>

        <template slot-scope="{ row, index }" slot="handle">
          <div v-if="editIndex === index">
            <Button @click="rowEditSave(index)" type="success" size="small">保存</Button>
            <Button @click="editIndex = -1" type="error"  size="small">取消</Button>
          </div>
          <div v-else>
            <Button @click="rowBeginEdit(row, index)" type="primary">编辑</Button>
          </div>
        </template>
      </Table>
    
  </div>
</template>

<script>
import Tables from '_c/tables'
import dataOptions from './data.js'
import tableHelper from './table-helper.js'
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
    let fire=95;
    let name=120;
    var columns=[
        { title: '可用', key: 'enabled',slot:'enabled',fixed:'left',width:two},
        { title: '排序号', key: 'orderId',slot:'orderId',fixed:'left',width:twoOrder,sortable: true },
        { title: '字段', key: 'field',slot:'field',fixed:'left',width:name },
        { title: '显示', key: 'display',slot:'display',fixed:'left',width:name},
        { title: '主键', key: 'isPrimaryKey',slot:'isPrimaryKey',fixed:'left',width:two},
        { title: '类型', key: 'dataType',slot:'dataType',width:fire},
        { title: '编辑器', key: 'editorType',slot:'editorType',width:fire},
        { title: '編輯', key: 'editable',slot:'editable',width:two },
        { title: '排序', key: 'sortable',slot:'sortable',width:two },
        { title: '查询', key: 'queryable',slot:'queryable' ,width:two},
        { title: '导出', key: 'isExport',slot:'isExport' ,width:two},
        { title: '导入', key: 'isImport',slot:'isImport' ,width:two},
        { title: '固定', key: 'isFrozen',slot:'isFrozen',width:two },
        { title: '隐藏', key: 'isHidden',slot:'isHidden',width:two },
        { title: '必填', key: 'required',slot:'required' ,width:two},
        { title: '宽度', key: 'width',slot:'width' ,width:three},
        { title: '对齐方式', key: 'align',slot:'align' ,width:four},
        { title: '默认值', key: 'defaultValue',slot:'defaultValue',width:three },
        { title: '格式化', key: 'formatString',slot:'formatString' ,width:name},
        { title: '跨行', key: 'rowspan',slot:'rowspan' ,width:two},
        { title: '跨列', key: 'colspan',slot:'colspan' ,width:two},
        { title: '长度', key: 'length',slot:'length' ,width:two},
        { title: '精度', key: 'precision',slot:'precision' ,width:two},
        { title: '数据类型', key: 'dbDataType',width:85},
        {
          title: '操作',key: 'handle',slot:"handle",align:"center",width:three,fixed:'right'
        }
      ];
    return { 
      options:dataOptions,
      editIndex:-1,
      editRowData:tableHelper.getEditColumns(columns),
      columns: columns,
      tableData: [
        {enabled:true,orderId:100,field:"name",display:"名称",isPrimaryKey:true,dataType:"String",editorType:"textbox"},
        {enabled:true,orderId:100,field:"name",display:"名称",isPrimaryKey:true,dataType:"String",editorType:"textbox"},
        {enabled:true,orderId:100,field:"name",display:"名称",isPrimaryKey:true,dataType:"String",editorType:"textbox"}
      ]
    }
  },
  methods: {
    rowEditSave (index) {
      tableHelper.updateRowData(this.tableData[index],this.editRowData);
      tableHelper.clearRowData(this.editRowData);
      this.editIndex=-1;
    },
    rowBeginEdit:function(row,index){
      tableHelper.updateRowData(this.editRowData,row);
      this.editIndex=index;
    } 
  },
  mounted () {
    
  }
}
</script>

<style>
.ivu-table-cell{padding-right:3px;padding-left:3px; }
</style>
