namespace Kolokwium_Zadanie.DTOs;

public class ClientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public List<SubscriptionDTO> Subscriptions { get; set; }
}
