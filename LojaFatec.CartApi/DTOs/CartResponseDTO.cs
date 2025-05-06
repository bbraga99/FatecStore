namespace LojaFatec.CartApi.DTOs;

public class CartResponseDTO
{
    public CartHeaderResponseDTO CartHeader { get; set; } = new CartHeaderResponseDTO();
    public IEnumerable<CartItemResponseDTO> CartItems { get; set; } = Enumerable.Empty<CartItemResponseDTO>();
}
