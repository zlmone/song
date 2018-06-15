package song.api.common.resolver;

import org.springframework.core.MethodParameter;
import org.springframework.lang.Nullable;
import org.springframework.web.bind.support.WebDataBinderFactory;
import org.springframework.web.context.request.NativeWebRequest;
import org.springframework.web.method.support.HandlerMethodArgumentResolver;
import org.springframework.web.method.support.ModelAndViewContainer;
import song.api.common.config.JWTConfig;
import song.common.annotation.CurrentSimpleUser;
import song.common.exception.UnauthorizedException;
import song.common.toolkit.security.jwt.JWT;
import song.common.security.SimpleUser;

public class SimpleUserMethodArgumentResolver implements HandlerMethodArgumentResolver {

    @Override
    public boolean supportsParameter(MethodParameter parameter) {
        return parameter.getParameterType().isAssignableFrom(SimpleUser.class)
                && parameter.hasParameterAnnotation(CurrentSimpleUser.class);
    }

    @Nullable
    @Override
    public Object resolveArgument(MethodParameter methodParameter, @Nullable ModelAndViewContainer modelAndViewContainer, NativeWebRequest nativeWebRequest, @Nullable WebDataBinderFactory webDataBinderFactory) throws Exception {
        try {
            String token = nativeWebRequest.getHeader(JWT.tokenHeader);
            SimpleUser user =JWTConfig.getJWT().getSimpleUser(token);
            if (user==null) {
                throw new UnauthorizedException("UnauthorizedException");
            }
            return user;
        } catch (Exception ex) {
            throw new UnauthorizedException("UnauthorizedException");
        }
    }
}
