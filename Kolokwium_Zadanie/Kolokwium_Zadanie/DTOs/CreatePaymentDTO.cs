namespace Kolokwium_Zadanie.DTOs;

public class CreatePaymentDTO
{
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    public decimal Amount { get; set; }
}

