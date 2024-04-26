using Domain.Models;

namespace Domain.IRepositories;

public interface ICategoryRepository
{
     Task AddCategory(Category category);
     Task EditCategory(Category category);
     Task<Category> GetCategoryById(int id);
     Task<List<Category>> GetAllCategories();
     Task SaveAsync();
}