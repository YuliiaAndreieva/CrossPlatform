namespace App.Models;

public class CustomerProductHoldingDetailsViewModel
{
    public int CustomerId { get; set; }
    
    public int ProductId { get; set; }
    
    public DateTime DateAcquired { get; set; }
    
    public DateTime? DateDiscontinued { get; set; }
    
    public string? ProductName { get; set; }
    
    public string? ProductDetails { get; set; }
}