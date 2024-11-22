namespace App.Models;

public class RefContactOutcome
{
    public int OutcomeStatusCode { get; set; }
    
    public string OutcomeStatusDescription { get; set; }

    public ICollection<ContactHistory> ContactHistories { get; set; }
}