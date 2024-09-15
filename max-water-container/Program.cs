public class Solution
{
    public static int MaxArea(int[] heights)
    {
        int l = 0, r = heights.Length-1;
        int maxArea = 0;
        do
        {
            var area = CalculateArea(l, r, heights);
            maxArea = Math.Max(area, maxArea);
            if (heights[r] > heights[l])
            {
                l++;
            }
            else
            {
                r--;
            }
        } while (l < r);
        return maxArea;
    }
    public static int CalculateArea(int l, int r, int[] heights)
    {

        return (r - l) * Math.Min(heights[l], heights[r]);
    }
    public static void Main()
    {
        Console.WriteLine(MaxArea(new int[] { 1, 7, 2, 5, 4, 7, 3, 6 }));
    }
}
