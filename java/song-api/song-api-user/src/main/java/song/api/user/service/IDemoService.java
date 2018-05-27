package song.api.user.service;

import song.common.toolkit.base.IBaseService;
import song.common.toolkit.db.pager.PagedData;
import song.api.user.model.Demo;

public interface IDemoService extends IBaseService<Demo> {
    PagedData<Demo> getByName(String name);

    void save();

}
