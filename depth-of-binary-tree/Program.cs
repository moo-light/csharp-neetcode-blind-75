using System.Collections;
using Utils.Tree;

public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        //try dfs backtracking
        return FindMaxDepth(root, 0);
    }

    private int FindMaxDepth(TreeNode root, int count)
    {
        if (root == null) return count;
        count++;
        var maxx = Math.Max(
            FindMaxDepth(root.left, count),
            FindMaxDepth(root.right, count)
            );
        return maxx;
    }

    public static void Main()
    {
        var sol = new Solution();
        TreeNode root = TreeNode.CreateTree(new List<int?>() { 1, 2, 3, null, null, 4,});
        root.Print();
        sol.MaxDepth(root).Print();
        sol.MaxDepth(TreeNode.CreateTree(new int[] {})).Print();
    }
}
