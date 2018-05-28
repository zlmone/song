package song.api.user.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;
import song.common.toolkit.security.jwt.JWTAudience;

@Configuration
@ConfigurationProperties(prefix = "jwt")
public class JWTAudienceConfig extends JWTAudience {

}
