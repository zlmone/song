package song.api.common.config;

import org.springframework.boot.web.servlet.FilterRegistrationBean;
import song.api.common.filter.JWTFilter;
import song.common.config.Configuration;
import song.common.toolkit.security.jwt.JWT;
import song.common.toolkit.security.jwt.JWTAudience;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class JWTConfig {
    private static JWTAudience audience;
    public static JWTAudience getAudience() throws IOException {
        if(audience==null)
        {
            Configuration config = new Configuration("jwt.properties");
            audience = new JWTAudience();
            audience.setAudience(config.getProperty("jwt.audience"));
            audience.setSecret(config.getProperty("jwt.secret"));
            audience.setIssuer(config.getProperty("jwt.issuer"));
            audience.setExpireMin(config.getPropertyInt("jwt.expireMin"));
        }
        return audience;
    }

    private static List<String> ignoreRoute = new ArrayList<String>();  // 放行接口列表

    static {
        ignoreRoute.add("/user/login");
        ignoreRoute.add("/user/register");
    }

    public static  List<String> addIgnoreRoute(String route) {
        ignoreRoute.add(route);
        return ignoreRoute;
    }

    public static  List<String> getIgnoreRoute() {
        return ignoreRoute;
    }


    public static  FilterRegistrationBean getJWTFilterBean(){
        //拦截器
        FilterRegistrationBean registrationBean = new FilterRegistrationBean();
        //自定义拦截类
        JWTFilter httpBearerFilter = new JWTFilter();
        registrationBean.setFilter(httpBearerFilter);
        List<String> urlPatterns = new ArrayList<String>();
        urlPatterns.add("/*");
        registrationBean.setUrlPatterns(urlPatterns);
        return registrationBean;
    }

    public static JWT getJWT() throws IOException {
        return new JWT(getAudience());
    }
}
