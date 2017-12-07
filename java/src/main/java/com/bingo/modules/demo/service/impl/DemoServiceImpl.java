package com.bingo.modules.demo.service.impl;

import com.bingo.modules.demo.mapper.DemoMapper;
import com.bingo.modules.demo.pojo.Demo;
import com.bingo.modules.demo.service.DemoService;
import com.github.pagehelper.PageHelper;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.List;
import java.util.Map;

/**
 * Created by LinXiuzi on 2017/6/10.
 */
@Service
public class DemoServiceImpl implements DemoService {

    @Resource
    private DemoMapper demoMapper;

    public int insert(Demo record) {
        return demoMapper.insert(record);
    }

    public Demo selectById(String id) {

        return demoMapper.selectByIdForXML(id);
    }


    /**
     * 分页查询
     * @param pageData 分页对象
     * @return
    public PageData selectForPage(PageData pageData){

        PageHelper.startPage(pageData.getPageNum(), pageData.getPageSize());
        pageData.setData(demoMapper.selectAll());
        return pageData;

    }
*/

    /**
     * 返回list集合
     * @return
     */
//    public List<Map<String,Object>> selectForList(){
//        return demoMapper.selectDemoMapList();
//    }
}
