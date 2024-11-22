using System.Text.Json.Serialization;

namespace App.Models;

public class CustomerProfileViewModel
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }
    
    [JsonPropertyName("customerDetails")]
    public string CustomerDetails { get; set; }
}