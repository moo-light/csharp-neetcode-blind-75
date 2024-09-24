using Utils.Tree;

public class Solution
{
    // 1 2 3 4 5
    // 2 4 5
    //
    // find 2 4 5 in 1 2 3 4 5
    // dfs
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null && subRoot == null) return true;
        if (root == null && subRoot != null) return false;

        if (root.val == subRoot.val && IsSameTree(root, subRoot))
        {
            return true;
        }
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);

    }
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        //return IsSameTreeBFS(p, q);
        if (p == null && q == null) return true;
        if (p != null && q != null && p.val == q.val)
        {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        return false;
    }
    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.IsSubtree(TreeNode.CreateTree(new int[] { 1, 2, 3, 4, 5 }), TreeNode.CreateTree(new int[] { 2, 4, 5 })).Print();
        sol.IsSubtree(TreeNode.CreateTree(new List<int?> { 1, 2, 3, 4, 5, null, null, 6 }), TreeNode.CreateTree(new int[] { 2, 4, 5 })).Print();
    }
}