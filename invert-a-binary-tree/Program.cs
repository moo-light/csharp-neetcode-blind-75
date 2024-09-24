using Utils.Tree;

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        var q = new Queue<TreeNode>();
        if (root != null) q.Enqueue(root);
        while (q.Count != 0)
        {
            var curr = q.Dequeue();
            (curr.left, curr.right) = (curr.right, curr.left);
            if (curr.left != null) q.Enqueue(curr.left);
            if (curr.right != null) q.Enqueue(curr.right);

        }

        return root;
    }
    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.InvertTree(TreeNode.CreateTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 })).Print();
        sol.InvertTree(TreeNode.CreateTree(new int[] {
            3,2,1
 })).Print(); sol.InvertTree(TreeNode.CreateTree(new int[] {
 }))?.Print();
    }
}
