package song.api.studio.service.impl;import org.springframework.beans.factory.annotation.Autowired;import org.springframework.stereotype.Service;import song.api.studio.dao.IColumnDao;import song.api.studio.model.Column;import song.api.studio.service.IColumnService;import song.common.toolkit.base.BaseService;import javax.annotation.Resource;import java.util.List;/** * description: * author:          song * createDate:      2018/1/4 */@Servicepublic class ColumnService extends BaseService<Column> implements IColumnService {    @Autowired    private IColumnDao columnDao;    public List<Column> getList(String tableId) {                return columnDao.getByTableId(tableId);    }}