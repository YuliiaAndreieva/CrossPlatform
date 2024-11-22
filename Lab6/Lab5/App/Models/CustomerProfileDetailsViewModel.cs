namespace App.Models;

public class CustomerProfileDetailsViewModel
{
    public int CustomerId { get; set; }
    
    public string CustomerDetails { get; set; }
    
    public ICollection<CustomerLoyaltyViewModel> CustomerLoyalties { get; set; }
}