package song.common.toolkit.excel;

import song.common.ui.excel.Excel;
import song.common.ui.excel.ExcelSheet;

import java.util.ArrayList;
import java.util.List;

public class ReadExcel extends Excel {
    private List<ExcelSheet> sheets;

    public List<ExcelSheet> getSheets() {
        return sheets;
    }

    public void setSheets(List<ExcelSheet> sheets) {
        this.sheets = sheets;
    }

    public void addSheet(ExcelSheet sheet) {
        if (this.sheets == null) {
            this.sheets = new ArrayList<ExcelSheet>();
        }
        this.sheets.add(sheet);
    }
}
