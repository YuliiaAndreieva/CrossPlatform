using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;
[ApiController]
[Authorize]
public class RefContactOutcomesController : Controller
{
    private readonly AppDbContext _context;

    public RefContactOutcomesController(AppDbContext context)
    {
        _context = context;
    }

    [Route("api/ref-contact-outcomes")]
    public IActionResult Index()
    {
        var outcomes = _context.RefContactOutcomes.ToList();
        return Ok(outcomes);
    }

    [Route("api/ref-contact-outcomes/{code}")]
    public IActionResult Details(int code)
    {
        var outcome = _context.RefContactOutcomes.FirstOrDefault(o => o.OutcomeStatusCode == code);
        if (outcome == null)
            return NotFound();
        return Ok(outcome);
    }
}