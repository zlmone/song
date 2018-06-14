package song.api.common.config;

import org.springframework.boot.web.servlet.FilterRegistrationBean;
import org.springframework.context.annotation.Bean;
import org.springframework.web.method.support.HandlerMethodArgumentResolver;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurationSupport;
import song.api.common.resolver.SimpleUserMethodArgumentResolver;
import song.common.toolkit.net.http.CorsHelper;

import java.util.List;

public class WebApplicationConfig extends WebMvcConfigurationSupport {
    @Override
    public void addCorsMappings(CorsRegistry registry) {
        CorsHelper.addAllow(registry);
    }

    @Override
    public void addArgumentResolvers(List<HandlerMethodArgumentResolver> argumentResolvers) {
        super.addArgumentResolvers(argumentResolvers);
        argumentResolvers.add(new SimpleUserMethodArgumentResolver());
    }

    @Bean
    public FilterRegistrationBean jwtFilterRegistrationBean(){
        return JWTConfig.getJWTFilterBean();
    }
}
