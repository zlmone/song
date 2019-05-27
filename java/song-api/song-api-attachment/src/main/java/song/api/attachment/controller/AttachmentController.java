package song.api.attachment.controller;

import org.springframework.web.bind.annotation.*;
import song.api.attachment.model.Attachment;
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
