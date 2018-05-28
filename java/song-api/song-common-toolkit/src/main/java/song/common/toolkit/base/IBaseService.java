package song.common.toolkit.base;

import song.common.toolkit.db.pager.PagedData;

import java.util.List;

public interface IBaseService<T> {
    T findById(Object id);

    T findOne(T t);

    List<T> find(T t);

    int count(T t);

    List<T> findAll();

    boolean update(T t);

    boolean insert(T t);

    boolean delete(T t);

    boolean deleteById(Object id);

    PagedData<T> findPaging(int pageIndex, int pageSize, T t);

    PagedData<T> findAllPaging(int pageIndex, int pageSize);
}
