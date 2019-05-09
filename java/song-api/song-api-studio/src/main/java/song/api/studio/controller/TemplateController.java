package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Template;
import song.api.studio.service.ITemplateService;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/tpl")
public class TemplateController extends BaseController {
    @Autowired
    private ITemplateService templateService;

    @GetMapping(value = "/list")
    public ActionResult getList() {
        return getActionResult(templateService.list());
    }

    @GetMapping(value = "/info")
    public ActionResult getInfo(String id) {
        return getActionResult(templateService.getById(id));
    }
}
