package song.common.toolkit.excel;

import org.apache.poi.openxml4j.exceptions.InvalidFormatException;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;

public abstract class ExcelReader {
    protected ReadExcel excel;

    public ExcelReader(ReadExcel excel) {
        this.excel = excel;
    }

    public abstract ReadExcel read(String filePath) throws IOException;

    public abstract ReadExcel read(File file) throws IOException, InvalidFormatException;

    public abstract ReadExcel read(InputStream inputStream) throws IOException;
}
