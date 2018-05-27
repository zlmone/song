package song.api.user.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import song.common.toolkit.base.BaseService;
import song.common.toolkit.db.pager.PagedData;
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

    @Transactional
    public void save() {
        Demo demo=new Demo();
        demo.setName("name999");

        this.insert(demo);
        String id=demo.getId();

        this.deleteById("1");

    }
}
