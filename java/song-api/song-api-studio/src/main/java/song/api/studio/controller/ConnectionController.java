package song.api.studio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
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
        return getActionResult(connectionService.list());
    }

    @GetMapping(value = "/info")
    public ActionResult getInfo(String id) {
        return getActionResult(connectionService.getById(id));
    }
}
