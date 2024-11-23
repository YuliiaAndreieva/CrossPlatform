namespace App.Models;

public class ServiceAndProduct
{
    public int ProductId { get; set; }
    
    public string ProductName { get; set; }
    
    public string ProductDetails { get; set; }
    
    public ICollection<CustomerProductHolding> CustomerProductHoldings { get; set; }
}