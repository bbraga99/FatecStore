using Fatec.Store.Carts.Api.Domain.Interfaces.Services;
using Fatec.Store.Carts.Api.Models.CreateCart;
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
            await _cartService.CreateCartAsync(cartRequest);

            return Ok();
        }
    }
}