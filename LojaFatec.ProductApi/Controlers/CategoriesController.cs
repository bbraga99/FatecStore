using System.Formats.Asn1;
using LojaFatec.ProductApi.DTOs;
using LojaFatec.ProductApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaFatec.ProductApi.Controlers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> Get()
    {
        var categoriesDTO = await _categoryService.GetCategories();

        return Ok(categoriesDTO);
    }
    
    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetCategoriesProduct()
    {
        var categoriesDTO = await _categoryService.GetCategoriesProducts();

        return Ok(categoriesDTO);
    }


    [HttpGet("id:int", Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetByID(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);

        return Ok(categoryDTO);
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CategoryRequestDTO categoryRequestDTO)
    {
        if (categoryRequestDTO is null) return BadRequest("Invalid data");

        var newCategory = await _categoryService.AddCategory(categoryRequestDTO);

        return new CreatedAtRouteResult("GetCategory", 
                        new { id = newCategory.CategoryId }, categoryRequestDTO);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CategoryResponseDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId) return BadRequest("ID doesn't exist");

        if (categoryDTO is null) return BadRequest();

        await _categoryService.UpdateCategory(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoryResponseDTO>> Delete(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if (categoryDTO is null) return NotFound("Category not found");

        await _categoryService.RemoveCategory(id);

        return Ok(categoryDTO);
    }
}
