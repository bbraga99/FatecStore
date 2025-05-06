using System.Reflection.PortableExecutable;
using AutoMapper;
using LojaFatec.CartApi.Context;
using LojaFatec.CartApi.DTOs;
using LojaFatec.CartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaFatec.CartApi.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CartHeader> GetCartHeaderByUserIdAsync(string userId)
    {
        return await _context.CartHeaders.FirstOrDefaultAsync(
                                     c => c.UserId == userId);
    }
    public async Task<IEnumerable<CartItem>> GetCartItemsByHeaderIdAsync(int headerId)
    {
        return await _context.CartItems.Where(c => c.CartHeaderId == headerId)
                                        .Include(c => c.Product)
                                        .ToListAsync();
    }
    public async Task<CartItem> GetCartItemsAsync(int productId, int headerId)
    {
        return await _context.CartItems.AsNoTracking().FirstOrDefaultAsync(
                                                        c => c.ProductId == productId 
                                                        && c.CartHeaderId == headerId);
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task AddProductAsync(Product product)
    {
         await _context.Products.AddAsync(product);

         await _context.SaveChangesAsync();
    }
    public async Task AddCartHeaderAsync(CartHeader header)
    {
        await _context.CartHeaders.AddAsync(header);

        await _context.SaveChangesAsync();
    }

    public async Task AddCartItemAsync(CartItem item)
    {
        await _context.CartItems.AddAsync(item);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCartItemAsync(CartItem item)
    {
        _context.CartItems.Update(item);

        await _context.SaveChangesAsync();
    }
    public async Task RemoveCartHeaderAsync(CartHeader header)
    {
        _context.CartHeaders.Remove(header);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveCartItemAsync(CartItem item)
    {
        _context.CartItems.Remove(item);

        await _context.SaveChangesAsync();
    }

}
