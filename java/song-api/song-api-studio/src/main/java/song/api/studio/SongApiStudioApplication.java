package song.api.studio;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
@MapperScan("song.api.studio.dao")
public class SongApiStudioApplication {

	public static void main(String[] args) {
		SpringApplication.run(SongApiStudioApplication.class, args);
	}
}
