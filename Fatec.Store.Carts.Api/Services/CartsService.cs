using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Domain.Interfaces.HttpClient;
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
        private readonly IDiscountServiceClient _discountServiceClient;

        private readonly IMapper _mapper;

        public CartsService(
            ICartsRepository cartsRepository,
            IMapper mapper,
            IProductsRepository productsRepository,
            IDiscountServiceClient discountServiceClient)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
            _productsRepository = productsRepository;
            _discountServiceClient = discountServiceClient;
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
            product.CartId = cart.Id;

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

            cart.CalculateTotalAmount();

            if (!string.IsNullOrEmpty(cart.CouponCode))
            {
                await ApplyCouponDiscountAsync(cart.Id, cart.CouponCode);

                return new(cart.Products.Count());
            }

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

            return _mapper.Map<GetCartByUserIdResponse>(cart);
        }

        public async Task RemoveProductFromCartAsync(int cartId, int productId)
        {
            var product = await _productsRepository.GetProductByProductIdAndCartIdAsync(productId, cartId) ?? null;

            if (product is null)
                return;

            await _productsRepository.RemoveProductAsync(product);
        }

        public async Task CleanCartAsync(int cartId)
        {
            var cart = await _cartsRepository.GetCartByIdAsync(cartId);

            if (cart?.Products?.Any() ?? false)
            {
                await _cartsRepository.CleanCartAsync(cart.Products);

                cart = await _cartsRepository.GetCartByIdAsync(cartId);
                cart.CalculateTotalAmount();

                await _cartsRepository.UpdateCartAsync(cart);
            }

            return;
        }

        public async Task ApplyCouponDiscountAsync(int cartId, string couponCode)
        {
            var cart = await _cartsRepository.GetCartByIdAsync(cartId);
            var coupon = await _discountServiceClient.GetDiscountCoupon(couponCode);

            if (cart is null || coupon is null)
                throw new Exception("NotFound");

            cart.CouponCode = coupon?.CouponCode!;
            cart.TotalDiscount = cart.TotalAmount * (coupon.Discount / 100);

            await _cartsRepository.UpdateCartAsync(cart);
        }

        public async Task RemoveCouponDiscountAsync(int cartId)
        {
            var cart = await _cartsRepository.GetCartByIdAsync(cartId);

            if (string.IsNullOrEmpty(cart.CouponCode))
                return;

            cart.RemoveCouponDiscount();
            await _cartsRepository.UpdateCartAsync(cart);
        }

        #region Modo alternativo para fazer o clean Cart com menos chamadas par ao banco
        /// <summary>
        /// Modo alternativo para limpar o carrinho
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        /// 
        //public async Task CleanCartAsyncAlternativo(int cartId)
        //{
        //    var cart = await _cartsRepository.GetCartByIdAsync(cartId);

        //    if (cart?.Products?.Any() ?? false)
        //    {
        //        cart.Products.ToList().Clear();
        //        cart.CalculateTotals();

        //        await _cartsRepository.UpdateCartAsync(cart);
        //    }

        //    return;
        //}

        #endregion Modo alternativo para fazer o clean Cart com menos chamadas par ao banco
    }
}