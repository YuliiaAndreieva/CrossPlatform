namespace App.Models;

public class HouseholdMember
{
    public int CustomerId { get; set; }
    
    public int MemberCount { get; set; }
    
    public int CountOfChildren { get; set; }
    
    public int CountOfWageEarners { get; set; }

    public CustomerProfile Customer { get; set; }
}