package song.web.controller;

import com.studio.api.base.BaseController;
import song.web.service.IUserService;
import song.web.model.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
@RequestMapping("/user")
public class UserController extends BaseController {
    @Autowired
    private IUserService userService;

    @RequestMapping(value = "/getlist", method = RequestMethod.GET)
    @ResponseBody
    public List<User> getList() {
        return null;
    }
}
