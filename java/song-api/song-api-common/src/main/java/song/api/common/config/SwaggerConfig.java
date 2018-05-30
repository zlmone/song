package song.api.common.config;

import org.springframework.context.annotation.Bean;
import springfox.documentation.builders.ApiInfoBuilder;
import springfox.documentation.builders.PathSelectors;
import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.service.ApiInfo;
import springfox.documentation.service.Contact;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spring.web.plugins.Docket;

public class SwaggerConfig extends PackageConfig {

    @Bean
    public Docket createRestApi() {
        return this.getDocket(this.getBasePackage());
    }
    public Docket getDocket(String basePackage) {
        return new Docket(DocumentationType.SWAGGER_2)
                .apiInfo(apiInfo())
                .select()
                .apis(RequestHandlerSelectors.basePackage(basePackage))
                .paths(PathSelectors.any())
                .build();
    }
    protected ApiInfo apiInfo() {
        return new ApiInfoBuilder()
                .title("song.api")
                .description("song.api-restful")
                .termsOfServiceUrl("")
                .contact(new Contact("song","",""))
                .version("1.0")
                .build();
    }
}
