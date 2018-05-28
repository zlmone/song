package song.common.toolkit.export;

import javax.servlet.http.HttpServletResponse;

public class ExporterFactory {
    public static Exporter getExporter(ExportType type, HttpServletResponse response) {
        switch (type){
            case word:
            case html:
            case txt:
            case pdf:
            case csv:
        }
        return new ExcelExporter(response);
    }
}
