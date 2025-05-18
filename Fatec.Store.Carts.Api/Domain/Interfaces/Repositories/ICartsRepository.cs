using Fatec.Store.Carts.Api.Domain.Entities;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.Repositories
{
    public interface ICartsRepository
    {
        Task CreateCartAsync(Cart cart);

        Task UpdateCartAsync(Cart cart);

        Task<Cart> GetCartByUserIdAsync(int userId);

        Task<Cart> GetCartByIdAsync(int cartId);

    }
}
