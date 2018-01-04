package com.studio.api.controller;

import com.studio.api.base.BaseController;
import com.studio.api.service.ITemplateService;
import com.studio.model.Template;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
@RequestMapping("/template")
public class TemplateController extends BaseController {
    @Autowired
    private ITemplateService templateService;

    @RequestMapping(value = "/getlist", method = RequestMethod.GET)
    @ResponseBody
    public List<Template> getList() {
        return null;
    }
}
