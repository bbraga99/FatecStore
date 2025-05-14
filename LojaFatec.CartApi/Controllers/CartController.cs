using Fatec.Store.Cart.Api.DTOs.Mappings;
using LojaFatec.CartApi.DTOs;
using LojaFatec.CartApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace LojaFatec.CartApi.Controllers;

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
    public async Task<ActionResult<CartResponseDTO>> CreateCartAsync([FromBody] CartRequestDTO cartRequestDTO)
    {
        var updatedCart = await _cartService.CreateCartAsync(cartRequestDTO);

        return Ok(updatedCart);
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
