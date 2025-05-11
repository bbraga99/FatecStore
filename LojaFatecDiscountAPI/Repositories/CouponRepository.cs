using Fatec.Store.Discount.Api.Context;
using Fatec.Store.Discount.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Discount.Api.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly AppDbContext _context;

    public CouponRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
    {
        var coupons = await _context.coupons.ToListAsync();

        return coupons;
    }

    public async Task<Coupon> GetCouponByCodeAsync(string couponCode)
    {
        var coupon = await _context.coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);

        return coupon;
    }

    public async Task CreateCouponAsync(Coupon coupon)
    {
        if(await _context.coupons.AnyAsync(c => c.CouponCode == coupon.CouponCode))
        {
            throw new Exception("Coupon already exist");
        }

        var newCoupon = _context.coupons.Add(coupon);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCouponAsync(Coupon coupon)
    {
        _context.coupons.Entry(coupon).
                                State = EntityState.Modified; 

        await _context.SaveChangesAsync();
    }

    public async Task ActiveOrInactiveCoupon(string couponCode)
    {
        var coupon = await GetCouponByCodeAsync(couponCode);

        coupon.Active = !coupon.Active;

        await _context.SaveChangesAsync(); 
    }
}
