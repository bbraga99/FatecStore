using Fatec.Store.Discounts.Api.Models;

namespace Fatec.Store.Discounts.Api.Repositories;

public interface ICouponRepository
{
    public Task<IEnumerable<Coupon>> GetAllCouponsAsync();
    public Task<Coupon> GetCouponByCodeAsync(string couponCode);
    public Task CreateCouponAsync(Coupon coupon);
    public Task UpdateCouponAsync(Coupon coupon);
    public Task ActiveOrInactiveCoupon(string couponCode);
}
