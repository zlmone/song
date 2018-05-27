package song.api.user.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.user.config.ApplicationConfig;
import song.api.user.model.LoginInfo;
import song.api.user.model.User;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;

import java.util.Date;
import java.util.UUID;

@RestController
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private ApplicationConfig config;

    @GetMapping(value = "/info")
    public ActionResult getInfo() {
        User user = new User();
        user.setId(UUID.randomUUID().toString());
        user.setUserId("userid1");
        user.setUserName("username");
        user.setRealName("realname");
        user.setBirthday(new Date());
        user.addRole("admin");
        return new ActionResult(user);
    }

    @PostMapping(value = "/login")
    public ActionResult login(String username,String password){
        LoginInfo loginInfo = new LoginInfo(UUID.randomUUID().toString());
        return new ActionResult(true, "登录成功", loginInfo);
    }

    @PostMapping(value = "/logout")
    public ActionResult logout() {
        return new ActionResult(true, "退出成功");
    }
}
