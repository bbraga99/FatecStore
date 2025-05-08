using AutoMapper;
using Fatec.Store.Cart.Api.DTOs.Mappings;
using Fatec.Store.Discount.Api.DTOs;
using LojaFatec.CartApi.DTOs;
using LojaFatec.CartApi.Models;
using LojaFatec.CartApi.Repositories;

namespace LojaFatec.CartApi.Service
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;

        public CartService(IMapper mapper, ICartRepository cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }
        public async Task<CartResponseDTO> GetCartByUserID(string id)
        {
            var header = await _cartRepository.GetCartHeaderByUserIdAsync(id);

            if (header == null) throw new Exception("Cart don't find");

            var items = await _cartRepository.GetCartItemsByHeaderIdAsync(header.Id);

            var cart = new Cart
            {
                CartHeader = header,
                CartItems = items.ToList()
            };

            return _mapper.Map<CartResponseDTO>(cart);
        }
        public async Task<CartResponseDTO> UpdateCartAsync(CartRequestDTO cartRequestDTO)
        {
            var cart = _mapper.Map<Cart>(cartRequestDTO);

            var itemToAdd = cart.CartItems.First();
            var product = await _cartRepository.GetProductByIdAsync(itemToAdd.ProductId);
            if(product == null)
            {
                await _cartRepository.AddProductAsync(itemToAdd.Product);
            }

            var cartHeader = await _cartRepository.GetCartHeaderByUserIdAsync(cart.CartHeader.UserId);
            if (cartHeader == null)
            {
                await _cartRepository.AddCartHeaderAsync(cart.CartHeader);

                itemToAdd.CartHeaderId = cart.CartHeader.Id;
                itemToAdd.Product = null;

                await _cartRepository.AddCartItemAsync(itemToAdd);
            }
            else
            {
                var existingItem = await _cartRepository.GetCartItemsAsync(itemToAdd.ProductId, cartHeader.Id);

                if (existingItem == null)
                {
                    itemToAdd.CartHeaderId = cartHeader.Id;
                    itemToAdd.Product = null;

                    await _cartRepository.AddCartItemAsync(itemToAdd);
                }
                else
                {
                    itemToAdd.Id = existingItem.Id;
                    itemToAdd.Quantity += existingItem.Quantity;
                    itemToAdd.CartHeaderId = cartHeader.Id;
                    itemToAdd.Product = null;

                    await _cartRepository.UpdateCartItemAsync(itemToAdd);
                }
            }

            return await GetCartByUserID(cart.CartHeader.UserId);
        }

        public async Task<bool> CleanCartAsync(string userId)
        {
            var header = await _cartRepository.GetCartHeaderByUserIdAsync(userId);

            if (header == null) return false;

            var items = await _cartRepository.GetCartItemsByHeaderIdAsync(header.Id);

            foreach (var item in items)
            {
                await _cartRepository.RemoveCartItemAsync(item);
            }

            await _cartRepository.RemoveCartHeaderAsync(header);

            return true;

        }
        public async Task<bool> DeleteItemAsync(int productId, int headerId)
        {
            var item = await _cartRepository.GetCartItemsAsync(productId, headerId);

            if (item == null) return false;

            int total = (await _cartRepository.GetCartItemsByHeaderIdAsync(item.CartHeaderId)).Count();
            await _cartRepository.RemoveCartItemAsync(item);

            if(total == 1)
            {
                var header = await _cartRepository.GetCartHeaderByUserIdAsync(item.CartHeader.UserId);
                if (header != null) await _cartRepository.RemoveCartHeaderAsync(header);
            }

            return true;
        }

        public async Task<CartTotalDTO> CalculateCartTotalValue(string userId)
        {
            var cartTotal = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cartTotal is null || cartTotal.CartItems == null || !cartTotal.CartItems.A
                    throw new Exception("Cart empty or not found");

            double total = cartTotal.CartItems.Sum(item => item.Product.Price * item.Quantity);

            double discount = 0;

            //if(!string.IsNullOrEmpty(cartTotal.CartHeader.CouponCode))
            //{
                
            //}

            return null;
        }
    }
}