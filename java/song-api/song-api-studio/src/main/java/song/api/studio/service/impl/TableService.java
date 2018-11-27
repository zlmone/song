package song.api.studio.service.impl;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.studio.dao.IColumnDao;
import song.api.studio.dao.IConnectionDao;
import song.api.studio.dao.IProjectDao;
import song.api.studio.dao.ITableDao;
import song.api.studio.model.Table;
import song.api.studio.service.ITableService;
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
    public void FillTables(String projectId) {

    }

    @Override
    public void FillTable(String projectId,String tableId) {

    }
}
