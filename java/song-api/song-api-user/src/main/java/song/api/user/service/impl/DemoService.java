package song.api.user.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.common.base.BaseService;
import song.api.common.data.PagedData;
import song.api.user.dao.IDemoDao;
import song.api.user.model.Demo;
import song.api.user.service.IDemoService;

@Service
public class DemoService extends BaseService<Demo> implements IDemoService {
    @Autowired
    private IDemoDao demoDao;

    public PagedData<Demo> getByName(String name) {
        return this.findAllPaging(1, 2);
    }
}
