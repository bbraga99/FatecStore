using Fatec.Store.Carts.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Carts.Api.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}