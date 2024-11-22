namespace App.Models;

public class CustomerProfileDetailsViewModel
{
    public int CustomerId { get; set; }
    
    public required string CustomerDetails { get; set; }
    
    public required ICollection<CustomerLoyaltyViewModel> CustomerLoyalties { get; set; }
}