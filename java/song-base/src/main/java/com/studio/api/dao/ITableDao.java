package com.studio.api.dao;

import com.studio.api.base.IDao;
import com.studio.model.Table;
import org.apache.ibatis.annotations.Param;

import java.util.List;

public interface ITableDao extends IDao {
    List<Table> getByProjectId(@Param("projectId") String projectId);
}
