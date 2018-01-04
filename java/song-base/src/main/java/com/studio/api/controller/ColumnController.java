package com.studio.api.controller;

import com.studio.api.base.BaseController;
import com.studio.api.service.IColumnService;
import com.studio.model.Column;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
@RequestMapping("/column")
public class ColumnController extends BaseController {
    @Autowired
    private IColumnService columnService;

    @RequestMapping(value = "/getlist", method = RequestMethod.GET)
    @ResponseBody
    public List<Column> getList(String tableId) {
        return columnService.getList(tableId);
    }
}
