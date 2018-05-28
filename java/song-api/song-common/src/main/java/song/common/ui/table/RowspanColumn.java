package song.common.ui.table;

/**
 * 合并相同数据行的列配置
 */
public class RowspanColumn {
    private String prop;
    private int startIndex=-1;
    private int mergeCount=0;
    private String prevValue;

    public String getProp() {
        return prop;
    }

    public void setProp(String prop) {
        this.prop = prop;
    }

    public int getStartIndex() {
        return startIndex;
    }

    public void setStartIndex(int startIndex) {
        this.startIndex = startIndex;
    }

    public int getMergeCount() {
        return mergeCount;
    }

    public void setMergeCount(int mergeCount) {
        this.mergeCount = mergeCount;
    }

    public String getPrevValue() {
        return prevValue;
    }

    public void setPrevValue(String prevValue) {
        this.prevValue = prevValue;
    }

    /**
     * 设置和并信息
     * @param prevValue
     * @param startIndex
     * @param mergeCount
     */
    public void setInfo(String prevValue, int startIndex,int mergeCount) {
        this.setInfo(prevValue,startIndex);
        this.mergeCount=mergeCount;
    }
    public void setInfo(String prevValue, int startIndex) {
        this.prevValue=prevValue;
        this.startIndex=startIndex;
    }

    /**
     * 清除和并信息
     */
    public void clearInfo() {
        this.setInfo(null,-1,0);
    }
}
