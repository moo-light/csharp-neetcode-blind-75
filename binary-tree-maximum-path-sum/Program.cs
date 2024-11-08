
using Utils.Tree;

public class Solution
{
    public int MaxPathSum(TreeNode root)
    {
        int max = root.val;
        FindMaxSum(root, ref max);
        return max;
    }
    // i wonder how i can figure this solution out on my own
    private int FindMaxSum(TreeNode root, ref int max)
    {
        if (root == null) return 0;

        var left = Math.Max(FindMaxSum(root.left, ref max), 0);
        var right = Math.Max(FindMaxSum(root.right, ref max), 0);

        max = Math.Max(max, root.val + left + right);
        Console.WriteLine(max);
        return root.val + Math.Max(left, right);
    }
        
    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.MaxPathSum(new TreeNode(new List<int?> { -15, 10, 20, null, null, 15, 5, -5 }).Print()).Print();
        sol.MaxPathSum(new TreeNode(new List<int?> { -5 })).Print();
    }
}
