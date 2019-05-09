package song.api.studio.dao;


import org.apache.ibatis.annotations.Param;
import song.api.studio.model.Column;
import song.common.toolkit.base.IBaseDao;

import java.util.List;

public interface IColumnDao extends IBaseDao<Column> {
    List<Column> getByTableId(@Param("tableId") String tableId);
}
