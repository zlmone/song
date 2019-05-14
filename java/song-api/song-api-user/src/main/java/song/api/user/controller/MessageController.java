package song.api.user.controller;


import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;

@RestController
@RequestMapping("/msg")
public class MessageController extends BaseController {


    @GetMapping(value = "/count")
    public ActionResult count() {

        return success(10);
    }

    @GetMapping(value = "/init")
    public ActionResult init() {

        return success();
    }


    @GetMapping(value = "/content")
    public ActionResult content() {

        return success();
    }

}
