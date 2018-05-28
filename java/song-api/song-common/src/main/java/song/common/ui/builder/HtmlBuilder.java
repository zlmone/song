package song.common.ui.builder;

import song.common.lang.StringHelper;
import song.common.util.MapHelper;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by song on 2017/9/21.
 */
public class HtmlBuilder extends  TagBuilder {
    private HashMap<String, String> styles = new HashMap<String, String>();
    private List classNames = new ArrayList<String>();

    public HtmlBuilder(String tagName) {
        super(tagName);
    }

    public TagBuilder css(String key, String value) {
        styles.put(key, value);
        return this;
    }

    public TagBuilder addClass(String className) {
        classNames.add(className);
        return this;
    }

    public TagBuilder removeClass(String className) {
        classNames.remove(className);
        return this;
    }

    @Override
    protected String getAttributes() {
        if (styles.size() > 0) {
            this.attr("style", getStyles());
        }
        if (classNames.size() > 0) {
            this.attr("class", StringHelper.join(" ", classNames));
        }
        return super.getAttributes();
    }

    //region 私有方法
    private String getStyles() {
        return MapHelper.join(styles, ":", ";");
    }
    //endregion
}
