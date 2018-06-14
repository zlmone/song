package song.api.user.service.impl;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import song.api.user.dao.IUserDao;
import song.api.user.model.LoginLog;
import song.api.user.model.User;
import song.api.user.service.IUserService;
import song.common.security.SimpleUser;

@Service
public class UserService implements IUserService {
    @Autowired
    private IUserDao userDao;


    @Override
    public SimpleUser getSimpleUser(String userName, String password) {
        return userDao.getSimpleUser(userName,password);
    }

    @Override
    public User getUserInfo(String userId) {
        return userDao.getUserInfo(userId);
    }

    @Override
    public void saveLoginLog(LoginLog log) {
        userDao.saveLoginLog(log);
    }
}
