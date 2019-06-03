package song.api.system.controller;import org.springframework.web.bind.annotation.PostMapping;import org.springframework.web.bind.annotation.RequestBody;import org.springframework.web.bind.annotation.RequestMapping;import org.springframework.web.bind.annotation.RestController;import song.common.toolkit.base.BaseController;import song.common.toolkit.export.ExportExcel;import song.common.toolkit.export.ExportType;import song.common.toolkit.export.ExporterFactory;import javax.servlet.http.HttpServletResponse;import java.io.IOException;/** * description: * author:          song * createDate:      2018/5/8 */@RestController@RequestMapping("/exporter")public class ExporterController extends BaseController {    @PostMapping(value = "/excel")    public void exportExcel(HttpServletResponse response, @RequestBody ExportExcel excel) throws IOException {        ExporterFactory.getExporter(ExportType.excel, response).export(excel);    }    @PostMapping(value = "/txt")    public void exportTxt(HttpServletResponse response) throws IOException {    }    @PostMapping(value = "/csv")    public void exportCsv(HttpServletResponse response) throws IOException {    }}