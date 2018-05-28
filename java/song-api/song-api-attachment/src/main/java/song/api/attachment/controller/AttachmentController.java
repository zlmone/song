package song.api.attachment.controller;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.attachment.model.Attachment;
import song.common.result.ActionResult;

import java.util.List;

@RestController
@RequestMapping("/attachment")
public class AttachmentController {
    @DeleteMapping(value = "delete")
    public ActionResult delete(String id) {
        ActionResult result = new ActionResult();


        return result;
    }

    @DeleteMapping(value = "save")
    public ActionResult save(@RequestBody List<Attachment> attachments) {
        ActionResult result = new ActionResult();


        return result;
    }
}
