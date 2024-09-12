using System.Net.Security;
using System.Threading.Channels;

public class Solution
{
    public List<List<int>> ThreeSum(int[] nums)
    {
        int[,,] arr = new int[nums.Length, nums.Length, nums.Length];
        var result = new List<List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                for (int k = 0; k < nums.Length; k++)
                    if (i > j && j > k)
                    {
                        arr[i, j, k] = nums[i] + nums[j] + nums[k];
                        if (arr[i, j, k] == 0)
                        {
                            var item = new List<int>() { nums[i], nums[j], nums[k] };

                            item.Sort();
                            if (!result.Any(x => x[0] == item[0] && x[1] == item[1] && x[2] == item[2]))
                                result.Add(item);
                        }
                    }//Console.Write("{0} ",arr[i,j]);
            }//Console.WriteLine();
        }
        return result;
    }
    //this is wrong can't continue
    public List<List<int>> ThreeSumAttempt2(int[] num)
    {
        var result = new List<List<int>>();

        var nums = new List<int>();
        var pos = new List<int>();
        for (int i = 0; i < num.Length; i++)
        {
            if (!nums.Contains(num[i]))
            {
                nums.Add(num[i]);
                pos.Add(i);
            }
        }
        for (int i = 0; i < nums.Count; i++)
        {
            int item = nums[i];
            Console.Write(item+":" + pos[i] + ":" + num[pos[i]] +" ");
        }
        Console.WriteLine();
        int[,] arr = new int[nums.Count, nums.Count];
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = 0; j < nums.Count; j++)
            {
                if (i <= j)
                {
                    continue;
                }

                arr[i, j] = nums[i] + nums[j];
                for (int k = 0; k < nums.Count; k++)
                {
                    if (j <= k) continue; 

                    if (nums[k] + arr[i, j] == 0)
                    {
                        Console.WriteLine($"{pos[i]} {pos[j]} {pos[k]}P");
                        var sum = new List<int>()
                        {
                            num[pos[i]],
                            num[pos[j]],
                            num[pos[k]]
                        };
                        result.Add(sum);
                    }
                }
            }
        }
        return result;
    }

    public static void Main()
    {
        var s = new Solution();
        var res = s.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
        var res2 = s.ThreeSumAttempt2(new int[] { -1, 0, 1, 2, -1, -4 });
        Action<List<int>> print = x => Console.WriteLine($"{x[0]} {x[1]} {x[2]}");
        res.ForEach(print);
        //res2.ForEach(print);
    }
}