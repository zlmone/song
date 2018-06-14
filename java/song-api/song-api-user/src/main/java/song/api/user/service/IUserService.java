package song.api.user.service;

import song.api.user.model.LoginLog;
import song.api.user.model.User;
import song.common.security.SimpleUser;

public interface IUserService {
    SimpleUser getSimpleUser(String userName, String password);

    User getUserInfo(String userId);

    void saveLoginLog(LoginLog log);
}
