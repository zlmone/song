package song.api.user.model;import song.api.user.base.BaseModel;import java.util.Date;/** * description: * author:          song * createDate:      2018/4/13 */public class User extends BaseModel {    private String userId;    private String userName;    private String realName;    private Date birthday;    public String getUserId() {        return userId;    }    public void setUserId(String userId) {        this.userId = userId;    }    public String getUserName() {        return userName;    }    public void setUserName(String userName) {        this.userName = userName;    }    public String getRealName() {        return realName;    }    public void setRealName(String realName) {        this.realName = realName;    }    public Date getBirthday() {        return birthday;    }    public void setBirthday(Date birthday) {        this.birthday = birthday;    }}