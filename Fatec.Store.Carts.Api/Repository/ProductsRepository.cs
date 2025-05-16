using Fatec.Store.Carts.Api.Context;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Domain.Interfaces.Repositories;

namespace Fatec.Store.Carts.Api.Repository
{
    public class ProductsRepository(AppDbContext context) : IProductsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task RemoveProductsAsync(IEnumerable<Product> products)
        {
            _context.Products.RemoveRange();
            await _context.SaveChangesAsync();
        }
    }
}
