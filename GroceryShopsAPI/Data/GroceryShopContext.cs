using Microsoft.EntityFrameworkCore;
using GroceryShopsAPI.Models;

namespace GroceryShopsAPI.Data
{
    public class GroceryShopContext : DbContext
    {
        public GroceryShopContext(DbContextOptions<GroceryShopContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
