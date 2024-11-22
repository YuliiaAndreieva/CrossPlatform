namespace App.Models;

public class CustomerPreference
{
    public int CustomerId { get; set; }
    
    public int FactorCode { get; set; }

    public CustomerProfile Customer { get; set; }
    
    public RefPreferenceFactor RefPreferenceFactor { get; set; }
}