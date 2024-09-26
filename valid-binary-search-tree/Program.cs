using Utils.Tree;

public class Solution
{
    //dfs
    /* find if Tree is valid binary search tree
     * condition: left < mid <right and left is also bst
     * First: check left < mid and right > mid
     * Second: check left and right is BST
     * IF: left == null || right == null return true because there's nothing to check
     */
    public bool IsValidBST(TreeNode root)
    {
        if (root == null) return true;
        return Valid(root, int.MinValue,int.MaxValue);
    }
    public bool Valid(TreeNode node, int min, int max)
    {
        if (node == null) return true;
        if (!(min < node.val && node.val < max))
        {
            return false;
        }

        return Valid(node.left, min, node.val)&&Valid(node.right, node.val,max);
    }
    //bfs if wanted
    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.IsValidBST(TreeNode.CreateTree(new List<int?> { 2,1, 3 })).Print();
        TreeNode root = TreeNode.CreateTree(new List<int?> { 5, 4, 6, null, null, 3, 7 });
        root.Print();
        sol.IsValidBST(root).Print();
    }
}