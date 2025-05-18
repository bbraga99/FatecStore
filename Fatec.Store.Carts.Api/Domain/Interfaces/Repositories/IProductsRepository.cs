using Fatec.Store.Carts.Api.Domain.Entities;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task RemoveProductAsync(Product product);

        Task AddProductCartAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task<Product> GetProductByProductIdAndCartIdAsync(int productId, int cartId);
    }
}