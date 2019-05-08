package song.api.studio.controller;


import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.studio.model.LoginInfo;
import song.api.studio.model.User;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;
import song.common.util.UUIDHelper;

@RestController
@RequestMapping("/user")
public class UserController extends BaseController {


    @GetMapping(value = "/login")
    public ActionResult login() {
        LoginInfo loginInfo = new LoginInfo();
        loginInfo.setToken(UUIDHelper.next());
        return getActionResult(loginInfo);
    }

    @GetMapping(value = "/logout")
    public ActionResult logout() {

        return getActionResult();
    }


    @GetMapping(value = "/info")
    public ActionResult getList() {
        User user = new User();
        user.setUserId(UUIDHelper.next());
        user.setLoginId(UUIDHelper.next());
        user.setUserName("admin");
        return getActionResult(user);
    }

}
