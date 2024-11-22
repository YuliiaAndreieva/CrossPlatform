namespace App.Models;

public class SpecialOffer
{
    public int SpecialOfferId { get; set; }
    
    public string SpecialOfferDetails { get; set; }
    

    public ICollection<CustomerOffer> CustomerOffers { get; set; }
}