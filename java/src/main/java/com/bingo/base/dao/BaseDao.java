package com.bingo.base.dao;

import com.bingo.base.dao.extend.BingoMapper;
import tk.mybatis.mapper.common.BaseMapper;
import tk.mybatis.mapper.common.Marker;
import tk.mybatis.mapper.common.RowBoundsMapper;

/**
 * Created by lxz94 on 2017/7/12.
 */
public interface BaseDao<T> extends BaseMapper<T>, RowBoundsMapper<T>, Marker, BingoMapper<T> {
}
