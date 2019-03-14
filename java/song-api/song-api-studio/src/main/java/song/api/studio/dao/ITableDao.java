package song.api.studio.dao;


import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Param;
import song.api.studio.model.Table;
import song.common.toolkit.base.IBaseDao;

import java.util.List;

@Mapper
public interface ITableDao extends IBaseDao<Table> {
    List<Table> getByProjectId(@Param("projectId") String projectId);


}
