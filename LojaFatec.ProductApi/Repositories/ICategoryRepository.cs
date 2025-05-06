using LojaFatec.ProductApi.Models;

namespace LojaFatec.ProductApi.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetCategoryProducuts();
    Task<Category> GetById(int id);
    Task<Category> Create(Category category);   
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
}
