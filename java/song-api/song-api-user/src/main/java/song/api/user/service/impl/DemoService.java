package song.api.user.service.impl;

import com.github.pagehelper.PageHelper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.user.base.BaseService;
import song.api.user.dao.IDemoDao;
import song.api.user.model.Demo;
import song.api.user.service.IDemoService;

import java.util.List;

@Service
public class DemoService extends BaseService implements IDemoService {
    @Autowired
    private IDemoDao demoDao;

    public List<Demo> getByName(String name) {
        PageHelper.startPage(1, 2);
        return demoDao.getByName(name);
    }
}
