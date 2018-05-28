package song.common.toolkit.excel;

import song.common.ui.excel.ExcelSheet;
import song.common.ui.table.RowspanColumn;

import java.util.List;

public class WriteExcelSheet extends ExcelSheet {
    private  boolean isFixedHeader=false;
    private List<RowspanColumn> rowspanColumns;

    public boolean isFixedHeader() {
        return isFixedHeader;
    }

    public void setFixedHeader(boolean fixedHeader) {
        isFixedHeader = fixedHeader;
    }

    public List<RowspanColumn> getRowspanColumns() {
        return rowspanColumns;
    }

    public void setRowspanColumns(List<RowspanColumn> rowspanColumns) {
        this.rowspanColumns = rowspanColumns;
    }
}
