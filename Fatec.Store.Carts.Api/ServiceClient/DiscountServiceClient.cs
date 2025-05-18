using Fatec.Store.Carts.Api.Domain.Interfaces.HttpClient;
using Fatec.Store.Carts.Api.Models.DTOs.GetCouponClientResponse;
using System.Net;

namespace Fatec.Store.Carts.Api.ServiceClient;

public class DiscountServiceClient : IDiscountServiceClient
{
    private readonly HttpClient _httpClient;

    private readonly string _discountUrl;

    public DiscountServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _discountUrl = "http://18.230.152.32:8084/api/coupons";
    }

    public async Task<GetCouponResponse?> GetDiscountCoupon(string couponCode)
    {
        var response = await _httpClient.GetAsync($"{_discountUrl}/{couponCode}");

        if (response.StatusCode.Equals(HttpStatusCode.NoContent))
            return null;

        return await response.Content.ReadFromJsonAsync<GetCouponResponse>();
    }
}