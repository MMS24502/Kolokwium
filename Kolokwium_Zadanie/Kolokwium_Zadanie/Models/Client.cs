using System.ComponentModel.DataAnnotations;

namespace Kolokwium_Zadanie.Models;

public class Client
{
    [Key]
    public int IdClient { get; set; }

    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }
    
    [MaxLength(100)]
    public string? Phone { get; set; }

    // Navigation property for Sales
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
