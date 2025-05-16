using Fatec.Store.Carts.Api.Domain.Interfaces.Services;
using Fatec.Store.Carts.Api.Models.CreateCart;
using Fatec.Store.Carts.Api.Models.GetCartByUserId;
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

        [HttpPut("{cartId}")]
        public async Task<IActionResult> UpdateCartAsync(object productList)
        {
            return Ok();
        }

        private IActionResult GetActionResult(Exception ex, string context) => ex.Message switch
        {
            "NotFound" => NotFound($"{context} não encontrado"),
            "BadRequest" => BadRequest($"{context} não inválido"),
            _ => throw new Exception("Ocorreu um erro no servidor."),
        };
    }
}