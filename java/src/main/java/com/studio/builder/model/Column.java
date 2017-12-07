package com.studio.builder.model;import com.song.common.EditorType;import javax.persistence.Table;/** * description: * author:          song * createDate:      2017/10/25 */@Table(name = "studio_Column")public class Column extends BaseModel{    private String tableID;    private String field;    private String display;    private String dbDataType;    private DataType dataType;    private boolean isPrimaryKey;    private int length;    private int precision;    private EditorType editorType;    private boolean sortable;    private boolean queryable;    private boolean isExport;    private boolean isImport;    private boolean isFrozen;    private boolean isHidden;    private boolean required;    private int width;    private String formatString;    private String defaultValue;    private String align;    private int rowspan;    private int colspan;    private int orderID;    private boolean enabled;    private String comment;    public String getComment() {        return comment;    }    public void setComment(String comment) {        this.comment = comment;    }    public String getTableID() {        return tableID;    }    public void setTableID(String tableID) {        this.tableID = tableID;    }    public String getField() {        return field;    }    public void setField(String field) {        this.field = field;    }    public String getDisplay() {        return display;    }    public void setDisplay(String display) {        this.display = display;    }    public String getDBDataType() {        return dbDataType;    }    public void setDBDataType(String dbDataType) {        this.dbDataType = dbDataType;    }    public DataType getDataType() {        return dataType;    }    public void setDataType(DataType dataType) {        this.dataType = dataType;    }    public boolean isPrimaryKey() {        return isPrimaryKey;    }    public void setPrimaryKey(boolean primaryKey) {        isPrimaryKey = primaryKey;    }    public int getLength() {        return length;    }    public void setLength(int length) {        this.length = length;    }    public int getPrecision() {        return precision;    }    public void setPrecision(int precision) {        this.precision = precision;    }    public EditorType getEditorType() {        return editorType;    }    public void setEditorType(EditorType editorType) {        this.editorType = editorType;    }    public boolean isSortable() {        return sortable;    }    public void setSortable(boolean sortable) {        this.sortable = sortable;    }    public boolean isQueryable() {        return queryable;    }    public void setQueryable(boolean queryable) {        this.queryable = queryable;    }    public boolean isExport() {        return isExport;    }    public void setExport(boolean export) {        isExport = export;    }    public boolean isImport() {        return isImport;    }    public void setImport(boolean anImport) {        isImport = anImport;    }    public boolean isFrozen() {        return isFrozen;    }    public void setFrozen(boolean frozen) {        isFrozen = frozen;    }    public boolean isHidden() {        return isHidden;    }    public void setHidden(boolean hidden) {        isHidden = hidden;    }    public boolean isRequired() {        return required;    }    public void setRequired(boolean required) {        this.required = required;    }    public int getWidth() {        return width;    }    public void setWidth(int width) {        this.width = width;    }    public String getFormatString() {        return formatString;    }    public void setFormatString(String formatString) {        this.formatString = formatString;    }    public String getDefaultValue() {        return defaultValue;    }    public void setDefaultValue(String defaultValue) {        this.defaultValue = defaultValue;    }    public String getAlign() {        return align;    }    public void setAlign(String align) {        this.align = align;    }    public int getRowspan() {        return rowspan;    }    public void setRowspan(int rowspan) {        this.rowspan = rowspan;    }    public int getColspan() {        return colspan;    }    public void setColspan(int colspan) {        this.colspan = colspan;    }    public int getOrderID() {        return orderID;    }    public void setOrderID(int orderID) {        this.orderID = orderID;    }    public boolean isEnabled() {        return enabled;    }    public void setEnabled(boolean enabled) {        this.enabled = enabled;    }}