using Fatec.Store.Carts.Api.DTOs;
using Fatec.Store.Carts.Api.DTOs.Request.CreateCart;

namespace Fatec.Store.Carts.Api.Service;

public interface ICartService
{
    public Task<CartResponseDTO> GetCartByUserID(string id);
    public Task<CartResponseDTO> UpdateCartAsync(string cartId, CartRequestDTO cartRequestDTO);
    public Task<CartResponseDTO> CreateCartAsync(CreateCartRequestDTO cartRequestDTO);
    public Task<bool> DeleteItemAsync(int productId, int headerId);
    public Task<bool> CleanCartAsync(string userId);

    //public Task<CartTotalDTO> CalculateCartTotalValue(string userId);
}
