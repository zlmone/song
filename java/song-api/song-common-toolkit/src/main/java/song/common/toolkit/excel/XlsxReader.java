package song.common.toolkit.excel;

import org.apache.poi.openxml4j.exceptions.InvalidFormatException;
import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import song.common.lang.StringHelper;
import song.common.ui.MultipleColumnParser;
import song.common.ui.excel.ExcelSheet;
import song.common.ui.table.TableColumn;
import song.common.util.ListHelper;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class XlsxReader extends ExcelReader {
    public XlsxReader(ReadExcel excel) {
        super(excel);
    }

    @Override
    public ReadExcel read(String filePath) throws IOException {
        XSSFWorkbook workbook = new XSSFWorkbook(filePath);
        return read(workbook);
    }

    @Override
    public ReadExcel read(File file) throws IOException, InvalidFormatException {
        XSSFWorkbook workbook = new XSSFWorkbook(file);
        return read(workbook);
    }

    @Override
    public ReadExcel read(InputStream inputStream) throws IOException {
        XSSFWorkbook workbook = new XSSFWorkbook(inputStream);
        return read(workbook);
    }

    public ReadExcel read(XSSFWorkbook workbook) throws IOException {
        //读取配置的sheet信息
        try {
            List<ExcelSheet> sheets = excel.getSheets();
            for (int i = 0; i < sheets.size(); i++) {
                ExcelSheet excelSheet = sheets.get(i);
                String sheetName = excelSheet.getSheetName();
                XSSFSheet sheet;
                //先根据配置的sheet名称获取，如果没有名称则根据下标获取
                if (!StringHelper.isEmpty(sheetName)) {
                    sheet = workbook.getSheet(sheetName);
                } else {
                    sheet = workbook.getSheetAt(i);
                }
                if (sheet != null) {
                    excelSheet.setSheetName(sheet.getSheetName());
                    this.readSheet(sheet, excelSheet);
                }
            }
        }finally {
            if (workbook != null) {
                workbook.close();
            }
        }
        return excel;
    }

    /**
     * 读取每个sheet的数据
     *
     * @param sheet
     * @param excelSheet
     */
    private void readSheet(XSSFSheet sheet, ExcelSheet excelSheet) {
        List<TableColumn> columns = excelSheet.getColumns();
        if (!ListHelper.isEmpty(columns)) {
            //列头多少行
            int headRowNumber = MultipleColumnParser.getDepthRows(columns);
            //获取所有的数据列
            List<TableColumn> dataColumns = MultipleColumnParser.getDataColumns(columns);
            //数据开始的行数等于，开始行数+列头行数
            int firstDataRowIndex = excelSheet.getStartRowIndex() + headRowNumber;
            int lastRowIndex = sheet.getLastRowNum();
            for (int i = firstDataRowIndex; i <= lastRowIndex; i++) {
                XSSFRow row = sheet.getRow(i);
                if (row != null) {
                    excelSheet.addRow(readRow(row, dataColumns, excelSheet.getStartColumnIndex()));
                }
            }
        }
    }

    /**
     * 读取每一行的数据
     *
     * @param row
     * @param dataColumns
     * @param startColumnIndex
     * @return
     */
    private Map<String, Object> readRow(XSSFRow row, List<TableColumn> dataColumns, int startColumnIndex) {
        Map<String, Object> dataRow = new HashMap<String, Object>();
        //获取每一行的数据
        for (int i = startColumnIndex; i < dataColumns.size(); i++) {
            XSSFCell cell = row.getCell(i);
            dataRow.put(dataColumns.get(i).getProp(), readCell(cell));
        }
        return dataRow;
    }

    /**
     * 获取单元格的值
     *
     * @param cell
     * @return
     */
    private Object readCell(XSSFCell cell) {
        switch (cell.getCellTypeEnum()) {
            case STRING:
                return cell.getStringCellValue();
            case BOOLEAN:
                return cell.getBooleanCellValue();
            case NUMERIC:
                return cell.getNumericCellValue();
            case FORMULA:
                return cell.getCellFormula();
            case BLANK:
            case ERROR:
                return "";
            default:
                return null;
        }
    }
}
