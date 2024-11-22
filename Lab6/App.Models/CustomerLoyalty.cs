using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class CustomerLoyalty
{
    public int CustomerId { get; set; }
    
    public DateTime DateFirstPurchase { get; set; }
    
    public DateTime DateLastPurchase { get; set; }
    
    public string OtherLoyaltyDetails { get; set; }

    public CustomerProfile Customer { get; set; }
}