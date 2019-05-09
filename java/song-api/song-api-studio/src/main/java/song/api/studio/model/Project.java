package song.api.studio.model;import com.baomidou.mybatisplus.annotation.TableName;import song.common.toolkit.base.IdModel;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2017/10/25 */@TableName(value = "studio_project")public class Project extends IdModel<String> {    private String projectCode;    private String projectName;    private String nameSpace;    private String comment;    private String connectionId;    private String templateId;    private List<Table> tables = new ArrayList<Table>();    public List<Table> getTables() {        return tables;    }    public void setTables(List<Table> tables) {        this.tables = tables;    }    public String getProjectCode() {        return projectCode;    }    public void setProjectCode(String projectCode) {        this.projectCode = projectCode;    }    public String getProjectName() {        return projectName;    }    public void setProjectName(String projectName) {        this.projectName = projectName;    }    public String getNameSpace() {        return nameSpace;    }    public void setNameSpace(String nameSpace) {        this.nameSpace = nameSpace;    }    public String getComment() {        return comment;    }    public void setComment(String comment) {        this.comment = comment;    }    public String getConnectionId() {        return connectionId;    }    public void setConnectionId(String connectionId) {        this.connectionId = connectionId;    }    public String getTemplateId() {        return templateId;    }    public void setTemplateId(String templateId) {        this.templateId = templateId;    }}