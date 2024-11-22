namespace App.Models;

public class CustomerLoyaltyViewModel
{
    public int CustomerId { get; set; }
    
    public DateTime DateFirstPurchase { get; set; }
    
    public DateTime DateLastPurchase { get; set; }
    
    public string OtherLoyaltyDetails { get; set; }
}