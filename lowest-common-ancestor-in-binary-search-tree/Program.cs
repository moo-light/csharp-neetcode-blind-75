using Utils.Tree;

public class Solution
{
    /* find lowest common 
     * First find children is availiable
     * Second go lower left and right
     * Third check if both child have both children availiable then choose that as lowest
     */

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root.val == null) return null;
        // check if children p&q exist
        if (isChildrenHere(root, p) && isChildrenHere(root, q))
        {
            //go Lower
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left != null) return left;
            if (right != null) return right;
            return root;
        }
        return null;
    }
    public bool isChildrenHere(TreeNode root, TreeNode p)
    {
        if (p == null) return true;
        if (root == null) return false;
        if (root.val == p.val) return true;
        return isChildrenHere(root.left, p) || isChildrenHere(root.right, p);
    }

    public static void Main(string[] args)
    {
        var sol = new Solution();
        TreeNode root = TreeNode.CreateTree(new List<int?> { 5, 3, 8, 1, 4, 7, 9, null, 2 });
        root.Print();
        sol.LowestCommonAncestor(root, new TreeNode(3), new TreeNode(8))?.val?.Print();
        sol.LowestCommonAncestor(TreeNode.CreateTree(new List<int?> { 5, 3, 8, 1, 4, 7, 9, null, 2 }), new TreeNode(3), new TreeNode(4))?.val?.Print();
        sol.LowestCommonAncestor(TreeNode.CreateTree(new List<int?> { 5, 3, 8, 1, 4, 7, 9, null, 2 }), null, new TreeNode(8))?.val?.Print();
    }
}