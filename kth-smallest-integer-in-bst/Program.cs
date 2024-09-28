using Utils.Tree;

public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        //var list = new List<int>();
        //DFS(root, list, k);
        //list.Print();
        //return list[k-1];
        return FindKNeetCodeSolution(root, k);
    }
    // should find better solution
    private void DFS(TreeNode curr, List<int> list, int k)
    {
        if (curr == null) return;
        DFS(curr.left, list, k);
        list.Add(curr.val);
        DFS(curr.right, list, k);
    }

    //this solution will find K instantly and  not wait for the DFS to finish
    int FindKNeetCodeSolution(TreeNode root, int k)
    {
        var st = new Stack<TreeNode>();
        var curr = root;
        while (curr != null ||st.Count>0)
        {
            //traversal to the left until end of curr
            //this will not have null in stack
            while (curr != null)
            {
                st.Push(curr);
                curr = curr.left;
            }
            curr = st.Pop();//pop every loop
            k--;
            if (k == 0) return curr.val;
            //curr can be null but if stack still have number it will continue
            curr = curr.right;
        }
        return -1;
    }



    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.KthSmallest(new TreeNode(new int[] { 2, 1, 3 }).Print(), 1).Print();
        sol.KthSmallest(new TreeNode(new List<int?> { 4, 3, 5, 2, null }).Print(), 4).Print();
        sol.KthSmallest(new TreeNode(new List<int?> { 5, 2, 8, 1, 4, 6, 9, null, null, 3, null, null, 7 }).Print(), 4).Print();
    }
}