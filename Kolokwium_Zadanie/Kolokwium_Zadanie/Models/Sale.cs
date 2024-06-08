using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Kolokwium_Zadanie.Models;

public class Sale
{
    [Key]
    public int IdSale { get; set; }

    [ForeignKey("Client")]
    public int IdClient { get; set; }
    public virtual Client Client { get; set; }

    [ForeignKey("Subscription")]
    public int IdSubscription { get; set; }
    public virtual Subscription Subscription { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}
