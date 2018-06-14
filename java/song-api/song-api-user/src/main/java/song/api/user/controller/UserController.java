package song.api.user.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.common.config.JWTConfig;
import song.api.user.model.User;
import song.api.user.service.IUserService;
import song.common.lang.StringHelper;
import song.common.result.ActionResult;
import song.common.result.ResultCode;
import song.common.security.CryptionHelper;
import song.common.security.SimpleUser;
import song.common.toolkit.base.BaseController;

@RestController
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private IUserService userService;

    @GetMapping(value = "/info")
    public ActionResult getInfo(String userId) {
        User user = userService.getUserInfo(userId);
        return new ActionResult(user);
    }

    @PostMapping(value = "/login")
    public ActionResult login(String userName, String password) throws Exception {
        String aesPassword = CryptionHelper.aesEncrypt(CryptionHelper.md5(password), CryptionHelper.secretkey);
        ActionResult result = new ActionResult(false, "登陆失败", ResultCode.unauthorized);
        SimpleUser user = null;
        try {
            user = userService.getSimpleUser(userName, aesPassword);
        } catch (Exception ex) {
            result.setMsg("获取用户信息失败");
        }
        if (user != null) {
            try {
                String token = JWTConfig.getJWT().create(user);
                if (!StringHelper.isEmpty(token)) {
                    result.setSuccess(true);
                    result.setCode(ResultCode.ok);
                    result.setMsg("登陆成功");
                    result.setData(token);
                } else {
                    result.setMsg("创建token失败");
                }
            } catch (Exception ex) {
                result.setMsg("创建token失败");
            }
        } else {
            result.setMsg("用户名或密码错误");
        }
        return result;
    }

    @PostMapping(value = "/logout")
    public ActionResult logout() {
        return new ActionResult(true, "退出成功");
    }
}
