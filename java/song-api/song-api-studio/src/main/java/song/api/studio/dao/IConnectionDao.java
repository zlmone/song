package song.api.studio.dao;


import org.apache.ibatis.annotations.Mapper;
import song.api.studio.model.Connection;
import song.common.toolkit.base.IBaseDao;

@Mapper
public interface IConnectionDao extends IBaseDao<Connection> {

}
