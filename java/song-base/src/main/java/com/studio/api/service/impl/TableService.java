package com.studio.api.service.impl;

import com.studio.api.base.BaseService;
import com.studio.api.dao.ITableDao;
import com.studio.api.service.ITableService;
import com.studio.model.Table;
import org.springframework.stereotype.Service;

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
