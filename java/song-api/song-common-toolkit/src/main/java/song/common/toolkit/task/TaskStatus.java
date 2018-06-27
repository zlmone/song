package song.common.toolkit.task;import java.util.HashMap;import java.util.Map;/** * description: * author:          song * createDate:      2018/6/27 */public enum TaskStatus {    //待处理    pending(0,"待处理"),    //处理中    processing(1,"处理中"),    //处理成功    success(2,"处理成功"),    //处理失败    fail(3,"处理失败"),    //待重试    retry(4,"待重试");    private int value;    private String text;    private static Map<Integer, TaskStatus> enumMap = new HashMap<>();    static {        for (TaskStatus status : TaskStatus.values()) {            enumMap.put(status.getValue(), status);        }    }    public static TaskStatus valueOf(int value){        return enumMap.get(value);    }    TaskStatus(int value,String text) {        this.value = value;        this.text=text;    }    public int getValue() {        return value;    }    public void setValue(int value) {        this.value = value;    }    public String getText() {        return text;    }    public void setText(String text) {        this.text = text;    }}