package song.common.result;/** * description: * author:          song * createDate:      2018/4/17 */public class ActionResult extends BaseResult {    private Object data;    public ActionResult(boolean success) {        super(success);    }    public ActionResult(boolean success, String code) {        super(success, code);    }    public ActionResult(boolean success, String code, String msg) {        super(success, code, msg);    }    public ActionResult() {    }    public ActionResult(boolean success, Object data) {        super(success);        this.data = data;    }    public ActionResult(boolean success, String msg, Object data) {        super(success, msg);        this.data = data;    }    public ActionResult(boolean success, String code, String msg, Object data) {        super(success, code, msg);        this.data = data;    }    public ActionResult(Object data) {        this.data = data;    }    public Object getData() {        return data;    }    public void setData(Object data) {        this.data = data;    }}