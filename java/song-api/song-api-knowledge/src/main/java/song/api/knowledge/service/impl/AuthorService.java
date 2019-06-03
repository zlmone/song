package song.api.knowledge.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.knowledge.dao.IAuthorDao;
import song.api.knowledge.service.IAuthorService;
import song.common.toolkit.base.BaseService;


@Service
public class AuthorService extends BaseService implements IAuthorService {
    @Autowired
    private IAuthorDao demoDao;

}
