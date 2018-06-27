package song.common.structure;

public class ExpressionNode {
    private String data;
    private ExpressionNode leftChild;
    private ExpressionNode rightChild;

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }

    public ExpressionNode getLeftChild() {
        return leftChild;
    }

    public void setLeftChild(ExpressionNode leftChild) {
        this.leftChild = leftChild;
    }

    public ExpressionNode getRightChild() {
        return rightChild;
    }

    public void setRightChild(ExpressionNode rightChild) {
        this.rightChild = rightChild;
    }

    public ExpressionNode() {
    }

    public ExpressionNode(String data) {
        this.data = data;
    }

    public ExpressionNode(String data, ExpressionNode leftChild, ExpressionNode rightChild) {
        this.data = data;
        this.leftChild = leftChild;
        this.rightChild = rightChild;
    }
}
