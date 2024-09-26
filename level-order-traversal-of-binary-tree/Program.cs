using Utils.Tree;

public class Solution
{

    public List<List<int>> LevelOrder(TreeNode root)
    {
        var res = new List<List<int>>();
        var queue = new Queue<TreeNode>();
        if(root !=null) queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var list = new List<int>();
            var n = queue.Count;
            for (int i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                // change from node.val.Value to node.val to be able to run in neetcode
                list.Add(node.val.Value); 
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            res.Add(list);
        }

        return res;
    }

    public static void Main(string[] args)
    {
        var sol = new Solution();
        TreeNode root = TreeNode.CreateTree(new List<int?> { 1, 2, 3, 4, 5, 6, 7 });
        root.Print();
        sol.LevelOrder(root).Print();
    }
}