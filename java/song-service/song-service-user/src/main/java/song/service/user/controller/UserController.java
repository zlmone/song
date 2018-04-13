package song.service.user.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import song.service.user.base.BaseController;
import song.service.user.config.ApplicationConfig;
import song.service.user.model.User;

import java.util.Date;
import java.util.UUID;

@RestController
@EnableAutoConfiguration
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private ApplicationConfig config;

    @RequestMapping(value = "/get",method = RequestMethod.GET)
    public User getlist(){
        User user=new User();
        user.setId(UUID.randomUUID().toString());
        user.setUserId("userid");
        user.setUserName("username");
        user.setRealName("realname");
        user.setBirthday(new Date());

        return user;
    }
}
