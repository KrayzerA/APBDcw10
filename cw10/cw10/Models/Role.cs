using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

public class Role
{
    [Key] public int IdRole { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = null!;
    
    public ICollection<Account> Accounts { get; set; } = null!;
}