package song.api.studio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Connection;
import song.api.studio.service.IConnectionService;
import song.common.toolkit.base.BaseController;

import java.util.List;

@RestController
@RequestMapping("/connection")
public class ConnectionController extends BaseController {
    @Autowired
    private IConnectionService connectionService;

    @GetMapping(value = "/list")
    public List<Connection> getList() {
        return null;
    }
}
