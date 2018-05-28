package song.common.toolkit.excel;

import java.io.IOException;
import java.io.OutputStream;

public class XlsWriter extends ExcelWriter {
    public XlsWriter(WriteExcel excel) {
        super(excel);
    }

    @Override
    public void write(OutputStream stream) throws IOException {

    }
}
