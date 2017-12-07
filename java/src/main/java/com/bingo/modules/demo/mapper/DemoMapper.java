package com.bingo.modules.demo.mapper;

import com.bingo.base.dao.BaseDao;
import com.bingo.modules.demo.pojo.Demo;

import java.util.List;
import java.util.Map;

public interface DemoMapper extends BaseDao<Demo> {


    Demo selectByIdForXML(String id);

    List<Map<String,Object>> selectDemoMapList();

}