package song.api.user.controller;

import eu.bitwalker.useragentutils.DeviceType;
import eu.bitwalker.useragentutils.UserAgent;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import song.api.common.config.JWTConfig;
import song.api.user.model.LoginLog;
import song.api.user.model.User;
import song.api.user.service.IUserService;
import song.common.lang.StringHelper;
import song.common.net.http.HttpRequest;
import song.common.result.ActionResult;
import song.common.result.ResultCode;
import song.common.security.CryptionHelper;
import song.common.security.SimpleUser;
import song.common.toolkit.base.BaseController;

import javax.servlet.http.HttpServletRequest;
import java.util.Date;

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

    @GetMapping(value = "/login")
    public ActionResult login(HttpServletRequest request, String userName, String password) throws Exception {
        String aesPassword = CryptionHelper.aesEncrypt(password,CryptionHelper.secretkey);
        ActionResult result = new ActionResult(false, "登陆失败", ResultCode.unauthorized);
        SimpleUser user = null;
        try {
            user = userService.getSimpleUser(userName, aesPassword);
        } catch (Exception ex) {
            result.setMsg("获取用户信息失败");
        }
        if (user != null) {
            String token = null;
            try {
                token = JWTConfig.getJWT().create(user);
            } catch (Exception ex) {
                result.setMsg("创建token失败");
            }
            if (!StringHelper.isEmpty(token)) {
                result.setSuccess(true);
                result.setCode(ResultCode.ok);
                result.setMsg("登陆成功");
                result.setData(token);
                //保存登录日志
                this.saveLoginLog(user, request);

            } else {
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

    private LoginLog saveLoginLog(SimpleUser user, HttpServletRequest request) {
        LoginLog loginLog = new LoginLog();

        try {
            //写入登录日志
            HttpRequest httpRequest = new HttpRequest(request);
            UserAgent userAgent = UserAgent.parseUserAgentString(httpRequest.getUserAgent());
            loginLog.setClientIp(httpRequest.getIp());
            loginLog.setBrowser(userAgent.getBrowser().getName());
            loginLog.setOs(userAgent.getOperatingSystem().getName());
            DeviceType deviceType = userAgent.getOperatingSystem().getDeviceType();
            switch (deviceType) {
                case COMPUTER:
                    loginLog.setClientType(0);
                    break;
                case MOBILE:
                    loginLog.setClientType(1);
                    break;
                case TABLET:
                    loginLog.setClientType(2);
                    break;
                default:
                    loginLog.setClientType(3);
            }
            loginLog.setLoginTime(new Date());
            loginLog.setSuccess(true);
            loginLog.setUserId(user.getUserId());
            userService.saveLoginLog(loginLog);
        } catch (Exception ex) {
            //写入文件日志
        }
        return loginLog;
    }
}
