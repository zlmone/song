package song.service.user;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import song.service.config.ApplicationConfig;

@RestController
@EnableAutoConfiguration
@RequestMapping("/user")
public class UserController {
    @Autowired
    private ApplicationConfig config;

    @RequestMapping(value = "/getlist",method = RequestMethod.GET)
    public String getlist(){
        return "[{userid:"+config.getId()+",username:"+config.getName()+"}]";
    }
}
