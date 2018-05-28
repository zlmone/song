package song.common.toolkit.base;

import com.github.pagehelper.PageHelper;
import com.github.pagehelper.PageInfo;
import org.springframework.beans.factory.annotation.Autowired;
import tk.mybatis.mapper.common.Mapper;
import song.common.toolkit.db.pager.PagedData;

import java.util.List;

public class BaseService<T> implements IBaseService<T>{
    @Autowired
    protected Mapper<T> baseDao;

    public T findById(Object id) {
        return baseDao.selectByPrimaryKey(id);
    }

    public T findOne(T t) {
        return baseDao.selectOne(t);
    }

    public List<T> find(T t) {
        return baseDao.select(t);
    }

    public int count(T t) {
        return baseDao.selectCount(t);
    }

    public List<T> findAll() {
        return baseDao.selectAll();
    }

    public boolean update(T t) {
        return baseDao.updateByPrimaryKey(t)>0;
    }

    public boolean insert(T t) {
        return baseDao.insertSelective(t)>0;
    }

    public boolean delete(T t) {
        return baseDao.delete(t)>0;
    }

    public boolean deleteById(Object id) {
        return baseDao.deleteByPrimaryKey(id)>0;
    }

    public PagedData<T> findPaging(int pageIndex, int pageSize, T t){
        PageHelper.startPage(pageIndex, pageSize);
        List<T> list = baseDao.select(t);
        return new PagedData<T>(new PageInfo<T>(list));
    }

    public PagedData<T> findAllPaging(int pageIndex, int pageSize){
        PageHelper.startPage(pageIndex, pageSize);
        List<T> list = baseDao.selectAll();
        return new PagedData<T>(new PageInfo<T>(list));
    }
}
