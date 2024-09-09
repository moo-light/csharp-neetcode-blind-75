int MaxProfit(int[] prices)
{
    int minn = int.MaxValue;
    int maxx = 0;
    // brute force
    for (int i = 0; i < prices.Length-1; i++)
    {
        for (int j = i+1; j < prices.Length; j++)
        {
            if (prices[j] - prices[i] > maxx) maxx = prices[j] - prices[i]; 
        }
    }
    return maxx;
}
int MaxProfitNeetCodeSolution(int[] prices)
{
    int l = 0;
    int maxx = 0;
    // brute force
    for (int r = 1; r < prices.Length - 1; r++)
    {
        if (prices[l] < prices[r])
        {
            maxx = prices[r] - prices[l];
        }
        else
        {
            l = r;
        }
    }
    return maxx;
}
Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
Console.WriteLine(MaxProfit(new int[] { 2,4,1 }));
Console.WriteLine(MaxProfitNeetCodeSolution(new int[] { 3,2,6,5,7,1 }));