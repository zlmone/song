package song.api.common.config;import org.springframework.boot.web.servlet.FilterRegistrationBean;import org.springframework.context.annotation.Bean;import org.springframework.web.servlet.config.annotation.CorsRegistry;import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;import song.api.common.filter.XssFilter;import song.common.toolkit.net.http.CorsHelper;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2019/1/8 */public class SimpleWebApplicationConfig implements WebMvcConfigurer {    @Override    public void addCorsMappings(CorsRegistry registry) {        CorsHelper.addAllow(registry);    }/*    @Bean    public static FilterRegistrationBean xssFilterRegistrationBean(){        //拦截器        FilterRegistrationBean registrationBean = new FilterRegistrationBean();        //自定义拦截类        registrationBean.setFilter(new XssFilter());        List<String> urlPatterns = new ArrayList<String>();        urlPatterns.add("/*");        registrationBean.setUrlPatterns(urlPatterns);        return registrationBean;    }*/}