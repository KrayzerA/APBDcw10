using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using cw10.Models;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(IdAccount), nameof(IdProduct))]
public class ShoppingCart
{
    [ForeignKey(nameof(Account))] public int IdAccount { get; set; }
    [ForeignKey(nameof(Product))] public int IdProduct { get; set; }

    [Required] public int Amount { get; set; }

    public Account Account { get; set; } = null!;
    public Product Product { get; set; } = null!;
}