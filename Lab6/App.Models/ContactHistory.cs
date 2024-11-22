namespace App.Models;

public class ContactHistory
{
    public int ContactHistoryId { get; set; }
    
    public int CustomerId { get; set; }
    
    public int OutcomeStatusCode { get; set; }
    
    public DateTime ContactDatetime { get; set; }
    
    public string ContactDetails { get; set; }

    public CustomerProfile Customer { get; set; }
    
    public RefContactOutcome RefContactOutcome { get; set; }
}