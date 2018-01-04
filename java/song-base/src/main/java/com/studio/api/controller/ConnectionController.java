package com.studio.api.controller;

import com.studio.api.base.BaseController;
import com.studio.api.service.IConnectionService;
import com.studio.model.Connection;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
@RequestMapping("/connection")
public class ConnectionController extends BaseController {
    @Autowired
    private IConnectionService connectionService;

    @RequestMapping(value = "/getlist", method = RequestMethod.GET)
    @ResponseBody
    public List<Connection> getList() {
        return null;
    }
}
