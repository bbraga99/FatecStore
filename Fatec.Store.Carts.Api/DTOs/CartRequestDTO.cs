namespace Fatec.Store.Carts.Api.DTOs;

public class CartRequestDTO
{
    public CartHeaderResponseDTO? CartHeader {  get; set; }
    public IEnumerable<CartItemResponseDTO>? CartItems { get; set; }
}
