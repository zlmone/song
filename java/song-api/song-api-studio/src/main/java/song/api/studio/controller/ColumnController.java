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
        return getActionResult(columnService.getList(tableId));
    }

    @PostMapping(value = "/save")
    public ActionResult save(@RequestBody Column column) {
        return getSaveResult(columnService.saveOrUpdate(column));
    }

    @DeleteMapping(value = "/remove")
    public ActionResult remove(String id) {
        return getActionResult(columnService.removeById(id));
    }
}

