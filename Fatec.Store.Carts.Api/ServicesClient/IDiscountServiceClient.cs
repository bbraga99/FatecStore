using Fatec.Store.Carts.Api.Models.ServiceClientModel;

namespace Fatec.Store.Carts.Api.ServicesClient;

public interface IDiscountServiceClient
{
    public Task<GetCouponResponse> GetDiscountCoupon(string couponCode);
    
}
