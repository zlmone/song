package song.common.toolkit.db.pager;import com.github.pagehelper.PageInfo;import java.util.List;/** * description: * author:          song * createDate:      2017/10/9 */public class PagedData<T> {    public PagedData(PageInfo<T> pageInfo) {        this.pageNum = pageInfo.getPageNum();        this.pageSize = pageInfo.getPageSize();        this.total = pageInfo.getTotal();        this.data = pageInfo.getList();        this.pages = pageInfo.getPages();    }    public PagedData(int pageNum, int pageSize) {        this.pageNum = pageNum;        this.pageSize = pageSize;    }    public PagedData(int pageNum, int pageSize, List<T> data) {        this.pageNum = pageNum;        this.pageSize = pageSize;        this.data = data;    }    public PagedData(int pageNum, int pageSize, long total, List<T> data) {        this.pageNum = pageNum;        this.pageSize = pageSize;        this.total = total;        this.data = data;    }    public PagedData(int pageNum, int pageSize, long total, List<T> data, int pages) {        this.pageNum = pageNum;        this.pageSize = pageSize;        this.total = total;        this.data = data;        this.pages = pages;    }    private int pageNum;    private int pageSize;    private long total;    private List<T> data;    private int pages;    public long getTotal() {        return total;    }    public void setTotal(long total) {        this.total = total;    }    public List<T> getData() {        return data;    }    public void setData(List<T> data) {        this.data = data;    }    public int getPageIndex() {        return pageNum;    }    public void setPageIndex(int pageNum) {        this.pageNum = pageNum;    }    public int getPageSize() {        return pageSize;    }    public void setPageSize(int pageSize) {        this.pageSize = pageSize;    }    public int getPages() {        return pages;    }    public void setPages(int pages) {        this.pages = pages;    }}