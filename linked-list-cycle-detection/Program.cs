using System.Diagnostics;

namespace linked_list_cycle_detection
{
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            var curr = head;
            var set = new HashSet<ListNode>();
            while (curr.next != null)
            {
                if(set.Contains(curr)) return true;
                set.Add(curr);
                curr = curr.next;
            }
            return false;
        }
        public bool TestCycle(ListNode head, int index)
        {
            var indexNode = head;
            var lastNode = head;
            var i = 0;
            while (lastNode.next != null)
            {
                lastNode = lastNode.next;
                if (i == index) continue;
                if (i++ < index)
                {
                    indexNode = lastNode;
                }
            }
            if (i == index) lastNode.next = indexNode;
            return HasCycle(head);
        }
        public static void Main(string[] args)
        {
            var sol = new Solution();
            sol.TestCycle(new ListNode(new int[] { 1, 2, 3, 4 }), 3).Print();
            sol.TestCycle(new ListNode(new int[] { 1, 2 }), 0).Print();
            sol.TestCycle(new ListNode(new int[] { 1, 2 }), 1).Print();
            sol.TestCycle(new ListNode(new int[] { 1, 2 }), 2).Print();
        }
    }
}