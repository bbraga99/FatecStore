using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Domain.Interfaces.Repositories;
using Fatec.Store.Carts.Api.Domain.Interfaces.Services;
using Fatec.Store.Carts.Api.Models.DTOs.AddProductCart;
using Fatec.Store.Carts.Api.Models.DTOs.CreateCart;
using Fatec.Store.Carts.Api.Models.DTOs.GetCartByUserId;

namespace Fatec.Store.Carts.Api.Services
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;

        private readonly IMapper _mapper;

        public CartsService(ICartsRepository cartsRepository, IMapper mapper, IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        public async Task<AddProductCartResponse> AddProductCartAsync(int cartId, AddProductCartRequest productRequest)
        {
            var cart = await _cartsRepository.GetCartByIdAsync(cartId) ?? throw new Exception("NotFound");

            var product = cart.Products.FirstOrDefault(product => product.ProductId.Equals(productRequest.ProductId)) ?? null;

            return product is null
                ? await AddProductCartAsync(productRequest, cart)
                : await UpdateProductAsync(productRequest, cart, product);
        }

        private async Task<AddProductCartResponse> AddProductCartAsync(AddProductCartRequest productRequest, Cart cart)
        {
            var product = _mapper.Map<Product>(productRequest);
            await _productsRepository.AddProductCartAsync(product);

            return await UpdateCartAsync(cart);
        }

        private async Task<AddProductCartResponse> UpdateProductAsync(AddProductCartRequest productRequest, Cart cart, Product product)
        {
            product = _mapper.Map(productRequest, product);
            await _productsRepository.UpdateProductAsync(product);

            return await UpdateCartAsync(cart);
        }

        private async Task<AddProductCartResponse> UpdateCartAsync(Cart cart)
        {
            cart = await _cartsRepository.GetCartByIdAsync(cart.Id);
            cart.CalculateTotals();
            await _cartsRepository.UpdateCartAsync(cart);

            return new(cart.Products.Count());
        }

        public async Task CreateCartAsync(CreateCartRequest cartRequest)
        {
            var cart = await _cartsRepository.GetCartByUserIdAsync(cartRequest.UserId);

            if (cart is null)
                await _cartsRepository.CreateCartAsync(_mapper.Map<Cart>(cartRequest));
        }

        public async Task<GetCartByUserIdResponse> GetCartByUserIdAsync(GetCartByUserIdRequest request)
        {
            var cart = await _cartsRepository.GetCartByUserIdAsync(request.UserId)
                ?? throw new Exception("NotFound");

            var response = _mapper.Map<GetCartByUserIdResponse>(cart);

            return response;
        }
    }
}