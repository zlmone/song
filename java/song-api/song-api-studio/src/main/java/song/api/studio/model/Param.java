package song.api.studio.model;

import javax.persistence.Table;

/**
 * description:
 * author:          song
 * createDate:      2019/5/8
 */
@Table(name = "studio_param")
public class Param {
    private String templateId;
    private String paramName;
    private String paramCode;
    private String paramValue;
    private String comment;

    public String getTemplateId() {
        return templateId;
    }

    public void setTemplateId(String templateId) {
        this.templateId = templateId;
    }

    public String getParamName() {
        return paramName;
    }

    public void setParamName(String paramName) {
        this.paramName = paramName;
    }

    public String getParamCode() {
        return paramCode;
    }

    public void setParamCode(String paramCode) {
        this.paramCode = paramCode;
    }

    public String getParamValue() {
        return paramValue;
    }

    public void setParamValue(String paramValue) {
        this.paramValue = paramValue;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }
}
