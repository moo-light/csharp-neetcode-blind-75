public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        foreach (var item in nums)
        {
            if (!dict.TryAdd(item, 1)) dict[item]++;
        }
        var res = new List<int>();
        var arr = dict.ToArray();
        for (int i = 0; i < dict.Count - 1; i++)
        {
            for (int j = i + 1; j < dict.Count; j++)
                if (arr[i].Value < arr[j].Value)
                {
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (k == 0) break;
            res.Add(arr[i].Key);
            k--;
        }
        return res.ToArray();
    }
    public static void Main()
    {
        var s = new Solution();
        var res = s.TopKFrequent(
            new int[] { 1, 2 }, 2
        );
        foreach (var item in res)
        {
            Console.WriteLine(item);
        }
    }
}
