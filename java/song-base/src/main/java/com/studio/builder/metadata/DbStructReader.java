package com.studio.builder.metadata;import com.song.db.DBColumn;import com.song.db.DBConnectionConfig;import com.song.db.DBTable;import java.util.List;/** * description: * author:          song * createDate:      2017/10/25 */public abstract class DbStructReader {    protected DBConnectionConfig config;    public DbStructReader(DBConnectionConfig config) {         this.config=config;    }    /**     * 获取数据库所有系统表     * @return     */    public abstract List<String> getSystemTableNames();    /**     * 获取数据库所有存储过程     * @return     */    public abstract List<String> getProcedureNames();    /**     * 获取数据库所有视图     * @return     */    public abstract List<String> getViewNames();    /**     * 获取数据库所有用户定义的表     * @return     */    public abstract List<String> getUserTableNames();    /**     * 获取数据库所有数据类型     * @return     */    public abstract List<String> getDataTypes();    /**     * 根据表名获取字段信息集合     * @param tableName     * @return     */    public abstract List<DBColumn> getColumns(String tableName);    public abstract DBTable getTable(String tableName);}