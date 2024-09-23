using System.Collections;
using Utils.Tree;
public class Solution
{
    //try dfs
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return IsSameTreeBFS(p, q);
        if (p == null && q == null) return true;
        if (p != null && q != null && p.val == q.val)
        {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        return false;
    }
    //try bfs if wanted 
    public bool IsSameTreeBFS(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        var q1 = new Queue<TreeNode>();
        var q2 = new Queue<TreeNode>();
        q1.Enqueue(p);
        q2.Enqueue(q);
        var (list1, list2) = (new List<TreeNode>(), new List<TreeNode>());
        while (q1.Count != 0)
        {
            var curr = q1.Dequeue();
            var cur = q2.Dequeue();
            if (curr != null)
            {
                q1.Enqueue(curr.left);
                q1.Enqueue(curr.right);
            }
            if (cur != null)
            {
                q2.Enqueue(cur.left);
                q2.Enqueue(cur.right);
            }
            list1.Add(curr);
            list2.Add(cur);
        }

        if (list1.Count != list2.Count) return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i]?.val != list2[i]?.val) return false;
        }
        return true;
    }
    public static void Main()
    {
        var sol = new Solution();
        sol.IsSameTree(
            TreeNode.CreateTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }),
            TreeNode.CreateTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })
            ).Print();
        sol.IsSameTree(
            TreeNode.CreateTree(new int[] { 4, 3 }),
            TreeNode.CreateTree(new List<int?> { 4, null, 3 })
            ).Print();
        sol.IsSameTree(
            TreeNode.CreateTree(new int[] { 1, 2, 3 }),
            TreeNode.CreateTree(new List<int?> { 1, 3, 2 })
            ).Print();
    }
}