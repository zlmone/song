package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Connection;
import song.api.studio.model.Project;
import song.api.studio.model.Table;
import song.api.studio.service.ITableService;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/table")
public class TableController extends BaseController {
    @Autowired
    private ITableService tableService;

    @GetMapping(value = "/list")
    public ActionResult getList(String projectId) {
        return success(tableService.getList(projectId));
    }

    @GetMapping(value = "/info")
    public ActionResult getInfo(String tableId) {
        return success(tableService.getById(tableId));
    }

    @PostMapping(value = "/save")
    public ActionResult save(@RequestBody Table entity) {
        return saveSuccess(tableService.saveOrUpdate(entity));
    }

    @DeleteMapping(value = "/remove")
    public ActionResult remove(String id) {
        return success(tableService.removeById(id));
    }
}
