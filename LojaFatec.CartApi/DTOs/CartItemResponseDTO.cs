using LojaFatec.CartApi.Models;

namespace LojaFatec.CartApi.DTOs;

public class CartItemResponseDTO
{
    public int Id { get; set; }
    public ProductResponseDTO Product { get; set; } = new ProductResponseDTO();
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int CartHeaderId { get; set; }
    public CartHeaderResponseDTO CartHeader { get; set; } = new CartHeaderResponseDTO();
}
