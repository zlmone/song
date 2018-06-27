package song.common.structure;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Stack;

public class ExpressionTree {
    private ExpressionNode root;

    public void create(String expression) {
        List<String> operators = new ArrayList<>();
        List<ExpressionNode> numbers = new ArrayList<>();
        String tmp="";
        char[] expressions=expression.toCharArray();
        for (char s : expressions) {
            if (s >= '0' && s <= '9') {
                tmp += s;
            } else {
                numbers.add(new ExpressionNode(tmp));
                tmp="";
                operators.add(s+"");
            }
        }
        numbers.add(new ExpressionNode(tmp));

        while (operators.size() > 0) {
            ExpressionNode left = numbers.remove(0);
            ExpressionNode right = numbers.remove(0);
            String operator = operators.remove(0);
            ExpressionNode node = new ExpressionNode(operator, left, right);
            numbers.add(0, node);
        }
        root = numbers.get(0);
    }

    private void build(String expression) {
        char[] expressions=expression.toCharArray();
        Stack<ExpressionNode> stack=new Stack<ExpressionNode>();
        for (int i = 0; i < expressions.length; i++) {
            char s = expressions[i];
            if(s=='/'||s=='+'||s=='*'||s=='-'){
                ExpressionNode left = stack.pop();
                ExpressionNode right = stack.pop();
                stack.push(new ExpressionNode(s+"",left,right));
            }else{
                stack.push(new ExpressionNode(s+""));
            }
        }
        root=stack.pop();
    }

    public String toString(ExpressionNode node) {
        String s="";
        if (node.getLeftChild()!=null) {
            s += toString(node.getLeftChild());
        }
        s += node.getData();
        if (node.getRightChild() != null) {
            s += toString(node.getRightChild());
        }
        return s;
    }

    public String toString() {
        return toString(root);
    }

    public static void main(String[] args) {
        ExpressionTree tree = new ExpressionTree();
        tree.build("1+34*45/6+7");
        String s = tree.toString();
        System.out.println(s);
    }
}
