package song.api.studio.model;import song.common.db.DBType;import song.common.toolkit.base.IdModel;import javax.persistence.Table;/** * description: * author:          song * createDate:      2017/10/25 */@Table(name = "studio_Connection")public class Connection extends IdModel<String> {    @javax.persistence.Column(name = "ConnectionName")    private String connectionName;    @javax.persistence.Column(name = "DbType")    private DBType dbType;    @javax.persistence.Column(name = "ConnectionString")    private String connectionString;    @javax.persistence.Column(name = "UserName")    private String userName;    @javax.persistence.Column(name = "Password")    private String password;    public String getUserName() {        return userName;    }    public void setUserName(String userName) {        this.userName = userName;    }    public String getPassword() {        return password;    }    public void setPassword(String password) {        this.password = password;    }    public String getConnectionName() {        return connectionName;    }    public void setConnectionName(String connectionName) {        this.connectionName = connectionName;    }    public DBType getDbType() {        return dbType;    }    public void setDbType(DBType dbType) {        this.dbType = dbType;    }    public String getConnectionString() {        return connectionString;    }    public void setConnectionString(String connectionString) {        this.connectionString = connectionString;    }}