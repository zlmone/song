package song.api.common.config;

import song.common.config.Configuration;
import song.common.toolkit.security.jwt.JWTAudience;

import java.io.IOException;

public class JWTAudienceConfig {
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
}
