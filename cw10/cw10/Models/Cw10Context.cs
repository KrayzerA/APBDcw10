using Microsoft.EntityFrameworkCore;

namespace cw10.Models;

public class Cw10Context : DbContext
{
    protected Cw10Context()
    {
    }

    public Cw10Context(DbContextOptions<Cw10Context> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Account> Accounts { get; set; }
}