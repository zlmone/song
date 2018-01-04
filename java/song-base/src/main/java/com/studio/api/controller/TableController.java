package com.studio.api.controller;

import com.studio.api.base.BaseController;
import com.studio.api.service.ITableService;
import com.studio.model.Table;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
@RequestMapping("/table")
public class TableController extends BaseController {
    @Autowired
    private ITableService tableService;

    @RequestMapping(value = "/getlist", method = RequestMethod.GET)
    @ResponseBody
    public List<Table> getList(String projectId) {
        return tableService.getList(projectId);
    }
}
