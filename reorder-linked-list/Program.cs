public class Solution
{
    // 7 -> [0,1,2,3,4,5,6]
    // -> [0,6,1,5,2,4,3]
    // [2 4 6 8 10]
    // 2.next=last.next = 4.next = 8.next = 6
    // 2 4 6 8 10

    // get last 10
    // get parent 8.next -> null -> last node
    // last.next = first.next  10.next = 4
    // first.next = last 2.next = 10
    // 2.next = 10.next = 4
    // 2 10 4 6 8
    // 4.next = 8.next = 6
    public void ReorderList(ListNode head)
    {
        if (head == null) return;
        if (head.next == null) return;
        Func<ListNode, ListNode> getLastNode = (ListNode head) =>
        {
            while (head.next != null)
            {
                head = head.next;
            }
            return head;
        };
        Func<ListNode, ListNode, ListNode> getParentNode = (ListNode head, ListNode curNode) =>
        {
            while (head.next != curNode)
            {
                head = head.next;
            }
            return head;
        };
        var firstNode = head;
        var lastNode = getLastNode(head);
        do
        {
            // get parent =  8.next set to null became last node
            // last.next = first.next  10.next = 4
            // first.next = last 2.next = 10
            // 2.next = 10.next = 2.next.next 
            var parentNode = getParentNode(head, lastNode);
            parentNode.next = null;
            lastNode.next = firstNode.next;
            firstNode.next = lastNode;
            firstNode = firstNode.next.next;
            lastNode = parentNode;
        } while (lastNode != firstNode && firstNode.next != lastNode);

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
        var node2 = CreateNode(new int[] { 2, 4, 6, 8 });
        s.ReorderList(node);
        s.ReorderList(node2);
        s.ReorderList(CreateNode(new int[] { 1 }));
    }
}
