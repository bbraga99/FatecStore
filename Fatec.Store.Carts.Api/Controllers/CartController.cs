using Fatec.Store.Carts.Api.DTOs;
using Fatec.Store.Carts.Api.DTOs.Request.CreateCart;
using Fatec.Store.Carts.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fatec.Store.Carts.Api.Controllers;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<CartResponseDTO>> GetCart(string userId)
    {
        var cart = await _cartService.GetCartByUserID(userId);

        return Ok(cart);
    }

    [HttpPost]
    public async Task<ActionResult<CartResponseDTO>> CreateCartAsync([FromBody] CreateCartRequestDTO cartRequestDTO)
    {
        var updatedCart = await _cartService.CreateCartAsync(cartRequestDTO);

        return Ok(updatedCart);
    }

    [HttpPut]
    public async Task<ActionResult<CartResponseDTO>> UpdateCart(string cartId, [FromBody] CartRequestDTO cartRequestDTO)
    {
        var result = await _cartService.UpdateCartAsync(cartId,cartRequestDTO);
        return Ok(result);
    }

    [HttpDelete("{itemId}")]
    public async Task<ActionResult> DeleteItem(int itemId, int headerId)
    {
        var result = await _cartService.DeleteItemAsync(itemId, headerId);

        return Ok(result);
    }
    
    [HttpDelete("clean/{userId}")]
    public async Task<ActionResult> ClearCart(string userId)
    {
        var result = await _cartService.CleanCartAsync(userId);

        if (!result) return BadRequest("Error");

        return NoContent();
    }
}
