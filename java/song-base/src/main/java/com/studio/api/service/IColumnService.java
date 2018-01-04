package com.studio.api.service;

import com.studio.api.base.IBaseService;
import com.studio.model.Column;

import java.util.List;

public interface IColumnService extends IBaseService<Column> {
    List<Column> getList(String tableId);
}
