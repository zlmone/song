package song.common.toolkit.export;

import song.common.net.http.HttpFileResponse;

import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public abstract class Exporter extends HttpFileResponse {
    public Exporter(HttpServletResponse response) {
        super(response);
    }

    public abstract void export(ExportExcel excel) throws IOException;
}
