using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class RefPreferenceFactor
{
    public int FactorCode { get; set; }
    
    public string FactorDescription { get; set; }

    public ICollection<CustomerPreference> CustomerPreferences { get; set; }
}