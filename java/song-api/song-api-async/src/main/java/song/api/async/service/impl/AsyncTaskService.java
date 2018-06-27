package song.api.async.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.async.dao.IAsyncTaskDao;
import song.api.async.service.IAsyncTaskService;
import song.common.toolkit.task.async.AsyncTask;
import song.common.toolkit.base.BaseService;

import java.util.List;


@Service
public class AsyncTaskService extends BaseService implements IAsyncTaskService {
    @Autowired
    private IAsyncTaskDao taskDao;


    @Override
    public List<AsyncTask> getPendings() {
        return taskDao.getPendings();
    }
}
