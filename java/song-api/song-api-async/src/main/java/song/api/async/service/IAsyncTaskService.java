package song.api.async.service;

import song.common.toolkit.task.async.AsyncTask;
import song.common.toolkit.base.IBaseService;

import java.util.List;

public interface IAsyncTaskService extends IBaseService {
    List<AsyncTask> getPendings();
}
