package song.common.structure;

import java.util.Stack;

public class ExpressionTree extends BinaryTree {

    private int calculate(String operator, int num1, int num2) {
        switch (operator) {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                return num1 / num2;
        }
        return 0;
    }

    private void postBuild(String expression) {
        char[] expressions = expression.toCharArray();
        Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
        for (int i = 0; i < expressions.length; i++) {
            char s = expressions[i];
            if (s == '/' || s == '+' || s == '*' || s == '-') {
                BinaryTreeNode left = stack.pop();
                BinaryTreeNode right = stack.pop();
                stack.push(new BinaryTreeNode(s + "", left, right));
            } else {
                stack.push(new BinaryTreeNode(s + ""));
            }
        }
        this.setRoot(stack.pop());
    }


    public static void main(String[] args) {
        ExpressionTree tree = new ExpressionTree();
        tree.postBuild("1+34*45/6+7");
        String s = tree.inOrder();
        System.out.println(s);
    }
}
