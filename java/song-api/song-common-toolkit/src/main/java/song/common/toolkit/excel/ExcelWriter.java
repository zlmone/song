package song.common.toolkit.excel;


import java.io.IOException;
import java.io.OutputStream;

public abstract class ExcelWriter {
    protected WriteExcel excel;

    public ExcelWriter(WriteExcel excel) {
        this.excel = excel;
    }

    public abstract void write(OutputStream stream) throws IOException;
}
