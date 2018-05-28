package song.api.studio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import song.api.studio.model.Connection;
import song.api.studio.service.IConnectionService;
import song.common.toolkit.base.BaseController;

import java.util.List;

@Controller
@RequestMapping("/connection")
public class ConnectionController extends BaseController {
    @Autowired
    private IConnectionService connectionService;

    @RequestMapping(value = "/getlist", method = RequestMethod.GET)
    @ResponseBody
    public List<Connection> getList() {
        return null;
    }
}
