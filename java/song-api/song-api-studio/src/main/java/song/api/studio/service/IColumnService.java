package song.api.studio.service;


import song.api.studio.model.Column;
import song.common.toolkit.base.IBaseService;

import java.util.List;

public interface IColumnService extends IBaseService<Column> {
    List<Column> getList(String tableId);

    boolean insert(Column t);

    boolean update(Column t);
}
