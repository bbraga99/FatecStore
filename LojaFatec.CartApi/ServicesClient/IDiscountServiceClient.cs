using Fatec.Store.Cart.Api.Models.ServiceClientModel;

namespace Fatec.Store.Cart.Api.ServicesClient;

public interface IDiscountServiceClient
{
    public Task<GetCouponResponse> GetDiscountCoupon(string couponCode);
    
}
