using Fatec.Store.Discount.Api.Context;
using Fatec.Store.Discount.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Discount.Api.Repositories;

public class UserCouponRepository : IUserCouponRepository
{

    private readonly AppDbContext _context;

    public UserCouponRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> HasUserUsedCouponAsync(string userId, string couponCode)
    {
        return await _context.userCoupons.AnyAsync(
                                    c => c.UserID == userId && c.CouponCode == couponCode);
    }

    public async Task AddUserCouponAsync(UserCoupon userCoupon)
    {
        await _context.userCoupons.AddAsync(userCoupon);
        await _context.SaveChangesAsync();
    }

}
