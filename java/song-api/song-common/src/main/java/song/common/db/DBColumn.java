package song.common.db;/** * description: * author:          song * createDate:      2017/10/25 */public class DBColumn {    private int seqno;    private String field;    private String display;    private String dataType;    private boolean isIdentity;    private boolean isPrimaryKey;    private int length;    //精度    private int precision;    //小数位    private int scale;    private boolean isNullable;    private String defaultValue;    private String comment;    public int getSeqno() {        return seqno;    }    public void setSeqno(int seqno) {        this.seqno = seqno;    }    public String getField() {        return field;    }    public void setField(String field) {        this.field = field;    }    public String getDisplay() {        return display;    }    public void setDisplay(String display) {        this.display = display;    }    public String getDataType() {        return dataType;    }    public void setDataType(String dataType) {        this.dataType = dataType;    }    public boolean isIdentity() {        return isIdentity;    }    public void setIdentity(boolean identity) {        isIdentity = identity;    }    public boolean isPrimaryKey() {        return isPrimaryKey;    }    public void setPrimaryKey(boolean primaryKey) {        isPrimaryKey = primaryKey;    }    public int getLength() {        return length;    }    public void setLength(int length) {        this.length = length;    }    public int getPrecision() {        return precision;    }    public void setPrecision(int precision) {        this.precision = precision;    }    public int getScale() {        return scale;    }    public void setScale(int scale) {        this.scale = scale;    }    public boolean isNullable() {        return isNullable;    }    public void setNullable(boolean nullable) {        isNullable = nullable;    }    public String getDefaultValue() {        return defaultValue;    }    public void setDefaultValue(String defaultValue) {        this.defaultValue = defaultValue;    }    public String getComment() {        return comment;    }    public void setComment(String comment) {        this.comment = comment;    }}