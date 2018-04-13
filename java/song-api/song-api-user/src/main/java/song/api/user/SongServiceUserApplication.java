package song.api.user;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.ServletComponentScan;

@SpringBootApplication
public class SongServiceUserApplication {

	public static void main(String[] args) {
		SpringApplication.run(SongServiceUserApplication.class, args);
	}
}
