package song.api.dict.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.dict.model.Dict;
import song.common.toolkit.base.BaseService;
import song.api.dict.dao.IDictDao;
import song.api.dict.service.IDictService;

import java.util.List;


@Service
public class DictService extends BaseService implements IDictService {
    @Autowired
    private IDictDao dictDao;

    @Override
    public List<Dict> getDictList(String dictType) {
        return dictDao.getDictList(dictType);
    }
}
