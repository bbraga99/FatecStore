using Fatec.Store.Discounts.Api.DTOs;

namespace Fatec.Store.Discounts.Api.Services;

public interface ICouponService
{
    public Task<IEnumerable<CouponReponseDTO>> GetAllCoupons();
    public Task<CouponReponseDTO> GetCoupon(string couponCode);
    public Task<CouponReponseDTO> CreateCoupon(CouponRequestDTO couponRequestDTO);
    public Task<CouponReponseDTO> UseCoupon(CouponRequestPatchDTO couponCode);
    public Task<CouponReponseDTO> ActiveOrInactiveCoupon(string couponCode);
}
