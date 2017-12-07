package com.song.ui.builder;


import com.song.lang.StringHelper;
import com.song.util.MapHelper;


import java.util.HashMap;


public class TagBuilder {
    private HashMap<String, String> attrs = new HashMap<String, String>();

    public TagBuilder(String tagName) {
        this.tagName = tagName;
    }

    private String tagName;

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    private String content;

    public TagBuilder attr(String key, Object value) {
        attrs.put(key, StringHelper.wrap(value.toString(), "\""));
        return this;
    }

    public String toString(TagReanderMode mode) {
        switch (mode) {
            case StartTag:
                return String.format("<%s %s>", tagName, getAttributes());
            case SelfClosing:
                return String.format("<%s %s/>", tagName, getAttributes());
            case EndTag:
                return String.format("</%s>", tagName);
            default:
                return String.format("<%s %s>%s</%s>", tagName, getAttributes(), StringHelper.asEmpty(content), tagName);
        }
    }

    public String toString() {
        return toString(TagReanderMode.Normal);
    }

    //region 私有方法
    protected String getAttributes() {
        return MapHelper.join(attrs, "=", " ");
    }
    //endregion


}
