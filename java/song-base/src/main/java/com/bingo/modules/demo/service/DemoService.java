package com.bingo.modules.demo.service;

import com.bingo.modules.demo.pojo.Demo;

/**
 * Created by LinXiuzi on 2017/6/10.
 */
public interface DemoService {

    int insert(Demo record);

    Demo selectById(String id);



}
