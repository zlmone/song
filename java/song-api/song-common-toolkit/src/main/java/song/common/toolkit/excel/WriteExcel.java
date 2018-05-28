package song.common.toolkit.excel;

import song.common.ui.excel.Excel;

import java.util.List;

public class WriteExcel extends Excel {
    private List<WriteExcelSheet> sheets;

    public List<WriteExcelSheet> getSheets() {
        return sheets;
    }

    public void setSheets(List<WriteExcelSheet> sheets) {
        this.sheets = sheets;
    }
}
