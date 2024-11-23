using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Authorize]
public class HouseholdMembersController : Controller
{
    private readonly AppDbContext _context;

    public HouseholdMembersController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("api/household-members")]
    public async Task<IActionResult> GetHouseholdMembersAsCustomer()
    {
        try
        {
            var customerProfiles = await _context.HouseholdMembers
                .Include(hm => hm.Customer) 
                .Select(hm => hm.Customer) 
                .ToListAsync();

            return Ok(customerProfiles);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
    
    [HttpGet("api/household-members/{id}")]
    public IActionResult Details(int id)
    {
        var profile = _context.HouseholdMembers
            .Include(p => p.Customer)
            .FirstOrDefault(p => p.CustomerId == id);

        if (profile is null)
            return NotFound();
        return Ok(profile);
    }
}