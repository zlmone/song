package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Template;
import song.api.studio.service.ITemplateService;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/template")
public class TemplateController extends BaseController {
    @Autowired
    private ITemplateService templateService;

    @GetMapping(value = "/list")
    public List<Template> getList() {
        return null;
    }
}
