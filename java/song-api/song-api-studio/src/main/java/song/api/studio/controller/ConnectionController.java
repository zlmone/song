package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Connection;
import song.api.studio.service.IConnectionService;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;


@RestController
@RequestMapping("/conn")
public class ConnectionController extends BaseController {
    @Autowired
    private IConnectionService connectionService;

    @GetMapping(value = "/list")
    public ActionResult getList() {
        return success(connectionService.list());
    }

    @GetMapping(value = "/info")
    public ActionResult getInfo(String id) {
        return success(connectionService.getById(id));
    }

    @PostMapping(value = "/save")
    public ActionResult save(@RequestBody Connection entity) {
        return saveSuccess(connectionService.saveOrUpdate(entity));
    }

    @DeleteMapping(value = "/remove")
    public ActionResult remove(String id) {
        return success(connectionService.removeById(id));
    }
}
