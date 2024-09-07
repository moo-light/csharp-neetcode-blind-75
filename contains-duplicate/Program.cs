public class Program
{
    public bool hasDuplicate(int[] nums)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            var check = count.TryAdd(num, 1);
            if (!check) return true;
        }
        return false;
    }
    private static void Main(string[] args)
    {

        var p = new Program();
        Console.WriteLine(p.hasDuplicate([1, 2, 3, 3]));
        Console.WriteLine(p.hasDuplicate([1, 2, 3, 4]));
    }
}