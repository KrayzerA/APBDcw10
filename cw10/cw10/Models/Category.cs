using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

public class Category
{
    [Key] public int IdCategory { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = null!;
    
    public ICollection<Product> Products { get; set; } = null!;
}