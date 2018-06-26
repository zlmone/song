package song.common.toolkit.excel;


import song.common.ui.excel.ExcelType;

import java.io.IOException;
import java.io.OutputStream;

public abstract class ExcelWriter {
    protected WriteExcel excel;

    public ExcelWriter(WriteExcel excel) {
        this.excel = excel;
    }

    public abstract void write(OutputStream stream) throws IOException;

    /**
     * 获取excel最大可容纳的行数
     * @param type
     * @return
     */
    public int getMaxRows(ExcelType type) {
        if (type == ExcelType.xls) {
            return 65536;
        }
        return 1048576;
    }
}
