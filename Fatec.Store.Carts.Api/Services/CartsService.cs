using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Domain.Interfaces.Repositories;
using Fatec.Store.Carts.Api.Domain.Interfaces.Services;
using Fatec.Store.Carts.Api.Models.CreateCart;

namespace Fatec.Store.Carts.Api.Services
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IMapper _mapper;

        public CartsService(ICartsRepository cartsRepository, IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
        }

        public async Task CreateCartAsync(CreateCartRequest cartRequest)
        {
            var cart = await _cartsRepository.GetCartByUserIdAsync(cartRequest.UserId);

            if (cart is null)
            {
                cart = _mapper.Map<Cart>(cartRequest);
                cart.CalculateTotalAmount();
                await _cartsRepository.CreateCartAsync(cart);
            }
        }
    }
}
