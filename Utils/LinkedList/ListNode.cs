using System.Text;

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
    public static ListNode? CreateNode(int[] arr, ListNode node = null)
    {
        node ??= new ListNode();
        int i = 0;
        if (arr == null || arr.Length == 0) return null;
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
  
    public override string ToString()
    {
        if (this == null) return "";

        var sb = new StringBuilder();
        var curr = this;
        sb.Append("[");
        while (curr != null)
        {
            sb.Append(curr.val);
            if (curr?.next != null)
                sb.Append(',');
            curr = curr.next;
        }
        sb.Append("]");
        return sb.ToString();
    }
}