using Fatec.Store.Discounts.Api.Models;

namespace Fatec.Store.Discounts.Api.Repositories;

public interface IUserCouponRepository
{
    Task<bool> HasUserUsedCouponAsync(string userId, string couponId);
    Task AddUserCouponAsync(UserCoupon userCoupon);
}
