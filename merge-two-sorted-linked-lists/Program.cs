public class Solution
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        public ListNode(int[] arr)
        {
            CreateNode(arr, this);
        }
        public ListNode CreateNode(int[] arr, ListNode node = null)
        {
            node ??= new ListNode();
            int i = 0;
            var newNode = node;
            while (i < arr.Length)
            {
                newNode.val = arr[i++];
                if (i < arr.Length)
                    newNode.next = new ListNode();
                newNode = newNode.next;
            }
            return node;
        }
        public void Print()
        {
            var curNode = this;
            while (curNode != null)
            {
                Console.Write(curNode + " ");
                curNode = curNode.next;
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            return $"{val}";
        }
    }
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null) return null;
        ListNode? result = new ListNode();
        var curNode = result;
        while (list1 != null || list2 != null)
        {
            
            while (list2 != null && (list1 == null || list1.val > list2.val))
            {
                curNode.val = list2.val;
                list2 = list2.next;
                if (list1 == null && list2 == null ) continue;
                curNode.next = new ListNode();
                curNode = curNode.next;
            }
            if (list1 == null) continue;
            curNode.val = list1.val;
            list1 = list1.next;
            if (list1 == null && list2 == null) continue;
            curNode.next = new ListNode();
            curNode = curNode.next;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        var sol = new Solution();
        var res = sol.MergeTwoLists(new ListNode(new int[] { 1, 2, 4 }), new ListNode(new int[] { 1, 3, 5,5 }));
     sol.MergeTwoLists(new ListNode(new int[] { 1, 2, 4,5,5 }), new ListNode(new int[] { 1, 3, 5,5 })).Print();
        res?.Print();
        sol.MergeTwoLists(new ListNode(new int[] { 2, }), new ListNode(new int[] { 1, })).Print();
        sol.MergeTwoLists(new ListNode(new int[] { 2,4 }), new ListNode(new int[] { 1, })).Print();
    }
}