using System.Net.Http.Headers;

namespace Fatec.Store.Carts.Api.Models;

public class CartItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int CartHeaderId { get; set; }
    public Product Product { get; set; }
    public CartHeader CartHeader { get; set; } = new CartHeader();
}
