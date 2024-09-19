public class Solution
{
    //find the index of target in array of nums if not return -1
    public int Search(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length - 1;
        while (l != r)
        {
            int mid = (l + r) / 2;
            if (nums[mid] == target) return mid;
            //normal binary search
            if (nums[l] <= nums[mid])
            {
                if (nums[mid] < target || nums[l] > target)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            else
            {
                if (nums[mid] > target || nums[r]<target)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
        }
        if (nums[l] == target) return l;
        return -1;// will jump if while function stop
    }
    public static void Main(string[] args)
    {
        var sol = new Solution();
        int res;
        //res = sol.Search(new int[] { 4, 5, 6, 0, 1, 2, 3, }, 6);//RRL
        //Console.WriteLine(res);
        res = sol.Search(new int[] { 1, 3, 5, }, 1);//LL
        Console.WriteLine(res);
        res = sol.Search(new int[] { 1, 3, 5, }, 5);//RR
        Console.WriteLine(res);
        res = sol.Search(new int[] { 5, 1, 3, }, 5);//LL
        Console.WriteLine(res);
        res = sol.Search(new int[] { 5, 1, 3, }, 3);//RR
        Console.WriteLine(res);
        res = sol.Search(new int[] { 3, 5, 1, }, 3);//LL
        Console.WriteLine(res);
        res = sol.Search(new int[] { 3, 5, 1, }, 1);//RR
        Console.WriteLine(res);
        //res = sol.Search(new int[] { 4, 5, 0, 1, 2, 3 }, 2);
        //Console.WriteLine(res);
        //res = sol.Search(new int[] { 4, 5, 6, 7 }, 2);
        //Console.WriteLine(res);
        //res = sol.Search(new int[] { 0, 5, }, 2);
        //Console.WriteLine(res);
    }
}
