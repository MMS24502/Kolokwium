using Kolokwium_Zadanie.Context;
using Kolokwium_Zadanie.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_Zadanie.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly MasterContext _context;

    public ClientController(MasterContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDTO>> GetClientWithSubscriptions(int id)
    {
        var client = await _context.Clients
            .Where(c => c.IdClient == id)
            .Select(c => new ClientDTO
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Subscriptions = c.Sales
                    .Select(s => new SubscriptionDTO
                    {
                        IdSubscription = s.Subscription.IdSubscription,
                        Name = s.Subscription.Name,
                        TotalPaidAmount = _context.Payments
                            .Count(p => p.IdSubscription == s.Subscription.IdSubscription) * s.Subscription.Price
                    }).ToList()
            }).FirstOrDefaultAsync();

        if (client == null)
            return NotFound("Client not found.");

        return Ok(client);
    }
}
