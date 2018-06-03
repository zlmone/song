package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Table;
import song.api.studio.service.ITableService;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/table")
public class TableController extends BaseController {
    @Autowired
    private ITableService tableService;

    @GetMapping(value = "/list")
    public List<Table> getList(String projectId) {
        return tableService.getList(projectId);
    }
}
