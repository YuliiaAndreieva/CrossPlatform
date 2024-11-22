namespace App.Models;

public class CustomerProductHoldingViewModel
{
    public int CustomerId { get; set; }
    
    public int ProductId { get; set; }
    
    public string ProductName { get; set; }
    
    public DateTime DateAcquired { get; set; }
}