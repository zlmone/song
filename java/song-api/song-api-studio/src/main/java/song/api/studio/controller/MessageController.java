package song.api.studio.controller;


import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;

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
