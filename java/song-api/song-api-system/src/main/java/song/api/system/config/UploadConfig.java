package song.api.system.config;import org.springframework.boot.context.properties.ConfigurationProperties;import org.springframework.context.annotation.Configuration;/** * description: * author:          song * createDate:      2018/5/30 */@Configuration@ConfigurationProperties(prefix = "attachment.upload")public class UploadConfig {    private String tempDirectory;    public String getTempDirectory() {        return tempDirectory;    }    public void setTempDirectory(String tempDirectory) {        this.tempDirectory = tempDirectory;    }}