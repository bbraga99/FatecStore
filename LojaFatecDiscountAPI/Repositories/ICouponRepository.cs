using Fatec.Store.Discount.Api.Models;

namespace Fatec.Store.Discount.Api.Repositories;

public interface ICouponRepository
{
    public Task<IEnumerable<Coupon>> GetAllCouponsAsync();
    public Task<Coupon> GetCouponByCodeAsync(string couponCode);
    public Task CreateCouponAsync(Coupon coupon);
    public Task UpdateCouponAsync(Coupon coupon);
    public Task DisableCoupon(string couponCode);
}
