package song.api.common.config;

import org.springframework.boot.web.servlet.FilterRegistrationBean;
import org.springframework.context.annotation.Bean;
import org.springframework.web.method.support.HandlerMethodArgumentResolver;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import song.api.common.resolver.SimpleUserMethodArgumentResolver;
import song.api.common.filter.XssFilter;
import song.common.toolkit.net.http.CorsHelper;

import java.util.ArrayList;
import java.util.List;

public class WebApplicationConfig implements WebMvcConfigurer {
    @Override
    public void addCorsMappings(CorsRegistry registry) {
        CorsHelper.addAllow(registry);
    }

    @Override
    public void addArgumentResolvers(List<HandlerMethodArgumentResolver> argumentResolvers) {
        argumentResolvers.add(new SimpleUserMethodArgumentResolver());
    }

    @Bean
    public FilterRegistrationBean jwtFilterRegistrationBean() {
        return JWTConfig.getJWTFilterBean();
    }

    @Bean
    public static  FilterRegistrationBean getJWTFilterBean(){
        //拦截器
        FilterRegistrationBean registrationBean = new FilterRegistrationBean();
        //自定义拦截类
        registrationBean.setFilter(new XssFilter());
        List<String> urlPatterns = new ArrayList<String>();
        urlPatterns.add("/*");
        registrationBean.setUrlPatterns(urlPatterns);
        return registrationBean;
    }
}
