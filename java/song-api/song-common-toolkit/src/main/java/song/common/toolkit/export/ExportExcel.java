package song.common.toolkit.export;

import song.common.lang.StringHelper;
import song.common.toolkit.excel.WriteExcel;
import song.common.util.DateHelper;

public class ExportExcel extends WriteExcel {
    private String fileName;


    public void setFileName(String fileName) {
        this.fileName = fileName;
    }

    public String getFileName() {
        if (StringHelper.isEmpty(fileName)) {
            fileName = DateHelper.nowDateTime();
        }
        if (!fileName.contains(".")) {
            fileName = fileName + "." + this.getType().name();
        }
        return fileName;
    }
}
