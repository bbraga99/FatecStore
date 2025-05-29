using Fatec.Store.Carts.Api.Context;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Carts.Api.Repository
{
    public class CartsRepository(AppDbContext context) : ICartsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CleanCartAsync(IEnumerable<Product> products)
        {
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCartAsync(Cart cart)
        {
            await _context.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart?> GetCartByIdAsync(int cartId) =>
            await _context.Carts
                .Include(cart => cart.Products)
                .FirstOrDefaultAsync(cart => cart.Id.Equals(cartId));

        public async Task<Cart?> GetCartByUserIdAsync(int userId) =>
             await _context.Carts
                .Include(cart => cart.Products)
                .FirstOrDefaultAsync(cart => cart.UserId.Equals(userId));

        public async Task UpdateCartAsync(Cart cart)
        {
            _context.Update(cart);
            await _context.SaveChangesAsync();
        }


    }
}
