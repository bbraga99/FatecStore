using Fatec.Store.Carts.Api.Models.DTOs.AddProductCart;
using Fatec.Store.Carts.Api.Models.DTOs.CreateCart;
using Fatec.Store.Carts.Api.Models.DTOs.GetCartByUserId;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.Services
{
    public interface ICartsService
    {
        Task CreateCartAsync(CreateCartRequest cartRequest);

        Task<GetCartByUserIdResponse> GetCartByUserIdAsync(GetCartByUserIdRequest request);

        Task<AddProductCartResponse> AddProductCartAsync(int cartId, AddProductCartRequest productRequest);

        Task RemoveProductFromCartAsync(int cartId, int productId);

        Task CleanCartAsync(int cartId);

        Task ApplyCouponDiscountAsync(int cartId, string couponCode);

        Task RemoveCouponDiscountAsync(int cartId);
    }
}
