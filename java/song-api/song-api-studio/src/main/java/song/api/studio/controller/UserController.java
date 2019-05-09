package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.studio.service.IUserService;
import song.api.studio.vm.LoginInfo;
import song.api.studio.model.User;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;
import song.common.util.UUIDHelper;

import java.util.HashMap;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private IUserService userService;

    @GetMapping(value = "/login")
    public ActionResult login() {
        LoginInfo loginInfo = new LoginInfo();
        loginInfo.setToken(UUIDHelper.next());
        return getActionResult(loginInfo);
    }

    @GetMapping(value = "/logout")
    public ActionResult logout(String token) {

        return getActionResult();
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
            return getActionResult(map);
        }

        return getActionResult(user);
    }

    @GetMapping(value = "/list")
    public ActionResult getList() {
        return getActionResult(userService.list());
    }

}
