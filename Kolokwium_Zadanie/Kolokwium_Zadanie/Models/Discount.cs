using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_Zadanie.Models;

public class Discount
{
    [Key]
    public int IdDiscount { get; set; }

    [Required]
    public int Value { get; set; }

    [ForeignKey("Subscription")]
    public int IdSubscription { get; set; }
    public virtual Subscription Subscription { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public DateTime DateTo { get; set; }
}
