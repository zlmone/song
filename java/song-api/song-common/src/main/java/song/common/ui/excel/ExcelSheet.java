package song.common.ui.excel;

import song.common.ui.table.TableColumn;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class ExcelSheet {
    private String sheetName;
    private int startRowIndex = 0;
    private int startColumnIndex = 0;
    private List<TableColumn> columns;
    private List<Map<String, Object>> rows;

    public int getStartRowIndex() {
        return startRowIndex;
    }

    public void setStartRowIndex(int startRowIndex) {
        this.startRowIndex = startRowIndex;
    }

    public int getStartColumnIndex() {
        return startColumnIndex;
    }

    public void setStartColumnIndex(int startColumnIndex) {
        this.startColumnIndex = startColumnIndex;
    }

    public String getSheetName() {
        return sheetName;
    }

    public void setSheetName(String sheetName) {
        this.sheetName = sheetName;
    }

    public List<TableColumn> getColumns() {
        return columns;
    }

    public void setColumns(List<TableColumn> columns) {
        this.columns = columns;
    }

    public List<Map<String, Object>> getRows() {
        return rows;
    }

    public void setRows(List<Map<String, Object>> rows) {
        this.rows = rows;
    }

    public void addRow(Map<String, Object> row) {
        if (this.rows == null) {
            this.rows = new ArrayList<Map<String, Object>>();
        }
        this.rows.add(row);
    }
}
