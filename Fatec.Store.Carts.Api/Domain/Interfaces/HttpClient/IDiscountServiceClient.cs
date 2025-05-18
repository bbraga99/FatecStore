using Fatec.Store.Carts.Api.Models.DTOs.GetCouponClientResponse;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.HttpClient
{
    public interface IDiscountServiceClient
    {
        public Task<GetCouponResponse> GetDiscountCoupon(string couponCode);
    }
}
