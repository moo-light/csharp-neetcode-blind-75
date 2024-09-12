int LongestConsecutive(int[] nums)
{
    int i;
    if (nums.Length == 0) return 0;
    for (i = 0; i < nums.Length - 1; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] > nums[j])
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }
    }
    foreach (var item in nums.ToList())
    {
        Console.Write(item + " ");
    }
    int count = 1, maxx = 1;
    for (i = 0; i < nums.Length - 1; i++)
    {
        if (nums[i] == nums[i + 1]) continue;
        if (nums[i] + 1 < nums[i + 1])
        {
            count = 1;
        }
        else
            count++;
        if (count > maxx) maxx = count;

    }
    return maxx;

}

Console.WriteLine(NeetCodeSolutionLongestConsecutive(new int[] { }));
Console.WriteLine(NeetCodeSolutionLongestConsecutive(new int[] { 0 }));
Console.WriteLine(NeetCodeSolutionLongestConsecutive(new int[] { 0, -1 }));
Console.WriteLine(NeetCodeSolutionLongestConsecutive(new int[] { 0, 3, 2, 5, 4, 6, 1, 1 }));
Console.WriteLine(NeetCodeSolutionLongestConsecutive(new int[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 }));

int NeetCodeSolutionLongestConsecutive(int[] nums)
{
    if (nums.Length == 0) return 0;

    // using HashSet find the longest 1 -> 2->3 ->4
    // learning: what the heck is HEAP
    int maxx = 0;
    var set = new HashSet<int>();
    int i;
    for (i = 0; i < nums.Length; i++)
        set.Add(nums[i]);
    i = 0;
    do
    {
        // find the smaller number so that we dont waste the time iterating though all the number
        if (!set.Contains(nums[i] - 1)) // do i need this? (technically i dont but i have to use it for the speed)
        {
            var count = 1;
            var curValue = nums[i];
            while (set.Contains(curValue + 1))
            {
                count++; curValue++;
            }
            maxx = Math.Max(count, maxx);
        }
        i++;
        //Console.WriteLine(i);
    } while (i < nums.Length);
    return maxx;
}