using Fatec.Store.Carts.Api.Domain.Interfaces.HttpClient;
using Fatec.Store.Carts.Api.Models.DTOs.GetCouponClientResponse;

namespace Fatec.Store.Carts.Api.Models.ServicesClient;

public class DiscountServiceClient : IDiscountServiceClient
{
    private readonly HttpClient _httpClient;

    private readonly string _discountUrl;

    public DiscountServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _discountUrl = "http://localhost:5017/api/coupons";
    }

    public async Task<GetCouponResponse> GetDiscountCoupon(string couponCode)
    {
        var response = await _httpClient.GetAsync($"{_discountUrl}/{couponCode}");
        var content = await response.Content.ReadFromJsonAsync<GetCouponResponse>();

        return content;
    }
}