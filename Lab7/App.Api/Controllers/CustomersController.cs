using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Authorize]
public class CustomersController : Controller
{
    private readonly AppDbContext _context;

    public CustomersController(
        AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("api/customers/search")]
    public IActionResult SearchCustomers(
        DateTime? contactStartDate,
        DateTime? contactEndDate,
        int? specialOfferId,
        DateTime? productStartDate,
        DateTime? productEndDate)
    {
        var query = _context.CustomerProfiles
            .Include(c => c.ContactHistories)
            .Include(c => c.CustomerOffers)
            .Include(c => c.CustomerProductHoldings)
            .AsQueryable();

        if (contactStartDate.HasValue && contactEndDate.HasValue)
        {
            query = query.Where(c => c.ContactHistories.Any(ch =>
                ch.ContactDatetime >= contactStartDate.Value && ch.ContactDatetime <= contactEndDate.Value));
        }

        if (specialOfferId.HasValue)
        {
            query = query.Where(c => c.CustomerOffers.Any(co => co.SpecialOfferId == specialOfferId.Value));
        }

        if (productStartDate.HasValue && productEndDate.HasValue)
        {
            query = query.Where(c => c.CustomerProductHoldings.Any(cph =>
                cph.DateAcquired >= productStartDate.Value && cph.DateAcquired <= productEndDate.Value));
        }

        var result = query.ToList();

        return Ok(result);
    }
}