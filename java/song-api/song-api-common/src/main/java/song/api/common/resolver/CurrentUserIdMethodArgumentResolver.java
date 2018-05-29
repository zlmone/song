package song.api.common.resolver;

import org.springframework.core.MethodParameter;
import org.springframework.lang.Nullable;
import org.springframework.web.bind.support.WebDataBinderFactory;
import org.springframework.web.context.request.NativeWebRequest;
import org.springframework.web.method.support.HandlerMethodArgumentResolver;
import org.springframework.web.method.support.ModelAndViewContainer;
import song.api.common.config.JWTAudienceConfig;
import song.common.annotation.CurrentUserId;
import song.common.exception.UnauthorizedException;
import song.common.lang.StringHelper;
import song.common.toolkit.security.jwt.JWT;

public class CurrentUserIdMethodArgumentResolver implements HandlerMethodArgumentResolver {

    @Override
    public boolean supportsParameter(MethodParameter parameter) {
        return parameter.getParameterType().isAssignableFrom(String.class)
                && parameter.hasParameterAnnotation(CurrentUserId.class);
    }

    @Nullable
    @Override
    public Object resolveArgument(MethodParameter methodParameter, @Nullable ModelAndViewContainer modelAndViewContainer, NativeWebRequest nativeWebRequest, @Nullable WebDataBinderFactory webDataBinderFactory) throws Exception {
        try {
            String token = nativeWebRequest.getHeader(JWT.tokenHeader);
            String userid = new JWT(JWTAudienceConfig.getAudience()).getUserId(token);
            if (StringHelper.isEmpty(userid)) {
                throw new UnauthorizedException("UnauthorizedException");
            }
            return userid;
        } catch (Exception ex) {
            throw new UnauthorizedException("UnauthorizedException");
        }
    }
}
