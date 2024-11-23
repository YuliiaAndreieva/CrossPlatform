namespace App.Models;

public class CustomerOffer
{
    public int CustomerId { get; set; }
    
    public int SpecialOfferId { get; set; }
    
    public DateTime DateOfferAccepted { get; set; }
    
    public CustomerProfile Customer { get; set; }
    
    public SpecialOffer SpecialOffer { get; set; }
}