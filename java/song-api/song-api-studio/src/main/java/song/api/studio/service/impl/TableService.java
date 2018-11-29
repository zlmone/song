package song.api.studio.service.impl;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.studio.dao.IColumnDao;
import song.api.studio.dao.IConnectionDao;
import song.api.studio.dao.IProjectDao;
import song.api.studio.dao.ITableDao;
import song.api.studio.model.Column;
import song.api.studio.model.Table;
import song.api.studio.service.ITableService;
import song.common.lang.StringHelper;
import song.common.toolkit.base.BaseService;

import javax.annotation.Resource;
import java.util.List;

@Service
public class TableService extends BaseService<Table> implements ITableService {
    @Autowired
    private ITableDao tableDao;
    @Autowired
    private IColumnDao columnDao;
    @Autowired
    private IProjectDao projectDao;
    @Autowired
    private IConnectionDao connectionDao;

    public List<Table> getList(String projectId) {
        return tableDao.getByProjectId(projectId);
    }

    @Override
    public void fillTables(String projectId,List<Table> tables) {
        //先查询所有存在的表
        List<Table> existTables = tableDao.getByProjectId(projectId);
        for (Table table : tables) {
            String tableId=existsTable(existTables, table);
            if (StringHelper.isEmpty(tableId)) {
                tableDao.insert(table);
            }else{
                table.setId(tableId);
            }
            fillColumns(projectId,table.getId(),table.getColumns());
        }
    }

    @Override
    public void fillColumns(String projectId, String tableId, List<Column> columns) {
        if (!StringHelper.isEmpty(tableId)) {
            List<Column> existColumns = columnDao.getByTableId(tableId);
            for (Column column : columns) {
                Column oldColumn = existsColumn(existColumns, column);
                if (oldColumn!=null) {
                    //如果存在列，则更新
                    oldColumn.setDataType(column.getDataType());



                }else{
                    //不存在则新增列
                    columnDao.insert(column);
                }
            }
        }
    }

    private String existsTable(List<Table> tables,Table table){
        for (Table tab : tables) {
            if (tab.getTableName().equalsIgnoreCase(table.getTableName())) {
                return tab.getId();
            }
        }
        return null;
    }

    private Column existsColumn(List<Column> columns, Column column) {
        for (Column col : columns) {
            if (col.getField().equalsIgnoreCase(column.getField())) {
                return col;
            }
        }
        return null;
    }
}
