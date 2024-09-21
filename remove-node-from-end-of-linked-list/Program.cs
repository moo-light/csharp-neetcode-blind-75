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
public class Solution
{
    //the subject tell us to reaverse the liskedlist then remove the nth node
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var curNode = head;
        var i = 0;
        while (curNode != null) { i++; curNode = curNode.next; };
        n = i - n;
        curNode = head;
        if (n == 0) return head.next;

        while (n > 1)
        {
            n--;
            Console.WriteLine(n);
            curNode = curNode.next;
        }
        if (curNode != null) 
        curNode.next = curNode.next.next;
        return head;
    }
    public static void Main(string[] args)
    {
        var sol = new Solution();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 1, 2, 3, 4, 5 }),5).Print();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 1, 2, 3, 4, 5 }), 1).Print();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 1, 2, 3, 4, 5 }), 2).Print();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 1, 2, 3, 4, 5 }), 3).Print();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 1, 2, 3, 4, 5 }), 4).Print();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 2 }), 1)?.Print();
        sol.RemoveNthFromEnd(new ListNode(new int[] { 1, 2 }), 2)?.Print();
    }
}
