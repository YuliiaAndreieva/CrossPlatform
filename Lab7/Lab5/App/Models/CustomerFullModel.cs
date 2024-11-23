namespace App.Models;

public class CustomerFullModel
{
    public int CustomerId { get; set; }
    
    public string? CustomerDetails { get; set; }
    
    public required ICollection<ContactHistoryViewModel> ContactHistories { get; set; }
    
    public required ICollection<CustomerProductHoldingViewModel> CustomerProductHoldings { get; set; }
    
    public ICollection<CustomerOfferViewModel>? CustomerOffers { get; set; }
}