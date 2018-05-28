package song.api.studio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import song.api.studio.model.Column;
import song.api.studio.service.IColumnService;
import song.common.toolkit.base.BaseController;

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
