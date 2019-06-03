package song.api.system.controller;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.system.model.Attachment;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;

import java.util.List;


@RestController
@RequestMapping("/attachment")
public class AttachmentController extends BaseController {
    @PostMapping(value = "/delete")
    public ActionResult delete(String id) {
        ActionResult result = new ActionResult();


        return result;
    }

    @PostMapping(value = "/save")
    public ActionResult save(@RequestBody List<Attachment> attachments) {
        ActionResult result = new ActionResult();


        return result;
    }
}
