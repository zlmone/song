package song.api.dict.service;

import song.api.dict.model.Dict;
import song.common.toolkit.base.IBaseService;

import java.util.List;

public interface IDictService extends IBaseService {
    List<Dict> getDictList(String dictType);
}
