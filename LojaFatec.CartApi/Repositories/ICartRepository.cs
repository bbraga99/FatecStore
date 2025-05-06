using LojaFatec.CartApi.DTOs;
using LojaFatec.CartApi.Models;

namespace LojaFatec.CartApi.Repositories;

public interface ICartRepository
{
    Task<CartHeader> GetCartHeaderByUserIdAsync(string userId);
    Task<IEnumerable<CartItem>> GetCartItemsByHeaderIdAsync(int headerId);
    Task<CartItem> GetCartItemsAsync(int productId, int headerId);
    Task<Product> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
    Task AddCartHeaderAsync(CartHeader header);
    Task AddCartItemAsync(CartItem item);
    Task UpdateCartItemAsync(CartItem item);
    Task RemoveCartItemAsync(CartItem item);
    Task RemoveCartHeaderAsync(CartHeader header);
}
