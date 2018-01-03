package com.studio.model;import com.song.db.PrimaryKeyType;import javax.persistence.Transient;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2017/10/25 */@javax.persistence.Table(name = "studio_Table")public class Table extends BaseModel {    @javax.persistence.Column(name = "projectId")    private String projectId;    @javax.persistence.Column(name = "tableCode")    private String tableCode;    @javax.persistence.Column(name = "tableName")    private String tableName;    @javax.persistence.Column(name = "primaryKey")    private String primaryKey;    @javax.persistence.Column(name = "primaryKeyType")    private PrimaryKeyType primaryKeyType;    @javax.persistence.Column(name = "defaultSortName")    private String defaultSortName;    @javax.persistence.Column(name = "defaultSortType")    private String defaultSortType;    private String comment;    private boolean enabled;    @Transient    private List<Column> columns = new ArrayList<Column>();    public List<Column> getColumns() {        return columns;    }    public void setColumns(List<Column> columns) {        this.columns = columns;    }    public String getProjectId() {        return projectId;    }    public void setProjectId(String projectId) {        this.projectId = projectId;    }    public String getTableCode() {        return tableCode;    }    public void setTableCode(String tableCode) {        this.tableCode = tableCode;    }    public String getTableName() {        return tableName;    }    public void setTableName(String tableName) {        this.tableName = tableName;    }    public String getPrimaryKey() {        return primaryKey;    }    public void setPrimaryKey(String primaryKey) {        this.primaryKey = primaryKey;    }    public PrimaryKeyType getPrimaryKeyType() {        return primaryKeyType;    }    public void setPrimaryKeyType(PrimaryKeyType primaryKeyType) {        this.primaryKeyType = primaryKeyType;    }    public String getDefaultSortName() {        return defaultSortName;    }    public void setDefaultSortName(String defaultSortName) {        this.defaultSortName = defaultSortName;    }    public String getDefaultSortType() {        return defaultSortType;    }    public void setDefaultSortType(String defaultSortType) {        this.defaultSortType = defaultSortType;    }    public String getComment() {        return comment;    }    public void setComment(String comment) {        this.comment = comment;    }    public boolean isEnabled() {        return enabled;    }    public void setEnabled(boolean enabled) {        this.enabled = enabled;    }}