package song.common.ui.builder;

import song.common.lang.StringHelper;
import song.common.util.MapHelper;

import java.util.HashMap;


public class TagBuilder {
    private HashMap<String, String> attrs = new HashMap<String, String>();
    private String tagName;
    private String content;

    public TagBuilder(String tagName) {
        this.tagName = tagName;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public TagBuilder attr(String key, Object value) {
        attrs.put(key, StringHelper.wrap(value.toString(), "\""));
        return this;
    }

    public String toString(TagReanderMode mode) {
        switch (mode) {
            case start:
                return String.format("<%s %s>", tagName, getAttributes());
            case selfClosing:
                return String.format("<%s %s/>", tagName, getAttributes());
            case end :
                return String.format("</%s>", tagName);
            default:
                return String.format("<%s %s>%s</%s>", tagName, getAttributes(), StringHelper.asEmpty(content), tagName);
        }
    }

    public String toString() {
        return toString(TagReanderMode.normal);
    }

    //region 私有方法
    protected String getAttributes() {
        return MapHelper.join(attrs, "=", " ");
    }
    //endregion


}
