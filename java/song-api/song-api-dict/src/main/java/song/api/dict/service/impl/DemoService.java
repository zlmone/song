package song.api.dict.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.common.toolkit.base.BaseService;
import song.api.dict.dao.IDemoDao;
import song.api.dict.service.IDemoService;


@Service
public class DemoService extends BaseService implements IDemoService {
    @Autowired
    private IDemoDao demoDao;

}
