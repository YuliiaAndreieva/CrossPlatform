namespace App.Models;

public class HouseholdMemberViewModel
{
    public int CustomerId { get; set; }
    
    public int MemberCount { get; set; }
    
    public int CountOfChildren { get; set; }
    
    public int CountOfWageEarners { get; set; }
}