using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

public class Account
{
    [Key] public int IdAccount { get; set; }

    [Required] [MaxLength(50)] public string FirstName { get; set; } = null!;

    [Required] [MaxLength(50)] public string LastName { get; set; } = null!;

    [Required] [MaxLength(80)] public string Email { get; set; } = null!;

    [MaxLength(9)] public string? Phone { get; set; }

    [ForeignKey(nameof(Role))] public int IdRole { get; set; }

    public Role Role { get; set; } = null!;

    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = null!;
}