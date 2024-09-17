public class Solution
{
    // 2 4 6 8 10 -> 10 8 6 4 2 
    // getLast last.next = parent 10.next = 8.next = null
    // last = parent  
    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return head;
        if (head.next == null) return head;

        ListNode parent;
        ListNode lastNode;
        ListNode result = GetParentOfLastNode(head).next;

        do
        {
            parent = GetParentOfLastNode(head);
            lastNode = parent.next;
            lastNode.next = parent;
            lastNode = parent;
            parent.next = null;
        } while (head != parent);
        return result;
    }
    public ListNode ReverseListNeetCodeSolution(ListNode head)
    {

        ListNode parent = null;
        ListNode current = head;

        while (current != null)
        {
            var temp = current.next;
            current.next = null;
            parent = current;
            current = temp;
        }
        return parent;
    }
    // 2 4 6 8 10
    // 4 6 8 10
    // 6 8 10
    // 8 10
    // 10
    // 8.next.next = 10.next = 8
    // 8.next = null
    public ListNode ReverseListNeetCodeSolutionRecursive(ListNode head)
    {
        if (head == null) return head;
        var newHead = head;
        if (head.next != null)
        {
            newHead = ReverseListNeetCodeSolutionRecursive(head.next);
            head.next.next = head;
        }
        head.next = null;
        return newHead;
    }
    public ListNode GetParentOfLastNode(ListNode head)
    {
        while (head.next.next != null)
        {
            head = head.next;
        }
        return head;
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        //prev if(o.next = current) -> prev
    }
    public static ListNode CreateNode(int[] arr)
    {
        if (arr.Length == 0) return null;
        var node = new ListNode();
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
    public static void Main()
    {
        var s = new Solution();
        var node = CreateNode(new int[] { 2, 4, 6, 8, 10 });
        var res = s.ReverseListNeetCodeSolutionRecursive(node);
        s.ReverseList(CreateNode(Array.Empty<int>()));
        s.ReverseList(CreateNode(new int[] { 1 }));
    }
}
    