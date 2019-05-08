package song.api.studio.controller;


import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.studio.model.LoginInfo;
import song.api.studio.model.User;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;
import song.common.util.UUIDHelper;

@RestController
@RequestMapping("/message")
public class MessageController extends BaseController {
    

    @GetMapping(value = "/count")
    public ActionResult login() {

        return getActionResult(10);
    }

    @GetMapping(value = "/init")
    public ActionResult logout() {

        return getActionResult();
    }


    @GetMapping(value = "/content")
    public ActionResult getList() {

        return getActionResult();
    }

}
