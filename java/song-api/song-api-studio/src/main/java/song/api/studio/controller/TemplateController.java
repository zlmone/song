package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import song.api.studio.model.Template;
import song.api.studio.service.ITemplateService;
import song.common.toolkit.base.BaseController;

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
