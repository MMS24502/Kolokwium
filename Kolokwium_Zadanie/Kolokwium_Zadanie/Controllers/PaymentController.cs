using Kolokwium_Zadanie.Context;
using Kolokwium_Zadanie.DTOs;
using Kolokwium_Zadanie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_Zadanie.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly MasterContext _context;

    public PaymentsController(MasterContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment(CreatePaymentDTO paymentDto)
    {
        var subscription = await _context.Subscriptions.FindAsync(paymentDto.IdSubscription);
        if (subscription == null)
            return NotFound("Subscription not found.");

        var client = await _context.Clients.FindAsync(paymentDto.IdClient);
        if (client == null)
            return NotFound("Client not found.");

        if (paymentDto.Amount < subscription.Price)
            return BadRequest("Insufficient payment amount.");

        var payment = new Payment
        {
            IdClient = paymentDto.IdClient,
            IdSubscription = paymentDto.IdSubscription,
            Date = DateTime.Now
        };

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return Ok(new { PaymentId = payment.IdClient });
    }
}
