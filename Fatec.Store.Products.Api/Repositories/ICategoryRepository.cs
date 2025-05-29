using Fatec.Store.Products.Api.Models;

namespace Fatec.Store.Products.Api.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetCategoryProducuts();
    Task<Category> GetById(int id);
    Task<Category> Create(Category category);   
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
}
