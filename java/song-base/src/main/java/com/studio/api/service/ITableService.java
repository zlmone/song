package com.studio.api.service;

import com.studio.api.common.IService;
import com.studio.model.Table;

import java.util.List;

public interface ITableService extends IService {
    List<Table> getList(String projectId);
}
