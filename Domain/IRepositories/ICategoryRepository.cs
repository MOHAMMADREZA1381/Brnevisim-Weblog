using Domain.Models;

namespace Domain.IRepositories;

public interface ICategoryRepository
{
    public Task AddCategory(Category category);
    public Task EditCategory(Category category);
    public Task<Category> GetCategoryById(int id);
    public Task<List<Category>> GetAllCategories();
    public Task SaveAsync();
}