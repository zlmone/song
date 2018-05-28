package song.api.common.config;

import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurationSupport;
import song.common.toolkit.http.CorsHelper;

public class WebApplicationConfig extends WebMvcConfigurationSupport {
    @Override
    public void addCorsMappings(CorsRegistry registry) {
        CorsHelper.addAllow(registry);
    }
}
