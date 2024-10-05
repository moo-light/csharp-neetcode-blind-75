using Utils.Tree;

public class Solution
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {


        return Build(preorder, inorder);
    }
    // this is too hard i don't really understand preorder and inorder reverse
    // i understand how i should find mid
    // but i can't find a way to traversal with left and right
    // every recall of Build() create a smaller preorder and inorder
    private TreeNode Build(int[] pre, int[] @in)
    {
        if (pre.Length == 0 ) return null;
        var node = new TreeNode(pre[0]);
        var mid = Array.IndexOf(@in, pre[0]);
        node.left = Build(pre.Skip(1).Take(mid).ToArray(), @in.Take(mid).ToArray());
        node.right = Build(pre.Skip(mid + 1).ToArray(), @in.Skip(mid + 1).ToArray());
        return node;
    }

    public static void Main(string[] args)
    {
        var sol = new Solution();
        //TreeNode tree = new TreeNode(new List<int?> { 2, 1, 4, null, null, 3 }).Print();
        TreeNode tree = new TreeNode(new List<int?> { 5, 2, 8, 1, 4, 6, 9, null, null, 3, null, null, 7 }).Print();

        sol.BuildTree(tree.PreOrder().ToArray(), tree.InOrder().ToArray()).Print();
    }
}