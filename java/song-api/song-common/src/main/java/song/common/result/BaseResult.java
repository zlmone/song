package song.common.result;/** * description: * author:          song * createDate:      2018/4/17 */public class BaseResult {    private boolean success=true;    private String code=ResultCode.ok;    private String msg;    public BaseResult() {    }    public BaseResult(boolean success) {        this.success = success;    }    public BaseResult(boolean success, String code) {        this.success = success;        this.code = code;    }    public BaseResult(boolean success, String code, String msg) {        this.success = success;        this.code = code;        this.msg = msg;    }    public boolean isSuccess() {        return success;    }    public void setSuccess(boolean success) {        this.success = success;    }    public String getCode() {        //防止错误的场景不设置编码问题        if(!this.success && code==ResultCode.ok){            code=ResultCode.error;        }        return code;    }    public void setCode(String code) {        this.code = code;    }    public String getMsg() {        return msg;    }    public void setMsg(String msg) {        this.msg = msg;    }}