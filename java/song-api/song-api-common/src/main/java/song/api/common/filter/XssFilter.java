package song.api.common.filter;import song.common.security.XssHttpServletRequestWrapper;import javax.servlet.*;import javax.servlet.http.HttpServletRequest;import java.io.IOException;/** * description: * author:          song * createDate:      2019/1/7 */public class XssFilter implements Filter {    @Override    public void init(FilterConfig config) throws ServletException {    }    @Override    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)            throws IOException, ServletException {        XssHttpServletRequestWrapper xssHttpServletRequestWrapper = new XssHttpServletRequestWrapper((HttpServletRequest) request);        chain.doFilter(xssHttpServletRequestWrapper, response);    }    @Override    public void destroy() {    }}