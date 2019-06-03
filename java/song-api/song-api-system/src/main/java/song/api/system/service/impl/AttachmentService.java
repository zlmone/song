package song.api.system.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import song.api.system.dao.IAttachmentDao;
import song.api.system.service.IAttachmentService;
import song.common.toolkit.base.BaseService;


@Service
public class AttachmentService extends BaseService implements IAttachmentService {
    @Autowired
    private IAttachmentDao demoDao;

}
