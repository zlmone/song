package song.common.toolkit.base;import song.common.result.ActionResult;import song.common.result.GridResult;import song.common.toolkit.db.pager.PagedData;/** * description: * author:          song * createDate:      2018/4/13 */public class BaseController {    public <T> GridResult<T> getGridResult(PagedData<T> pagedData) {        return new GridResult<T>(pagedData.getTotal(), pagedData.getData());    }    public ActionResult getSaveResult(boolean result) {        return new ActionResult(result, result ? "保存成功" : "保存失败");    }}