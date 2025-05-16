using Fatec.Store.Carts.Api.Models.DTO.CreateCart;
using Fatec.Store.Carts.Api.Models.DTO.GetCartByUserId;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.Services
{
    public interface ICartsService
    {
        Task CreateCartAsync(CreateCartRequest cartRequest);

        Task<GetCartByUserIdResponse> GetCartByUserIdAsync(GetCartByUserIdRequest request);
    }
}
