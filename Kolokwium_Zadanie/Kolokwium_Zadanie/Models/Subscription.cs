using System.ComponentModel.DataAnnotations;

namespace Kolokwium_Zadanie.Models;

public class Subscription
{
    [Key]
    public int IdSubscription { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime RenewalPeriod { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public decimal Price { get; set; }
}

