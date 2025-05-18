using Fatec.Store.Carts.Api.Context;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Carts.Api.Repository
{
    public class ProductsRepository(AppDbContext context) : IProductsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddProductCartAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductByProductIdAndCartIdAsync(int productId, int cartId) =>
            await _context.Products.FirstOrDefaultAsync(product =>
                product.ProductId.Equals(productId) && product.CartId.Equals(cartId));

        public async Task RemoveProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }
    }
}
