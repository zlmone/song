package com.song.toolkit.pdm;/** * description: * author:          song * createDate:      2017/10/25 */public class PdmColumn {    private String id;    private String objectID;    private String name;    private String code;    private String comment;    private String dataType;    private int length;    private boolean identity;    //是否必填    private boolean mandatory;    private boolean isPrimaryKey;    public boolean isPrimaryKey() {        return isPrimaryKey;    }    public void setPrimaryKey(boolean primaryKey) {        isPrimaryKey = primaryKey;    }    public String getId() {        return id;    }    public void setId(String id) {        this.id = id;    }    public String getObjectID() {        return objectID;    }    public void setObjectID(String objectID) {        this.objectID = objectID;    }    public String getName() {        return name;    }    public void setName(String name) {        this.name = name;    }    public String getCode() {        return code;    }    public void setCode(String code) {        this.code = code;    }    public String getComment() {        return comment;    }    public void setComment(String comment) {        this.comment = comment;    }    public String getDataType() {        return dataType;    }    public void setDataType(String dataType) {        this.dataType = dataType;    }    public int getLength() {        return length;    }    public void setLength(int length) {        this.length = length;    }    public boolean isIdentity() {        return identity;    }    public void setIdentity(boolean identity) {        this.identity = identity;    }    public boolean isMandatory() {        return mandatory;    }    public void setMandatory(boolean mandatory) {        this.mandatory = mandatory;    }}