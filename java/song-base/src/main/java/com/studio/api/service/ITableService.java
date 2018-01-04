package com.studio.api.service;

import com.studio.api.base.IBaseService;
import com.studio.model.Table;

import java.util.List;

public interface ITableService extends IBaseService<Table> {
    List<Table> getList(String projectId);
}
