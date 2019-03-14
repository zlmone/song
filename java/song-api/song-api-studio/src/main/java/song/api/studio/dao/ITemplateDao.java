package song.api.studio.dao;


import org.apache.ibatis.annotations.Mapper;
import song.api.studio.model.Template;
import song.common.toolkit.base.IBaseDao;

@Mapper
public interface ITemplateDao extends IBaseDao<Template> {

}
