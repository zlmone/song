package song.common.toolkit.exception;

import javax.servlet.http.HttpServletRequest;

public abstract class BaseExceptionHandler {
    protected abstract void handle(HttpServletRequest request,
                                   Exception exception);
}
