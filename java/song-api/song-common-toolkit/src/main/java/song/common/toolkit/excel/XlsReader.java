package song.common.toolkit.excel;

import org.apache.poi.openxml4j.exceptions.InvalidFormatException;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;

public class XlsReader extends ExcelReader {
    public XlsReader(ReadExcel excel) {
        super(excel);
    }

    @Override
    public ReadExcel read(String filePath) throws IOException {
        return excel;
    }

    @Override
    public ReadExcel read(File file) throws IOException , InvalidFormatException {
        return excel;
    }

    @Override
    public ReadExcel read(InputStream inputStream) throws IOException {
        return excel;
    }
}
