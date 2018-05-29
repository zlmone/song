package song.api.common.config;

import song.common.toolkit.security.jwt.JWTAudience;

public class JWTAudienceConfig {
    public static JWTAudience getAudience() {
        return new JWTAudience();
    }
}
