using LojaFatec.CartApi.DTOs;

namespace Fatec.Store.Cart.Api.DTOs.Mappings;

public class CartRequestDTO
{
    public CartHeaderResponseDTO? CartHeader {  get; set; }
    public IEnumerable<CartItemResponseDTO>? CartItems { get; set; }
}
