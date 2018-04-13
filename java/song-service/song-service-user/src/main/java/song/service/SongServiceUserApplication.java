package song.service;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
@MapperScan("song.service.user.dao")
public class SongServiceUserApplication {

	public static void main(String[] args) {
		SpringApplication.run(SongServiceUserApplication.class, args);
	}
}
