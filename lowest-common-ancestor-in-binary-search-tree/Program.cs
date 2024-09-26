using Utils.Tree;

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {

    }

    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.LowestCommonAncestor(TreeNode.CreateTree(new List<int?> { 5, 3, 8, 1, 4, 7, 9, null, 2 }), new TreeNode(3), new TreeNode(8)).Print();
        sol.LowestCommonAncestor(TreeNode.CreateTree(new List<int?> { 5, 3, 8, 1, 4, 7, 9, null, 2}), new TreeNode(3), new TreeNode(4)).Print();
    }
}