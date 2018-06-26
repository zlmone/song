package song.common.toolkit.excel;

import song.common.ui.excel.ExcelType;

/**
 * excel读写工厂
 */
public class ExcelFactory {
    public static ExcelWriter getWriter(WriteExcel options) {
        ExcelType type = options.getType();
        if (type == ExcelType.xls) {
            return new XlsWriter(options);
        }
        return new XlsxWriter(options);
    }

    public static ExcelReader getReader(ReadExcel excel) {
        ExcelType type = excel.getType();
        if (type == ExcelType.xls) {
            return new XlsReader(excel);
        }
        return new XlsxReader(excel);
    }


}
