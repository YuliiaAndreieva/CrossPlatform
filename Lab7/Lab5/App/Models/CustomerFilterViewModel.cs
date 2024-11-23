namespace App.Models;

public class CustomerFilterViewModel
{
    public DateTime? ContactStartDate { get; set; }
    
    public DateTime? ContactEndDate { get; set; }
    
    public int? SpecialOfferId { get; set; }
    
    public DateTime? ProductStartDate { get; set; }
    
    public DateTime? ProductEndDate { get; set; }
    
    public List<SpecialOfferViewModel>? SpecialOffers { get; set; }
}

public class SpecialOfferViewModel
{
    public int SpecialOfferId { get; set; }
    
    public string? SpecialOfferDetails { get; set; }
}