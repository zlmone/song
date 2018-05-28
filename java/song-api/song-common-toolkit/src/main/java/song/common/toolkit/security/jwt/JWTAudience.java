package song.common.toolkit.security.jwt;/** * description: * author:          song * createDate:      2018/5/17 */public class JWTAudience {    private String audience;    private String secret;    private String issuer;    private int expireMin;    public String getAudience() {        return audience;    }    public void setAudience(String audience) {        this.audience = audience;    }    public String getSecret() {        return secret;    }    public void setSecret(String secret) {        this.secret = secret;    }    public String getIssuer() {        return issuer;    }    public void setIssuer(String issuer) {        this.issuer = issuer;    }    public int getExpireMin() {        return expireMin;    }    public void setExpireMin(int expireMin) {        this.expireMin = expireMin;    }    /**     * 将配置的分钟转换为毫秒     *     * @return     */    public long getExpireMillis() {        long exp = this.getExpireMin() * 60 * 1000;        return exp>0 ? exp : JWT.expireMillis;    }}