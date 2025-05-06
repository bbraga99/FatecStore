using Fatec.Store.Product.Api.DTOs.Mappings;
using LojaFatec.ProductApi.DTOs;
using LojaFatec.ProductApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaFatec.ProductApi.Controlers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> Get()
    {
        var productsDTO = await _productService.GetProducts();

        if (productsDTO is null) return NotFound("Products not found");

        return Ok(productsDTO);
    }

    [HttpGet("id:int", Name = "GetProduct")]
    public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetById(int id)
    {
        var productDTO = await _productService.GetById(id);

        if (productDTO is null) return NotFound("Product not found");

        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ProductRequestDTO productRequestDTO)
    {
        var newCategory = await _productService.AddProduct(productRequestDTO);   

        return new CreatedAtRouteResult("GetProduct", new 
                                            {id = newCategory.Id}, productRequestDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProductResponseDTO productDTO)
    {
        if (id != productDTO.Id) return BadRequest("Data invalid");

        if (productDTO is null) return BadRequest("Data invalid");

        await _productService.UpdateProduct(productDTO);

        return Ok(productDTO);
    }

    [HttpPatch("update-stock")]
    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateStockRequestDTO updateStockRequestDTO)
    {
        await _productService.UpdateQuantity(updateStockRequestDTO);

        return Ok();
    }

    [HttpDelete("{id:int}")] 
    public async Task<ActionResult> Delete(int id)
    {
        var productDTO = await _productService.GetById(id);

        if (productDTO is null) return NotFound("Product not found");

        await _productService.RemoveProduct(id);

        return Ok(productDTO);
    }
}
