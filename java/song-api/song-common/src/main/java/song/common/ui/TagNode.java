package song.common.ui;import java.util.ArrayList;import java.util.HashMap;import java.util.List;/** * description: * author:          song * createDate:      2017/10/27 */public class TagNode {    private String name;    private HashMap<String, String> attributes = new HashMap<String, String>();    private String text;    private List<TagNode> childNodes = new ArrayList<TagNode>();    public TagNode(String name) {        this.name = name;    }    public TagNode() {    }    public void addAttribute(String key, String value) {        attributes.put(key, value);    }    public String getAttribute(String key) {        return attributes.get(key);    }    public void appendChild(TagNode node) {        childNodes.add(node);    }    public String getName() {        return name;    }    public void setName(String name) {        this.name = name;    }    public HashMap<String, String> getAttributes() {        return attributes;    }    public void setAttributes(HashMap<String, String> attributes) {        this.attributes = attributes;    }    public String getText() {        return text;    }    public void setText(String text) {        this.text = text;    }    public List<TagNode> getChildNodes() {        return childNodes;    }    public void setChildNodes(List<TagNode> childNodes) {        this.childNodes = childNodes;    }}