package song.common.toolkit.db.orm.adapter;import java.sql.SQLException;import java.util.List;import java.util.Map;/** * description: * author:          song * createDate:      2017/10/29 */public interface IDataAdapter {    List<Map<String, Object>> toListMap() throws SQLException;    <T> List<T> toList(Class<T> clazz) throws Exception;    List<String> toListString() throws SQLException;    List<Object> toListObject() throws SQLException;    Object toObject() throws SQLException;}