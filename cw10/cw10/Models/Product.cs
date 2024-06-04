using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace cw10.Models;

public class Product
{
    [Key] public int IdProduct { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = null!;

    [Required] public Decimal Weight { get; set; }

    [Required] public Decimal Width { get; set; }

    [Required] public Decimal Height { get; set; }

    [Required] public Decimal Depth { get; set; }


    public ICollection<Category> Categories { get; set; } = null!;
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = null!;
}