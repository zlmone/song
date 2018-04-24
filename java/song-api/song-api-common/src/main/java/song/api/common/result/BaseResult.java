package song.api.common.result;/** * description: * author:          song * createDate:      2018/4/17 */public class BaseResult {    private boolean success=true;    private String code=ResultCode.OK;    private String msg;    public BaseResult() {    }    public BaseResult(boolean success) {        this.success = success;    }    public BaseResult(boolean success, String msg) {        this.success = success;        this.msg = msg;    }    public BaseResult(boolean success, String code, String msg) {        this.success = success;        this.code = code;        this.msg = msg;    }    public boolean isSuccess() {        return success;    }    public void setSuccess(boolean success) {        this.success = success;    }    public String getCode() {        return code;    }    public void setCode(String code) {        this.code = code;    }    public String getMsg() {        return msg;    }    public void setMsg(String msg) {        this.msg = msg;    }}