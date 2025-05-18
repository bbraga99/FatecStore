using Fatec.Store.Carts.Api.Domain.Interfaces.Services;
using Fatec.Store.Carts.Api.Models.DTOs.AddProductCart;
using Fatec.Store.Carts.Api.Models.DTOs.CreateCart;
using Fatec.Store.Carts.Api.Models.DTOs.GetCartByUserId;
using Microsoft.AspNetCore.Mvc;

namespace Fatec.Store.Carts.Api.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsService _cartService;

        public CartsController(ICartsService cartsService)
        {
            _cartService = cartsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCartRequest cartRequest)
        {
            try
            {
                await _cartService.CreateCartAsync(cartRequest);

                return CreatedAtRoute("GetCartByUserId", new { userId = cartRequest.UserId }, cartRequest.UserId);
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Carrinho");
            }
        }

        [HttpGet("{userId}", Name = "GetCartByUserId")]
        public async Task<IActionResult> GetCartByUserIdAsync(int userId)
        {
            try
            {
                var cart = await _cartService.GetCartByUserIdAsync(new GetCartByUserIdRequest(userId));

                return Ok(cart);
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Carrinho");
            }
        }

        [HttpPost("{cartId}/products")]
        public async Task<IActionResult> AddProductCartAsync([FromRoute] int cartId, AddProductCartRequest cartProduct)
        {
            try
            {
                var response = await _cartService.AddProductCartAsync(cartId, cartProduct);

                return Ok(response);
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Carrinho");
            }
        }

        [HttpDelete("{cartId}/products/{productId}")]
        public async Task<IActionResult> RemoveProductFromCartAsync([FromRoute] int cartId, [FromRoute] int productId)
        {
            try
            {
                await _cartService.RemoveProductFromCartAsync(cartId, productId);

                return Ok();
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Produto");
            }
        }

        [HttpDelete("{cartId}/clean")]
        public async Task<IActionResult> CleanCartAsync([FromRoute] int cartId)
        {
            try
            {
                await _cartService.CleanCartAsync(cartId);

                return Ok();
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Produto");
            }
        }

        [HttpPost("{cartId}/coupon/{couponCode}")]
        public async Task<IActionResult> ApplyCouponDiscountAsync([FromRoute] int cartId, [FromRoute] string couponCode)
        {
            try
            {
                await _cartService.ApplyCouponDiscountAsync(cartId, couponCode);

                return Ok();
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Carrinho e/ou cupom");
            }
        }

        [HttpDelete("{cartId}/coupon")]
        public async Task<IActionResult> RemoveCouponDiscountAsync([FromRoute] int cartId)
        {
            try
            {
                await _cartService.RemoveCouponDiscountAsync(cartId);

                return Ok();
            }
            catch (Exception e)
            {
                return GetActionResult(e, "Carrinho");
            }
        }

        private IActionResult GetActionResult(Exception ex, string context) => ex.Message switch
        {
            "NotFound" => NotFound($"{context} não encontrado"),
            "BadRequest" => BadRequest($"{context} inválido"),
            _ => throw new Exception("Ocorreu um erro no servidor."),
        };
    }
}