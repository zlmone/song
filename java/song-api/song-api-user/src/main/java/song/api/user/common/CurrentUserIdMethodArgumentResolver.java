package song.api.user.common;

import song.common.annotation.CurrentUserId;
import song.common.exception.UnauthorizedException;
import song.common.lang.StringHelper;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.MethodParameter;
import org.springframework.lang.Nullable;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.support.WebDataBinderFactory;
import org.springframework.web.context.request.NativeWebRequest;
import org.springframework.web.method.support.HandlerMethodArgumentResolver;
import org.springframework.web.method.support.ModelAndViewContainer;
import song.common.toolkit.security.jwt.JWT;

@Component
public class CurrentUserIdMethodArgumentResolver implements HandlerMethodArgumentResolver {
    @Autowired
    private JWTManager jwt;

    @Override
    public boolean supportsParameter(MethodParameter parameter) {
        return parameter.getParameterType().isAssignableFrom(String.class)
                && parameter.hasParameterAnnotation(CurrentUserId.class);
    }

    @Nullable
    @Override
    public Object resolveArgument(MethodParameter methodParameter, @Nullable ModelAndViewContainer modelAndViewContainer, NativeWebRequest nativeWebRequest, @Nullable WebDataBinderFactory webDataBinderFactory) throws Exception {
        try {
            String token =nativeWebRequest.getHeader(JWT.tokenHeader);
            String userid = jwt.getUserId(token);
            if (StringHelper.isEmpty(userid)) {
                throw new UnauthorizedException("用户未鉴权");
            }
            return userid;
        } catch (Exception ex) {
            throw new UnauthorizedException("用户鉴权失败");
        }
    }
}
