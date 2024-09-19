public class Solution
{
    // 3 4 5 6 1 2 
    // l 0 r 5
    // l 3 r 5
    // l=4 r=5
    // l=4 r=4
    // 0 1 (1 + 0)/2==0
    public int FindMin(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;
        //4, 5, 0, 1, 2, 3
        while (l != r)
        {
            if (nums[l] <= nums[r])
            {
                return nums[l];
            }
            int mid = (l + r) / 2;

            if (nums[mid] > nums[r])
            {
                l = mid + 1;
            }
            else
            {
                r = mid;
            }
        }
        return nums[l];// will jump if while exit
    }
    public static void Main(string[] args)
    {
        var sol = new Solution();
        var res =
        sol.FindMin(new int[] { 3, 4, 5, 6, 1, 2 });
        Console.WriteLine(res);
        res = sol.FindMin(new int[] { 4, 5, 0, 1, 2, 3 });
        Console.WriteLine(res);
        res = sol.FindMin(new int[] { 4, 5, 6, 7 });
        Console.WriteLine(res);
        res = sol.FindMin(new int[] { 0, 5, });
        Console.WriteLine(res);
    }
}
