package song.api.studio.controller;


import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import song.api.common.config.JWTConfig;
import song.api.studio.model.User;
import song.api.studio.service.IUserService;
import song.api.studio.viewmodel.LoginInfo;
import song.common.lang.StringHelper;
import song.common.result.ActionResult;
import song.common.security.SimpleUser;
import song.common.toolkit.base.BaseController;
import song.common.util.UUIDHelper;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private IUserService userService;

    @GetMapping(value = "/login")
    public ActionResult login(String userName,String password) {
        User user = userService.getOne(Wrappers.<User>lambdaQuery().eq(User::getUserName,userName).eq(User::getPassword, password));
        if (user != null && !StringHelper.isEmpty(user.getUserName())) {
            SimpleUser simpleUser = new SimpleUser(user.getId(),user.getUserName(),user.getRealName());
            try {
                String token = JWTConfig.getJWT().create(simpleUser);
                LoginInfo loginInfo = new LoginInfo();
                loginInfo.setToken(token);
                return success(loginInfo);
            } catch (Exception ex) {
                return fail("登录成功，创建token失败");
            }
        }
        return unauthorized("账号或者密码不正确");
    }

    @GetMapping(value = "/logout")
    public ActionResult logout(String token) {

        return success();
    }


    @GetMapping(value = "/info")
    public ActionResult getUserInfo(String id) {
        User user=userService.getById(id);
        if (user == null) {
            Map<String, String> map = new HashMap<>();
            map.put("avatar", "test");
            map.put("userName", "admin");
            map.put("userId", UUIDHelper.next());
            map.put("access", "test");
            return success(map);
        }

        return success(user);
    }

    @GetMapping(value = "/list")
    public ActionResult getList() {
        return success(userService.list());
    }

    @PostMapping(value = "/save")
    public ActionResult save(@RequestBody User entity) {
        return saveSuccess(userService.saveOrUpdate(entity));
    }

    @DeleteMapping(value = "/remove")
    public ActionResult remove(String id) {
        return success(userService.removeById(id));
    }
}
