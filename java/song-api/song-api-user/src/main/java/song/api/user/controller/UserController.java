package song.api.user.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.user.config.ApplicationConfig;
import song.api.user.model.User;
import song.api.common.base.BaseController;

import java.util.Date;
import java.util.UUID;

@RestController
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private ApplicationConfig config;

    @GetMapping(value = "/list")
    public User getlist() {
        User user = new User();
        user.setId(UUID.randomUUID().toString());
        user.setUserId("userid1");
        user.setUserName("username");
        user.setRealName("realname");
        user.setBirthday(new Date());

        return user;
    }
}
