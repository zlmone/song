package song.api.studio.builder.metadata;import song.common.db.DBColumn;import song.common.db.DBConnectionConfig;import song.common.db.DBTable;import song.common.toolkit.db.orm.DBSession;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2017/10/25 */public class MySQLMetadataReader extends DbMetadataReader {    public MySQLMetadataReader(DBConnectionConfig config) {        super(config);    }    public List<String> getSystemTableNames() {        return null;    }    public List<String> getProcedureNames() {        return null;    }    public List<String> getViewNames() {        return null;    }    public List<String> getUserTableNames() {        return null;    }    public List<String> getDataTypes() {        return null;    }    public List<DBColumn> getColumns(String tableName) {        return null;    }    public DBTable getTable(String tableName) {        return null;    }}