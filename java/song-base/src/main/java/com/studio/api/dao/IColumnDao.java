package com.studio.api.dao;

import com.studio.api.base.IDao;
import com.studio.model.Column;
import org.apache.ibatis.annotations.Param;

import java.util.List;

public interface IColumnDao extends IDao{
    List<Column> getByTableId(@Param("tableId") String tableId);
}
