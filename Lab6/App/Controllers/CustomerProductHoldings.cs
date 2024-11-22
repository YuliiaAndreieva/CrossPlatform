using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Authorize]
public class CustomerProductHoldings : Controller
{
    private readonly AppDbContext _context;

    public CustomerProductHoldings(
        AppDbContext context)
    {
        _context = context;
    }

    [Route("api/customer-product-holdings")]
    public IActionResult GetCustomerProductHoldings()
    {
        var productHoldings = _context.CustomerProductHoldings
            .Include(cph => cph.ServiceAndProduct)
            .Select(cph => new
            {
                cph.CustomerId,
                cph.ProductId,
                ProductName = cph.ServiceAndProduct.ProductName
            })
            .ToList();

        return Ok(productHoldings);
    }

    [Route("api/customer-product-holdings/{customerId}/{productId}")]
    public IActionResult GetCustomerProductHoldingDetails(int customerId, int productId)
    {
        var productHoldingDetails = _context.CustomerProductHoldings
            .Include(cph => cph.ServiceAndProduct)
            .FirstOrDefault(cph => cph.CustomerId == customerId && cph.ProductId == productId);

        if (productHoldingDetails == null)
            return NotFound();

        return Ok(new
        {
            productHoldingDetails.CustomerId,
            productHoldingDetails.ProductId,
            productHoldingDetails.DateAcquired,
            productHoldingDetails.DateDiscontinued,
            ProductName = productHoldingDetails.ServiceAndProduct.ProductName,
            ProductDetails = productHoldingDetails.ServiceAndProduct.ProductDetails
        });
    }
}