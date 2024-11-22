using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class CustomerProfile
{
    public int CustomerId { get; set; }
    
    public string CustomerDetails { get; set; }
    
    public ICollection<CustomerLoyalty> CustomerLoyalties { get; set; }
    
    public ICollection<CustomerPreference> CustomerPreferences { get; set; }
    
    public ICollection<ContactHistory> ContactHistories { get; set; }
    
    public ICollection<CustomerProductHolding> CustomerProductHoldings { get; set; }
    
    public ICollection<CustomerAsset> CustomerAssets { get; set; }
    
    public ICollection<HouseholdMember> HouseholdMembers { get; set; }
    
    public ICollection<CustomerOffer> CustomerOffers { get; set; }
}