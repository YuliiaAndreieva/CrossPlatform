namespace App.Models;

public class CustomerFullModel
{
    public int CustomerId { get; set; }
    
    public string CustomerDetails { get; set; }
    
    public ICollection<ContactHistoryViewModel> ContactHistories { get; set; }
    
    public ICollection<CustomerProductHoldingViewModel> CustomerProductHoldings { get; set; }
    
    public ICollection<CustomerOfferViewModel> CustomerOffers { get; set; }
}