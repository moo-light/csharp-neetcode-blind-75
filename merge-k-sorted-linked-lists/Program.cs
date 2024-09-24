public class Solution
{

    public ListNode MergeKLists(ListNode[] lists)
    {
        return MergeKLists(0, null, lists.ToList());
    }
    public ListNode MergeKLists(int index, ListNode resultNode, List<ListNode> lists)
    {
        if (index > lists.Count || index < 0) throw new Exception("Invalid index!");
        if (lists == null) return resultNode;
        if (lists.Count == index) return resultNode;

        ListNode curr = resultNode;
        ListNode newNode = lists[index];
        if (index == 0)
        {
            resultNode = new ListNode(0, newNode);// create a tempnode 0 to remove later
            return MergeKLists(index + 1, resultNode, lists).next;// remove the temp node
        }
        else
        {
            while (curr != null)
            {
                var temp = curr;
                curr = curr.next;

                if (curr == null)
                {
                    temp.next = newNode;
                    continue;
                }
                //only run when curr is last
                while (newNode?.val <= curr?.val)
                {
                    temp.next = newNode;
                    newNode = newNode.next; //shifting
                    temp.next.next = curr;
                    temp = temp.next;
                }
            }
            MergeKLists(index + 1, resultNode, lists);
        }
        return resultNode;
    }
    public static ListNode[] CreateListNodeArray(int[][] array)
    {
        var result = new ListNode[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = ListNode.CreateNode(array[i]);
        }
        return result;
    }
    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.MergeKLists(CreateListNodeArray(new int[][] { }));
        sol.MergeKLists(CreateListNodeArray(new int[][] { Array.Empty<int>() }));
        sol.MergeKLists(CreateListNodeArray(new int[][]
        {
            new int[]{-4,-2,1,3,5 },
            //new int[]{-1,24,25},
            //new int[]{7}
            //,new int[]{8},new int[]{7},
            //new int[]{6},
            new int[]{-7,-8}
            //,new int[]{-7},
            //new int[]{-6}
        })).Print();
    }
}