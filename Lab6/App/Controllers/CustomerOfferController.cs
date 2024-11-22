using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Authorize]
public class CustomerOfferController : Controller
{
    private AppDbContext _context;

    public CustomerOfferController(
        AppDbContext context)
    {
        _context = context;
    }

    [Route("api/special-offers")]
    public IActionResult Index()
    {
        var offers = _context.SpecialOffers.ToList();
        return Ok(offers);
    }
}