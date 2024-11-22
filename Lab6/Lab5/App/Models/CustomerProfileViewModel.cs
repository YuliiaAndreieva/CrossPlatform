using System.Text.Json.Serialization;

namespace App.Models;

public class CustomerProfileViewModel
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }
    
    [JsonPropertyName("customerDetails")]
    public required string CustomerDetails { get; set; }
}