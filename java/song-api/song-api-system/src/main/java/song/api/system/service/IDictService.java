package song.api.system.service;

import song.api.system.model.Dict;
import song.common.toolkit.base.IBaseService;

import java.util.List;

public interface IDictService extends IBaseService {
    List<Dict> getDictList(String dictType);
}
