package song.api.user.config;import org.springframework.context.annotation.Bean;import org.springframework.context.annotation.Configuration;import springfox.documentation.builders.ApiInfoBuilder;import springfox.documentation.builders.PathSelectors;import springfox.documentation.builders.RequestHandlerSelectors;import springfox.documentation.service.ApiInfo;import springfox.documentation.spi.DocumentationType;import springfox.documentation.spring.web.plugins.Docket;import springfox.documentation.swagger2.annotations.EnableSwagger2;/** * description: * author:          song * createDate:      2018/4/16 */@Configuration@EnableSwagger2public class SwaggerConfig {    @Bean    public Docket createRestApi() {        return new Docket(DocumentationType.SWAGGER_2)                .apiInfo(apiInfo())                .select()                .apis(RequestHandlerSelectors.basePackage("song.api.user.controller"))                .paths(PathSelectors.any())                .build();    }    private ApiInfo apiInfo() {        return new ApiInfoBuilder()                .title("song.api文档")                .description("restful接口")                .termsOfServiceUrl("")                .contact("song")                .version("1.0")                .build();    }}