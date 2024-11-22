namespace App.Models;

public class CustomerProductHolding
{
    public int CustomerId { get; set; }
    
    public int ProductId { get; set; }
    
    public DateTime DateAcquired { get; set; }
    
    public DateTime? DateDiscontinued { get; set; }
    

    public CustomerProfile Customer { get; set; }
    
    public ServiceAndProduct ServiceAndProduct { get; set; }
}