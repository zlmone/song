package song.api.studio.builder.transform;import song.api.studio.builder.mapping.DataTypeMapping;import song.api.studio.builder.metadata.DbMetadataReader;import song.api.studio.model.Column;import song.api.studio.model.Connection;import song.api.studio.model.Table;import song.common.db.*;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2017/10/25 */public class DbModelTransform extends ModelTransform {    protected DBConnectionConfig dbConnectionConfig;    private DbMetadataReader dbReader;    public DbModelTransform(Connection connection) throws Exception {        this.setDbType(DBType.parse(connection.getDbType().name()));        //初始化连接对象        dbConnectionConfig = new DBConnectionConfig(                DBType.parse(connection.getDbType().name()),                connection.getUrl(),                connection.getUserName(),                connection.getPassword());        //初始化数据库结构读取器        dbReader = new DbMetadataReader(dbConnectionConfig);    }    /**     * 将表结构转换为生成器模型     *     * @return     */    public List<Table> getTables() {        List<Table> tables = new ArrayList<Table>();        //获取所有表名        List<String> dbTableNames = null;        try {            dbTableNames = dbReader.getUserTableNames();            for (String dbTableName : dbTableNames) {                tables.add(getTable(dbTableName));            }        } catch (Exception e) {            e.printStackTrace();        }        return tables;    }    public Table getTable(String dbTableName){        //获取表结构信息        DBTable dbTable = dbReader.getTable(dbTableName);        //将表结构转换为生成器需要的模型        Table table = new Table();        table.setTableCode(dbTable.getCode());        table.setTableName(dbTable.getName());        table.setComment(dbTable.getComment());        try {            table.setColumns(parseColumns(dbReader.getColumns(dbTableName), table));        } catch (Exception e) {            e.printStackTrace();        }        //修正列配置        this.repairColumns(table);        return table;    }    /**     * 将表字段结构转换为生成器模型     *     * @param dbColumns     * @return     */    private List<Column> parseColumns(List<DBColumn> dbColumns, Table table) {        List<Column> columns = new ArrayList<Column>();        for (DBColumn dbColumn : dbColumns) {            Column column = new Column();            column.setField(dbColumn.getField());            column.setDisplay(dbColumn.getDisplay());            column.setDBDataType(dbColumn.getDataType());            column.setLength(dbColumn.getLength());            column.setRequired(dbColumn.isNullable());            column.setComment(dbColumn.getComment());            column.setDefaultValue(dbColumn.getDefaultValue());            column.setPrecision(dbColumn.getPrecision());            column.setOrderId(dbColumn.getSeqno());            column.setDataType(DataTypeMapping.getDataType(dbType.getName(), column.getDBDataType()));            if (dbColumn.isIdentity()) {                table.setPrimaryKeyType(PrimaryKeyType.IdEntity);            }            if (dbColumn.isPrimaryKey()) {                column.setPrimaryKey(true);                table.setPrimaryKey(column.getField());            }            columns.add(column);        }        return columns;    }}