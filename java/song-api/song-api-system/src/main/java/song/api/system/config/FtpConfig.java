package song.api.system.config;import org.springframework.boot.context.properties.ConfigurationProperties;import org.springframework.context.annotation.Configuration;import song.common.net.ServerConnection;/** * description: * author:          song * createDate:      2018/5/30 */@Configuration@ConfigurationProperties(prefix = "ftp")public class FtpConfig extends ServerConnection {}