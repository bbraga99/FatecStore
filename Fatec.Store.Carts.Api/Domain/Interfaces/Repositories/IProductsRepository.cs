using Fatec.Store.Carts.Api.Domain.Entities;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task RemoveProductsAsync(IEnumerable<Product> products);
    }
}