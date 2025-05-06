using LojaFatec.ProductApi.DTOs;

namespace LojaFatec.ProductApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDTO>> GetCategories();
    Task<IEnumerable<CategoryResponseDTO>> GetCategoriesProducts();
    Task<CategoryResponseDTO> GetCategoryById(int id);
    Task<CategoryResponseDTO> AddCategory(CategoryRequestDTO categoryRequestDTO);
    Task UpdateCategory(CategoryResponseDTO categoryDTO);
    Task RemoveCategory(int id);
}
