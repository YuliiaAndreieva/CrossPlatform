namespace ClassLib.Lab2;

public static class SocksPurchaseService
{
    public static int CalculateMinimumCost(int n, List<(int ai, int bi)> suppliers)
    {
        if (n <= 0)
            throw new ArgumentOutOfRangeException(nameof(n), "The number of socks should be greater than zero.");
        
        if (suppliers is null || suppliers.Count == 0)
            throw new ArgumentException("Suppliers list cannot be empty.");
        
        const int inf = int.MaxValue;
        int maxAi = suppliers.Max(supplier => supplier.ai);
        int maxN = n + maxAi;
        int[] dp = new int[maxN + 1];
        Array.Fill(dp, inf);
        dp[0] = 0;
        
        foreach (var (ai, bi) in suppliers)
        {
            for (int amount = ai; amount <= maxN; amount++)
            {
                if (dp[amount - ai] is not inf)
                    dp[amount] = Math.Min(dp[amount], dp[amount - ai] + bi);
            }
        }
        
        int minCost = dp.Skip(n).Take(maxN - n + 1).Min();

        return minCost;
    }
}
