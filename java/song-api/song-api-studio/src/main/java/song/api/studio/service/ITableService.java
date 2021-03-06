package song.api.studio.service;


import song.api.studio.model.Column;
import song.api.studio.model.Table;
import song.common.toolkit.base.IBaseService;
import java.util.List;

public interface ITableService extends IBaseService<Table> {
    List<Table> getList(String projectId);

    void fillTables(String projectId,List<Table> tables);

    void fillColumns(String projectId,String tableId, List<Column> columns);

}
