package song.api.studio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Column;
import song.api.studio.service.IColumnService;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/column")
public class ColumnController extends BaseController {
    @Autowired
    private IColumnService columnService;

    @GetMapping(value = "/list")
    public List<Column> getList(String tableId) {
        return columnService.getList(tableId);
    }
}
