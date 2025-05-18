using Fatec.Store.Carts.Api.Domain.Entities;
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

    }
}
