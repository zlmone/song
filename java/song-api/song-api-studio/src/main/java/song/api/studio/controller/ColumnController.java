package song.api.studio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Column;
import song.api.studio.service.IColumnService;
import song.common.lang.StringHelper;
import song.common.result.ActionResult;
import song.common.result.GridResult;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/column")
public class ColumnController extends BaseController {
    @Autowired
    private IColumnService columnService;

    @GetMapping(value = "/list")
    public ActionResult getList(String tableId) {
        return new ActionResult(columnService.getList(tableId));
    }

    @PostMapping(value = "/save")
    public ActionResult saveColumn(@RequestBody Column column) {

        boolean result;
        if (StringHelper.isBlank(column.getId())) {
            result = columnService.insert(column);
        }else{
            result = columnService.update(column);
        }
        return getSaveResult(result);
    }
}
