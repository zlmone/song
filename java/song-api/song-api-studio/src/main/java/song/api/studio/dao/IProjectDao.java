package song.api.studio.dao;import org.apache.ibatis.annotations.Mapper;import org.apache.ibatis.annotations.Param;import song.api.studio.model.Project;import song.common.toolkit.base.IBaseDao;import java.util.List;/** * description: * author:          song * createDate:      2017/12/28 */@Mapperpublic interface IProjectDao extends IBaseDao<Project> {    List<Project> getByName(@Param("projectName") String projectName);}