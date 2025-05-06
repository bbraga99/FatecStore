using LojaFatec.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaFatec.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Categories
            mb.Entity<Category>().HasKey(c => c.CategoryId);

            mb.Entity<Category>().
                Property(c => c.Name).
                    HasMaxLength(100).
                        IsRequired();

            mb.Entity<Category>()
              .HasMany(g => g.Products)
               .WithOne(c => c.Category)
                 .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            //Products
            mb.Entity<Product>().
                Property(c => c.Name).
                    HasMaxLength(100).
                        IsRequired();

            mb.Entity<Product>().
               Property(c => c.Description).
                   HasMaxLength(255).
                       IsRequired();

            mb.Entity<Product>().
               Property(c => c.ImageURL).
                   HasMaxLength(255).
                       IsRequired();

           
        }
    }
}
