namespace App;

public static class SocksPurchaseService
{
    public static List<(int ai, int bi)> SortSuppliersByPrice(List<(int ai, int bi)> suppliers)
    {
        if (suppliers == null || !suppliers.Any())
        {
            throw new ArgumentException("Suppliers list is empty or null.");
        }
        
        return suppliers.OrderBy(s => s.bi / (double)s.ai).ToList();
    }
    
    public static int CalculateMinimumCost(int n, List<(int ai, int bi)> suppliers)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "The number of socks should be greater than zero.");
        }
        
        if (suppliers == null || suppliers.Count == 0)
        {
            throw new ArgumentException("Suppliers list cannot be empty.");
        }
        
        var sortedSuppliers = SortSuppliersByPrice(suppliers);

        int totalCost = 0;
        int remainingSocks = n;
        
        foreach (var supplier in sortedSuppliers)
        {
            int packSize = supplier.ai;
            int packPrice = supplier.bi;
            
            if (remainingSocks <= packSize)
            {
                totalCost += packPrice;
                remainingSocks = 0; 
                break;
            }
            
            int packsToBuy = remainingSocks / packSize;
            totalCost += packsToBuy * packPrice;
            
            remainingSocks -= packsToBuy * packSize;
        }
        
        if (remainingSocks > 0)
        {
            totalCost += sortedSuppliers[0].bi;
        }

        return totalCost;
    }
}
