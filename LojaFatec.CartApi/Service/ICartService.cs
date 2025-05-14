using Fatec.Store.Cart.Api.DTOs.Mappings;
using Fatec.Store.Discount.Api.DTOs;
using LojaFatec.CartApi.DTOs;

namespace LojaFatec.CartApi.Service;

public interface ICartService
{
    public Task<CartResponseDTO> GetCartByUserID(string id);
    public Task<CartResponseDTO> UpdateCartAsync(CartRequestDTO cartRequestDTO);

    //criar metodo createCart e tirar a responsabilidade deo updatecart
    public Task<bool> DeleteItemAsync(int productId, int headerId);
    public Task<bool> CleanCartAsync(string userId);

    //public Task<CartTotalDTO> CalculateCartTotalValue(string userId);
}
