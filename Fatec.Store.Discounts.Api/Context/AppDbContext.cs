using Fatec.Store.Discounts.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Discounts.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Coupon> coupons { get; set; }
    public DbSet<UserCoupon> userCoupons { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        mb.Entity<Coupon>()
            .HasIndex(c => c.CouponCode)
            .IsUnique();
    }
}
