using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Authorize]
public class CustomerProfilesController : Controller
{
    private readonly AppDbContext _context;

    public CustomerProfilesController(AppDbContext context)
    {
        _context = context;
    }
    
    [Route("api/customer-profiles")]
    public IActionResult Index()
    {
        var profiles = _context.CustomerProfiles.ToList();
        return Ok(profiles);
    }
    
    [Route("api/customer-profiles/{id}")]
    public IActionResult Details(int id)
    {
        var profile = _context.CustomerProfiles
            .Include(p => p.CustomerLoyalties)
            .FirstOrDefault(p => p.CustomerId == id);

        if (profile is null)
            return NotFound();
        return Ok(profile);
    }
}