package song.api.attachment.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.attachment.dao.IAttachmentDao;
import song.api.attachment.service.IAttachmentService;
import song.common.toolkit.base.BaseService;


@Service
public class AttachmentService extends BaseService implements IAttachmentService {
    @Autowired
    private IAttachmentDao demoDao;

}
