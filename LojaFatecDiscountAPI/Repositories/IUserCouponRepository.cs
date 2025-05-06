using Fatec.Store.Discount.Api.Models;

namespace Fatec.Store.Discount.Api.Repositories;

public interface IUserCouponRepository
{
    Task<bool> HasUserUsedCouponAsync(string userId, string couponId);
    Task AddUserCouponAsync(UserCoupon userCoupon);
}
