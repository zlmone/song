package song.api.user.service;

import song.api.common.base.IBaseService;
import song.api.common.data.PagedData;
import song.api.user.model.Demo;

import java.util.List;

public interface IDemoService extends IBaseService<Demo> {
    PagedData<Demo> getByName(String name);
}
