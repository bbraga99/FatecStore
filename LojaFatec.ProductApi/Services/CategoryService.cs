using AutoMapper;
using LojaFatec.ProductApi.DTOs;
using LojaFatec.ProductApi.Models;
using LojaFatec.ProductApi.Repositories;

namespace LojaFatec.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryResponseDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();

        if (categoriesEntity is null) throw new Exception("Categories not found");

        return _mapper.Map<IEnumerable<CategoryResponseDTO>>(categoriesEntity);
    }
    public async Task<IEnumerable<CategoryResponseDTO>> GetCategoriesProducts() 
    {       
        var categoriesEntity = await _categoryRepository.GetCategoryProducuts();
        
        if (categoriesEntity is null) throw new Exception("Categories not found");

        return _mapper.Map<IEnumerable<CategoryResponseDTO>>(categoriesEntity);
    }
    public async Task<CategoryResponseDTO> GetCategoryById(int id)
    {
        var categoryEntity = await _categoryRepository.GetById(id);
        
        if (categoryEntity is null) throw new Exception("Category not found");

        return _mapper.Map<CategoryResponseDTO>(categoryEntity);
    }
    public async Task<CategoryResponseDTO> AddCategory(CategoryRequestDTO categoryRequestDTO)
    {
        if (categoryRequestDTO is null) throw new Exception("Invalid data");
        
        var categoryEntity = _mapper.Map<Category>(categoryRequestDTO);

        await _categoryRepository.Create(categoryEntity);

        return _mapper.Map<CategoryResponseDTO>(categoryEntity);
    }
    public async Task UpdateCategory(CategoryResponseDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);

        await _categoryRepository.Update(categoryEntity);
    }
    public async Task RemoveCategory(int id)
    {
        var categoryEntity = _categoryRepository.GetById(id).Result;

        await _categoryRepository.Delete(categoryEntity.CategoryId);
    }
}
