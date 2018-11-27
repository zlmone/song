package song.api.studio.service;


import song.api.studio.model.Table;
import song.common.toolkit.base.IBaseService;
import java.util.List;

public interface ITableService extends IBaseService<Table> {
    List<Table> getList(String projectId);

    void FillTables(String projectId);

    void FillTable(String projectId,String tableId);
}
