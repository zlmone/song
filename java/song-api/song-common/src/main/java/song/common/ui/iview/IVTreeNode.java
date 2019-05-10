package song.common.ui.iview;

import song.common.ui.tree.TreeNode;

import java.util.ArrayList;
import java.util.List;

/**
 * description:
 * author:          song
 * createDate:      2019/5/10
 */

public class IVTreeNode extends TreeNode {
    private boolean disableCheckbox;
    private boolean selected;
    private String render;
    private String data;
    private List<IVTreeNode> children;

    public IVTreeNode() {
    }

    public IVTreeNode(String id, String title, String data) {
        super(id, title);
        this.data = data;
    }

    public IVTreeNode(String id, String title, String data, boolean expand) {
        super(id, title, expand);
        this.data = data;
    }

    public IVTreeNode(String id, String title) {
        super(id, title);
    }

    public IVTreeNode(String id, String title, boolean expand) {
        super(id, title, expand);
    }

    public IVTreeNode(String id, String title, boolean expand, boolean disabled) {
        super(id, title, expand, disabled);
    }

    public boolean isDisableCheckbox() {
        return disableCheckbox;
    }

    public void setDisableCheckbox(boolean disableCheckbox) {
        this.disableCheckbox = disableCheckbox;
    }

    public boolean isSelected() {
        return selected;
    }

    public void setSelected(boolean selected) {
        this.selected = selected;
    }

    public String getRender() {
        return render;
    }

    public void setRender(String render) {
        this.render = render;
    }

    public List<IVTreeNode> getChildren() {
        return children;
    }

    public void setChildren(List<IVTreeNode> children) {
        this.children = children;
    }

    public void addChildren(IVTreeNode treeNode) {
        if (this.children == null) {
            this.children = new ArrayList<>();
        }
        this.children.add(treeNode);
    }

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }
}
