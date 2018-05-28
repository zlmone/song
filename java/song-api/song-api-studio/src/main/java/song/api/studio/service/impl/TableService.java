package song.api.studio.service.impl;


import org.springframework.stereotype.Service;
import song.api.studio.dao.ITableDao;
import song.api.studio.model.Table;
import song.api.studio.service.ITableService;
import song.common.toolkit.base.BaseService;

import javax.annotation.Resource;
import java.util.List;

@Service
public class TableService extends BaseService<Table> implements ITableService {

    @Resource
    private ITableDao tableDao;

    public List<Table> getList(String projectId) {
        return tableDao.getByProjectId(projectId);
    }
}
