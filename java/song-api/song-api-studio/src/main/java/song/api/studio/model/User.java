package song.api.studio.model;

import com.baomidou.mybatisplus.annotation.TableName;
import song.common.toolkit.base.IdModel;

/**
 * description:
 * author:          song
 * createDate:      2019/5/8
 */
@TableName(value = "studio_user")
public class User extends IdModel<String> {
    private String userName;
    private String realName;
    private String password;
    private  boolean isAdmin;
    private String ipAddress;
    private String macAddress;
    private boolean enable;

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getRealName() {
        return realName;
    }

    public void setRealName(String realName) {
        this.realName = realName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public boolean isAdmin() {
        return isAdmin;
    }

    public void setAdmin(boolean admin) {
        isAdmin = admin;
    }

    public String getIpAddress() {
        return ipAddress;
    }

    public void setIpAddress(String ipAddress) {
        this.ipAddress = ipAddress;
    }

    public String getMacAddress() {
        return macAddress;
    }

    public void setMacAddress(String macAddress) {
        this.macAddress = macAddress;
    }

    public boolean isEnable() {
        return enable;
    }

    public void setEnable(boolean enable) {
        this.enable = enable;
    }
}
