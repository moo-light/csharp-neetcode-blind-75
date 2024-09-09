public class Solution
{
    // solve with no disvision operator
    public int[] ProductExceptSelf(int[] nums)
    {
        // generate all array with 1
        var arr1 = new int[nums.Length]; 
        var arr2 = new int[nums.Length]; 
        for (int i = 0; i < arr1.Length; i++)
        {
            (arr1[i], arr2[i]) = (1,1);
        }
        //execute first loop
        for (int i = 1; i < nums.Length; i++)
        {
            arr1[i] = arr1[i-1]*nums[i - 1];
        }
        for (int i = nums.Length-2; i >=0; i--)
        {
            arr2[i] = arr2[i+1]*nums[i + 1];

        }
        return arr1.Select((x,ind)=>x * arr2[ind]).ToArray();
    }
    public static void Main()
    {
        var sol = new Solution();
        var arr1 = sol.ProductExceptSelf(new int[] { 1, 2, 2, 3, 3, 3 });
        foreach (var item in arr1)
        {
            Console.WriteLine(item);
        }
    }
}
